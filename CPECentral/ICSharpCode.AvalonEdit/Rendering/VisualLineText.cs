﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media.TextFormatting;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Rendering
{
    /// <summary>
    ///     VisualLineElement that represents a piece of text.
    /// </summary>
    public class VisualLineText : VisualLineElement
    {
        private readonly VisualLine parentVisualLine;

        /// <summary>
        ///     Creates a visual line text element with the specified length.
        ///     It uses the <see cref="ITextRunConstructionContext.VisualLine" /> and its
        ///     <see cref="VisualLineElement.RelativeTextOffset" /> to find the actual text string.
        /// </summary>
        public VisualLineText(VisualLine parentVisualLine, int length) : base(length, length)
        {
            if (parentVisualLine == null) {
                throw new ArgumentNullException("parentVisualLine");
            }
            this.parentVisualLine = parentVisualLine;
        }

        /// <summary>
        ///     Gets the parent visual line.
        /// </summary>
        public VisualLine ParentVisualLine
        {
            get { return parentVisualLine; }
        }

        /// <inheritdoc />
        public override bool CanSplit
        {
            get { return true; }
        }

        /// <summary>
        ///     Override this method to control the type of new VisualLineText instances when
        ///     the visual line is split due to syntax highlighting.
        /// </summary>
        protected virtual VisualLineText CreateInstance(int length)
        {
            return new VisualLineText(parentVisualLine, length);
        }

        /// <inheritdoc />
        public override TextRun CreateTextRun(int startVisualColumn, ITextRunConstructionContext context)
        {
            if (context == null) {
                throw new ArgumentNullException("context");
            }

            int relativeOffset = startVisualColumn - VisualColumn;
            StringSegment text =
                context.GetText(context.VisualLine.FirstDocumentLine.Offset + RelativeTextOffset + relativeOffset,
                    DocumentLength - relativeOffset);
            return new TextCharacters(text.Text, text.Offset, text.Count, TextRunProperties);
        }

        /// <inheritdoc />
        public override bool IsWhitespace(int visualColumn)
        {
            int offset = visualColumn - VisualColumn + parentVisualLine.FirstDocumentLine.Offset + RelativeTextOffset;
            return char.IsWhiteSpace(parentVisualLine.Document.GetCharAt(offset));
        }

        /// <inheritdoc />
        public override TextSpan<CultureSpecificCharacterBufferRange> GetPrecedingText(int visualColumnLimit,
            ITextRunConstructionContext context)
        {
            if (context == null) {
                throw new ArgumentNullException("context");
            }

            int relativeOffset = visualColumnLimit - VisualColumn;
            StringSegment text = context.GetText(context.VisualLine.FirstDocumentLine.Offset + RelativeTextOffset,
                relativeOffset);
            var range = new CharacterBufferRange(text.Text, text.Offset, text.Count);
            return new TextSpan<CultureSpecificCharacterBufferRange>(range.Length,
                new CultureSpecificCharacterBufferRange(TextRunProperties.CultureInfo, range));
        }

        /// <inheritdoc />
        public override void Split(int splitVisualColumn, IList<VisualLineElement> elements, int elementIndex)
        {
            if (splitVisualColumn <= VisualColumn || splitVisualColumn >= VisualColumn + VisualLength) {
                throw new ArgumentOutOfRangeException("splitVisualColumn", splitVisualColumn,
                    "Value must be between " + (VisualColumn + 1) + " and " + (VisualColumn + VisualLength - 1));
            }
            if (elements == null) {
                throw new ArgumentNullException("elements");
            }
            if (elements[elementIndex] != this) {
                throw new ArgumentException("Invalid elementIndex - couldn't find this element at the index");
            }
            int relativeSplitPos = splitVisualColumn - VisualColumn;
            VisualLineText splitPart = CreateInstance(DocumentLength - relativeSplitPos);
            SplitHelper(this, splitPart, splitVisualColumn, relativeSplitPos + RelativeTextOffset);
            elements.Insert(elementIndex + 1, splitPart);
        }

        /// <inheritdoc />
        public override int GetRelativeOffset(int visualColumn)
        {
            return RelativeTextOffset + visualColumn - VisualColumn;
        }

        /// <inheritdoc />
        public override int GetVisualColumn(int relativeTextOffset)
        {
            return VisualColumn + relativeTextOffset - RelativeTextOffset;
        }

        /// <inheritdoc />
        public override int GetNextCaretPosition(int visualColumn, LogicalDirection direction, CaretPositioningMode mode)
        {
            int textOffset = parentVisualLine.StartOffset + RelativeTextOffset;
            int pos = TextUtilities.GetNextCaretPosition(parentVisualLine.Document,
                textOffset + visualColumn - VisualColumn, direction, mode);
            if (pos < textOffset || pos > textOffset + DocumentLength) {
                return -1;
            }
            return VisualColumn + pos - textOffset;
        }
    }
}