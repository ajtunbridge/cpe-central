#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;

#endregion

namespace CPECentral.Presenters
{
    public class PartLibraryView3Presenter
    {
        private readonly IPartLibraryView3 _view;

        public PartLibraryView3Presenter(IPartLibraryView3 view)
        {
            _view = view;

            _view.PerformSearch += _view_PerformSearch;
        }

        private void _view_PerformSearch(object sender, StringEventArgs e)
        {
            var searchWorker = new BackgroundWorker();

            searchWorker.DoWork += (x, y) => {
                try {
                    using (var cpe = new CPEUnitOfWork()) {
                        IOrderedEnumerable<Part> parts = cpe.Parts.GetWhereDrawingNumberMatches(e.Value)
                            .OrderBy(p => p.DrawingNumber);

                        var results = new List<PartLibraryView3Model>();

                        var docService = new DocumentService();

                        foreach (Part part in parts) {
                            PartVersion latestVersion = cpe.PartVersions.GetLatestVersion(part);

                            Document drawingDocument = latestVersion.DrawingDocumentId.HasValue
                                ? cpe.Documents.GetById(latestVersion.DrawingDocumentId.Value)
                                : null;

                            var result = new PartLibraryView3Model {
                                DrawingNumber = part.DrawingNumber,
                                CurrentVersion = latestVersion.VersionNumber,
                                Name = part.Name,
                                PathToDrawingFile =
                                    drawingDocument == null ? null : docService.GetPathToDocument(drawingDocument, cpe),
                                Part = part
                            };

                            results.Add(result);
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
                var results = y.Result as IEnumerable<PartLibraryView3Model>;
                _view.DisplayResults(results);
            };

            searchWorker.RunWorkerAsync();
        }
    }
}