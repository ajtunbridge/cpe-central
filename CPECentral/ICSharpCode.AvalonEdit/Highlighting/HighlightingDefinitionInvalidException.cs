#region Using directives

using System;
using System.Runtime.Serialization;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting
{
    /// <summary>
    ///     Indicates that the highlighting definition that was tried to load was invalid.
    /// </summary>
    [Serializable]
    public class HighlightingDefinitionInvalidException : Exception
    {
        /// <summary>
        ///     Creates a new HighlightingDefinitionInvalidException instance.
        /// </summary>
        public HighlightingDefinitionInvalidException()
        {
        }

        /// <summary>
        ///     Creates a new HighlightingDefinitionInvalidException instance.
        /// </summary>
        public HighlightingDefinitionInvalidException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Creates a new HighlightingDefinitionInvalidException instance.
        /// </summary>
        public HighlightingDefinitionInvalidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Creates a new HighlightingDefinitionInvalidException instance.
        /// </summary>
        protected HighlightingDefinitionInvalidException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}