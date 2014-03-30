#region Using directives

using System;
using System.Collections.Generic;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting.Xshd
{
    /// <summary>
    ///     A list of keywords.
    /// </summary>
    [Serializable]
    public class XshdKeywords : XshdElement
    {
        private readonly NullSafeCollection<string> words = new NullSafeCollection<string>();

        /// <summary>
        ///     The color.
        /// </summary>
        public XshdReference<XshdColor> ColorReference { get; set; }

        /// <summary>
        ///     Gets the list of key words.
        /// </summary>
        public IList<string> Words
        {
            get { return words; }
        }

        /// <inheritdoc />
        public override object AcceptVisitor(IXshdVisitor visitor)
        {
            return visitor.VisitKeywords(this);
        }
    }
}