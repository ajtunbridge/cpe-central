#region Using directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using ICSharpCode.AvalonEdit.Document;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Abstact base class for all types
    /// </summary>
    public abstract class AXmlObject : TextSegment
    {
        /// <summary> Empty string.  The namespace used if there is no "xmlns" specified </summary>
        public static readonly string NoNamespace = string.Empty;

        /// <summary> Namespace for "xml:" prefix: "http://www.w3.org/XML/1998/namespace" </summary>
        public static readonly string XmlNamespace = "http://www.w3.org/XML/1998/namespace";

        /// <summary> Namesapce for "xmlns:" prefix: "http://www.w3.org/2000/xmlns/" </summary>
        public static readonly string XmlnsNamespace = "http://www.w3.org/2000/xmlns/";

        private List<SyntaxError> syntaxErrors;

        /// <summary> Creates new object </summary>
        protected AXmlObject()
        {
            LastUpdatedFrom = this;
        }

        /// <summary> Parent node. </summary>
        /// <remarks>
        ///     New cached items start with null parent.
        ///     Cache constraint:
        ///     If cached item has parent set, then the whole subtree must be consistent
        /// </remarks>
        public AXmlObject Parent { get; set; }

        /// <summary>
        ///     Gets the document that has owns this object.
        ///     Once set, it is not changed.  Not even set to null.
        /// </summary>
        internal AXmlDocument Document { get; set; }

        /// <summary>
        ///     The error that occured in the context of this node (excluding nested nodes)
        /// </summary>
        public IEnumerable<SyntaxError> MySyntaxErrors
        {
            get
            {
                if (syntaxErrors == null) {
                    return new SyntaxError[] {};
                }
                return syntaxErrors;
            }
        }

        /// <summary>
        ///     The error that occured in the context of this node and all nested nodes.
        ///     It has O(n) cost.
        /// </summary>
        public IEnumerable<SyntaxError> SyntaxErrors
        {
            get { return GetSelfAndAllChildren().SelectMany(obj => obj.MySyntaxErrors); }
        }

        /// <summary> The parser tree object this object was updated from </summary>
        /// <remarks> Initialized to 'this' </remarks>
        internal AXmlObject LastUpdatedFrom { get; private set; }

        internal bool IsCached { get; set; }

        /// <summary> Occurs before the value of any local properties changes.  Nested changes do not cause the event to occur </summary>
        public event EventHandler<AXmlObjectEventArgs> Changing;

        /// <summary> Occurs after the value of any local properties changed.  Nested changes do not cause the event to occur </summary>
        public event EventHandler<AXmlObjectEventArgs> Changed;

        /// <summary> Raises Changing event </summary>
        protected void OnChanging()
        {
            AXmlParser.Log("Changing {0}", this);
            if (Changing != null) {
                Changing(this, new AXmlObjectEventArgs {Object = this});
            }
            AXmlDocument doc = Document;
            if (doc != null) {
                doc.OnObjectChanging(this);
            }
            // As a convenience, also rasie an event for the parent element
            var me = this as AXmlTag;
            if (me != null && (me.IsStartOrEmptyTag || me.IsEndTag) && me.Parent is AXmlElement) {
                me.Parent.OnChanging();
            }
        }

        /// <summary> Raises Changed event </summary>
        protected void OnChanged()
        {
            AXmlParser.Log("Changed {0}", this);
            if (Changed != null) {
                Changed(this, new AXmlObjectEventArgs {Object = this});
            }
            AXmlDocument doc = Document;
            if (doc != null) {
                doc.OnObjectChanged(this);
            }
            // As a convenience, also rasie an event for the parent element
            var me = this as AXmlTag;
            if (me != null && (me.IsStartOrEmptyTag || me.IsEndTag) && me.Parent is AXmlElement) {
                me.Parent.OnChanged();
            }
        }

        internal void AddSyntaxError(SyntaxError error)
        {
            DebugAssert(error.Object == this, "Must own the error");
            if (syntaxErrors == null) {
                syntaxErrors = new List<SyntaxError>();
            }
            syntaxErrors.Add(error);
        }

        /// <summary> Throws exception if condition is false </summary>
        /// <remarks> Present in release mode - use only for very cheap aserts </remarks>
        protected static void Assert(bool condition, string message)
        {
            if (!condition) {
                throw new InternalException("Assertion failed: " + message);
            }
        }

        /// <summary> Throws exception if condition is false </summary>
        [Conditional("DEBUG")]
        protected static void DebugAssert(bool condition, string message)
        {
            if (!condition) {
                throw new InternalException("Assertion failed: " + message);
            }
        }

        /// <summary> Recursively gets self and all nested nodes. </summary>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification =
                "Using a method makes the API look more LINQ-like and indicates that the returned collection is computed every time."
            )]
        public virtual IEnumerable<AXmlObject> GetSelfAndAllChildren()
        {
            return new[] {this};
        }

        /// <summary> Get all ancestors of this node </summary>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification =
                "Using a method makes the API look more LINQ-like and indicates that the returned collection is computed every time."
            )]
        public IEnumerable<AXmlObject> GetAncestors()
        {
            AXmlObject curr = Parent;
            while (curr != null) {
                yield return curr;
                curr = curr.Parent;
            }
        }

        /// <summary> Call appropriate visit method on the given visitor </summary>
        public abstract void AcceptVisitor(IAXmlVisitor visitor);

        /// <summary> Is call to UpdateDataFrom is allowed? </summary>
        internal bool CanUpdateDataFrom(AXmlObject source)
        {
            return
                GetType() == source.GetType() &&
                StartOffset == source.StartOffset &&
                (LastUpdatedFrom == source || !IsCached);
        }

        /// <summary> Copy all data from the 'source' to this object </summary>
        /// <remarks> Returns true if any updates were done </remarks>
        internal virtual bool UpdateDataFrom(AXmlObject source)
        {
            Assert(GetType() == source.GetType(), "Source has different type");
            DebugAssert(StartOffset == source.StartOffset, "Source has different StartOffset");

            if (LastUpdatedFrom == source) {
                DebugAssert(EndOffset == source.EndOffset, "Source has different EndOffset");
                return false;
            }

            Assert(!IsCached, "Can not update cached item");
            Assert(source.IsCached, "Must update from cache");

            LastUpdatedFrom = source;
            StartOffset = source.StartOffset;
            // In some cases we are just updating objects of that same
            // type and position and hoping to be luckily right
            EndOffset = source.EndOffset;

            // Do not bother comparing - assume changed if non-null
            if (syntaxErrors != null || source.syntaxErrors != null) {
                // May be called again in derived class - oh, well, does not matter
                OnChanging();
                Document.Parser.TrackedSegments.RemoveSyntaxErrorsOf(this);
                if (source.syntaxErrors == null) {
                    syntaxErrors = null;
                }
                else {
                    syntaxErrors = new List<SyntaxError>();
                    foreach (SyntaxError error in source.MySyntaxErrors) {
                        // The object differs, so create our own copy
                        // The source still might need it in the future and we do not want to break it
                        AddSyntaxError(error.Clone(this));
                    }
                }
                Document.Parser.TrackedSegments.AddSyntaxErrorsOf(this);
                OnChanged();
            }

            return true;
        }

        /// <summary> Verify that the item is consistent.  Only in debug build. </summary>
        [Conditional("DEBUG")]
        internal virtual void DebugCheckConsistency(bool allowNullParent)
        {
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1}-{2})", GetType().Name.Remove(0, 4), StartOffset,
                EndOffset);
        }

        #region Helpper methods

        /// <summary> The part of name before ":" </summary>
        /// <returns> Empty string if not found </returns>
        protected static string GetNamespacePrefix(string name)
        {
            if (string.IsNullOrEmpty(name)) {
                return string.Empty;
            }
            int colonIndex = name.IndexOf(':');
            if (colonIndex != -1) {
                return name.Substring(0, colonIndex);
            }
            return string.Empty;
        }

        /// <summary> The part of name after ":" </summary>
        /// <returns> Whole name if ":" not found </returns>
        protected static string GetLocalName(string name)
        {
            if (string.IsNullOrEmpty(name)) {
                return string.Empty;
            }
            int colonIndex = name.IndexOf(':');
            if (colonIndex != -1) {
                return name.Remove(0, colonIndex + 1);
            }
            return name ?? string.Empty;
        }

        #endregion
    }
}