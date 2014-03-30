#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Threading;
using ICSharpCode.AvalonEdit.Editing;

#endregion

namespace ICSharpCode.AvalonEdit.Search
{
    /// <summary>
    ///     Search commands for AvalonEdit.
    /// </summary>
    public static class SearchCommands
    {
        /// <summary>
        ///     Finds the next occurrence in the file.
        /// </summary>
        public static readonly RoutedCommand FindNext = new RoutedCommand(
            "FindNext", typeof (SearchPanel),
            new InputGestureCollection {new KeyGesture(Key.F3)}
            );

        /// <summary>
        ///     Finds the previous occurrence in the file.
        /// </summary>
        public static readonly RoutedCommand FindPrevious = new RoutedCommand(
            "FindPrevious", typeof (SearchPanel),
            new InputGestureCollection {new KeyGesture(Key.F3, ModifierKeys.Shift)}
            );

        /// <summary>
        ///     Closes the SearchPanel.
        /// </summary>
        public static readonly RoutedCommand CloseSearchPanel = new RoutedCommand(
            "CloseSearchPanel", typeof (SearchPanel),
            new InputGestureCollection {new KeyGesture(Key.Escape)}
            );
    }

    /// <summary>
    ///     TextAreaInputHandler that registers all search-related commands.
    /// </summary>
    public class SearchInputHandler : TextAreaInputHandler
    {
        private readonly SearchPanel panel;

        /// <summary>
        ///     Creates a new SearchInputHandler and registers the search-related commands.
        /// </summary>
        public SearchInputHandler(TextArea textArea)
            : base(textArea)
        {
            RegisterCommands(CommandBindings);
            panel = new SearchPanel();
            panel.Attach(TextArea);
        }

        private void RegisterCommands(ICollection<CommandBinding> commandBindings)
        {
            commandBindings.Add(new CommandBinding(ApplicationCommands.Find, ExecuteFind));
            commandBindings.Add(new CommandBinding(SearchCommands.FindNext, ExecuteFindNext));
            commandBindings.Add(new CommandBinding(SearchCommands.FindPrevious, ExecuteFindPrevious));
            commandBindings.Add(new CommandBinding(SearchCommands.CloseSearchPanel, ExecuteCloseSearchPanel));
        }

        private void ExecuteFind(object sender, ExecutedRoutedEventArgs e)
        {
            panel.Open();
            if (!(TextArea.Selection.IsEmpty || TextArea.Selection.IsMultiline)) {
                panel.SearchPattern = TextArea.Selection.GetText();
            }
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Input, (Action) delegate { panel.Reactivate(); });
        }

        private void ExecuteFindNext(object sender, ExecutedRoutedEventArgs e)
        {
            panel.FindNext();
        }

        private void ExecuteFindPrevious(object sender, ExecutedRoutedEventArgs e)
        {
            panel.FindPrevious();
        }

        private void ExecuteCloseSearchPanel(object sender, ExecutedRoutedEventArgs e)
        {
            panel.Close();
        }

        /// <summary>
        ///     Fired when SearchOptions are modified inside the SearchPanel.
        /// </summary>
        public event EventHandler<SearchOptionsChangedEventArgs> SearchOptionsChanged
        {
            add { panel.SearchOptionsChanged += value; }
            remove { panel.SearchOptionsChanged -= value; }
        }
    }
}