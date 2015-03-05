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
using Customer = CPECentral.Data.EF5.Customer;
using Employee = CPECentral.Data.EF5.Employee;
using Part = CPECentral.Data.EF5.Part;

#endregion

namespace CPECentral.Presenters
{
    public class PartLibraryView2Presenter
    {
        private readonly IPartLibraryView2 _view;

        public PartLibraryView2Presenter(IPartLibraryView2 view)
        {
            _view = view;

            _view.RetrieveLibrary += _view_RetrieveLibrary;
            _view.PartSelected += _view_PartSelected;
            _view.FindParts += _view_FindParts;
            _view.DeletePart += _view_DeletePart;
        }

        private void _view_PartSelected(object sender, PartEventArgs e)
        {
            using (BusyCursor.Show()) {
                using (var cpe = new CPEUnitOfWork()) {
                    Employee employee = cpe.Employees.GetById(Session.CurrentEmployee.Id);
                    employee.LastViewedPartId = e.Part.Id;
                    cpe.Employees.Update(employee);
                    cpe.Commit();
                }
            }
        }

        private void _view_DeletePart(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _view_FindParts(object sender, StringEventArgs e)
        {
            var findPartsWorker = new BackgroundWorker();
            findPartsWorker.DoWork += findPartsWorker_DoWork;
            findPartsWorker.RunWorkerCompleted += findPartsWorker_RunWorkerCompleted;
            findPartsWorker.RunWorkerAsync(e.Value);
        }

        private void _view_RetrieveLibrary(object sender, EventArgs e)
        {
            var retrieveLibraryWorker = new BackgroundWorker();
            retrieveLibraryWorker.DoWork += retrieveLibraryWorker_DoWork;
            retrieveLibraryWorker.RunWorkerCompleted += retrieveLibraryWorker_RunWorkerCompleted;
            retrieveLibraryWorker.RunWorkerAsync();
        }

        private void retrieveLibraryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                return;
            }

            var refreshModel = e.Result as PartLibraryViewReloadModel;

            _view.DisplayRefreshModel(refreshModel);
        }

        private void retrieveLibraryWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var refreshModel = new PartLibraryViewReloadModel();
            refreshModel.Results = new List<PartLibraryViewReloadModel.CustomerParts>();

            try {
                using (var cpe = new CPEUnitOfWork()) {
                    IOrderedEnumerable<Customer> customers = cpe.Customers.GetAll().OrderBy(c => c.Name);

                    foreach (Customer customer in customers) {
                        refreshModel.Results.Add(new PartLibraryViewReloadModel.CustomerParts {
                            Customer = customer,
                            Parts = customer.Parts.OrderBy(p => p.DrawingNumber).ToList()
                        });
                    }

                    refreshModel.LastViewedPartId = cpe.Employees.GetById(Session.CurrentEmployee.Id).LastViewedPartId;
                }

                e.Result = refreshModel;
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private void findPartsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                return;
            }

            var searchModel = e.Result as PartLibraryView2SearchModel;

            _view.DisplaySearchModel(searchModel);
        }

        private void findPartsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            const double fuzziness = 0.7d;

            var cpe = new CPEUnitOfWork();
            var tricorn = new TricornDataProvider();

            try {
                var searchTerm = (string) e.Argument;

                var searchModel = new PartLibraryView2SearchModel();
                searchModel.DrawingNumberFuzzyMatches = new List<Part>();
                searchModel.DrawingNumberMatches = new List<Part>();
                searchModel.NameFuzzyMatches = new List<Part>();
                searchModel.NameMatches = new List<Part>();

                // find matches on drawing number and name
                List<Part> drawingNumberMatches = cpe.Parts.GetWhereDrawingNumberContains(searchTerm).ToList();
                IEnumerable<Part> nameMatches = cpe.Parts.GetWhereNameContains(searchTerm);

                // search using Tricorn works order info
                IEnumerable<WOrder> worksOrders = tricorn.GetWorksOrdersByUserReference(searchTerm);
                if (worksOrders.Any()) {
                    foreach (WOrder wo in worksOrders) {
                        IEnumerable<Part> matches = cpe.Parts.GetWhereDrawingNumberMatches(wo.Drawing_Number);
                        ICollection<Part> fuzzyMatches = cpe.Parts.GetFuzzyDrawingNumberMatches(wo.Drawing_Number,
                            fuzziness);
                        drawingNumberMatches.AddRange(matches);
                        searchModel.DrawingNumberFuzzyMatches.AddRange(fuzzyMatches.Except(drawingNumberMatches));
                    }
                }

                // perform fuzzy search
                ICollection<Part> fuzzyDrawingNumberMatches = cpe.Parts.GetFuzzyDrawingNumberMatches(searchTerm,
                    fuzziness);
                ICollection<Part> fuzzyNameMatches = cpe.Parts.GetFuzzyNameMatches(searchTerm, fuzziness);

                // remove all matches that have already been matched exactly
                IOrderedEnumerable<Part> distinctFuzzyDrawingNumberMatches =
                    fuzzyDrawingNumberMatches.Except(drawingNumberMatches).OrderBy(p => p.DrawingNumber);
                IOrderedEnumerable<Part> distinctFuzzyNameMatches =
                    fuzzyNameMatches.Except(nameMatches).OrderBy(p => p.Name);

                searchModel.DrawingNumberMatches.AddRange(drawingNumberMatches.OrderBy(p => p.DrawingNumber));
                searchModel.NameMatches.AddRange(nameMatches.OrderBy(p => p.Name));

                searchModel.DrawingNumberFuzzyMatches.AddRange(distinctFuzzyDrawingNumberMatches);
                searchModel.NameFuzzyMatches.AddRange(distinctFuzzyNameMatches);

                e.Result = searchModel;
            }
            catch (Exception ex) {
                e.Result = ex;
            }
            finally {
                cpe.Dispose();
                tricorn.Dispose();
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

            _view.DialogService.ShowError(message);
        }
    }
}