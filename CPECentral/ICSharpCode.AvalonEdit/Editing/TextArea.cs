﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Indentation;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Editing
{
    /// <summary>
    ///     Control that wraps a TextView and adds support for user input and the caret.
    /// </summary>
    public class TextArea : Control, IScrollInfo, IWeakEventListener, ITextEditorComponent, IServiceProvider
    {
        internal readonly ImeSupport ime;

        #region Constructor

        static TextArea()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (TextArea),
                new FrameworkPropertyMetadata(typeof (TextArea)));
            KeyboardNavigation.IsTabStopProperty.OverrideMetadata(
                typeof (TextArea), new FrameworkPropertyMetadata(Boxes.True));
            KeyboardNavigation.TabNavigationProperty.OverrideMetadata(
                typeof (TextArea), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));
            FocusableProperty.OverrideMetadata(
                typeof (TextArea), new FrameworkPropertyMetadata(Boxes.True));
        }

        /// <summary>
        ///     Creates a new TextArea instance.
        /// </summary>
        public TextArea() : this(new TextView())
        {
        }

        /// <summary>
        ///     Creates a new TextArea instance.
        /// </summary>
        protected TextArea(TextView textView)
        {
            if (textView == null) {
                throw new ArgumentNullException("textView");
            }
            this.textView = textView;
            Options = textView.Options;

            selection = emptySelection = new EmptySelection(this);

            textView.Services.AddService(typeof (TextArea), this);

            textView.LineTransformers.Add(new SelectionColorizer(this));
            textView.InsertLayer(new SelectionLayer(this), KnownLayer.Selection, LayerInsertionPosition.Replace);

            caret = new Caret(this);
            caret.PositionChanged += (sender, e) => RequestSelectionValidation();
            ime = new ImeSupport(this);

            leftMargins.CollectionChanged += leftMargins_CollectionChanged;

            DefaultInputHandler = new TextAreaDefaultInputHandler(this);
            ActiveInputHandler = DefaultInputHandler;
        }

        #endregion

        #region InputHandler management

        private ITextAreaInputHandler activeInputHandler;
        private bool isChangingInputHandler;

        private ImmutableStack<TextAreaStackedInputHandler> stackedInputHandlers =
            ImmutableStack<TextAreaStackedInputHandler>.Empty;

        /// <summary>
        ///     Gets the default input handler.
        /// </summary>
        /// <remarks>
        ///     <inheritdoc cref="ITextAreaInputHandler" />
        /// </remarks>
        public TextAreaDefaultInputHandler DefaultInputHandler { get; private set; }

        /// <summary>
        ///     Gets/Sets the active input handler.
        ///     This property does not return currently active stacked input handlers. Setting this property detached all stacked
        ///     input handlers.
        /// </summary>
        /// <remarks>
        ///     <inheritdoc cref="ITextAreaInputHandler" />
        /// </remarks>
        public ITextAreaInputHandler ActiveInputHandler
        {
            get { return activeInputHandler; }
            set
            {
                if (value != null && value.TextArea != this) {
                    throw new ArgumentException("The input handler was created for a different text area than this one.");
                }
                if (isChangingInputHandler) {
                    throw new InvalidOperationException("Cannot set ActiveInputHandler recursively");
                }
                if (activeInputHandler != value) {
                    isChangingInputHandler = true;
                    try {
                        // pop the whole stack
                        PopStackedInputHandler(stackedInputHandlers.LastOrDefault());
                        Debug.Assert(stackedInputHandlers.IsEmpty);

                        if (activeInputHandler != null) {
                            activeInputHandler.Detach();
                        }
                        activeInputHandler = value;
                        if (value != null) {
                            value.Attach();
                        }
                    }
                    finally {
                        isChangingInputHandler = false;
                    }
                    if (ActiveInputHandlerChanged != null) {
                        ActiveInputHandlerChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the list of currently active stacked input handlers.
        /// </summary>
        /// <remarks>
        ///     <inheritdoc cref="ITextAreaInputHandler" />
        /// </remarks>
        public ImmutableStack<TextAreaStackedInputHandler> StackedInputHandlers
        {
            get { return stackedInputHandlers; }
        }

        /// <summary>
        ///     Occurs when the ActiveInputHandler property changes.
        /// </summary>
        public event EventHandler ActiveInputHandlerChanged;

        /// <summary>
        ///     Pushes an input handler onto the list of stacked input handlers.
        /// </summary>
        /// <remarks>
        ///     <inheritdoc cref="ITextAreaInputHandler" />
        /// </remarks>
        public void PushStackedInputHandler(TextAreaStackedInputHandler inputHandler)
        {
            if (inputHandler == null) {
                throw new ArgumentNullException("inputHandler");
            }
            stackedInputHandlers = stackedInputHandlers.Push(inputHandler);
            inputHandler.Attach();
        }

        /// <summary>
        ///     Pops the stacked input handler (and all input handlers above it).
        ///     If <paramref name="inputHandler" /> is not found in the currently stacked input handlers, or is null, this method
        ///     does nothing.
        /// </summary>
        /// <remarks>
        ///     <inheritdoc cref="ITextAreaInputHandler" />
        /// </remarks>
        public void PopStackedInputHandler(TextAreaStackedInputHandler inputHandler)
        {
            if (stackedInputHandlers.Any(i => i == inputHandler)) {
                ITextAreaInputHandler oldHandler;
                do {
                    oldHandler = stackedInputHandlers.Peek();
                    stackedInputHandlers = stackedInputHandlers.Pop();
                    oldHandler.Detach();
                } while (oldHandler != inputHandler);
            }
        }

        #endregion

        #region Document property

        /// <summary>
        ///     Document property.
        /// </summary>
        public static readonly DependencyProperty DocumentProperty
            = TextView.DocumentProperty.AddOwner(typeof (TextArea), new FrameworkPropertyMetadata(OnDocumentChanged));

        /// <summary>
        ///     Gets/Sets the document displayed by the text editor.
        /// </summary>
        public TextDocument Document
        {
            get { return (TextDocument) GetValue(DocumentProperty); }
            set { SetValue(DocumentProperty, value); }
        }

        /// <inheritdoc />
        public event EventHandler DocumentChanged;

        private static void OnDocumentChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            ((TextArea) dp).OnDocumentChanged((TextDocument) e.OldValue, (TextDocument) e.NewValue);
        }

        private void OnDocumentChanged(TextDocument oldValue, TextDocument newValue)
        {
            if (oldValue != null) {
                TextDocumentWeakEventManager.Changing.RemoveListener(oldValue, this);
                TextDocumentWeakEventManager.Changed.RemoveListener(oldValue, this);
                TextDocumentWeakEventManager.UpdateStarted.RemoveListener(oldValue, this);
                TextDocumentWeakEventManager.UpdateFinished.RemoveListener(oldValue, this);
            }
            textView.Document = newValue;
            if (newValue != null) {
                TextDocumentWeakEventManager.Changing.AddListener(newValue, this);
                TextDocumentWeakEventManager.Changed.AddListener(newValue, this);
                TextDocumentWeakEventManager.UpdateStarted.AddListener(newValue, this);
                TextDocumentWeakEventManager.UpdateFinished.AddListener(newValue, this);
            }
            // Reset caret location and selection: this is necessary because the caret/selection might be invalid
            // in the new document (e.g. if new document is shorter than the old document).
            caret.Location = new TextLocation(1, 1);
            ClearSelection();
            if (DocumentChanged != null) {
                DocumentChanged(this, EventArgs.Empty);
            }
            CommandManager.InvalidateRequerySuggested();
        }

        #endregion

        #region Options property

        /// <summary>
        ///     Options property.
        /// </summary>
        public static readonly DependencyProperty OptionsProperty
            = TextView.OptionsProperty.AddOwner(typeof (TextArea), new FrameworkPropertyMetadata(OnOptionsChanged));

        /// <summary>
        ///     Gets/Sets the document displayed by the text editor.
        /// </summary>
        public TextEditorOptions Options
        {
            get { return (TextEditorOptions) GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }

        /// <summary>
        ///     Occurs when a text editor option has changed.
        /// </summary>
        public event PropertyChangedEventHandler OptionChanged;

        /// <summary>
        ///     Raises the <see cref="OptionChanged" /> event.
        /// </summary>
        protected virtual void OnOptionChanged(PropertyChangedEventArgs e)
        {
            if (OptionChanged != null) {
                OptionChanged(this, e);
            }
        }

        private static void OnOptionsChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            ((TextArea) dp).OnOptionsChanged((TextEditorOptions) e.OldValue, (TextEditorOptions) e.NewValue);
        }

        private void OnOptionsChanged(TextEditorOptions oldValue, TextEditorOptions newValue)
        {
            if (oldValue != null) {
                PropertyChangedWeakEventManager.RemoveListener(oldValue, this);
            }
            textView.Options = newValue;
            if (newValue != null) {
                PropertyChangedWeakEventManager.AddListener(newValue, this);
            }
            OnOptionChanged(new PropertyChangedEventArgs(null));
        }

        #endregion

        #region ReceiveWeakEvent

        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            return ReceiveWeakEvent(managerType, sender, e);
        }

        /// <inheritdoc cref="IWeakEventListener.ReceiveWeakEvent" />
        protected virtual bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof (TextDocumentWeakEventManager.Changing)) {
                OnDocumentChanging();
                return true;
            }
            if (managerType == typeof (TextDocumentWeakEventManager.Changed)) {
                OnDocumentChanged((DocumentChangeEventArgs) e);
                return true;
            }
            if (managerType == typeof (TextDocumentWeakEventManager.UpdateStarted)) {
                OnUpdateStarted();
                return true;
            }
            if (managerType == typeof (TextDocumentWeakEventManager.UpdateFinished)) {
                OnUpdateFinished();
                return true;
            }
            if (managerType == typeof (PropertyChangedWeakEventManager)) {
                OnOptionChanged((PropertyChangedEventArgs) e);
                return true;
            }
            return false;
        }

        #endregion

        #region Caret handling on document changes

        private void OnDocumentChanging()
        {
            caret.OnDocumentChanging();
        }

        private void OnDocumentChanged(DocumentChangeEventArgs e)
        {
            caret.OnDocumentChanged(e);
            Selection = selection.UpdateOnDocumentChange(e);
        }

        private void OnUpdateStarted()
        {
            Document.UndoStack.PushOptional(new RestoreCaretAndSelectionUndoAction(this));
        }

        private void OnUpdateFinished()
        {
            caret.OnDocumentUpdateFinished();
        }

        private sealed class RestoreCaretAndSelectionUndoAction : IUndoableOperation
        {
            // keep textarea in weak reference because the IUndoableOperation is stored with the document
            private readonly TextViewPosition caretPosition;
            private readonly Selection selection;
            private readonly WeakReference textAreaReference;

            public RestoreCaretAndSelectionUndoAction(TextArea textArea)
            {
                textAreaReference = new WeakReference(textArea);
                // Just save the old caret position, no need to validate here.
                // If we restore it, we'll validate it anyways.
                caretPosition = textArea.Caret.NonValidatedPosition;
                selection = textArea.Selection;
            }

            #region IUndoableOperation Members

            public void Undo()
            {
                var textArea = (TextArea) textAreaReference.Target;
                if (textArea != null) {
                    textArea.Caret.Position = caretPosition;
                    textArea.Selection = selection;
                }
            }

            public void Redo()
            {
                // redo=undo: we just restore the caret/selection state
                Undo();
            }

            #endregion
        }

        #endregion

        #region TextView property

        private readonly TextView textView;
        private IScrollInfo scrollInfo;

        /// <summary>
        ///     Gets the text view used to display text in this text area.
        /// </summary>
        public TextView TextView
        {
            get { return textView; }
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            scrollInfo = textView;
            ApplyScrollInfo();
        }

        #endregion

        #region Selection property

        /// <summary>
        ///     The <see cref="SelectionBrush" /> property.
        /// </summary>
        public static readonly DependencyProperty SelectionBrushProperty =
            DependencyProperty.Register("SelectionBrush", typeof (Brush), typeof (TextArea));

        /// <summary>
        ///     The <see cref="SelectionForeground" /> property.
        /// </summary>
        public static readonly DependencyProperty SelectionForegroundProperty =
            DependencyProperty.Register("SelectionForeground", typeof (Brush), typeof (TextArea));

        /// <summary>
        ///     The <see cref="SelectionBorder" /> property.
        /// </summary>
        public static readonly DependencyProperty SelectionBorderProperty =
            DependencyProperty.Register("SelectionBorder", typeof (Pen), typeof (TextArea));

        /// <summary>
        ///     The <see cref="SelectionCornerRadius" /> property.
        /// </summary>
        public static readonly DependencyProperty SelectionCornerRadiusProperty =
            DependencyProperty.Register("SelectionCornerRadius", typeof (double), typeof (TextArea),
                new FrameworkPropertyMetadata(3.0));

        internal readonly Selection emptySelection;
        private Selection selection;

        /// <summary>
        ///     Gets/Sets the selection in this text area.
        /// </summary>
        public Selection Selection
        {
            get { return selection; }
            set
            {
                if (value == null) {
                    throw new ArgumentNullException("value");
                }
                if (value.textArea != this) {
                    throw new ArgumentException("Cannot use a Selection instance that belongs to another text area.");
                }
                if (!Equals(selection, value)) {
//					Debug.WriteLine("Selection change from " + selection + " to " + value);
                    if (textView != null) {
                        ISegment oldSegment = selection.SurroundingSegment;
                        ISegment newSegment = value.SurroundingSegment;
                        if (!Selection.EnableVirtualSpace &&
                            (selection is SimpleSelection && value is SimpleSelection && oldSegment != null &&
                             newSegment != null)) {
                            // perf optimization:
                            // When a simple selection changes, don't redraw the whole selection, but only the changed parts.
                            int oldSegmentOffset = oldSegment.Offset;
                            int newSegmentOffset = newSegment.Offset;
                            if (oldSegmentOffset != newSegmentOffset) {
                                textView.Redraw(Math.Min(oldSegmentOffset, newSegmentOffset),
                                    Math.Abs(oldSegmentOffset - newSegmentOffset),
                                    DispatcherPriority.Background);
                            }
                            int oldSegmentEndOffset = oldSegment.EndOffset;
                            int newSegmentEndOffset = newSegment.EndOffset;
                            if (oldSegmentEndOffset != newSegmentEndOffset) {
                                textView.Redraw(Math.Min(oldSegmentEndOffset, newSegmentEndOffset),
                                    Math.Abs(oldSegmentEndOffset - newSegmentEndOffset),
                                    DispatcherPriority.Background);
                            }
                        }
                        else {
                            textView.Redraw(oldSegment, DispatcherPriority.Background);
                            textView.Redraw(newSegment, DispatcherPriority.Background);
                        }
                    }
                    selection = value;
                    if (SelectionChanged != null) {
                        SelectionChanged(this, EventArgs.Empty);
                    }
                    // a selection change causes commands like copy/paste/etc. to change status
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        /// <summary>
        ///     Gets/Sets the background brush used for the selection.
        /// </summary>
        public Brush SelectionBrush
        {
            get { return (Brush) GetValue(SelectionBrushProperty); }
            set { SetValue(SelectionBrushProperty, value); }
        }

        /// <summary>
        ///     Gets/Sets the foreground brush used selected text.
        /// </summary>
        public Brush SelectionForeground
        {
            get { return (Brush) GetValue(SelectionForegroundProperty); }
            set { SetValue(SelectionForegroundProperty, value); }
        }

        /// <summary>
        ///     Gets/Sets the background brush used for the selection.
        /// </summary>
        public Pen SelectionBorder
        {
            get { return (Pen) GetValue(SelectionBorderProperty); }
            set { SetValue(SelectionBorderProperty, value); }
        }

        /// <summary>
        ///     Gets/Sets the corner radius of the selection.
        /// </summary>
        public double SelectionCornerRadius
        {
            get { return (double) GetValue(SelectionCornerRadiusProperty); }
            set { SetValue(SelectionCornerRadiusProperty, value); }
        }

        /// <summary>
        ///     Occurs when the selection has changed.
        /// </summary>
        public event EventHandler SelectionChanged;

        /// <summary>
        ///     Clears the current selection.
        /// </summary>
        public void ClearSelection()
        {
            Selection = emptySelection;
        }

        #endregion

        #region Force caret to stay inside selection

        private int allowCaretOutsideSelection;
        private bool ensureSelectionValidRequested;

        private void RequestSelectionValidation()
        {
            if (!ensureSelectionValidRequested && allowCaretOutsideSelection == 0) {
                ensureSelectionValidRequested = true;
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(EnsureSelectionValid));
            }
        }

        /// <summary>
        ///     Code that updates only the caret but not the selection can cause confusion when
        ///     keys like 'Delete' delete the (possibly invisible) selected text and not the
        ///     text around the caret.
        ///     So we'll ensure that the caret is inside the selection.
        ///     (when the caret is not in the selection, we'll clear the selection)
        ///     This method is invoked using the Dispatcher so that code may temporarily violate this rule
        ///     (e.g. most 'extend selection' methods work by first setting the caret, then the selection),
        ///     it's sufficient to fix it after any event handlers have run.
        /// </summary>
        private void EnsureSelectionValid()
        {
            ensureSelectionValidRequested = false;
            if (allowCaretOutsideSelection == 0) {
                if (!selection.IsEmpty && !selection.Contains(caret.Offset)) {
                    Debug.WriteLine("Resetting selection because caret is outside");
                    ClearSelection();
                }
            }
        }

        /// <summary>
        ///     Temporarily allows positioning the caret outside the selection.
        ///     Dispose the returned IDisposable to revert the allowance.
        /// </summary>
        /// <remarks>
        ///     The text area only forces the caret to be inside the selection when other events
        ///     have finished running (using the dispatcher), so you don't have to use this method
        ///     for temporarily positioning the caret in event handlers.
        ///     This method is only necessary if you want to run the WPF dispatcher, e.g. if you
        ///     perform a drag'n'drop operation.
        /// </remarks>
        public IDisposable AllowCaretOutsideSelection()
        {
            VerifyAccess();
            allowCaretOutsideSelection++;
            return new CallbackOnDispose(
                delegate {
                    VerifyAccess();
                    allowCaretOutsideSelection--;
                    RequestSelectionValidation();
                });
        }

        #endregion

        #region Properties

        private readonly Caret caret;

        private readonly ObservableCollection<UIElement> leftMargins = new ObservableCollection<UIElement>();

        private IReadOnlySectionProvider readOnlySectionProvider = NoReadOnlySections.Instance;

        /// <summary>
        ///     Gets the Caret used for this text area.
        /// </summary>
        public Caret Caret
        {
            get { return caret; }
        }

        /// <summary>
        ///     Gets the collection of margins displayed to the left of the text view.
        /// </summary>
        public ObservableCollection<UIElement> LeftMargins
        {
            get { return leftMargins; }
        }

        /// <summary>
        ///     Gets/Sets an object that provides read-only sections for the text area.
        /// </summary>
        public IReadOnlySectionProvider ReadOnlySectionProvider
        {
            get { return readOnlySectionProvider; }
            set
            {
                if (value == null) {
                    throw new ArgumentNullException("value");
                }
                readOnlySectionProvider = value;
                CommandManager.InvalidateRequerySuggested();
                    // the read-only status effects Paste.CanExecute and the IME
            }
        }

        private void leftMargins_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null) {
                foreach (ITextViewConnect c in e.OldItems.OfType<ITextViewConnect>()) {
                    c.RemoveFromTextView(textView);
                }
            }
            if (e.NewItems != null) {
                foreach (ITextViewConnect c in e.NewItems.OfType<ITextViewConnect>()) {
                    c.AddToTextView(textView);
                }
            }
        }

        #endregion

        #region IScrollInfo implementation

        private bool canHorizontallyScroll;
        private bool canVerticallyScroll;
        private ScrollViewer scrollOwner;

        bool IScrollInfo.CanVerticallyScroll
        {
            get { return scrollInfo != null ? scrollInfo.CanVerticallyScroll : false; }
            set
            {
                canVerticallyScroll = value;
                if (scrollInfo != null) {
                    scrollInfo.CanVerticallyScroll = value;
                }
            }
        }

        bool IScrollInfo.CanHorizontallyScroll
        {
            get { return scrollInfo != null ? scrollInfo.CanHorizontallyScroll : false; }
            set
            {
                canHorizontallyScroll = value;
                if (scrollInfo != null) {
                    scrollInfo.CanHorizontallyScroll = value;
                }
            }
        }

        double IScrollInfo.ExtentWidth
        {
            get { return scrollInfo != null ? scrollInfo.ExtentWidth : 0; }
        }

        double IScrollInfo.ExtentHeight
        {
            get { return scrollInfo != null ? scrollInfo.ExtentHeight : 0; }
        }

        double IScrollInfo.ViewportWidth
        {
            get { return scrollInfo != null ? scrollInfo.ViewportWidth : 0; }
        }

        double IScrollInfo.ViewportHeight
        {
            get { return scrollInfo != null ? scrollInfo.ViewportHeight : 0; }
        }

        double IScrollInfo.HorizontalOffset
        {
            get { return scrollInfo != null ? scrollInfo.HorizontalOffset : 0; }
        }

        double IScrollInfo.VerticalOffset
        {
            get { return scrollInfo != null ? scrollInfo.VerticalOffset : 0; }
        }

        ScrollViewer IScrollInfo.ScrollOwner
        {
            get { return scrollInfo != null ? scrollInfo.ScrollOwner : null; }
            set
            {
                if (scrollInfo != null) {
                    scrollInfo.ScrollOwner = value;
                }
                else {
                    scrollOwner = value;
                }
            }
        }

        void IScrollInfo.LineUp()
        {
            if (scrollInfo != null) {
                scrollInfo.LineUp();
            }
        }

        void IScrollInfo.LineDown()
        {
            if (scrollInfo != null) {
                scrollInfo.LineDown();
            }
        }

        void IScrollInfo.LineLeft()
        {
            if (scrollInfo != null) {
                scrollInfo.LineLeft();
            }
        }

        void IScrollInfo.LineRight()
        {
            if (scrollInfo != null) {
                scrollInfo.LineRight();
            }
        }

        void IScrollInfo.PageUp()
        {
            if (scrollInfo != null) {
                scrollInfo.PageUp();
            }
        }

        void IScrollInfo.PageDown()
        {
            if (scrollInfo != null) {
                scrollInfo.PageDown();
            }
        }

        void IScrollInfo.PageLeft()
        {
            if (scrollInfo != null) {
                scrollInfo.PageLeft();
            }
        }

        void IScrollInfo.PageRight()
        {
            if (scrollInfo != null) {
                scrollInfo.PageRight();
            }
        }

        void IScrollInfo.MouseWheelUp()
        {
            if (scrollInfo != null) {
                scrollInfo.MouseWheelUp();
            }
        }

        void IScrollInfo.MouseWheelDown()
        {
            if (scrollInfo != null) {
                scrollInfo.MouseWheelDown();
            }
        }

        void IScrollInfo.MouseWheelLeft()
        {
            if (scrollInfo != null) {
                scrollInfo.MouseWheelLeft();
            }
        }

        void IScrollInfo.MouseWheelRight()
        {
            if (scrollInfo != null) {
                scrollInfo.MouseWheelRight();
            }
        }

        void IScrollInfo.SetHorizontalOffset(double offset)
        {
            if (scrollInfo != null) {
                scrollInfo.SetHorizontalOffset(offset);
            }
        }

        void IScrollInfo.SetVerticalOffset(double offset)
        {
            if (scrollInfo != null) {
                scrollInfo.SetVerticalOffset(offset);
            }
        }

        Rect IScrollInfo.MakeVisible(Visual visual, Rect rectangle)
        {
            if (scrollInfo != null) {
                return scrollInfo.MakeVisible(visual, rectangle);
            }
            return Rect.Empty;
        }

        private void ApplyScrollInfo()
        {
            if (scrollInfo != null) {
                scrollInfo.ScrollOwner = scrollOwner;
                scrollInfo.CanVerticallyScroll = canVerticallyScroll;
                scrollInfo.CanHorizontallyScroll = canHorizontallyScroll;
                scrollOwner = null;
            }
        }

        #endregion

        #region Focus Handling (Show/Hide Caret)

        /// <inheritdoc />
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
        }

        /// <inheritdoc />
        protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnGotKeyboardFocus(e);
            // First activate IME, then show caret
            ime.OnGotKeyboardFocus(e);
            caret.Show();
        }

        /// <inheritdoc />
        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);
            caret.Hide();
            ime.OnLostKeyboardFocus(e);
        }

        #endregion

        #region OnTextInput / RemoveSelectedText / ReplaceSelectionWithText

        /// <summary>
        ///     Occurs when the TextArea receives text input.
        ///     This is like the <see cref="UIElement.TextInput" /> event,
        ///     but occurs immediately before the TextArea handles the TextInput event.
        /// </summary>
        public event TextCompositionEventHandler TextEntering;

        /// <summary>
        ///     Occurs when the TextArea receives text input.
        ///     This is like the <see cref="UIElement.TextInput" /> event,
        ///     but occurs immediately after the TextArea handles the TextInput event.
        /// </summary>
        public event TextCompositionEventHandler TextEntered;

        /// <summary>
        ///     Raises the TextEntering event.
        /// </summary>
        protected virtual void OnTextEntering(TextCompositionEventArgs e)
        {
            if (TextEntering != null) {
                TextEntering(this, e);
            }
        }

        /// <summary>
        ///     Raises the TextEntered event.
        /// </summary>
        protected virtual void OnTextEntered(TextCompositionEventArgs e)
        {
            if (TextEntered != null) {
                TextEntered(this, e);
            }
        }

        /// <inheritdoc />
        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            //Debug.WriteLine("TextInput: Text='" + e.Text + "' SystemText='" + e.SystemText + "' ControlText='" + e.ControlText + "'");
            base.OnTextInput(e);
            if (!e.Handled && Document != null) {
                if (string.IsNullOrEmpty(e.Text) || e.Text == "\x1b" || e.Text == "\b") {
                    // ASCII 0x1b = ESC.
                    // WPF produces a TextInput event with that old ASCII control char
                    // when Escape is pressed. We'll just ignore it.

                    // A deadkey followed by backspace causes a textinput event for the BS character.

                    // Similarly, some shortcuts like Alt+Space produce an empty TextInput event.
                    // We have to ignore those (not handle them) to keep the shortcut working.
                    return;
                }
                PerformTextInput(e);
                e.Handled = true;
            }
        }

        /// <summary>
        ///     Performs text input.
        ///     This raises the <see cref="TextEntering" /> event, replaces the selection with the text,
        ///     and then raises the <see cref="TextEntered" /> event.
        /// </summary>
        public void PerformTextInput(string text)
        {
            var textComposition = new TextComposition(InputManager.Current, this, text);
            var e = new TextCompositionEventArgs(Keyboard.PrimaryDevice, textComposition);
            e.RoutedEvent = TextInputEvent;
            PerformTextInput(e);
        }

        /// <summary>
        ///     Performs text input.
        ///     This raises the <see cref="TextEntering" /> event, replaces the selection with the text,
        ///     and then raises the <see cref="TextEntered" /> event.
        /// </summary>
        public void PerformTextInput(TextCompositionEventArgs e)
        {
            if (e == null) {
                throw new ArgumentNullException("e");
            }
            if (Document == null) {
                throw ThrowUtil.NoDocumentAssigned();
            }
            OnTextEntering(e);
            if (!e.Handled) {
                if (e.Text == "\n" || e.Text == "\r" || e.Text == "\r\n") {
                    ReplaceSelectionWithNewLine();
                }
                else {
                    ReplaceSelectionWithText(e.Text);
                }
                OnTextEntered(e);
                caret.BringCaretToView();
            }
        }

        private void ReplaceSelectionWithNewLine()
        {
            string newLine = TextUtilities.GetNewLineFromDocument(Document, Caret.Line);
            using (Document.RunUpdate()) {
                ReplaceSelectionWithText(newLine);
                if (IndentationStrategy != null) {
                    DocumentLine line = Document.GetLineByNumber(Caret.Line);
                    ISegment[] deletable = GetDeletableSegments(line);
                    if (deletable.Length == 1 && deletable[0].Offset == line.Offset &&
                        deletable[0].Length == line.Length) {
                        // use indentation strategy only if the line is not read-only
                        IndentationStrategy.IndentLine(Document, line);
                    }
                }
            }
        }

        internal void RemoveSelectedText()
        {
            if (Document == null) {
                throw ThrowUtil.NoDocumentAssigned();
            }
            selection.ReplaceSelectionWithText(string.Empty);
#if DEBUG
            if (!selection.IsEmpty) {
                foreach (ISegment s in selection.Segments) {
                    Debug.Assert(ReadOnlySectionProvider.GetDeletableSegments(s).Count() == 0);
                }
            }
#endif
        }

        internal void ReplaceSelectionWithText(string newText)
        {
            if (newText == null) {
                throw new ArgumentNullException("newText");
            }
            if (Document == null) {
                throw ThrowUtil.NoDocumentAssigned();
            }
            selection.ReplaceSelectionWithText(newText);
        }

        internal ISegment[] GetDeletableSegments(ISegment segment)
        {
            IEnumerable<ISegment> deletableSegments = ReadOnlySectionProvider.GetDeletableSegments(segment);
            if (deletableSegments == null) {
                throw new InvalidOperationException("ReadOnlySectionProvider.GetDeletableSegments returned null");
            }
            ISegment[] array = deletableSegments.ToArray();
            int lastIndex = segment.Offset;
            for (int i = 0; i < array.Length; i++) {
                if (array[i].Offset < lastIndex) {
                    throw new InvalidOperationException(
                        "ReadOnlySectionProvider returned incorrect segments (outside of input segment / wrong order)");
                }
                lastIndex = array[i].EndOffset;
            }
            if (lastIndex > segment.EndOffset) {
                throw new InvalidOperationException(
                    "ReadOnlySectionProvider returned incorrect segments (outside of input segment / wrong order)");
            }
            return array;
        }

        #endregion

        #region IndentationStrategy property

        /// <summary>
        ///     IndentationStrategy property.
        /// </summary>
        public static readonly DependencyProperty IndentationStrategyProperty =
            DependencyProperty.Register("IndentationStrategy", typeof (IIndentationStrategy), typeof (TextArea),
                new FrameworkPropertyMetadata(new DefaultIndentationStrategy()));

        /// <summary>
        ///     Gets/Sets the indentation strategy used when inserting new lines.
        /// </summary>
        public IIndentationStrategy IndentationStrategy
        {
            get { return (IIndentationStrategy) GetValue(IndentationStrategyProperty); }
            set { SetValue(IndentationStrategyProperty, value); }
        }

        #endregion

        #region OnKeyDown/OnKeyUp

        /// <inheritdoc />
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            foreach (TextAreaStackedInputHandler h in stackedInputHandlers) {
                if (e.Handled) {
                    break;
                }
                h.OnPreviewKeyDown(e);
            }
        }

        /// <inheritdoc />
        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {
            base.OnPreviewKeyUp(e);
            foreach (TextAreaStackedInputHandler h in stackedInputHandlers) {
                if (e.Handled) {
                    break;
                }
                h.OnPreviewKeyUp(e);
            }
        }

        // Make life easier for text editor extensions that use a different cursor based on the pressed modifier keys.
        /// <inheritdoc />
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            TextView.InvalidateCursor();
        }

        /// <inheritdoc />
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            TextView.InvalidateCursor();
        }

        #endregion

        #region ITextEditorComponent Members

        /// <summary>
        ///     Gets the requested service.
        /// </summary>
        /// <returns>Returns the requested service instance, or null if the service cannot be found.</returns>
        public virtual object GetService(Type serviceType)
        {
            return textView.Services.GetService(serviceType);
        }

        #endregion

        /// <inheritdoc />
        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            // accept clicks even where the text area draws no background
            return new PointHitTestResult(this, hitTestParameters.HitPoint);
        }

        /// <inheritdoc />
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == SelectionBrushProperty
                || e.Property == SelectionBorderProperty
                || e.Property == SelectionForegroundProperty
                || e.Property == SelectionCornerRadiusProperty) {
                textView.Redraw();
            }
        }

        /// <summary>
        ///     Occurs when text inside the TextArea was copied.
        /// </summary>
        public event EventHandler<TextEventArgs> TextCopied;

        internal void OnTextCopied(TextEventArgs e)
        {
            if (TextCopied != null) {
                TextCopied(this, e);
            }
        }
    }

    /// <summary>
    ///     EventArgs with text.
    /// </summary>
    [Serializable]
    public class TextEventArgs : EventArgs
    {
        private readonly string text;

        /// <summary>
        ///     Creates a new TextEventArgs instance.
        /// </summary>
        public TextEventArgs(string text)
        {
            if (text == null) {
                throw new ArgumentNullException("text");
            }
            this.text = text;
        }

        /// <summary>
        ///     Gets the text.
        /// </summary>
        public string Text
        {
            get { return text; }
        }
    }
}