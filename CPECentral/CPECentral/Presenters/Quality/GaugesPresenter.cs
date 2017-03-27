using System.Collections.Generic;
using System.Linq;
using CPECentral.Data.EF5;
using CPECentral.ViewModels.Quality;
using CPECentral.Views.Quality;
using nGenLibrary;

namespace CPECentral.Presenters.Quality
{
    public sealed class GaugesPresenter
    {
        private readonly GaugesView _view;

        public GaugesPresenter(GaugesView view)
        {
            _view = view;
            _view.RetrieveGaugeTypes += _view_RetrieveGaugeTypes;
            _view.FilterValuesChanged += _view_FilterValuesChanged;
        }

        private void _view_FilterValuesChanged(object sender, System.EventArgs e)
        {
            using (BusyCursor.Show())
            {
                IEnumerable<Gauge> gauges = null;

                using (var cpe = new CPEUnitOfWork())
                {
                    if (_view.FilterBookedOut)
                    {
                        // TODO: handle booked out gauges
                    }
                    else if (_view.FilterDueForCalibration)
                    {
                        // TODO: handle gauges due for calibration
                    }
                    else if (_view.FilterGaugeType != null)
                    {
                        gauges = cpe.Gauges.GetByGaugeType(_view.FilterGaugeType);
                    }
                    else
                    {
                        gauges = cpe.Gauges.GetAll();
                    }
                    
                    if (_view.FilterName.Length > 0)
                    {
                        gauges = gauges.Where(g => g.Name.ToLower().Contains(_view.FilterName.ToLower()));
                    }

                    if (_view.FilterReference.Length > 0)
                    {
                        gauges = gauges.Where(g => g.Reference.ToLower().Contains(_view.FilterReference.ToLower()));
                    }

                    var model = new GaugesViewModel();
                    foreach (var g in gauges)
                    {
                        model.AddItem(g);
                    }
                    _view.DisplayViewModel(model);
                }
            }
        }

        private void _view_RetrieveGaugeTypes(object sender, System.EventArgs e)
        {
            using (BusyCursor.Show())
            {
                using (var cpe = new CPEUnitOfWork())
                {
                    var types = cpe.GaugeTypes.GetAll().OrderBy(gt => gt.Name);
                    _view.DisplayGaugeTypes(types);
                }
            }
        }
    }
}