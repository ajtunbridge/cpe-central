using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Views;
using nGenLibrary;

namespace CPECentral.Presenters
{
    public class ToolsViewPresenter
    {
        private readonly IToolsView _view;

        public ToolsViewPresenter(IToolsView view)
        {
            _view = view;

            _view.LoadTools += _view_LoadTools;
        }

        void _view_LoadTools(object sender, ToolGroupEventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(e.ToolGroup);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var tools = e.Result as IEnumerable<Tool>;

            _view.DisplayTools(tools);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            IEnumerable<Tool> tools = null;

            try
            {
                using (BusyCursor.Show())
                {
                    using (var cpe = new UnitOfWork()) {
                        var group = e.Argument as ToolGroup;
                        tools = cpe.Tools.GetByToolGroup(group, true).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            e.Result = tools;
        }

        private void HandleException(Exception ex)
        {
            // TODO: handle exceptions properly
            _view.DialogService.ShowError(ex.Message);
        }
    }
}
