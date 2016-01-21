using System;
using CPECentral.Data.EF5;
using CPECentral.Presenters.Quality;

namespace CPECentral.Views.Quality
{
    public partial class CalibrationResultsView : ViewBase
    {
        public CalibrationResultsView()
        {
            InitializeComponent();

            if (!IsInDesignMode && !DesignMode)
            {
                _presenter = new CalibrationResultsPresenter(this);
            }
        }

        public Gauge Gauge { get; private set; }

        private readonly CalibrationResultsPresenter _presenter;

        public event EventHandler PerformCalibration;
        public event EventHandler GaugeChanged;

        private void resultsObjectListView_SelectionChanged(object sender, EventArgs e)
        {
            var resultIsSelected = resultsTreeListView.SelectedObject != null;

            editButton.Enabled = resultIsSelected;
            deleteButton.Enabled = resultIsSelected;
        }

        public void LoadGaugeResults(Gauge gauge)
        {
            Gauge = gauge;
            OnGaugeChanged();
        }

        private void calibrateNowButton_Click(object sender, EventArgs e)
        {
            OnPerformCalibration();
        }

        protected virtual void OnPerformCalibration()
        {
            PerformCalibration?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnGaugeChanged()
        {
            GaugeChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}