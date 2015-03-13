using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CPECentral.QMS;
using CPECentral.QMS.Model;
using CPECentral.Views;

namespace CPECentral.Presenters
{
    public class NonConformanceSelectorViewPresenter
    {
        private readonly INonConformanceSelectorView _view;

        public NonConformanceSelectorViewPresenter(INonConformanceSelectorView view)
        {
            _view = view;

            _view.RetrieveNonConformances += _view_RetrieveNonConformances;
        }

        void _view_RetrieveNonConformances(object sender, CustomEventArgs.StringEventArgs e)
        {
            var worker = new BackgroundWorker();

            worker.DoWork += (obj, args) => {
                try {
                    var qms = new QMSDataProvider();
                    var results = qms.GetNonConformances(e.Value).OrderByDescending(nc => nc.ReportNumber);
                    args.Result = results;
                }
                catch (Exception ex) {
                    args.Result = ex;
                }
            };

            worker.RunWorkerCompleted += (obj, args) => {
                if (args.Result is Exception) {
                    var ex = args.Result as Exception;
                    HandleException(ex);
                    return;
                }
                var results = args.Result as IEnumerable<NonConformance>;
                _view.DisplayNonConformances(results);
            };

            worker.RunWorkerAsync();
        }

        private void HandleException(Exception exception)
        {
            var msg = exception.InnerException == null ? exception.Message : exception.InnerException.Message;

            _view.DialogService.ShowError(msg);
        }
    }
}
