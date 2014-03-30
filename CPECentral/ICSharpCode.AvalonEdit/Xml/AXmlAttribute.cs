#region Using directives

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Name-value pair in a tag
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
    public class AXmlAttribute : AXmlObject
    {
        /// <summary> Name with namespace prefix - exactly as in source file </summary>
        public string Name { get; internal set; }

        /// <summary> Equals sign and surrounding whitespace </summary>
        public string EqualsSign { get; internal set; }

        /// <summary> The raw value - exactly as in source file (*probably* quoted and escaped) </summary>
        public string QuotedValue { get; internal set; }

        /// <summary> Unquoted and dereferenced value of the attribute </summary>
        public string Value { get; internal set; }

        internal override void DebugCheckConsistency(bool checkParentPointers)
        {
            DebugAssert(Name != null, "Null Name");
            DebugAssert(EqualsSign != null, "Null EqualsSign");
            DebugAssert(QuotedValue != null, "Null QuotedValue");
            DebugAssert(Value != null, "Null Value");
            base.DebugCheckConsistency(checkParentPointers);
        }

        /// <inheritdoc />
        public override void AcceptVisitor(IAXmlVisitor visitor)
        {
            visitor.VisitAttribute(this);
        }

        /// <inheritdoc />
        internal override bool UpdateDataFrom(AXmlObject source)
        {
            if (!base.UpdateDataFrom(source)) {
                return false;
            }
            var src = (AXmlAttribute) source;
            if (Name != src.Name ||
                EqualsSign != src.EqualsSign ||
                QuotedValue != src.QuotedValue ||
                Value != src.Value) {
                OnChanging();
                Name = src.Name;
                EqualsSign = src.EqualsSign;
                QuotedValue = src.QuotedValue;
                Value = src.Value;
                OnChanged();
                return true;
            }
            return false;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[{0} '{1}{2}{3}']", base.ToString(), Name, EqualsSign,
                Value);
        }

        #region Helpper methods

        /// <summary> The element containing this attribute </summary>
        /// <returns> Null if orphaned </returns>
        public AXmlElement ParentElement
        {
            get
            {
                var tag = Parent as AXmlTag;
                if (tag != null) {
                    return tag.Parent as AXmlElement;
                }
                return null;
            }
        }

        /// <summary> The part of name before ":"</summary>
        /// <returns> Empty string if not found </returns>
        public string Prefix
        {
            get { return GetNamespacePrefix(Name); }
        }

        /// <summary> The part of name after ":" </summary>
        /// <returns> Whole name if ":" not found </returns>
        public string LocalName
        {
            get { return GetLocalName(Name); }
        }

        /// <summary>
        ///     Resolved namespace of the name.  Empty string if not found
        ///     From the specification: "The namespace name for an unprefixed attribute name always has no value."
        /// </summary>
        public string Namespace
        {
            get
            {
                if (string.IsNullOrEmpty(Prefix)) {
                    return NoNamespace;
                }

                AXmlElement elem = ParentElement;
                if (elem != null) {
                    return elem.ResolvePrefix(Prefix);
                }
                return NoNamespace; // Orphaned attribute
            }
        }

        /// <summary> Attribute is declaring namespace ("xmlns" or "xmlns:*") </summary>
        public bool IsNamespaceDeclaration
        {
            get { return Name == "xmlns" || Prefix == "xmlns"; }
        }

        #endregion
    }
}