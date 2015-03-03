#region Using directives

using System;
using System.ComponentModel;
using System.Linq;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class PartViewPresenter
    {
        private readonly IPartView _partView;

        public PartViewPresenter(IPartView partView)
        {
            _partView = partView;

            _partView.ReloadData += _partView_ReloadData;
            _partView.SelectedVersionChanged += _partView_SelectedVersionChanged;
        }

        void _partView_SelectedVersionChanged(object sender, CustomEventArgs.PartVersionEventArgs e)
        {
            try {
                using (var cpe = new CPEUnitOfWork()) {
                    using (BusyCursor.Show()) {
                        var allVersions = cpe.PartVersions.GetByPart(e.PartVersion.PartId);
                        var latestVersion = allVersions.OrderByDescending(pv => pv.VersionNumber).First();
                        if (e.PartVersion != latestVersion) {
                            _partView.ShowVersionWarning();
                        }
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void _partView_ReloadData(object sender, EventArgs e)
        {
            var getDataWorker = new BackgroundWorker();
            getDataWorker.DoWork += getDataWorker_DoWork;
            getDataWorker.RunWorkerCompleted += getDataWorker_RunWorkerCompleted;
            getDataWorker.RunWorkerAsync(_partView.Part);
        }

        private void getDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                return;
            }

            var model = e.Result as PartViewModel;

            _partView.DisplayModel(model);
        }

        private void getDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                var part = (Part) e.Argument;

                using (var cpe = new CPEUnitOfWork()) {
                    Employee createdBy = cpe.Employees.GetById(part.CreatedBy);
                    Employee modifiedBy = cpe.Employees.GetById(part.ModifiedBy);

                    var model = new PartViewModel();
                    model.CreatedBy = createdBy.ToString();
                    model.ModifiedBy = modifiedBy.ToString();

                    e.Result = model;
                }
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private void HandleException(Exception ex)
        {
            string message;

            if (ex is DataProviderException) {
                message = ex.Message;
            }
            else {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _partView.DialogService.ShowError(message);
        }
    }
}