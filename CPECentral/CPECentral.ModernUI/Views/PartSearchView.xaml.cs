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
            DataContext = model;

            var db = new CPEUnitOfWork();
            foreach (var part in db.Parts.GetWhereDrawingNumberMatches("H5%"))
            {
                var latestVersion = db.PartVersions.GetLatestVersion(part);

                var photo = db.Photos.GetByPartVersion(latestVersion);

                var result = new PartSearchViewModel.SearchResult
                {
                    DrawingNumber = part.DrawingNumber,
                    Name = part.Name,
                    Version = latestVersion.VersionNumber,
                    PartId = part.Id,
                    ImageBytes = photo
                };

                model.SearchResults.Add(result);
            }        
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            const double columnRatio = 0.5;

            var remainingArea = SearchResultsListView.ActualWidth - SystemParameters.VerticalScrollBarWidth -
                             VersionColumn.Width - PhotoColumn.Width - 10;

            DrawingNumberColumn.Width = remainingArea*columnRatio;
            NameColumn.Width = remainingArea*columnRatio;
        }
    }
}
