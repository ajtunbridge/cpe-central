using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.QMS;
using CPECentral.Views;

namespace CPECentral.Presenters
{
    public class GaugesPresenter
    {
        private readonly GaugesView _view;

        public GaugesPresenter(GaugesView view)
        {
            _view = view;
            _view.FilterValueChanged += _view_FilterValueChanged;
        }

        private void _view_FilterValueChanged(object sender, EventArgs e)
        {
            var qms = new QMSDataProvider();

            if (_view.SelectedFilterValue == GaugesView.FilterValue.DueForCalibration)
            {
                _view.DisplayGauges(qms.GetGaugesDueForCalibration());
            }
        }
    }
}
