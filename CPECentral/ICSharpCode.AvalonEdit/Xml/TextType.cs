namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary> Identifies the context in which the text occured </summary>
    internal enum TextType
    {
        /// <summary> Ends with non-whitespace </summary>
        WhiteSpace,

        /// <summary> Ends with "&lt;";  "]]&gt;" is error </summary>
        CharacterData,

        /// <summary> Ends with "-->";  "--" is error </summary>
        Comment,

        /// <summary> Ends with "]]&gt;" </summary>
        CData,

        /// <summary> Ends with "?>" </summary>
        ProcessingInstruction,

        /// <summary> Ends with "&lt;" or ">" </summary>
        UnknownBang,

        /// <summary> Unknown </summary>
        Other
    }
}