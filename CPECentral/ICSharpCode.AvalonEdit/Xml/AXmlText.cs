#region Using directives

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Whitespace or character data
    /// </summary>
    public class AXmlText : AXmlObject
    {
        /// <summary> The context in which the text occured </summary>
        internal TextType Type { get; set; }

        /// <summary> The text exactly as in source </summary>
        public string EscapedValue { get; set; }

        /// <summary> The text with all entity references resloved </summary>
        public string Value { get; set; }

        /// <summary> True if the text contains only whitespace characters </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Whitespace",
            Justification = "System.Xml also uses 'Whitespace'")]
        public bool ContainsOnlyWhitespace { get; set; }

        /// <inheritdoc />
        public override void AcceptVisitor(IAXmlVisitor visitor)
        {
            visitor.VisitText(this);
        }

        /// <inheritdoc />
        internal override bool UpdateDataFrom(AXmlObject source)
        {
            if (!base.UpdateDataFrom(source)) {
                return false;
            }
            var src = (AXmlText) source;
            if (EscapedValue != src.EscapedValue ||
                Value != src.Value) {
                OnChanging();
                EscapedValue = src.EscapedValue;
                Value = src.Value;
                OnChanged();
                return true;
            }
            return false;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[{0} Text.Length={1}]", base.ToString(),
                EscapedValue.Length);
        }
    }
}