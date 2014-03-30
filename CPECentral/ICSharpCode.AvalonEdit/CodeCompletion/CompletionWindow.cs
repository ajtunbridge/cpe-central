#region Using directives

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;

#endregion

namespace ICSharpCode.AvalonEdit.CodeCompletion
{
    /// <summary>
    ///     The code completion window.
    /// </summary>
    public class CompletionWindow : CompletionWindowBase
    {
        private readonly CompletionList completionList = new CompletionList();
        private ToolTip toolTip = new ToolTip();

        /// <summary>
        ///     Creates a new code completion window.
        /// </summary>
        public CompletionWindow(TextArea textArea) : base(textArea)
        {
            // keep height automatic
            CloseAutomatically = true;
            SizeToContent = SizeToContent.Height;
            MaxHeight = 300;
            Width = 175;
            Content = completionList;
            // prevent user from resizing window to 0x0
            MinHeight = 15;
            MinWidth = 30;

            toolTip.PlacementTarget = this;
            toolTip.Placement = PlacementMode.Right;
            toolTip.Closed += toolTip_Closed;

            AttachEvents();
        }

        #region ToolTip handling

        private void toolTip_Closed(object sender, RoutedEventArgs e)
        {
            // Clear content after tooltip is closed.
            // We cannot clear is immediately when setting IsOpen=false
            // because the tooltip uses an animation for closing.
            if (toolTip != null) {
                toolTip.Content = null;
            }
        }

        private void completionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ICompletionData item = completionList.SelectedItem;
            if (item == null) {
                return;
            }
            object description = item.Description;
            if (description != null) {
                var descriptionText = description as string;
                if (descriptionText != null) {
                    toolTip.Content = new TextBlock {
                        Text = descriptionText,
                        TextWrapping = TextWrapping.Wrap
                    };
                }
                else {
                    toolTip.Content = description;
                }
                toolTip.IsOpen = true;
            }
            else {
                toolTip.IsOpen = false;
            }
        }

        #endregion

        /// <summary>
        ///     Gets the completion list used in this completion window.
        /// </summary>
        public CompletionList CompletionList
        {
            get { return completionList; }
        }

        /// <summary>
        ///     Gets/Sets whether the completion window should close automatically.
        ///     The default value is true.
        /// </summary>
        public bool CloseAutomatically { get; set; }

        /// <inheritdoc />
        protected override bool CloseOnFocusLost
        {
            get { return CloseAutomatically; }
        }

        /// <summary>
        ///     When this flag is set, code completion closes if the caret moves to the
        ///     beginning of the allowed range. This is useful in Ctrl+Space and "complete when typing",
        ///     but not in dot-completion.
        ///     Has no effect if CloseAutomatically is false.
        /// </summary>
        public bool CloseWhenCaretAtBeginning { get; set; }

        private void completionList_InsertionRequested(object sender, EventArgs e)
        {
            Close();
            // The window must close before Complete() is called.
            // If the Complete callback pushes stacked input handlers, we don't want to pop those when the CC window closes.
            ICompletionData item = completionList.SelectedItem;
            if (item != null) {
                item.Complete(TextArea, new AnchorSegment(TextArea.Document, StartOffset, EndOffset - StartOffset), e);
            }
        }

        private void AttachEvents()
        {
            completionList.InsertionRequested += completionList_InsertionRequested;
            completionList.SelectionChanged += completionList_SelectionChanged;
            TextArea.Caret.PositionChanged += CaretPositionChanged;
            TextArea.MouseWheel += textArea_MouseWheel;
            TextArea.PreviewTextInput += textArea_PreviewTextInput;
        }

        /// <inheritdoc />
        protected override void DetachEvents()
        {
            completionList.InsertionRequested -= completionList_InsertionRequested;
            completionList.SelectionChanged -= completionList_SelectionChanged;
            TextArea.Caret.PositionChanged -= CaretPositionChanged;
            TextArea.MouseWheel -= textArea_MouseWheel;
            TextArea.PreviewTextInput -= textArea_PreviewTextInput;
            base.DetachEvents();
        }

        /// <inheritdoc />
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (toolTip != null) {
                toolTip.IsOpen = false;
                toolTip = null;
            }
        }

        /// <inheritdoc />
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!e.Handled) {
                completionList.HandleKey(e);
            }
        }

        private void textArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = RaiseEventPair(this, PreviewTextInputEvent, TextInputEvent,
                new TextCompositionEventArgs(e.Device, e.TextComposition));
        }

        private void textArea_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = RaiseEventPair(GetScrollEventTarget(),
                PreviewMouseWheelEvent, MouseWheelEvent,
                new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta));
        }

        private UIElement GetScrollEventTarget()
        {
            if (completionList == null) {
                return this;
            }
            return completionList.ScrollViewer ?? completionList.ListBox ?? (UIElement) completionList;
        }

        private void CaretPositionChanged(object sender, EventArgs e)
        {
            int offset = TextArea.Caret.Offset;
            if (offset == StartOffset) {
                if (CloseAutomatically && CloseWhenCaretAtBeginning) {
                    Close();
                }
                else {
                    completionList.SelectItem(string.Empty);
                }
                return;
            }
            if (offset < StartOffset || offset > EndOffset) {
                if (CloseAutomatically) {
                    Close();
                }
            }
            else {
                TextDocument document = TextArea.Document;
                if (document != null) {
                    completionList.SelectItem(document.GetText(StartOffset, offset - StartOffset));
                }
            }
        }
    }
}