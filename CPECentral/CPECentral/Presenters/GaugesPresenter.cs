#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CPECentral.QMS;
using CPECentral.QMS.Model;
using CPECentral.Views;

#endregion

namespace CPECentral.Presenters
{
    public class GaugesPresenter
    {
        private readonly GaugesViewOld _view;

        public GaugesPresenter(GaugesViewOld view)
        {
            _view = view;
            _view.FilterValueChanged += _view_FilterValueChanged;
        }

        private void _view_FilterValueChanged(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync(_view.SelectedFilterValue);

        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                // TODO: handle exception
                return;
            }

            var gauges = e.Result as IEnumerable<Gauge>;

            _view.DisplayGauges(gauges);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var filterValue = (GaugesViewOld.FilterValue)e.Argument;

            IEnumerable<Gauge> gauges = null;

            var qms = new QMSDataProvider();

            if (filterValue == GaugesViewOld.FilterValue.DueForCalibration)
            {
                gauges = qms.GetGaugesDueForCalibration().OrderBy(g => g.CalibrationDueOn);
            }

            e.Result = gauges;
        }
    }
}