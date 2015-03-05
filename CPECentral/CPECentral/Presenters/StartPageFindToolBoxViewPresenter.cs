#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;

#endregion

namespace CPECentral.Presenters
{
    public class StartPageFindToolBoxViewPresenter
    {
        private readonly IStartPageFindToolBoxView _view;

        public StartPageFindToolBoxViewPresenter(IStartPageFindToolBoxView view)
        {
            _view = view;

            _view.PerformSearch += _view_PerformSearch;
        }

        private void _view_PerformSearch(object sender, StringEventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(e.Value);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                var ex = e.Result as Exception;
                string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                _view.DialogService.ShowError(msg);
                return;
            }

            var model = e.Result as StartPageFindToolBoxViewModel;

            _view.DisplayResults(model);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var drawingNumber = (string) e.Argument;

            var model = new StartPageFindToolBoxViewModel();
            model.Results = new List<StartPageFindToolBoxViewModelItem>();

            try {
                using (var cpe = new CPEUnitOfWork()) {
                    IEnumerable<Part> parts = cpe.Parts.GetWhereDrawingNumberContains(drawingNumber);

                    foreach (Part part in parts) {
                        model.Results.Add(new StartPageFindToolBoxViewModelItem {
                            DrawingNumber = part.DrawingNumber,
                            Location = part.ToolingLocation
                        });
                    }
                }

                e.Result = model;
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }
    }
}