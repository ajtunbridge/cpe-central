using CPECentral.Data.EF5;
using CPECentral.ModernUI.ViewModels;
using CPECentral.ModernUI.Views;

namespace CPECentral.ModernUI.Presenters
{
    public class PartSearchPresenter
    {
        private readonly PartSearchView _view;

        public PartSearchPresenter(PartSearchView view)
        {
            _view = view;
        }

        public void Search(string value)
        {
            var model = new PartSearchViewModel();
            var db = new CPEUnitOfWork();
            foreach (var part in db.Parts.GetWhereDrawingNumberMatches(value))
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

            _view.DisplayResults(model);
        }
    }
}