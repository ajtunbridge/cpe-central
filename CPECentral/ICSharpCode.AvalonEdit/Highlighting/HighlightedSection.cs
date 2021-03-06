﻿#region Using directives

using ICSharpCode.AvalonEdit.Document;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting
{
    /// <summary>
    ///     A text section with syntax highlighting information.
    /// </summary>
    public class HighlightedSection : ISegment
    {
        /// <summary>
        ///     Gets the highlighting color associated with the highlighted section.
        /// </summary>
        public HighlightingColor Color { get; set; }

        #region ISegment Members

        /// <summary>
        ///     Gets/sets the document offset of the section.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        ///     Gets/sets the length of the section.
        /// </summary>
        public int Length { get; set; }

        int ISegment.EndOffset
        {
            get { return Offset + Length; }
        }

        #endregion
    }
}