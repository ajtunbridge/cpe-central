#region Using directives

using System;
using System.Collections.ObjectModel;
using System.Globalization;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Logical grouping of other nodes together.
    /// </summary>
    public class AXmlElement : AXmlContainer
    {
        /// <summary> No tags are missing anywhere within this element (recursive) </summary>
        public bool IsProperlyNested { get; set; }

        /// <returns> True in wellformed XML </returns>
        public bool HasStartOrEmptyTag { get; set; }

        /// <returns> True in wellformed XML </returns>
        public bool HasEndTag { get; set; }

        /// <summary> The start or empty-element tag if there is any </summary>
        internal AXmlTag StartTag
        {
            get
            {
                Assert(HasStartOrEmptyTag, "Does not have a start tag");
                return (AXmlTag) Children[0];
            }
        }

        /// <summary> The end tag if there is any </summary>
        internal AXmlTag EndTag
        {
            get
            {
                Assert(HasEndTag, "Does not have an end tag");
                return (AXmlTag) Children[Children.Count - 1];
            }
        }

        /// <inheritdoc />
        internal override bool UpdateDataFrom(AXmlObject source)
        {
            if (!base.UpdateDataFrom(source)) {
                return false;
            }
            var src = (AXmlElement) source;
            // Clear the cache for this - quite expensive
            attributesAndElements = null;
            if (IsProperlyNested != src.IsProperlyNested ||
                HasStartOrEmptyTag != src.HasStartOrEmptyTag ||
                HasEndTag != src.HasEndTag) {
                OnChanging();
                IsProperlyNested = src.IsProperlyNested;
                HasStartOrEmptyTag = src.HasStartOrEmptyTag;
                HasEndTag = src.HasEndTag;
                OnChanged();
                return true;
            }
            return false;
        }

        internal override void DebugCheckConsistency(bool checkParentPointers)
        {
            DebugAssert(Children.Count > 0, "No children");
            base.DebugCheckConsistency(checkParentPointers);
        }

        /// <inheritdoc />
        public override void AcceptVisitor(IAXmlVisitor visitor)
        {
            visitor.VisitElement(this);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[{0} '{1}' Attr:{2} Chld:{3} Nest:{4}]", base.ToString(),
                Name, HasStartOrEmptyTag ? StartTag.Children.Count : 0, Children.Count, IsProperlyNested ? "Ok" : "Bad");
        }

        #region Helpper methods

        private ObservableCollection<AXmlObject> attributesAndElements;

        /// <summary> Gets attributes of the element </summary>
        /// <remarks>
        ///     Warning: this is a cenvenience method to access the attributes of the start tag.
        ///     However, since the start tag might be moved/replaced, this property might return
        ///     different values over time.
        /// </remarks>
        public AXmlAttributeCollection Attributes
        {
            get
            {
                if (HasStartOrEmptyTag) {
                    return StartTag.Attributes;
                }
                return AXmlAttributeCollection.Empty;
            }
        }

        /// <summary> Gets both attributes and elements.  Expensive, avoid use. </summary>
        /// <remarks> Warning: the collection will regenerate after each update </remarks>
        public ObservableCollection<AXmlObject> AttributesAndElements
        {
            get
            {
                if (attributesAndElements == null) {
                    if (HasStartOrEmptyTag) {
                        attributesAndElements = new MergedCollection<AXmlObject, ObservableCollection<AXmlObject>>(
                            // New wrapper with RawObject types
                            new FilteredCollection<AXmlObject, AXmlObjectCollection<AXmlObject>>(StartTag.Children,
                                x => x is AXmlAttribute),
                            new FilteredCollection<AXmlObject, AXmlObjectCollection<AXmlObject>>(Children,
                                x => x is AXmlElement)
                            );
                    }
                    else {
                        attributesAndElements =
                            new FilteredCollection<AXmlObject, AXmlObjectCollection<AXmlObject>>(Children,
                                x => x is AXmlElement);
                    }
                }
                return attributesAndElements;
            }
        }

        /// <summary> Name with namespace prefix - exactly as in source </summary>
        public string Name
        {
            get
            {
                if (HasStartOrEmptyTag) {
                    return StartTag.Name;
                }
                return EndTag.Name;
            }
        }

        /// <summary> The part of name before ":" </summary>
        /// <returns> Empty string if not found </returns>
        public string Prefix
        {
            get { return GetNamespacePrefix(Name); }
        }

        /// <summary> The part of name after ":" </summary>
        /// <returns> Empty string if not found </returns>
        public string LocalName
        {
            get { return GetLocalName(Name); }
        }

        /// <summary> Resolved namespace of the name </summary>
        /// <returns> Empty string if prefix is not found </returns>
        public string Namespace
        {
            get
            {
                string prefix = Prefix;
                if (string.IsNullOrEmpty(prefix)) {
                    return FindDefaultNamespace();
                }
                return ResolvePrefix(prefix);
            }
        }

        /// <summary> Find the defualt namespace for this context </summary>
        public string FindDefaultNamespace()
        {
            AXmlElement current = this;
            while (current != null) {
                string namesapce = current.GetAttributeValue(NoNamespace, "xmlns");
                if (namesapce != null) {
                    return namesapce;
                }
                current = current.Parent as AXmlElement;
            }
            return string.Empty; // No namesapce
        }

        /// <summary>
        ///     Recursively resolve given prefix in this context.  Prefix must have some value.
        /// </summary>
        /// <returns> Empty string if prefix is not found </returns>
        public string ResolvePrefix(string prefix)
        {
            if (string.IsNullOrEmpty(prefix)) {
                throw new ArgumentException("No prefix given", "prefix");
            }

            // Implicit namesapces
            if (prefix == "xml") {
                return XmlNamespace;
            }
            if (prefix == "xmlns") {
                return XmlnsNamespace;
            }

            AXmlElement current = this;
            while (current != null) {
                string namesapce = current.GetAttributeValue(XmlnsNamespace, prefix);
                if (namesapce != null) {
                    return namesapce;
                }
                current = current.Parent as AXmlElement;
            }
            return NoNamespace; // Can not find prefix
        }

        /// <summary>
        ///     Get unquoted value of attribute.
        ///     It looks in the no namespace (empty string).
        /// </summary>
        /// <returns>Null if not found</returns>
        public string GetAttributeValue(string localName)
        {
            return GetAttributeValue(NoNamespace, localName);
        }

        /// <summary>
        ///     Get unquoted value of attribute
        /// </summary>
        /// <param name="namespace">Namespace.  Can be no namepace (empty string), which is the default for attributes.</param>
        /// <param name="localName">Local name - text after ":"</param>
        /// <returns>Null if not found</returns>
        public string GetAttributeValue(string @namespace, string localName)
        {
            @namespace = @namespace ?? string.Empty;
            foreach (AXmlAttribute attr in Attributes.GetByLocalName(localName)) {
                DebugAssert(attr.LocalName == localName, "Bad hashtable");
                if (attr.Namespace == @namespace) {
                    return attr.Value;
                }
            }
            return null;
        }

        #endregion
    }
}