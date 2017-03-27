#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Views;
using nGenLibrary;
using Tricorn;

#endregion

namespace CPECentral.Presenters
{
    public class ToolsPresenter
    {
        private readonly IToolsView _view;

        public ToolsPresenter(IToolsView view)
        {
            _view = view;

            _view.AddTool += View_AddTool;
            _view.LoadGroupTools += View_LoadGroupTools;
            _view.LoadHolderTools += _view_LoadHolderTools;
            _view.EditTool += View_EditTool;
            _view.ToolRenamed += View_ToolRenamed;
            _view.DeleteTool += View_DeleteTool;
        }

        private bool View_ToolRenamed(Tool entity)
        {
            bool updatedOk = false;

            PerformDatabaseActionThenRefreshView(() => {
                using (var cpe = new CPEUnitOfWork()) {
                    using (BusyCursor.Show()) {
                        cpe.Tools.Update(entity);
                        cpe.Commit();
                        updatedOk = true;
                    }
                }
            });

            return updatedOk;
        }

        private void View_AddTool(object sender, ToolGroupEventArgs e)
        {
            using (BusyCursor.Show()) {
                using (var cpe = new CPEUnitOfWork()) {
                    bool hasChildGroups = cpe.ToolGroups.GetChildGroups(e.ToolGroup).Any();
                    if (hasChildGroups) {
                        const string question =
                            "The group you are creating this tool in has child groups!\n\nAre you sure you're adding it to the correct group?";
                        if (!_view.DialogService.AskQuestion(question)) {
                            return;
                        }
                    }
                }
            }

            IEnumerable<Material> tricornLinks = null;
            Tool newTool = null;

            using (var editToolDialog = new EditToolDialog()) {
                if (editToolDialog.ShowDialog(_view.ParentForm) != DialogResult.OK) {
                    return;
                }

                newTool = editToolDialog.Tool;
                tricornLinks = editToolDialog.TricornLinks;
            }

            PerformDatabaseActionThenRefreshView(() => {
                using (var cpe = new CPEUnitOfWork()) {
                    using (BusyCursor.Show()) {
                        newTool.ToolGroupId = e.ToolGroup.Id;
                        cpe.Tools.Add(newTool);

                        foreach (Material material in tricornLinks) {
                            var tricornTool = new TricornTool();
                            tricornTool.Tool = newTool;
                            tricornTool.TricornReference = material.Material_Reference;
                            cpe.TricornTools.Add(tricornTool);
                        }

                        cpe.Commit();

                        _view.RefreshTools();
                    }
                }
            });
        }

        private void View_EditTool(object sender, ToolEventArgs e)
        {
            IEnumerable<Material> tricornLinks = null;

            using (var editToolDialog = new EditToolDialog(e.Tool)) {
                if (editToolDialog.ShowDialog(_view.ParentForm) != DialogResult.OK) {
                    return;
                }
                tricornLinks = editToolDialog.TricornLinks;
            }

            PerformDatabaseActionThenRefreshView(() => {
                using (var cpe = new CPEUnitOfWork()) {
                    using (BusyCursor.Show()) {
                        cpe.Tools.Update(e.Tool);
                        IEnumerable<TricornTool> existingTricornTools = cpe.TricornTools.GetByTool(e.Tool);
                        foreach (TricornTool existingTool in existingTricornTools) {
                            bool hasBeenRemoved =
                                !tricornLinks.Any(t => t.Material_Reference == existingTool.TricornReference);
                            if (!hasBeenRemoved) {
                                continue;
                            }
                            cpe.TricornTools.Delete(existingTool);
                        }

                        foreach (Material material in tricornLinks) {
                            if (existingTricornTools.Any(t => t.TricornReference == material.Material_Reference)) {
                                continue;
                            }
                            var tricornTool = new TricornTool();
                            tricornTool.Tool = e.Tool;
                            tricornTool.TricornReference = material.Material_Reference;
                            cpe.TricornTools.Add(tricornTool);
                        }

                        cpe.Commit();
                    }
                }
            });
        }

        private void View_DeleteTool(object sender, ToolEventArgs e)
        {
            if (!_view.DialogService.AskQuestion("Are you sure you want to delete this tool?")) {
                return;
            }

            PerformDatabaseActionThenRefreshView(() => {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        cpe.Tools.Delete(e.Tool);
                        cpe.Commit();
                    }
                }
            });
        }

        private void View_ToolRenamed(object sender, ToolEventArgs e)
        {
        }

        private void View_LoadGroupTools(object sender, ToolGroupEventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += LoadToolsWorker_DoWork;
            worker.RunWorkerCompleted += LoadToolsWorker_RunWorkerCompleted;
            worker.RunWorkerAsync(e.ToolGroup);
        }

        private void _view_LoadHolderTools(object sender, HolderEventArgs e)
        {
            var loadHolderToolsWorker = new BackgroundWorker();
            loadHolderToolsWorker.DoWork += LoadToolsWorker_DoWork;
            loadHolderToolsWorker.RunWorkerCompleted += LoadToolsWorker_RunWorkerCompleted;
            loadHolderToolsWorker.RunWorkerAsync(e.Holder);
        }

        private void LoadToolsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                return;
            }

            var tools = e.Result as IEnumerable<Tool>;

            _view.DisplayTools(tools);
        }

        private void LoadToolsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IEnumerable<Tool> tools = null;

            try {
                using (var cpe = new CPEUnitOfWork()) {
                    if (e.Argument is ToolGroup) {
                        var group = e.Argument as ToolGroup;
                        tools = cpe.Tools.GetByToolGroup(group, true)
                            .OrderBy(t => t.Description)
                            .ToList();
                    }
                    else if (e.Argument is Holder) {
                        var holder = e.Argument as Holder;
                        tools = cpe.Tools.GetByHolder(holder)
                            .OrderBy(t => t.Description)
                            .ToList();
                    }
                }
            }
            catch (Exception ex) {
                e.Result = ex;
            }

            e.Result = tools;
        }

        private void PerformDatabaseActionThenRefreshView(Action action)
        {
            try {
                action();
            }
            catch (Exception ex) {
                HandleException(ex);
            }
            finally {
                _view.RefreshTools();
            }
        }

        private void HandleException(Exception ex)
        {
            // TODO: handle exceptions properly
            string message = ex.Message;

            if (ex is DataProviderException) {
                var dataEx = ex as DataProviderException;

                switch (dataEx.Error) {
                    case DataProviderError.UniqueConstraintViolation:
                        message = "A tool already exists in this group with this name.";
                        break;
                    case DataProviderError.RelationshipViolation:
                        message = "Unable to delete this tool!\n\nIt is used on at least one operation.";
                        break;
                }
            }

            _view.DialogService.ShowError(message);
        }
    }
}