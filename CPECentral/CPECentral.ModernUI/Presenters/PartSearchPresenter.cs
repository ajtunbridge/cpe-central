using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPECentral.Data.EF5;
using CPECentral.ModernUI.ViewModels;
using CPECentral.ModernUI.Views;
using SearchAsyncResults = System.Collections.Generic.List<CPECentral.ModernUI.ViewModels.PartSearchViewModel.SearchResult>;

namespace CPECentral.ModernUI.Presenters
{
    public class PartSearchPresenter
    {
        private readonly PartSearchView _view;

        public PartSearchPresenter(PartSearchView view)
        {
            _view = view;
        }

        public async Task SearchAsync(string value)
        {
            var model = new PartSearchViewModel();

            var results1 = await DoSearchAsync(value, "DrawingNumber");
            var results2 = await DoSearchAsync(value, "Name");

            var combinedResults = results1.Union(results2);
            
            var distinctSortedResults = combinedResults.OrderBy(r => r.DrawingNumber);

            model.SearchResults.AddRange(distinctSortedResults);

            _view.DisplayResults(model);
        }

        private async Task<SearchAsyncResults> DoSearchAsync(string value, string field)
        {
            var searchResults = await Task<SearchAsyncResults>.Factory.StartNew(() =>
            {
                var results = new SearchAsyncResults();

                var db = new CPEUnitOfWork();

                IEnumerable<Part> matches = null;

                switch (field)
                {
                    case "DrawingNumber":
                        matches = db.Parts.GetWhereDrawingNumberMatches(value);
                        break;
                    case "Name":
                        matches = db.Parts.GetWhereNameMatches(value);
                        break;
                    case "WorksOrder":
                        break;
                    case "Quote":
                        break;
                }

                if (matches == null)
                {
                    return null;
                }

                foreach (var part in matches)
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

                    results.Add(result);
                }

                return results;
            });

            return searchResults;
        }
    }
}