#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class HoldersViewPresenter
    {
        private const string NewGroupName = "NEW GROUP ";
        private const string NewHolderName = "NEW HOLDER ";
        private readonly IHoldersView _view;

        public HoldersViewPresenter(IHoldersView view)
        {
            _view = view;

            _view.LoadHolders += View_LoadHolders;
            _view.HolderRenamed += View_HolderRenamed;
            _view.HolderGroupRenamed += View_HolderGroupRenamed;
            _view.AddHolderGroup += View_AddHolderGroup;
            _view.AddHolder += View_AddHolder;
        }

        private void View_AddHolder(object sender, HolderGroupEventArgs e)
        {
            Holder newHolder = null;

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        IEnumerable<Holder> allHolders = cpe.Holders.GetByHolderGroup(e.HolderGroup);
                        string newName = NewHolderName + "01";
                        int count = 1;
                        while (allHolders.Any(h => h.Name.Equals(newName, StringComparison.OrdinalIgnoreCase))) {
                            count++;
                            newName = NewHolderName + count.ToString("00");
                        }

                        newHolder = new Holder {HolderGroupId = e.HolderGroup.Id, Name = newName};

                        cpe.Holders.Add(newHolder);
                        cpe.Commit();
                        _view.ReloadHolders(newHolder, true);
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex, newHolder);
            }
        }

        private void View_AddHolderGroup(object sender, EventArgs e)
        {
            HolderGroup newGroup = null;

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        IEnumerable<HolderGroup> allHolderGroups = cpe.HolderGroups.GetAll();
                        string newName = NewGroupName + "01";
                        int count = 1;
                        while (allHolderGroups.Any(g => g.Name.Equals(newName, StringComparison.OrdinalIgnoreCase))) {
                            count++;
                            newName = NewGroupName + count.ToString("00");
                        }

                        newGroup = new HolderGroup {Name = newName};

                        cpe.HolderGroups.Add(newGroup);
                        cpe.Commit();
                        _view.ReloadHolders(newGroup, true);
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex, newGroup);
            }
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