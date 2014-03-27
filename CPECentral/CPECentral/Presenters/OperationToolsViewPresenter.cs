using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using Tricorn;

namespace CPECentral.Presenters
{
    public class OperationToolsViewPresenter
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private readonly IOperationToolsView _view;

        public OperationToolsViewPresenter(IOperationToolsView view)
        {
            _view = view;

            _view.LoadOperationTools += _view_LoadOperationTools;
        }

        void _view_LoadOperationTools(object sender, OperationEventArgs e)
        {
            var loadToolsWorker = new BackgroundWorker();
            loadToolsWorker.DoWork += loadToolsWorker_DoWork;
            loadToolsWorker.RunWorkerCompleted += loadToolsWorker_RunWorkerCompleted;
            loadToolsWorker.RunWorkerAsync(e.Operation);
        }

        void loadToolsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                return;
            }

            var model = e.Result as OperationToolsViewModel;

            _view.DisplayModel(model);
        }

        void loadToolsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var operation = e.Argument as Operation;

            try {
                var model = new OperationToolsViewModel();
                model.Items = new List<OperationToolsViewModelItem>();

                using (var cpe = new CPEUnitOfWork()) {
                    var opTools = cpe.OperationTools.GetByOperation(operation)
                        .OrderBy(t => t.Position)
                        .ThenBy(t => t.Offset);

                    foreach (var opTool in opTools) {
                        var item = new OperationToolsViewModelItem();
                        item.OperationTool = opTool;

                        if (opTool.Holder != null) {
                            item.HolderName = opTool.Holder.Name;
                        }

                        item.ToolName = opTool.Tool.Description;

                        double? stockCount = 0;

                        using (var tricorn = new TricornDataProvider()) {
                            foreach (var tricornTool in cpe.TricornTools.GetByTool(opTool.Tool)) {
                                stockCount += tricorn.GetMStocks(tricornTool.TricornReference).Sum(ms => ms.Quantity_In_Stock);
                            }
                        }

                        item.QuantityInStock = stockCount;
                        
                        model.Items.Add(item);
                    }
                }

                e.Result = model;
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        void HandleException(Exception ex)
        {
            _view.DialogService.ShowError(ex.Message);
        }
    }
}
