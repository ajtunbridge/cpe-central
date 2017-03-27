using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CPECentral.Data.EF5;
using CPECentral.ModernUI.Presenters;
using CPECentral.ModernUI.ViewModels;

namespace CPECentral.ModernUI.Views
{
    /// <summary>
    /// Interaction logic for PartSearchView.xaml
    /// </summary>
    public partial class PartSearchView : UserControl
    {
        private readonly PartSearchPresenter _presenter;

        public event EventHandler ViewPart;

        public PartSearchView()
        {
            InitializeComponent();

            _presenter = new PartSearchPresenter(this);
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            const double columnRatio = 0.5;

            var remainingArea = SearchResultsListView.ActualWidth - SystemParameters.VerticalScrollBarWidth -
                             VersionColumn.Width - PhotoColumn.Width - 10;

            DrawingNumberColumn.Width = remainingArea*columnRatio;
            NameColumn.Width = remainingArea*columnRatio;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.Content = "Searching...";
            SearchButton.IsEnabled = false;

            await _presenter.SearchAsync(SearchValueTextBox.Text);

            SearchButton.Content = "Search";
            SearchButton.IsEnabled = true;
        }

        public void DisplayResults(PartSearchViewModel model)
        {
            DataContext = model;
        }

        private void SearchValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // TODO: find out if it's ok to use null as event arg
                Button_Click(sender, null);
            }
        }

        private void SearchResultsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = SearchResultsListView.SelectedItem as PartSearchViewModel.SearchResult;

            // TODO: preview drawing file in group box when search result selected
        }

        private void SearchResultsListView_ItemActivated(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            var searchResult = item.Content as PartSearchViewModel.SearchResult;
            
            var viewModel = new PartViewModel();
            viewModel.HeaderText = $"{searchResult.DrawingNumber} Version {searchResult.Version}: {searchResult.Name}";
            viewModel.PartId = searchResult.PartId;

        }

        protected virtual void OnViewPart()
        {
            ViewPart?.Invoke(this, System.EventArgs.Empty);
        }
    }
}
