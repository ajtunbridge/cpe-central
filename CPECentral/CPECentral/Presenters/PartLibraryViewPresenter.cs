#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Properties;
using CPECentral.ViewModels;
using CPECentral.Views;
using Tricorn;
using Part = CPECentral.Data.EF5.Part;

#endregion

namespace CPECentral.Presenters
{
    public class PartLibraryViewPresenter
    {
        private readonly IPartLibraryView _view;

        public PartLibraryViewPresenter(IPartLibraryView view)
        {
            _view = view;

            _view.PerformSearch += View_PerformSearch;
        }

        private void View_PerformSearch(object sender, StringEventArgs e)
        {
            var searchWorker = new BackgroundWorker();

            var wildcards = new[] {"%", "_"};

            bool isHeavyQuery = e.Value.All(c => wildcards.Any(wc => Convert.ToChar(wc) == c));

            if (isHeavyQuery)
            {
                _view.DisplayResults(null);
                _view.DialogService.Notify("This search would take too long to run so it has been aborted!");
                return;
            }

            searchWorker.DoWork += (x, y) => {
                try {
                    using (var cpe = new CPEUnitOfWork()) {
                        var results = new List<PartLibraryViewModel>();

                        IOrderedEnumerable<Part> matchedByDrawingNumber = cpe.Parts.GetWhereDrawingNumberMatches(e.Value)
                            .OrderBy(p => p.DrawingNumber);

                        var matchedByName = cpe.Parts.GetWhereNameMatches(e.Value);

                        results.AddRange(GenerateModelFromResults("Matched by drawing number", matchedByDrawingNumber,
                            cpe));
                        results.AddRange(GenerateModelFromResults("Matched by part name", matchedByName, cpe));

                        using (var tricorn = new TricornDataProvider()) {
                            var worksOrder = tricorn.GetWorksOrdersByUserReference(e.Value).FirstOrDefault();
                            if (worksOrder != null) {
                                var matchedByWorksOrderNumber =
                                    cpe.Parts.GetWhereDrawingNumberMatches(worksOrder.Drawing_Number);
                                results.AddRange(GenerateModelFromResults("Matched by works order number",
                                    matchedByWorksOrderNumber, cpe));
                            }
                        }

                        y.Result = results;
                    }
                }
                catch (Exception ex) {
                    y.Result = ex;
                }
            };

            searchWorker.RunWorkerCompleted += (x, y) => {
                if (y.Result is Exception) {
                    var ex = y.Result as Exception;
                    string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                    _view.DialogService.ShowError(msg);
                    return;
                }
                var results = y.Result as IEnumerable<PartLibraryViewModel>;
                _view.DisplayResults(results);
            };

            searchWorker.RunWorkerAsync();
        }

        private IEnumerable<PartLibraryViewModel> GenerateModelFromResults(string group, IEnumerable<Part> parts,
            CPEUnitOfWork cpe)
        {
            var results = new List<PartLibraryViewModel>();

            var docService = new DocumentService();

            foreach (Part part in parts) {
                PartVersion latestVersion = cpe.PartVersions.GetLatestVersion(part);

                var cachedPhoto = Session.PartPartPhotoCache[part.Id];

                if (cachedPhoto == null) {
                    var photoBytes = cpe.Photos.GetByPartVersion(latestVersion);
                    if (photoBytes != null) {
                        using (var ms = new MemoryStream(photoBytes)) {
                            Session.PartPartPhotoCache.CreateOrUpdate(part.Id, Image.FromStream(ms));
                        }
                    }
                }

                Document drawingDocument = latestVersion.DrawingDocumentId.HasValue
                    ? cpe.Documents.GetById(latestVersion.DrawingDocumentId.Value)
                    : null;

                var result = new PartLibraryViewModel {
                    Group = group,
                    DrawingNumber = part.DrawingNumber,
                    CurrentVersion = latestVersion.VersionNumber,
                    Name = part.Name,
                    PathToDrawingFile =
                        drawingDocument == null ? null : docService.GetPathToDocument(drawingDocument, cpe),
                    Part = part
                };

                results.Add(result);
            }

            return results;
        }
    }
}