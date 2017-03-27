#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Views;

#endregion

namespace CPECentral.Presenters
{
    public class ToolSelectorPresenter : IDisposable
    {
        private readonly CPEUnitOfWork _cpe = new CPEUnitOfWork();
        private readonly IToolSelectorView _view;
        private bool _disposed;

        public ToolSelectorPresenter(IToolSelectorView view)
        {
            _view = view;

            _view.FilterTools += _view_FilterTools;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        private void _view_FilterTools(object sender, StringEventArgs e)
        {
            string filterText = e.Value.Trim();

            if (filterText.IsNullOrWhitespace()) {
                _view.DialogService.ShowError("You haven't entered a filter value!");
                return;
            }

            var worker = new BackgroundWorker();

            worker.DoWork += (o, args) => {
                try {
                    IEnumerable<Tool> results = _cpe.Tools.GetWhereDescriptionMatches(filterText).ToList();
                    args.Result = results;
                }
                catch (Exception ex) {
                    args.Result = ex;
                }
            };

            worker.RunWorkerCompleted += (o, args) => {
                if (args.Result is Exception) {
                    var ex = args.Result as Exception;
                    HandleException(ex);
                    _view.DisplayFilterResults(null);
                    return;
                }

                var results = args.Result as IEnumerable<Tool>;
                _view.DisplayFilterResults(results);
            };

            worker.RunWorkerAsync();
        }

        private void HandleException(Exception ex)
        {
            string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

            _view.DialogService.ShowError(msg);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) {
                return;
            }

            if (disposing) {
                _cpe.Dispose();
            }

            _disposed = true;
        }

        ~ToolSelectorPresenter()
        {
            Dispose(false);
        }
    }
}