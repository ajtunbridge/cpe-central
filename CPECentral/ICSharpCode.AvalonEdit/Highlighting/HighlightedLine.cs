﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting
{
    /// <summary>
    ///     Represents a highlighted document line.
    /// </summary>
    public class HighlightedLine
    {
        /// <summary>
        ///     Creates a new HighlightedLine instance.
        /// </summary>
        public HighlightedLine(TextDocument document, DocumentLine documentLine)
        {
            if (document == null) {
                throw new ArgumentNullException("document");
            }
            if (!document.Lines.Contains(documentLine)) {
                throw new ArgumentException("Line is null or not part of document");
            }
            Document = document;
            DocumentLine = documentLine;
            Sections = new NullSafeCollection<HighlightedSection>();
        }

        /// <summary>
        ///     Gets the document associated with this HighlightedLine.
        /// </summary>
        public TextDocument Document { get; private set; }

        /// <summary>
        ///     Gets the document line associated with this HighlightedLine.
        /// </summary>
        public DocumentLine DocumentLine { get; private set; }

        /// <summary>
        ///     Gets the highlighted sections.
        ///     The sections are not overlapping, but they may be nested.
        ///     In that case, outer sections come in the list before inner sections.
        ///     The sections are sorted by start offset.
        /// </summary>
        public IList<HighlightedSection> Sections { get; private set; }

        /// <summary>
        ///     Gets the default color of all text outside a <see cref="HighlightedSection" />.
        /// </summary>
        public HighlightingColor DefaultTextColor { get; set; }

        /// <summary>
        ///     Produces HTML code for the line, with &lt;span class="colorName"&gt; tags.
        /// </summary>
        public string ToHtml(HtmlOptions options)
        {
            int startOffset = DocumentLine.Offset;
            return ToHtml(startOffset, startOffset + DocumentLine.Length, options);
        }

        /// <summary>
        ///     Produces HTML code for a section of the line, with &lt;span class="colorName"&gt; tags.
        /// </summary>
        public string ToHtml(int startOffset, int endOffset, HtmlOptions options)
        {
            if (options == null) {
                throw new ArgumentNullException("options");
            }
            int documentLineStartOffset = DocumentLine.Offset;
            int documentLineEndOffset = documentLineStartOffset + DocumentLine.Length;
            if (startOffset < documentLineStartOffset || startOffset > documentLineEndOffset) {
                throw new ArgumentOutOfRangeException("startOffset", startOffset,
                    "Value must be between " + documentLineStartOffset + " and " + documentLineEndOffset);
            }
            if (endOffset < startOffset || endOffset > documentLineEndOffset) {
                throw new ArgumentOutOfRangeException("endOffset", endOffset,
                    "Value must be between startOffset and " + documentLineEndOffset);
            }
            ISegment requestedSegment = new SimpleSegment(startOffset, endOffset - startOffset);

            var elements = new List<HtmlElement>();
            for (int i = 0; i < Sections.Count; i++) {
                HighlightedSection s = Sections[i];
                if (s.GetOverlap(requestedSegment).Length > 0) {
                    elements.Add(new HtmlElement(s.Offset, i, false, s.Color));
                    elements.Add(new HtmlElement(s.Offset + s.Length, i, true, s.Color));
                }
            }
            elements.Sort();

            TextDocument document = Document;
            var w = new StringWriter(CultureInfo.InvariantCulture);
            int textOffset = startOffset;
            foreach (HtmlElement e in elements) {
                int newOffset = Math.Min(e.Offset, endOffset);
                if (newOffset > startOffset) {
                    HtmlClipboard.EscapeHtml(w, document.GetText(textOffset, newOffset - textOffset), options);
                }
                textOffset = Math.Max(textOffset, newOffset);
                if (options.ColorNeedsSpanForStyling(e.Color)) {
                    if (e.IsEnd) {
                        w.Write("</span>");
                    }
                    else {
                        w.Write("<span");
                        options.WriteStyleAttributeForColor(w, e.Color);
                        w.Write('>');
                    }
                }
            }
            HtmlClipboard.EscapeHtml(w, document.GetText(textOffset, endOffset - textOffset), options);
            return w.ToString();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + GetType().Name + " " + ToHtml(new HtmlOptions()) + "]";
        }

        #region Nested type: HtmlElement

        private sealed class HtmlElement : IComparable<HtmlElement>
        {
            internal readonly HighlightingColor Color;
            internal readonly bool IsEnd;
            internal readonly int Nesting;
            internal readonly int Offset;

            public HtmlElement(int offset, int nesting, bool isEnd, HighlightingColor color)
            {
                Offset = offset;
                Nesting = nesting;
                IsEnd = isEnd;
                Color = color;
            }

            #region IComparable<HtmlElement> Members

            public int CompareTo(HtmlElement other)
            {
                int r = Offset.CompareTo(other.Offset);
                if (r != 0) {
                    return r;
                }
                if (IsEnd != other.IsEnd) {
                    if (IsEnd) {
                        return -1;
                    }
                    return 1;
                }
                if (IsEnd) {
                    return other.Nesting.CompareTo(Nesting);
                }
                return Nesting.CompareTo(other.Nesting);
            }

            #endregion
        }

        #endregion
    }
}