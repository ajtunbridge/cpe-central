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
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class HolderToolsPresenter
    {
        private readonly IHolderToolsView _view;

        public HolderToolsPresenter(IHolderToolsView view)
        {
            _view = view;

            _view.RetrieveHolderTools += _view_RetrieveHolderTools;
            _view.AddHolderTool += _view_AddHolderTool;
        }

        private void _view_AddHolderTool(object sender, HolderEventArgs e)
        {
            using (var toolSelectorDialog = new ToolSelectorDialog(true)) {
                if (toolSelectorDialog.ShowDialog(_view.ParentForm) != DialogResult.OK) {
                    return;
                }

                try {
                    using (BusyCursor.Show()) {
                        using (var cpe = new CPEUnitOfWork()) {
                            IEnumerable<HolderTool> existingTools = cpe.HolderTools.GetByHolder(e.Holder);

                            foreach (Tool tool in toolSelectorDialog.SelectedTools) {
                                // skip any tools that are already assigned
                                if (existingTools.Any(ht => ht.ToolId == tool.Id)) {
                                    continue;
                                }

                                var newHolderTool = new HolderTool();
                                newHolderTool.HolderId = e.Holder.Id;
                                newHolderTool.ToolId = tool.Id;
                                cpe.HolderTools.Add(newHolderTool);
                            }

                            cpe.Commit();
                            _view.LoadHolderTools(e.Holder);
                        }
                    }
                }
                catch (Exception ex) {
                    HandleException(ex);
                }
            }
        }

        private void _view_RetrieveHolderTools(object sender, HolderEventArgs e)
        {
            var retrieveHolderToolsWorker = new BackgroundWorker();
            retrieveHolderToolsWorker.DoWork += retrieveHolderToolsWorker_DoWork;
            retrieveHolderToolsWorker.RunWorkerCompleted += retrieveHolderToolsWorker_RunWorkerCompleted;
            retrieveHolderToolsWorker.RunWorkerAsync(e.Holder);
        }

        private void retrieveHolderToolsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                return;
            }

            var model = e.Result as HolderToolsViewModel;

            _view.DisplayModel(model);
        }

        private void retrieveHolderToolsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var holder = e.Argument as Holder;

            try {
                var model = new HolderToolsViewModel();
                model.Items = new List<HolderToolsViewModel.HolderToolsViewModelItem>();

                using (var cpe = new CPEUnitOfWork()) {
                    IEnumerable<HolderTool> holderTools = cpe.HolderTools.GetByHolder(holder);

                    foreach (HolderTool holderTool in holderTools) {
                        var item = new HolderToolsViewModel.HolderToolsViewModelItem();
                        item.HolderTool = holderTool;
                        item.Description = cpe.Tools.GetById(holderTool.ToolId).Description;

                        model.Items.Add(item);
                    }
                }

                e.Result = model;
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private void HandleException(Exception exception)
        {
            _view.DialogService.ShowError(exception.Message);
        }
    }
}