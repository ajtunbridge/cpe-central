#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CPECentral.Data.EF5;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class HoldersViewPresenter
    {
        private readonly IHoldersView _view;

        public HoldersViewPresenter(IHoldersView view)
        {
            _view = view;

            _view.LoadHolders += View_LoadHolders;
            _view.HolderRenamed += View_HolderRenamed;
            _view.HolderGroupRenamed += View_HolderGroupRenamed;
        }

        private bool View_HolderGroupRenamed(HolderGroup entity)
        {
            bool updatedOk = false;

            try {
                using (var cpe = new CPEUnitOfWork()) {
                    cpe.HolderGroups.Update(entity);
                    using (BusyCursor.Show()) {
                        cpe.Commit();
                    }
                    updatedOk = true;
                }
            }
            catch (Exception ex) {
                HandleException(ex, entity);
            }

            return updatedOk;
        }

        private bool View_HolderRenamed(Holder entity)
        {
            bool updatedOk = false;

            try {
                using (var cpe = new CPEUnitOfWork()) {
                    cpe.Holders.Update(entity);
                    using (BusyCursor.Show()) {
                        cpe.Commit();
                    }
                    updatedOk = true;
                }
            }
            catch (Exception ex) {
                HandleException(ex, entity);
            }

            return updatedOk;
        }

        private void View_LoadHolders(object sender, EventArgs e)
        {
            var loadHoldersWorker = new BackgroundWorker();
            loadHoldersWorker.DoWork += LoadHoldersWorker_DoWork;
            loadHoldersWorker.RunWorkerCompleted += LoadHoldersWorker_RunWorkerCompleted;
            loadHoldersWorker.RunWorkerAsync();
        }

        private void LoadHoldersWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception, null);
                return;
            }

            var result = e.Result as LoadHoldersWorkerResult;

            _view.DisplayHolders(result.HolderGroups, result.Holders);
        }

        private void LoadHoldersWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var result = new LoadHoldersWorkerResult();

            try {
                using (var cpe = new CPEUnitOfWork()) {
                    cpe.OpenConnection();
                    result.Holders = cpe.Holders.GetAll().ToList();
                    result.HolderGroups = cpe.HolderGroups.GetAll().ToList();
                    cpe.CloseConnection();
                }
                e.Result = result;
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private void HandleException(Exception ex, object sender)
        {
            string message = null;

            if (ex is DataProviderException) {
                var dataEx = ex as DataProviderException;

                if (dataEx.Error == DataProviderError.UniqueConstraintViolation) {
                    if (sender is Holder) {
                        message = "A holder already exists in this group with this name!";
                    }
                    else if (sender is HolderGroup) {
                        message = "A holder group already exists with this name!";
                    }
                }
                else {
                    message = dataEx.Message;
                }
            }
            else {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _view.DialogService.ShowError(message);
        }

        #region Nested type: LoadHoldersWorkerResult

        private class LoadHoldersWorkerResult
        {
            public IEnumerable<HolderGroup> HolderGroups { get; set; }
            public IEnumerable<Holder> Holders { get; set; }
        }

        #endregion
    }
}