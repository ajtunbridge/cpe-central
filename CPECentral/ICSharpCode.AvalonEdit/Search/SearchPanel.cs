﻿#region Using directives

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Rendering;

#endregion

namespace ICSharpCode.AvalonEdit.Search
{
    /// <summary>
    ///     Provides search functionality for AvalonEdit. It is displayed in the top-right corner of the TextArea.
    /// </summary>
    public class SearchPanel : Control
    {
        private readonly ToolTip messageView = new ToolTip {Placement = PlacementMode.Bottom, StaysOpen = false};
        private SearchPanelAdorner adorner;
        private TextDocument currentDocument;
        private SearchResultBackgroundRenderer renderer;
        private TextBox searchTextBox;

        private ISearchStrategy strategy;
        private TextArea textArea;

        #region DependencyProperties

        /// <summary>
        ///     Dependency property for <see cref="UseRegex" />.
        /// </summary>
        public static readonly DependencyProperty UseRegexProperty =
            DependencyProperty.Register("UseRegex", typeof (bool), typeof (SearchPanel),
                new FrameworkPropertyMetadata(false, SearchPatternChangedCallback));

        /// <summary>
        ///     Dependency property for <see cref="MatchCase" />.
        /// </summary>
        public static readonly DependencyProperty MatchCaseProperty =
            DependencyProperty.Register("MatchCase", typeof (bool), typeof (SearchPanel),
                new FrameworkPropertyMetadata(false, SearchPatternChangedCallback));

        /// <summary>
        ///     Dependency property for <see cref="WholeWords" />.
        /// </summary>
        public static readonly DependencyProperty WholeWordsProperty =
            DependencyProperty.Register("WholeWords", typeof (bool), typeof (SearchPanel),
                new FrameworkPropertyMetadata(false, SearchPatternChangedCallback));

        /// <summary>
        ///     Dependency property for <see cref="SearchPattern" />.
        /// </summary>
        public static readonly DependencyProperty SearchPatternProperty =
            DependencyProperty.Register("SearchPattern", typeof (string), typeof (SearchPanel),
                new FrameworkPropertyMetadata("", SearchPatternChangedCallback));

        /// <summary>
        ///     Dependency property for <see cref="MarkerBrush" />.
        /// </summary>
        public static readonly DependencyProperty MarkerBrushProperty =
            DependencyProperty.Register("MarkerBrush", typeof (Brush), typeof (SearchPanel),
                new FrameworkPropertyMetadata(Brushes.LightGreen, MarkerBrushChangedCallback));

        /// <summary>
        ///     Dependency property for <see cref="Localization" />.
        /// </summary>
        public static readonly DependencyProperty LocalizationProperty =
            DependencyProperty.Register("Localization", typeof (Localization), typeof (SearchPanel),
                new FrameworkPropertyMetadata(new Localization()));

        /// <summary>
        ///     Gets/sets whether the search pattern should be interpreted as regular expression.
        /// </summary>
        public bool UseRegex
        {
            get { return (bool) GetValue(UseRegexProperty); }
            set { SetValue(UseRegexProperty, value); }
        }

        /// <summary>
        ///     Gets/sets whether the search pattern should be interpreted case-sensitive.
        /// </summary>
        public bool MatchCase
        {
            get { return (bool) GetValue(MatchCaseProperty); }
            set { SetValue(MatchCaseProperty, value); }
        }

        /// <summary>
        ///     Gets/sets whether the search pattern should only match whole words.
        /// </summary>
        public bool WholeWords
        {
            get { return (bool) GetValue(WholeWordsProperty); }
            set { SetValue(WholeWordsProperty, value); }
        }

        /// <summary>
        ///     Gets/sets the search pattern.
        /// </summary>
        public string SearchPattern
        {
            get { return (string) GetValue(SearchPatternProperty); }
            set { SetValue(SearchPatternProperty, value); }
        }

        /// <summary>
        ///     Gets/sets the Brush used for marking search results in the TextView.
        /// </summary>
        public Brush MarkerBrush
        {
            get { return (Brush) GetValue(MarkerBrushProperty); }
            set { SetValue(MarkerBrushProperty, value); }
        }

        /// <summary>
        ///     Gets/sets the localization for the SearchPanel.
        /// </summary>
        public Localization Localization
        {
            get { return (Localization) GetValue(LocalizationProperty); }
            set { SetValue(LocalizationProperty, value); }
        }

        #endregion

        static SearchPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (SearchPanel),
                new FrameworkPropertyMetadata(typeof (SearchPanel)));
        }

        /// <summary>
        ///     Gets whether the Panel is already closed.
        /// </summary>
        public bool IsClosed { get; private set; }

        private static void MarkerBrushChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var panel = d as SearchPanel;
            if (panel != null) {
                panel.renderer.MarkerBrush = (Brush) e.NewValue;
            }
        }

        private static void SearchPatternChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var panel = d as SearchPanel;
            if (panel != null) {
                panel.ValidateSearchText();
                panel.UpdateSearch();
            }
        }

        private void UpdateSearch()
        {
            // only reset as long as there are results
            // if no results are found, the "no matches found" message should not flicker.
            // if results are found by the next run, the message will be hidden inside DoSearch ...
            if (renderer.CurrentResults.Any()) {
                messageView.IsOpen = false;
            }
            strategy = SearchStrategyFactory.Create(SearchPattern ?? "", !MatchCase, WholeWords,
                UseRegex ? SearchMode.RegEx : SearchMode.Normal);
            OnSearchOptionsChanged(new SearchOptionsChangedEventArgs(SearchPattern, MatchCase, UseRegex, WholeWords));
            DoSearch(true);
        }

        /// <summary>
        ///     Attaches this SearchPanel to a TextArea instance.
        /// </summary>
        public void Attach(TextArea textArea)
        {
            if (textArea == null) {
                throw new ArgumentNullException("textArea");
            }
            this.textArea = textArea;
            adorner = new SearchPanelAdorner(textArea, this);
            DataContext = this;

            renderer = new SearchResultBackgroundRenderer();
            currentDocument = textArea.Document;
            if (currentDocument != null) {
                currentDocument.TextChanged += textArea_Document_TextChanged;
            }
            textArea.DocumentChanged += textArea_DocumentChanged;
            KeyDown += SearchLayerKeyDown;

            CommandBindings.Add(new CommandBinding(SearchCommands.FindNext, (sender, e) => FindNext()));
            CommandBindings.Add(new CommandBinding(SearchCommands.FindPrevious, (sender, e) => FindPrevious()));
            CommandBindings.Add(new CommandBinding(SearchCommands.CloseSearchPanel, (sender, e) => Close()));
            IsClosed = true;
        }

        private void textArea_DocumentChanged(object sender, EventArgs e)
        {
            if (currentDocument != null) {
                currentDocument.TextChanged -= textArea_Document_TextChanged;
            }
            currentDocument = textArea.Document;
            if (currentDocument != null) {
                currentDocument.TextChanged += textArea_Document_TextChanged;
                DoSearch(false);
            }
        }

        private void textArea_Document_TextChanged(object sender, EventArgs e)
        {
            DoSearch(false);
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            searchTextBox = Template.FindName("PART_searchTextBox", this) as TextBox;
        }

        private void ValidateSearchText()
        {
            if (searchTextBox == null) {
                return;
            }
            BindingExpression be = searchTextBox.GetBindingExpression(TextBox.TextProperty);
            try {
                Validation.ClearInvalid(be);
                UpdateSearch();
            }
            catch (SearchPatternException ex) {
                var ve = new ValidationError(be.ParentBinding.ValidationRules[0], be, ex.Message, ex);
                Validation.MarkInvalid(be, ve);
            }
        }

        /// <summary>
        ///     Reactivates the SearchPanel by setting the focus on the search box and selecting all text.
        /// </summary>
        public void Reactivate()
        {
            if (searchTextBox == null) {
                return;
            }
            searchTextBox.Focus();
            searchTextBox.SelectAll();
        }

        /// <summary>
        ///     Moves to the next occurrence in the file.
        /// </summary>
        public void FindNext()
        {
            SearchResult result = renderer.CurrentResults.FindFirstSegmentWithStartAfter(textArea.Caret.Offset + 1);
            if (result == null) {
                result = renderer.CurrentResults.FirstSegment;
            }
            if (result != null) {
                SelectResult(result);
            }
        }

        /// <summary>
        ///     Moves to the previous occurrence in the file.
        /// </summary>
        public void FindPrevious()
        {
            SearchResult result = renderer.CurrentResults.FindFirstSegmentWithStartAfter(textArea.Caret.Offset);
            if (result != null) {
                result = renderer.CurrentResults.GetPreviousSegment(result);
            }
            if (result == null) {
                result = renderer.CurrentResults.LastSegment;
            }
            if (result != null) {
                SelectResult(result);
            }
        }

        private void DoSearch(bool changeSelection)
        {
            if (IsClosed) {
                return;
            }
            renderer.CurrentResults.Clear();

            if (!string.IsNullOrEmpty(SearchPattern)) {
                int offset = textArea.Caret.Offset;
                if (changeSelection) {
                    textArea.ClearSelection();
                }
                // We cast from ISearchResult to SearchResult; this is safe because we always use the built-in strategy
                foreach (SearchResult result in strategy.FindAll(textArea.Document, 0, textArea.Document.TextLength)) {
                    if (changeSelection && result.StartOffset >= offset) {
                        SelectResult(result);
                        changeSelection = false;
                    }
                    renderer.CurrentResults.Add(result);
                }
                if (!renderer.CurrentResults.Any()) {
                    messageView.IsOpen = true;
                    messageView.Content = Localization.NoMatchesFoundText;
                    messageView.PlacementTarget = searchTextBox;
                }
                else {
                    messageView.IsOpen = false;
                }
            }
            textArea.TextView.InvalidateLayer(KnownLayer.Selection);
        }

        private void SelectResult(SearchResult result)
        {
            textArea.Caret.Offset = result.StartOffset;
            textArea.Selection = Selection.Create(textArea, result.StartOffset, result.EndOffset);
            textArea.Caret.BringCaretToView();
            // show caret even if the editor does not have the Keyboard Focus
            textArea.Caret.Show();
        }

        private void SearchLayerKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key) {
                case Key.Enter:
                    e.Handled = true;
                    messageView.IsOpen = false;
                    if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) {
                        FindPrevious();
                    }
                    else {
                        FindNext();
                    }
                    if (searchTextBox != null) {
                        ValidationError error = Validation.GetErrors(searchTextBox).FirstOrDefault();
                        if (error != null) {
                            messageView.Content = Localization.ErrorText + " " + error.ErrorContent;
                            messageView.PlacementTarget = searchTextBox;
                            messageView.IsOpen = true;
                        }
                    }
                    break;
                case Key.Escape:
                    e.Handled = true;
                    Close();
                    break;
            }
        }

        /// <summary>
        ///     Closes the SearchPanel.
        /// </summary>
        public void Close()
        {
            bool hasFocus = IsKeyboardFocusWithin;

            AdornerLayer layer = AdornerLayer.GetAdornerLayer(textArea);
            if (layer != null) {
                layer.Remove(adorner);
            }
            messageView.IsOpen = false;
            textArea.TextView.BackgroundRenderers.Remove(renderer);
            if (hasFocus) {
                textArea.Focus();
            }
            IsClosed = true;

            // Clear existing search results so that the segments don't have to be maintained
            renderer.CurrentResults.Clear();
        }

        /// <summary>
        ///     Closes the SearchPanel and removes it.
        /// </summary>
        public void CloseAndRemove()
        {
            Close();
            textArea.DocumentChanged -= textArea_DocumentChanged;
            if (currentDocument != null) {
                currentDocument.TextChanged -= textArea_Document_TextChanged;
            }
        }

        /// <summary>
        ///     Opens the an existing search panel.
        /// </summary>
        public void Open()
        {
            if (!IsClosed) {
                return;
            }
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(textArea);
            if (layer != null) {
                layer.Add(adorner);
            }
            textArea.TextView.BackgroundRenderers.Add(renderer);
            IsClosed = false;
            DoSearch(false);
        }

        /// <summary>
        ///     Fired when SearchOptions are changed inside the SearchPanel.
        /// </summary>
        public event EventHandler<SearchOptionsChangedEventArgs> SearchOptionsChanged;

        /// <summary>
        ///     Raises the <see cref="SearchPanel.SearchOptionsChanged" /> event.
        /// </summary>
        protected virtual void OnSearchOptionsChanged(SearchOptionsChangedEventArgs e)
        {
            if (SearchOptionsChanged != null) {
                SearchOptionsChanged(this, e);
            }
        }
    }

    /// <summary>
    ///     EventArgs for <see cref="SearchPanel.SearchOptionsChanged" /> event.
    /// </summary>
    public class SearchOptionsChangedEventArgs : EventArgs
    {
        /// <summary>
        ///     Creates a new SearchOptionsChangedEventArgs instance.
        /// </summary>
        public SearchOptionsChangedEventArgs(string searchPattern, bool matchCase, bool useRegex, bool wholeWords)
        {
            SearchPattern = searchPattern;
            MatchCase = matchCase;
            UseRegex = useRegex;
            WholeWords = wholeWords;
        }

        /// <summary>
        ///     Gets the search pattern.
        /// </summary>
        public string SearchPattern { get; private set; }

        /// <summary>
        ///     Gets whether the search pattern should be interpreted case-sensitive.
        /// </summary>
        public bool MatchCase { get; private set; }

        /// <summary>
        ///     Gets whether the search pattern should be interpreted as regular expression.
        /// </summary>
        public bool UseRegex { get; private set; }

        /// <summary>
        ///     Gets whether the search pattern should only match whole words.
        /// </summary>
        public bool WholeWords { get; private set; }
    }

    internal class SearchPanelAdorner : Adorner
    {
        private readonly SearchPanel panel;

        public SearchPanelAdorner(TextArea textArea, SearchPanel panel)
            : base(textArea)
        {
            this.panel = panel;
            AddVisualChild(panel);
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index != 0) {
                throw new ArgumentOutOfRangeException();
            }
            return panel;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            panel.Arrange(new Rect(new Point(0, 0), finalSize));
            return new Size(panel.ActualWidth, panel.ActualHeight);
        }
    }
}