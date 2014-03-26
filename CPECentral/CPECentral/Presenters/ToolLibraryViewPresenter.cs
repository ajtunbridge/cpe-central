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

#endregion

namespace CPECentral.Presenters
{
    public class ToolLibraryViewPresenter
    {
        private readonly IToolLibraryView _view;

        public ToolLibraryViewPresenter(IToolLibraryView view)
        {
            _view = view;

            _view.LibraryRefreshStarted += _view_LibraryRefreshStarted;
            _view.ToolGroupRenamed += _view_ToolGroupRenamed;
            _view.ToolRenamed += _view_ToolRenamed;
            _view.ChangedToolsGroup += _view_ChangedToolsGroup;
            _view.ToolSelected += _view_ToolSelected;
        }

        void _view_ToolSelected(object sender, ToolEventArgs e)
        {
            var stockLevelsWorker = new BackgroundWorker();
            stockLevelsWorker.DoWork += stockLevelsWorker_DoWork;
            stockLevelsWorker.RunWorkerCompleted += stockLevelsWorker_RunWorkerCompleted;
            stockLevelsWorker.RunWorkerAsync(e.Tool);
        }

        void stockLevelsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception, null);
                _view.DisplayStockLevels(null);
                return;
            }

            var model = e.Result as StockLevelsViewModel;

            _view.DisplayStockLevels(model);
        }

        private void stockLevelsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var model = new StockLevelsViewModel();

            try {
                IEnumerable<TricornTool> tricornTools = null;
                using (var cpeDb = new UnitOfWork()) {
                    tricornTools = cpeDb.TricornTools.GetByTool(e.Argument as Tool);
                }
                if (tricornTools.Any()) {
                    var batches = new List<StockLevelsViewModelItem>();
                    using (var tricorn = new TricornDataProvider()) {
                        foreach (var tricornTool in tricornTools) {
                            var mstocks = tricorn.GetMStocks(tricornTool.TricornReference);
                            foreach (var mstock in mstocks) {
                                var item = new StockLevelsViewModelItem {
                                    BatchNumber = mstock.Batch_Number,
                                    Quantity = mstock.Quantity_In_Stock.HasValue ? mstock.Quantity_In_Stock.Value : 0,
                                    Location = mstock.Location
                                };
                                batches.Add(item);
                            }
                        }
                    }
                    model.StockLevels = batches;
                }
                e.Result = model;
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private bool _view_ToolRenamed(Tool entity)
        {
            var updatedOk = true;

            try {
                using (BusyCursor.Show()) {
                    using (var uow = new UnitOfWork()) {
                        uow.Tools.Update(entity);
                        uow.Commit();
                    }
                }
            }
            catch (Exception ex) {
                updatedOk = false;
                HandleException(ex, entity);
            }

            return updatedOk;
        }

        private void _view_ChangedToolsGroup(object sender, ToolEventArgs e)
        {
            try {
                using (BusyCursor.Show()) {
                    using (var uow = new UnitOfWork()) {
                        uow.Tools.Update(e.Tool);
                        uow.Commit();
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex, e.Tool);
            }
        }

        private bool _view_ToolGroupRenamed(ToolGroup entity)
        {
            var updatedOk = true;

            try {
                using (BusyCursor.Show()) {
                    using (var uow = new UnitOfWork()) {
                        uow.ToolGroups.Update(entity);
                        uow.Commit();
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex, entity);
                updatedOk = false;
            }

            return updatedOk;
        }

        private void _view_LibraryRefreshStarted(object sender, EventArgs e)
        {
            var reloadLibraryWorker = new BackgroundWorker();
            reloadLibraryWorker.DoWork += reloadLibraryWorker_DoWork;
            reloadLibraryWorker.RunWorkerCompleted += reloadLibraryWorker_RunWorkerCompleted;
            reloadLibraryWorker.RunWorkerAsync();
        }

        private void reloadLibraryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var model = e.Result as ToolLibraryViewModel;

            _view.DisplayToolGroupsAndTools(model);
        }

        private void reloadLibraryWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var uow = new UnitOfWork()) {
                var model = new ToolLibraryViewModel {
                    ToolGroups = uow.ToolGroups.GetAll(),
                    Tools = uow.Tools.GetAll()
                };
                e.Result = model;
            }
        }

        private void HandleException(Exception ex, IEntity entity)
        {
            string message = null;

            if (ex is DataProviderException) {
                var dataEx = ex as DataProviderException;

                if (dataEx.Error == DataProviderError.UniqueConstraintViolation) {
                    if (entity is ToolGroup) {
                        message = "A tool group with this name already exists!";
                    }
                    else if (entity is Tool) {
                        message = "A tool with this name already exists!";
                    }
                }
                else {
                    message = ex.Message;
                }
            }
            else {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _view.DialogService.ShowError(message);
        }
    }
}