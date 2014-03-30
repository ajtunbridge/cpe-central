#region Using directives

using System.Text;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Converts the XML tree back to text.
    ///     The text should exactly match the original.
    /// </summary>
    public class PrettyPrintAXmlVisitor : AbstractAXmlVisitor
    {
        private readonly StringBuilder sb = new StringBuilder();

        /// <summary>
        ///     Gets the pretty printed text
        /// </summary>
        public string Output
        {
            get { return sb.ToString(); }
        }

        /// <summary> Create XML text from a document </summary>
        public static string PrettyPrint(AXmlDocument doc)
        {
            var visitor = new PrettyPrintAXmlVisitor();
            visitor.VisitDocument(doc);
            return visitor.Output;
        }

        /// <summary> Visit RawDocument </summary>
        public override void VisitDocument(AXmlDocument document)
        {
            base.VisitDocument(document);
        }

        /// <summary> Visit RawElement </summary>
        public override void VisitElement(AXmlElement element)
        {
            base.VisitElement(element);
        }

        /// <summary> Visit RawTag </summary>
        public override void VisitTag(AXmlTag tag)
        {
            sb.Append(tag.OpeningBracket);
            sb.Append(tag.Name);
            base.VisitTag(tag);
            sb.Append(tag.ClosingBracket);
        }

        /// <summary> Visit RawAttribute </summary>
        public override void VisitAttribute(AXmlAttribute attribute)
        {
            sb.Append(attribute.Name);
            sb.Append(attribute.EqualsSign);
            sb.Append(attribute.QuotedValue);
        }

        /// <summary> Visit RawText </summary>
        public override void VisitText(AXmlText text)
        {
            sb.Append(text.EscapedValue);
        }
    }
}