#region Using directives

using System;
using System.ComponentModel;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;

#endregion

namespace CPECentral.Presenters
{
    public sealed class PartLibraryViewPresenter
    {
        private readonly IPartLibraryView _libraryView;

        public PartLibraryViewPresenter(IPartLibraryView libraryView)
        {
            _libraryView = libraryView;

            _libraryView.ReloadData += LibraryViewReloadData;
        }

        private void LibraryViewReloadData(object sender, EventArgs e)
        {
            var getPartsWorker = new BackgroundWorker();
            getPartsWorker.DoWork += GetPartsWorker_DoWork;
            getPartsWorker.RunWorkerCompleted += GetPartsWorker_RunWorkerCompleted;
            getPartsWorker.RunWorkerAsync();
        }

        private void GetPartsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                HandleException(e.Result as Exception);
                _libraryView.DisplayLibrary(null);
                return;
            }

            var viewModel = (PartLibraryViewModel) e.Result;

            _libraryView.DisplayLibrary(viewModel);
        }

        private void GetPartsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var uow = new UnitOfWork();

                var customers = uow.Customers.GetAll();
                var parts = uow.Parts.GetAll();

                var viewModel = new PartLibraryViewModel {Customers = customers, Parts = parts};

                e.Result = viewModel;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void HandleException(Exception ex)
        {
            string message;

            if (ex is DataProviderException)
            {
                message = ex.Message;
            }
            else
            {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _libraryView.DialogService.ShowError(message);
        }
    }
}