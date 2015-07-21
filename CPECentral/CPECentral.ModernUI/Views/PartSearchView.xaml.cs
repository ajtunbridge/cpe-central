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
using CPECentral.ModernUI.ViewModels;

namespace CPECentral.ModernUI.Views
{
    /// <summary>
    /// Interaction logic for PartSearchView.xaml
    /// </summary>
    public partial class PartSearchView : UserControl
    {
        public PartSearchView()
        {
            InitializeComponent();

            var model = new PartSearchViewModel();
            model.SearchResults.Add(new PartSearchViewModel.SearchResult
            {
                DrawingNumber = "H17070A",
                Name = "Inner Tube",
                Version = "07",
                ImageBytes = null,
                PartId = 5
            });
            SearchResultsListView.ItemsSource = model.SearchResults;
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            const double columnRatio = 0.5;

            var remainingArea = SearchResultsListView.ActualWidth - SystemParameters.VerticalScrollBarWidth -
                             VersionColumn.Width - PhotoColumn.Width - 5;

            DrawingNumberColumn.Width = remainingArea*columnRatio;
            NameColumn.Width = remainingArea*columnRatio;
        }
    }
}
