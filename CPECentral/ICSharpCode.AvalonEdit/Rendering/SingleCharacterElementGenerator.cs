#region Using directives

using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Rendering
{
    // This class is internal because it does not need to be accessed by the user - it can be configured using TextEditorOptions.

    /// <summary>
    ///     Element generator that displays · for spaces and » for tabs and a box for control characters.
    /// </summary>
    /// <remarks>
    ///     This element generator is present in every TextView by default; the enabled features can be configured using the
    ///     <see cref="TextEditorOptions" />.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Whitespace")]
    internal sealed class SingleCharacterElementGenerator : VisualLineElementGenerator, IBuiltinElementGenerator
    {
        /// <summary>
        ///     Creates a new SingleCharacterElementGenerator instance.
        /// </summary>
        public SingleCharacterElementGenerator()
        {
            ShowSpaces = true;
            ShowTabs = true;
            ShowBoxForControlCharacters = true;
        }

        /// <summary>
        ///     Gets/Sets whether to show · for spaces.
        /// </summary>
        public bool ShowSpaces { get; set; }

        /// <summary>
        ///     Gets/Sets whether to show » for tabs.
        /// </summary>
        public bool ShowTabs { get; set; }

        /// <summary>
        ///     Gets/Sets whether to show a box with the hex code for control characters.
        /// </summary>
        public bool ShowBoxForControlCharacters { get; set; }

        #region IBuiltinElementGenerator Members

        void IBuiltinElementGenerator.FetchOptions(TextEditorOptions options)
        {
            ShowSpaces = options.ShowSpaces;
            ShowTabs = options.ShowTabs;
            ShowBoxForControlCharacters = options.ShowBoxForControlCharacters;
        }

        #endregion

        public override int GetFirstInterestedOffset(int startOffset)
        {
            DocumentLine endLine = CurrentContext.VisualLine.LastDocumentLine;
            StringSegment relevantText = CurrentContext.GetText(startOffset, endLine.EndOffset - startOffset);

            for (int i = 0; i < relevantText.Count; i++) {
                char c = relevantText.Text[relevantText.Offset + i];
                switch (c) {
                    case ' ':
                        if (ShowSpaces) {
                            return startOffset + i;
                        }
                        break;
                    case '\t':
                        if (ShowTabs) {
                            return startOffset + i;
                        }
                        break;
                    default:
                        if (ShowBoxForControlCharacters && char.IsControl(c)) {
                            return startOffset + i;
                        }
                        break;
                }
            }
            return -1;
        }

        public override VisualLineElement ConstructElement(int offset)
        {
            char c = CurrentContext.Document.GetCharAt(offset);
            if (ShowSpaces && c == ' ') {
                return
                    new SpaceTextElement(CurrentContext.TextView.cachedElements.GetTextForNonPrintableCharacter(
                        "\u00B7", CurrentContext));
            }
            if (ShowTabs && c == '\t') {
                return
                    new TabTextElement(CurrentContext.TextView.cachedElements.GetTextForNonPrintableCharacter("\u00BB",
                        CurrentContext));
            }
            if (ShowBoxForControlCharacters && char.IsControl(c)) {
                var p = new VisualLineElementTextRunProperties(CurrentContext.GlobalTextRunProperties);
                p.SetForegroundBrush(Brushes.White);
                TextFormatter textFormatter = TextFormatterFactory.Create(CurrentContext.TextView);
                TextLine text = FormattedTextElement.PrepareText(textFormatter,
                    TextUtilities.GetControlCharacterName(c), p);
                return new SpecialCharacterBoxElement(text);
            }
            return null;
        }

        #region Nested type: SpaceTextElement

        private sealed class SpaceTextElement : FormattedTextElement
        {
            public SpaceTextElement(TextLine textLine) : base(textLine, 1)
            {
                BreakBefore = LineBreakCondition.BreakPossible;
                BreakAfter = LineBreakCondition.BreakDesired;
            }

            public override int GetNextCaretPosition(int visualColumn, LogicalDirection direction,
                CaretPositioningMode mode)
            {
                if (mode == CaretPositioningMode.Normal) {
                    return base.GetNextCaretPosition(visualColumn, direction, mode);
                }
                return -1;
            }

            public override bool IsWhitespace(int visualColumn)
            {
                return true;
            }
        }

        #endregion

        #region Nested type: SpecialCharacterBoxElement

        private sealed class SpecialCharacterBoxElement : FormattedTextElement
        {
            public SpecialCharacterBoxElement(TextLine text) : base(text, 1)
            {
            }

            public override TextRun CreateTextRun(int startVisualColumn, ITextRunConstructionContext context)
            {
                return new SpecialCharacterTextRun(this, TextRunProperties);
            }
        }

        #endregion

        #region Nested type: SpecialCharacterTextRun

        private sealed class SpecialCharacterTextRun : FormattedTextRun
        {
            private static readonly SolidColorBrush darkGrayBrush;

            static SpecialCharacterTextRun()
            {
                darkGrayBrush = new SolidColorBrush(Color.FromArgb(200, 128, 128, 128));
                darkGrayBrush.Freeze();
            }

            public SpecialCharacterTextRun(FormattedTextElement element, TextRunProperties properties)
                : base(element, properties)
            {
            }

            public override void Draw(DrawingContext drawingContext, Point origin, bool rightToLeft, bool sideways)
            {
                var newOrigin = new Point(origin.X + 1.5, origin.Y);
                TextEmbeddedObjectMetrics metrics = base.Format(double.PositiveInfinity);
                var r = new Rect(newOrigin.X - 0.5, newOrigin.Y - metrics.Baseline, metrics.Width + 2, metrics.Height);
                drawingContext.DrawRoundedRectangle(darkGrayBrush, null, r, 2.5, 2.5);
                base.Draw(drawingContext, newOrigin, rightToLeft, sideways);
            }

            public override TextEmbeddedObjectMetrics Format(double remainingParagraphWidth)
            {
                TextEmbeddedObjectMetrics metrics = base.Format(remainingParagraphWidth);
                return new TextEmbeddedObjectMetrics(metrics.Width + 3,
                    metrics.Height, metrics.Baseline);
            }

            public override Rect ComputeBoundingBox(bool rightToLeft, bool sideways)
            {
                Rect r = base.ComputeBoundingBox(rightToLeft, sideways);
                r.Width += 3;
                return r;
            }
        }

        #endregion

        #region Nested type: TabGlyphRun

        private sealed class TabGlyphRun : TextEmbeddedObject
        {
            private readonly TabTextElement element;
            private readonly TextRunProperties properties;

            public TabGlyphRun(TabTextElement element, TextRunProperties properties)
            {
                if (properties == null) {
                    throw new ArgumentNullException("properties");
                }
                this.properties = properties;
                this.element = element;
            }

            public override LineBreakCondition BreakBefore
            {
                get { return LineBreakCondition.BreakPossible; }
            }

            public override LineBreakCondition BreakAfter
            {
                get { return LineBreakCondition.BreakRestrained; }
            }

            public override bool HasFixedSize
            {
                get { return true; }
            }

            public override CharacterBufferReference CharacterBufferReference
            {
                get { return new CharacterBufferReference(); }
            }

            public override int Length
            {
                get { return 1; }
            }

            public override TextRunProperties Properties
            {
                get { return properties; }
            }

            public override TextEmbeddedObjectMetrics Format(double remainingParagraphWidth)
            {
                double width = Math.Min(0, element.text.WidthIncludingTrailingWhitespace - 1);
                return new TextEmbeddedObjectMetrics(width, element.text.Height, element.text.Baseline);
            }

            public override Rect ComputeBoundingBox(bool rightToLeft, bool sideways)
            {
                double width = Math.Min(0, element.text.WidthIncludingTrailingWhitespace - 1);
                return new Rect(0, 0, width, element.text.Height);
            }

            public override void Draw(DrawingContext drawingContext, Point origin, bool rightToLeft, bool sideways)
            {
                origin.Y -= element.text.Baseline;
                element.text.Draw(drawingContext, origin, InvertAxes.None);
            }
        }

        #endregion

        #region Nested type: TabTextElement

        private sealed class TabTextElement : VisualLineElement
        {
            internal readonly TextLine text;

            public TabTextElement(TextLine text) : base(2, 1)
            {
                this.text = text;
            }

            public override TextRun CreateTextRun(int startVisualColumn, ITextRunConstructionContext context)
            {
                // the TabTextElement consists of two TextRuns:
                // first a TabGlyphRun, then TextCharacters '\t' to let WPF handle the tab indentation
                if (startVisualColumn == VisualColumn) {
                    return new TabGlyphRun(this, TextRunProperties);
                }
                if (startVisualColumn == VisualColumn + 1) {
                    return new TextCharacters("\t", 0, 1, TextRunProperties);
                }
                throw new ArgumentOutOfRangeException("startVisualColumn");
            }

            public override int GetNextCaretPosition(int visualColumn, LogicalDirection direction,
                CaretPositioningMode mode)
            {
                if (mode == CaretPositioningMode.Normal) {
                    return base.GetNextCaretPosition(visualColumn, direction, mode);
                }
                return -1;
            }

            public override bool IsWhitespace(int visualColumn)
            {
                return true;
            }
        }

        #endregion
    }
}