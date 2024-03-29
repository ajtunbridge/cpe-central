﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Folding
{
    /// <summary>
    ///     A <see cref="VisualLineElementGenerator" /> that produces line elements for folded <see cref="FoldingSection" />s.
    /// </summary>
    public sealed class FoldingElementGenerator : VisualLineElementGenerator, ITextViewConnect
    {
        /// <summary>
        ///     Default brush for folding element text. Value: Brushes.Gray
        /// </summary>
        public static readonly Brush DefaultTextBrush = Brushes.Gray;

        private static Brush textBrush = DefaultTextBrush;
        private readonly List<TextView> textViews = new List<TextView>();
        private FoldingManager foldingManager;

        #region FoldingManager property / connecting with TextView

        /// <summary>
        ///     Gets/Sets the folding manager from which the foldings should be shown.
        /// </summary>
        public FoldingManager FoldingManager
        {
            get { return foldingManager; }
            set
            {
                if (foldingManager != value) {
                    if (foldingManager != null) {
                        foreach (TextView v in textViews) {
                            foldingManager.RemoveFromTextView(v);
                        }
                    }
                    foldingManager = value;
                    if (foldingManager != null) {
                        foreach (TextView v in textViews) {
                            foldingManager.AddToTextView(v);
                        }
                    }
                }
            }
        }

        void ITextViewConnect.AddToTextView(TextView textView)
        {
            textViews.Add(textView);
            if (foldingManager != null) {
                foldingManager.AddToTextView(textView);
            }
        }

        void ITextViewConnect.RemoveFromTextView(TextView textView)
        {
            textViews.Remove(textView);
            if (foldingManager != null) {
                foldingManager.RemoveFromTextView(textView);
            }
        }

        #endregion

        /// <summary>
        ///     Gets/sets the brush used for folding element text.
        /// </summary>
        public static Brush TextBrush
        {
            get { return textBrush; }
            set { textBrush = value; }
        }

        /// <inheritdoc />
        public override void StartGeneration(ITextRunConstructionContext context)
        {
            base.StartGeneration(context);
            if (foldingManager != null) {
                if (!foldingManager.textViews.Contains(context.TextView)) {
                    throw new ArgumentException("Invalid TextView");
                }
                if (context.Document != foldingManager.document) {
                    throw new ArgumentException("Invalid document");
                }
            }
        }

        /// <inheritdoc />
        public override int GetFirstInterestedOffset(int startOffset)
        {
            if (foldingManager != null) {
                foreach (FoldingSection fs in foldingManager.GetFoldingsContaining(startOffset)) {
                    // Test whether we're currently within a folded folding (that didn't just end).
                    // If so, create the fold marker immediately.
                    // This is necessary if the actual beginning of the fold marker got skipped due to another VisualElementGenerator.
                    if (fs.IsFolded && fs.EndOffset > startOffset) {
                        //return startOffset;
                    }
                }
                return foldingManager.GetNextFoldedFoldingStart(startOffset);
            }
            return -1;
        }

        /// <inheritdoc />
        public override VisualLineElement ConstructElement(int offset)
        {
            if (foldingManager == null) {
                return null;
            }
            int foldedUntil = -1;
            FoldingSection foldingSection = null;
            foreach (FoldingSection fs in foldingManager.GetFoldingsContaining(offset)) {
                if (fs.IsFolded) {
                    if (fs.EndOffset > foldedUntil) {
                        foldedUntil = fs.EndOffset;
                        foldingSection = fs;
                    }
                }
            }
            if (foldedUntil > offset && foldingSection != null) {
                // Handle overlapping foldings: if there's another folded folding
                // (starting within the foldingSection) that continues after the end of the folded section,
                // then we'll extend our fold element to cover that overlapping folding.
                bool foundOverlappingFolding;
                do {
                    foundOverlappingFolding = false;
                    foreach (FoldingSection fs in FoldingManager.GetFoldingsContaining(foldedUntil)) {
                        if (fs.IsFolded && fs.EndOffset > foldedUntil) {
                            foldedUntil = fs.EndOffset;
                            foundOverlappingFolding = true;
                        }
                    }
                } while (foundOverlappingFolding);

                string title = foldingSection.Title;
                if (string.IsNullOrEmpty(title)) {
                    title = "...";
                }
                var p = new VisualLineElementTextRunProperties(CurrentContext.GlobalTextRunProperties);
                p.SetForegroundBrush(textBrush);
                TextFormatter textFormatter = TextFormatterFactory.Create(CurrentContext.TextView);
                TextLine text = FormattedTextElement.PrepareText(textFormatter, title, p);
                return new FoldingLineElement(foldingSection, text, foldedUntil - offset) {textBrush = textBrush};
            }
            return null;
        }

        #region Nested type: FoldingLineElement

        private sealed class FoldingLineElement : FormattedTextElement
        {
            private readonly FoldingSection fs;

            internal Brush textBrush;

            public FoldingLineElement(FoldingSection fs, TextLine text, int documentLength) : base(text, documentLength)
            {
                this.fs = fs;
            }

            public override TextRun CreateTextRun(int startVisualColumn, ITextRunConstructionContext context)
            {
                return new FoldingLineTextRun(this, TextRunProperties) {textBrush = textBrush};
            }

            protected internal override void OnMouseDown(MouseButtonEventArgs e)
            {
                if (e.ClickCount == 2 && e.ChangedButton == MouseButton.Left) {
                    fs.IsFolded = false;
                    e.Handled = true;
                }
                else {
                    base.OnMouseDown(e);
                }
            }
        }

        #endregion

        #region Nested type: FoldingLineTextRun

        private sealed class FoldingLineTextRun : FormattedTextRun
        {
            internal Brush textBrush;

            public FoldingLineTextRun(FormattedTextElement element, TextRunProperties properties)
                : base(element, properties)
            {
            }

            public override void Draw(DrawingContext drawingContext, Point origin, bool rightToLeft, bool sideways)
            {
                TextEmbeddedObjectMetrics metrics = Format(double.PositiveInfinity);
                var r = new Rect(origin.X, origin.Y - metrics.Baseline, metrics.Width, metrics.Height);
                drawingContext.DrawRectangle(null, new Pen(textBrush, 1), r);
                base.Draw(drawingContext, origin, rightToLeft, sideways);
            }
        }

        #endregion
    }
}