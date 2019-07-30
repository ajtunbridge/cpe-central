using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Views.Quality;
using nGenLibrary;

namespace CPECentral.Presenters.Quality
{
    public class CalibrationResultsPresenter
    {
        private readonly CalibrationResultsView _view;

        public CalibrationResultsPresenter(CalibrationResultsView view)
        {
            _view = view;

            _view.PerformCalibration += _view_PerformCalibration;
        }

        private void _view_PerformCalibration(object sender, EventArgs e)
        {
            using (var cpe = new CPEUnitOfWork())
            {
                UserControl viewToShow = null;

                using (BusyCursor.Show())
                {
                    var gaugeType = cpe.GaugeTypes.GetById(_view.Gauge.GaugeTypeId);
                    var calibMethod = cpe.CalibrationMethods.GetById(gaugeType.CalibrationMethodId);

                    if (calibMethod.Description.ToLower() == "vernier calibration")
                    {
                        viewToShow = new VernierCalibrationView();
                        ((VernierCalibrationView) viewToShow).SetGauge(_view.Gauge);
                    }
                    else if (calibMethod.Description.ToLower() == "external micrometer calibration")
                    {
                        viewToShow = new MicrometerCalibrationView();
                        ((MicrometerCalibrationView) viewToShow).SetGauge(_view.Gauge);
                    }
                }

                if (viewToShow == null)
                {
                    return;
                }

                var dialog = new CalibrationShellDialog(viewToShow);

                if (dialog.ShowDialog(_view.ParentForm) != DialogResult.OK)
                {
                    return;
                }

                var calibResult = new CalibrationResult();
                calibResult.CalibratedBy = Session.CurrentEmployee.Id;
                calibResult.CalibratedOn = DateTime.Now;
                calibResult.GaugeId = _view.Gauge.Id;

                if (viewToShow is MicrometerCalibrationView)
                {
                    var view = viewToShow as MicrometerCalibrationView;

                    calibResult.ExternalDeviationM1 = view.M1Deviation;
                    calibResult.ExternalDeviationM2 = view.M2Deviation;
                    calibResult.ExternalDeviationM3 = view.M3Deviation;
                    calibResult.ExternalDeviationM4 = view.M4Deviation;
                }
                else if (viewToShow is VernierCalibrationView)
                {
                    var view = viewToShow as VernierCalibrationView;

                    calibResult.ExternalDeviationM1 = view.ExtM1Deviation;
                    calibResult.ExternalDeviationM2 = view.ExtM2Deviation;
                    calibResult.ExternalDeviationM3 = view.ExtM3Deviation;
                    calibResult.ExternalDeviationM4 = view.ExtM4Deviation;

                    calibResult.InternalDeviationM1 = view.IntM1Deviation;
                    calibResult.InternalDeviationM2 = view.IntM2Deviation;
                    calibResult.InternalDeviationM3 = view.IntM3Deviation;
                    calibResult.InternalDeviationM4 = view.IntM4Deviation;
                }

                cpe.CalibrationResults.Add(calibResult);

                cpe.Commit();
            }
        }
    }
}
