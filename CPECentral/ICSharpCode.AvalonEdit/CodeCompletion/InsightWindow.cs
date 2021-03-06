﻿#region Using directives

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.CodeCompletion
{
    /// <summary>
    ///     A popup-like window that is attached to a text segment.
    /// </summary>
    public class InsightWindow : CompletionWindowBase
    {
        static InsightWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (InsightWindow),
                new FrameworkPropertyMetadata(typeof (InsightWindow)));
            AllowsTransparencyProperty.OverrideMetadata(typeof (InsightWindow),
                new FrameworkPropertyMetadata(Boxes.True));
        }

        /// <summary>
        ///     Creates a new InsightWindow.
        /// </summary>
        public InsightWindow(TextArea textArea) : base(textArea)
        {
            CloseAutomatically = true;
            AttachEvents();
        }

        /// <summary>
        ///     Gets/Sets whether the insight window should close automatically.
        ///     The default value is true.
        /// </summary>
        public bool CloseAutomatically { get; set; }

        /// <inheritdoc />
        protected override bool CloseOnFocusLost
        {
            get { return CloseAutomatically; }
        }

        /// <inheritdoc />
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            Rect caret = TextArea.Caret.CalculateCaretRectangle();
            Point pointOnScreen = TextArea.TextView.PointToScreen(caret.Location - TextArea.TextView.ScrollOffset);
            Rect workingArea =
                Screen.FromPoint(pointOnScreen.ToSystemDrawing()).WorkingArea.ToWpf().TransformFromDevice(this);

            MaxHeight = workingArea.Height;
            MaxWidth = Math.Min(workingArea.Width, Math.Max(1000, workingArea.Width*0.6));
        }

        private void AttachEvents()
        {
            TextArea.Caret.PositionChanged += CaretPositionChanged;
        }

        /// <inheritdoc />
        protected override void DetachEvents()
        {
            TextArea.Caret.PositionChanged -= CaretPositionChanged;
            base.DetachEvents();
        }

        private void CaretPositionChanged(object sender, EventArgs e)
        {
            if (CloseAutomatically) {
                int offset = TextArea.Caret.Offset;
                if (offset < StartOffset || offset > EndOffset) {
                    Close();
                }
            }
        }
    }

    /// <summary>
    ///     TemplateSelector for InsightWindow to replace plain string content by a TextBlock with TextWrapping.
    /// </summary>
    internal sealed class InsightWindowTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is string) {
                return (DataTemplate) ((FrameworkElement) container).FindResource("TextBlockTemplate");
            }

            return null;
        }
    }
}