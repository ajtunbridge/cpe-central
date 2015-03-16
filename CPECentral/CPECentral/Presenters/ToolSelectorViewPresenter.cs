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
    public class ToolSelectorViewPresenter
    {
        private readonly IToolSelectorView _view;

        public ToolSelectorViewPresenter(IToolSelectorView view)
        {
            _view = view;

            _view.FilterTools += _view_FilterTools;
        }

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
                    using (var cpe = new CPEUnitOfWork()) {
                        IEnumerable<Tool> results = cpe.Tools.GetWhereDescriptionMatches(filterText).ToList();
                        args.Result = results;
                    }
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
    }
}