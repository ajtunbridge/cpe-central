namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Visitor for the XML tree
    /// </summary>
    public interface IAXmlVisitor
    {
        /// <summary> Visit RawDocument </summary>
        void VisitDocument(AXmlDocument document);

        /// <summary> Visit RawElement </summary>
        void VisitElement(AXmlElement element);

        /// <summary> Visit RawTag </summary>
        void VisitTag(AXmlTag tag);

        /// <summary> Visit RawAttribute </summary>
        void VisitAttribute(AXmlAttribute attribute);

        /// <summary> Visit RawText </summary>
        void VisitText(AXmlText text);
    }
}