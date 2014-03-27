#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;
using Tricorn;
using Part = CPECentral.Data.EF5.Part;

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
            _libraryView.PartSelected += _libraryView_PartSelected;
            _libraryView.Search += _libraryView_Search;
        }

        private void _libraryView_PartSelected(object sender, PartEventArgs e)
        {
            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        var emp = cpe.Employees.GetById(Session.CurrentEmployee.Id);
                        emp.LastViewedPartId = e.Part.Id;
                        cpe.Employees.Update(emp);
                        cpe.Commit();
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void _libraryView_DeletePart(object sender, PartEventArgs e)
        {
            if (e.Part == null) {
                _libraryView.DialogService.ShowError("No part selected!");
                return;
            }

            if (!AppSecurity.Check(AppPermission.ManageParts, true)) {
                return;
            }

            const string warningMessage =
                "WARNING!\n\nThis will delete all information pertaining to this part!\n\nDo you want to cancel?";

            if (_libraryView.DialogService.AskQuestion(warningMessage)) {
                return;
            }

            const string confirmationQuestion = "WARNING!\n\nAre you sure you want to proceed?";

            if (!_libraryView.DialogService.AskQuestion(confirmationQuestion)) {
                return;
            }

            using (var cpe = new CPEUnitOfWork()) {
                using (BusyCursor.Show()) {
                    var documents = new List<Document>();

                    var part = _libraryView.SelectedPart;

                    documents.AddRange(cpe.Documents.GetByPart(part));

                    var versions = cpe.PartVersions.GetByPart(part).ToList();

                    var methods = new List<Method>();
                    foreach (var version in versions) {
                        methods.AddRange(cpe.Methods.GetByPartVersion(version));
                        documents.AddRange(cpe.Documents.GetByPartVersion(version));
                    }

                    var operations = new List<Operation>();
                    foreach (var method in methods) {
                        operations.AddRange(cpe.Operations.GetByMethod(method));
                    }

                    foreach (var operation in operations) {
                        documents.AddRange(cpe.Documents.GetByOperation(operation));
                    }

                    Session.DocumentService.DeleteDocuments(documents);

                    operations.ForEach(op => cpe.Operations.Delete(op));
                    methods.ForEach(m => cpe.Methods.Delete(m));
                    versions.ForEach(v => cpe.PartVersions.Delete(v));
                    cpe.Parts.Delete(part);

                    cpe.Commit();

                    LibraryViewReloadData(sender, e);
                }
            }
        }

        private void _libraryView_Search(object sender, PartSearchEventArgs e)
        {
            _searchWorker = new BackgroundWorker();
            _searchWorker.DoWork += _searchWorker_DoWork;
            _searchWorker.RunWorkerCompleted += _searchWorker_RunWorkerCompleted;
            _searchWorker.RunWorkerAsync(e.SearchArgs);
        }

        private void _searchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (PartSearchArgs) e.Argument;

            try {
                using (var cpe = new CPEUnitOfWork()) {
                    IEnumerable<Part> matchingParts;

                    switch (args.Field) {
                        case SearchField.WorksOrderNumber:
                            using (var tricorn = new TricornDataProvider()) {
                                var drawingNumbers =
                                    tricorn.GetWorksOrders(args.Value).Select(wo => wo.Drawing_Number).Distinct();
                                var parts = new List<Part>();
                                foreach (var drawingNumber in drawingNumbers) {
                                    parts.AddRange(cpe.Parts.GetWhereDrawingNumberContains(drawingNumber));
                                }
                                matchingParts = parts;
                            }
                            break;
                        case SearchField.DrawingNumber:
                            matchingParts = cpe.Parts.GetWhereDrawingNumberMatches(args.Value);
                            break;
                        case SearchField.Name:
                            matchingParts = cpe.Parts.GetWhereNameMatches(args.Value);
                            break;
                        default:
                            matchingParts = cpe.Parts.GetWhereDrawingNumberMatches(args.Value);
                            break;
                    }

                    var customers = matchingParts.Select(part => part.Customer).Distinct().ToList();

                    var model = new PartLibraryViewModel();
                    model.Customers = customers;
                    model.Parts = matchingParts;

                    e.Result = model;
                }
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private void _searchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                _libraryView.RefreshLibrary();
                return;
            }

            var viewModel = (PartLibraryViewModel) e.Result;

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
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                _libraryView.RefreshLibrary();
                return;
            }

            var viewModel = (PartLibraryViewModel) e.Result;

            _libraryView.DisplayLibrary(viewModel);
        }

        private void GetPartsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                using (var cpe = new CPEUnitOfWork()) {
                    var customers = cpe.Customers.GetAll();
                    var parts = cpe.Parts.GetAll();
                    var lastViewedPartId = cpe.Employees.GetById(Session.CurrentEmployee.Id).LastViewedPartId;

                    var viewModel = new PartLibraryViewModel {
                        Customers = customers,
                        Parts = parts,
                        LastViewedPartId = lastViewedPartId
                    };

                    e.Result = viewModel;
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

            _libraryView.DialogService.ShowError(message);
        }
    }
}