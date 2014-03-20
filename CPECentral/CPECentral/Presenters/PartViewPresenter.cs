#region Using directives

using System;
using System.ComponentModel;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;

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

                using (var uow = new UnitOfWork()) {
                    var createdBy = uow.Employees.GetById(part.CreatedBy);
                    var modifiedBy = uow.Employees.GetById(part.ModifiedBy);

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