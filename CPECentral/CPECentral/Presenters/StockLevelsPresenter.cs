#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using Tricorn;

#endregion

namespace CPECentral.Presenters
{
    public class StockLevelsPresenter
    {
        private readonly IStockLevelsView _view;

        public StockLevelsPresenter(IStockLevelsView view)
        {
            _view = view;

            _view.LoadStockLevels += _view_LoadStockLevels;
        }

        private void _view_LoadStockLevels(object sender, ToolEventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(e.Tool);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                _view.DisplayStockLevels(null);
                return;
            }

            var model = e.Result as StockLevelsViewModel;

            _view.DisplayStockLevels(model);
        }

        private void HandleException(Exception exception)
        {
            throw new NotImplementedException();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var model = new StockLevelsViewModel();

            try {
                IEnumerable<TricornTool> tricornTools = null;
                using (var cpeDb = new CPEUnitOfWork()) {
                    tricornTools = cpeDb.TricornTools.GetByTool(e.Argument as Tool);
                }
                if (tricornTools.Any()) {
                    var batches = new List<TricornBatch>();
                    using (var tricorn = new TricornDataProvider()) {
                        foreach (TricornTool tricornTool in tricornTools) {
                            IEnumerable<MStock> mstocks = tricorn.GetMStocks(tricornTool.TricornReference);
                            foreach (MStock mstock in mstocks) {
                                var item = new TricornBatch {
                                    BatchNumber = mstock.Batch_Number,
                                    Quantity = mstock.Quantity_In_Stock.HasValue ? mstock.Quantity_In_Stock.Value : 0,
                                    Location = mstock.Location
                                };
                                batches.Add(item);
                            }
                        }
                    }
                    model.Batches = batches;
                }
                e.Result = model;
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }
    }
}