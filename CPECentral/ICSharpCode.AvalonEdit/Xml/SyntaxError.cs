#region Using directives

using ICSharpCode.AvalonEdit.Document;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary> Information about syntax error that occured during parsing </summary>
    public class SyntaxError : TextSegment
    {
        /// <summary> Object for which the error occured </summary>
        public AXmlObject Object { get; internal set; }

        /// <summary> Textual description of the error </summary>
        public string Message { get; internal set; }

        /// <summary> Any user data </summary>
        public object Tag { get; set; }

        internal SyntaxError Clone(AXmlObject newOwner)
        {
            return new SyntaxError {
                Object = newOwner,
                Message = Message,
                Tag = Tag,
                StartOffset = StartOffset,
                EndOffset = EndOffset,
            };
        }
    }
}