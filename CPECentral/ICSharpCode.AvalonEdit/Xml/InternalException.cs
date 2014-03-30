#region Using directives

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Exception used for internal errors in XML parser.
    ///     This exception indicates a bug in AvalonEdit.
    /// </summary>
    [Serializable]
    [SuppressMessage("Microsoft.Design", "CA1064:ExceptionsShouldBePublic",
        Justification =
            "This exception is not public because it is not supposed to be caught by user code - it indicates a bug in AvalonEdit."
        )]
    internal class InternalException : Exception
    {
        /// <summary>
        ///     Creates a new InternalException instance.
        /// </summary>
        public InternalException()
        {
        }

        /// <summary>
        ///     Creates a new InternalException instance.
        /// </summary>
        public InternalException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Creates a new InternalException instance.
        /// </summary>
        public InternalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        ///     Creates a new InternalException instance.
        /// </summary>
        protected InternalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}