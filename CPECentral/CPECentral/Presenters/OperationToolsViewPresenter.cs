using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;
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
            _view.AddOperationTool += _view_AddOperationTool;
            _view.EditOperationTool += _view_EditOperationTool;
            _view.DeleteOperationTool += _view_DeleteOperationTool;
        }

        void _view_DeleteOperationTool(object sender, OperationToolEventArgs e)
        {
            if (!_view.DialogService.AskQuestion("Are you sure you want to remove this tool from the list?")) {
                return;
            }

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        cpe.OperationTools.Delete(e.OperationTool);
                        cpe.Commit();
                        _view.RefreshOperationTools();
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        void _view_EditOperationTool(object sender, OperationToolEventArgs e)
        {
            using (var editOperationToolDialog = new EditOperationToolDialog(e.OperationTool))
            {
                if (editOperationToolDialog.ShowDialog(_view.ParentForm) != DialogResult.OK)
                {
                    return;
                }

                var editedOpTool = editOperationToolDialog.OperationTool;

                try
                {
                    using (BusyCursor.Show()) {
                        using (var cpe = new CPEUnitOfWork()) {
                            var duplicatePositionAndOffset = cpe.OperationTools.GetByOperation(editedOpTool.OperationId)
                                .Where(ot => ot.Id != editedOpTool.Id)
                                .Any(ot => ot.Position == editedOpTool.Position && ot.Offset == editedOpTool.Offset);

                            if (duplicatePositionAndOffset) {
                                _view.DialogService.ShowError("A tool already exists at this position and offset!");
                                return;
                            }

                            cpe.OperationTools.Update(editedOpTool);
                            cpe.Commit();
                            _view.RefreshOperationTools();
                        }
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        private void _view_AddOperationTool(object sender, OperationEventArgs e)
        {
            using (var editOperationToolDialog = new EditOperationToolDialog()) {
                if (editOperationToolDialog.ShowDialog(_view.ParentForm) != DialogResult.OK) {
                    return;
                }

                var newOpTool = editOperationToolDialog.OperationTool;
                newOpTool.OperationId = e.Operation.Id;

                try {
                    using (BusyCursor.Show()) {
                        using (var cpe = new CPEUnitOfWork()) {
                            var duplicatePositionAndOffset = cpe.OperationTools.GetByOperation(e.Operation)
                                .Any(ot => ot.Position == newOpTool.Position && ot.Offset == newOpTool.Offset);

                            if (duplicatePositionAndOffset) {
                                _view.DialogService.ShowError("A tool already exists at this position and offset!");
                                return;
                            }

                            cpe.OperationTools.Add(newOpTool);
                            cpe.Commit();
                            _view.RefreshOperationTools();
                        }
                    }
                }
                catch (Exception ex) {
                    HandleException(ex);
                }
            }
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
