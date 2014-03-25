#region Using directives

using System;
using System.ComponentModel;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

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
            _view.UpdateTool += _view_UpdateTool;
        }

        private void _view_UpdateTool(object sender, CustomEventArgs.ToolEventArgs e)
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
            bool updatedOk = true;

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

            _view.DisplayModel(model);
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