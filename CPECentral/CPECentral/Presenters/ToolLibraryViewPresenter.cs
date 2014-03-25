#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;

#endregion

namespace CPECentral.Presenters
{
    public class ToolLibraryViewPresenter
    {
        private readonly IToolLibraryView _view;

        public ToolLibraryViewPresenter(IToolLibraryView view)
        {
            _view = view;

            _view.LibraryRefreshStarted += ViewLibraryRefreshStarted;
        }

        private void ViewLibraryRefreshStarted(object sender, EventArgs e)
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
    }
}