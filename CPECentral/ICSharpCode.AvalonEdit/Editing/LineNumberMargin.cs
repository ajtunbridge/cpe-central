﻿#region Using directives

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Editing
{
    /// <summary>
    ///     Margin showing line numbers.
    /// </summary>
    public class LineNumberMargin : AbstractMargin, IWeakEventListener
    {
        private double emSize;
        private int maxLineNumberLength = 1;
        private bool selecting;
        private AnchorSegment selectionStart;
        private TextArea textArea;

        private Typeface typeface;

        static LineNumberMargin()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (LineNumberMargin),
                new FrameworkPropertyMetadata(typeof (LineNumberMargin)));
        }

        #region IWeakEventListener Members

        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            return ReceiveWeakEvent(managerType, sender, e);
        }

        #endregion

        /// <inheritdoc />
        protected override Size MeasureOverride(Size availableSize)
        {
            typeface = this.CreateTypeface();
            emSize = (double) GetValue(TextBlock.FontSizeProperty);

            FormattedText text = TextFormatterFactory.CreateFormattedText(
                this,
                new string('9', maxLineNumberLength),
                typeface,
                emSize,
                (Brush) GetValue(Control.ForegroundProperty)
                );
            return new Size(text.Width, 0);
        }

        /// <inheritdoc />
        protected override void OnRender(DrawingContext drawingContext)
        {
            TextView textView = TextView;
            Size renderSize = RenderSize;
            if (textView != null && textView.VisualLinesValid) {
                var foreground = (Brush) GetValue(Control.ForegroundProperty);
                foreach (VisualLine line in textView.VisualLines) {
                    int lineNumber = line.FirstDocumentLine.LineNumber;
                    FormattedText text = TextFormatterFactory.CreateFormattedText(
                        this,
                        lineNumber.ToString(CultureInfo.CurrentCulture),
                        typeface, emSize, foreground
                        );
                    double y = line.GetTextLineVisualYPosition(line.TextLines[0], VisualYPosition.TextTop);
                    drawingContext.DrawText(text, new Point(renderSize.Width - text.Width, y - textView.VerticalOffset));
                }
            }
        }

        /// <inheritdoc />
        protected override void OnTextViewChanged(TextView oldTextView, TextView newTextView)
        {
            if (oldTextView != null) {
                oldTextView.VisualLinesChanged -= TextViewVisualLinesChanged;
            }
            base.OnTextViewChanged(oldTextView, newTextView);
            if (newTextView != null) {
                newTextView.VisualLinesChanged += TextViewVisualLinesChanged;

                // find the text area belonging to the new text view
                textArea = newTextView.Services.GetService(typeof (TextArea)) as TextArea;
            }
            else {
                textArea = null;
            }
            InvalidateVisual();
        }

        /// <inheritdoc />
        protected override void OnDocumentChanged(TextDocument oldDocument, TextDocument newDocument)
        {
            if (oldDocument != null) {
                PropertyChangedEventManager.RemoveListener(oldDocument, this, "LineCount");
            }
            base.OnDocumentChanged(oldDocument, newDocument);
            if (newDocument != null) {
                PropertyChangedEventManager.AddListener(newDocument, this, "LineCount");
            }
            OnDocumentLineCountChanged();
        }

        /// <inheritdoc cref="IWeakEventListener.ReceiveWeakEvent" />
        protected virtual bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof (PropertyChangedEventManager)) {
                OnDocumentLineCountChanged();
                return true;
            }
            return false;
        }

        private void OnDocumentLineCountChanged()
        {
            int documentLineCount = Document != null ? Document.LineCount : 1;
            int newLength = documentLineCount.ToString(CultureInfo.CurrentCulture).Length;

            // The margin looks too small when there is only one digit, so always reserve space for
            // at least two digits
            if (newLength < 2) {
                newLength = 2;
            }

            if (newLength != maxLineNumberLength) {
                maxLineNumberLength = newLength;
                InvalidateMeasure();
            }
        }

        private void TextViewVisualLinesChanged(object sender, EventArgs e)
        {
            InvalidateVisual();
        }

        /// <inheritdoc />
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (!e.Handled && TextView != null && textArea != null) {
                e.Handled = true;
                textArea.Focus();

                SimpleSegment currentSeg = GetTextLineSegment(e);
                if (currentSeg == SimpleSegment.Invalid) {
                    return;
                }
                textArea.Caret.Offset = currentSeg.Offset + currentSeg.Length;
                if (CaptureMouse()) {
                    selecting = true;
                    selectionStart = new AnchorSegment(Document, currentSeg.Offset, currentSeg.Length);
                    if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) {
                        var simpleSelection = textArea.Selection as SimpleSelection;
                        if (simpleSelection != null) {
                            selectionStart = new AnchorSegment(Document, simpleSelection.SurroundingSegment);
                        }
                    }
                    textArea.Selection = Selection.Create(textArea, selectionStart);
                    if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) {
                        ExtendSelection(currentSeg);
                    }
                }
            }
        }

        private SimpleSegment GetTextLineSegment(MouseEventArgs e)
        {
            Point pos = e.GetPosition(TextView);
            pos.X = 0;
            pos.Y += TextView.VerticalOffset;
            VisualLine vl = TextView.GetVisualLineFromVisualTop(pos.Y);
            if (vl == null) {
                return SimpleSegment.Invalid;
            }
            TextLine tl = vl.GetTextLineByVisualYPosition(pos.Y);
            int visualStartColumn = vl.GetTextLineVisualStartColumn(tl);
            int visualEndColumn = visualStartColumn + tl.Length;
            int relStart = vl.FirstDocumentLine.Offset;
            int startOffset = vl.GetRelativeOffset(visualStartColumn) + relStart;
            int endOffset = vl.GetRelativeOffset(visualEndColumn) + relStart;
            if (endOffset == vl.LastDocumentLine.Offset + vl.LastDocumentLine.Length) {
                endOffset += vl.LastDocumentLine.DelimiterLength;
            }
            return new SimpleSegment(startOffset, endOffset - startOffset);
        }

        private void ExtendSelection(SimpleSegment currentSeg)
        {
            if (currentSeg.Offset < selectionStart.Offset) {
                textArea.Caret.Offset = currentSeg.Offset;
                textArea.Selection = Selection.Create(textArea, currentSeg.Offset,
                    selectionStart.Offset + selectionStart.Length);
            }
            else {
                textArea.Caret.Offset = currentSeg.Offset + currentSeg.Length;
                textArea.Selection = Selection.Create(textArea, selectionStart.Offset,
                    currentSeg.Offset + currentSeg.Length);
            }
        }

        /// <inheritdoc />
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (selecting && textArea != null && TextView != null) {
                e.Handled = true;
                SimpleSegment currentSeg = GetTextLineSegment(e);
                if (currentSeg == SimpleSegment.Invalid) {
                    return;
                }
                ExtendSelection(currentSeg);
            }
            base.OnMouseMove(e);
        }

        /// <inheritdoc />
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (selecting) {
                selecting = false;
                selectionStart = null;
                ReleaseMouseCapture();
                e.Handled = true;
            }
            base.OnMouseLeftButtonUp(e);
        }

        /// <inheritdoc />
        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            // accept clicks even when clicking on the background
            return new PointHitTestResult(this, hitTestParameters.HitPoint);
        }
    }
}