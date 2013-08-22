#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.ViewModels;
using CPECentral.Views;

#endregion

namespace CPECentral.Presenters
{

    public sealed class PartLibraryViewPresenter
    {
        private readonly IPartLibraryView _libraryView;
        private BackgroundWorker _searchWorker;

        public PartLibraryViewPresenter(IPartLibraryView libraryView)
        {
            _libraryView = libraryView;

            _libraryView.ReloadData += LibraryViewReloadData;
            _libraryView.DeletePart += _libraryView_DeletePart;
            _libraryView.Search += _libraryView_Search;
        }

        void _libraryView_DeletePart(object sender, PartEventArgs e)
        {
            const string warningMessage = "WARNING!\n\nThis will delete all information pertaining to this part!\n\nDo you want to cancel?";

            if (_libraryView.DialogService.AskQuestion(warningMessage))
            {
                return;
            }

            const string confirmationQuestion = "WARNING!\n\nAre you sure you want to proceed?";

            if (!_libraryView.DialogService.AskQuestion(confirmationQuestion))
            {
                return;
            }


        }

        void _libraryView_Search(object sender, PartSearchEventArgs e)
        {
            _searchWorker = new BackgroundWorker();
            _searchWorker.DoWork += _searchWorker_DoWork;
            _searchWorker.RunWorkerCompleted += _searchWorker_RunWorkerCompleted;
            _searchWorker.RunWorkerAsync(e.SearchArgs);
        }

        void _searchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (PartSearchArgs)e.Argument;

            try
            {
                using (var uow = new UnitOfWork())
                {
                    IEnumerable<Part> matchingParts;

                    switch (args.Field)
                    {
                        case SearchField.DrawingNumber:
                            matchingParts = uow.Parts.GetWhereDrawingNumberContains(args.Value);
                            break;
                        case SearchField.Name:
                            matchingParts = uow.Parts.GetWhereNameContains(args.Value);
                            break;
                        default:
                            matchingParts = uow.Parts.GetWhereDrawingNumberContains(args.Value);
                            break;
                    }

                    var customers = matchingParts.Select(part => part.Customer).Distinct().ToList();

                    var model = new PartLibraryViewModel();
                    model.Customers = customers;
                    model.Parts = matchingParts;

                    e.Result = model;
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void _searchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {        
            if (e.Result is Exception)
            {
                HandleException(e.Result as Exception);
                _libraryView.RefreshLibrary();
                return;
            }

            var viewModel = (PartLibraryViewModel)e.Result;

            _libraryView.DisplaySearchResults(viewModel);
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
                _libraryView.RefreshLibrary();
                return;
            }

            var viewModel = (PartLibraryViewModel) e.Result;

            _libraryView.DisplayLibrary(viewModel);
        }

        private void GetPartsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var customers = uow.Customers.GetAll();
                    var parts = uow.Parts.GetAll();

                    var viewModel = new PartLibraryViewModel {Customers = customers, Parts = parts};

                    e.Result = viewModel;
                }
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