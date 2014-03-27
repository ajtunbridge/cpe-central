using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using Tricorn;

namespace CPECentral.Presenters
{
    public class StockLevelsViewPresenter
    {
        private readonly IStockLevelsView _view;

        public StockLevelsViewPresenter(IStockLevelsView view)
        {
            _view = view;

            _view.LoadStockLevels += _view_LoadStockLevels;
        }

        void _view_LoadStockLevels(object sender, CustomEventArgs.ToolEventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(e.Tool);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
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

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var model = new StockLevelsViewModel();

            try
            {
                IEnumerable<TricornTool> tricornTools = null;
                using (var cpeDb = new CPEUnitOfWork())
                {
                    tricornTools = cpeDb.TricornTools.GetByTool(e.Argument as Tool);
                }
                if (tricornTools.Any())
                {
                    var batches = new List<TricornBatch>();
                    using (var tricorn = new TricornDataProvider())
                    {
                        foreach (var tricornTool in tricornTools)
                        {
                            var mstocks = tricorn.GetMStocks(tricornTool.TricornReference);
                            foreach (var mstock in mstocks)
                            {
                                var item = new TricornBatch
                                {
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
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }
    }
}
