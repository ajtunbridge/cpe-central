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

        public PartSearchView()
        {
            InitializeComponent();

            _presenter = new PartSearchPresenter(this);
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            const double columnRatio = 0.5;

            var remainingArea = SearchResultsListView.ActualWidth - SystemParameters.VerticalScrollBarWidth -
                             VersionColumn.Width - PhotoColumn.Width;

            DrawingNumberColumn.Width = remainingArea*columnRatio;
            NameColumn.Width = remainingArea*columnRatio;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _presenter.Search(SearchValueTextBox.Text);
        }

        public void DisplayResults(PartSearchViewModel model)
        {
            DataContext = model;
        }
    }
}
