using System;
using CPECentral.Presenters;
using CPECentral.ViewModels;

namespace CPECentral.Views
{
    public partial class TurnoverGraphView : ViewBase
    {
        private readonly TurnoverGraphPresenter _presenter;

        public TurnoverGraphView()
        {
            InitializeComponent();

            if (!IsInDesignMode && !DesignMode)
            {
                _presenter = new TurnoverGraphPresenter(this);
            }
        }

        private void TurnoverGraphView_Load(object sender, EventArgs e)
        {
            if (!IsInDesignMode && !DesignMode)
            {
                _presenter.RetrieveData();
            }
        }

        public void DisplayData(TurnoverGraphViewModel model)
        {
            chart.Series[0].Points.Clear();

            foreach (var point in model.GraphPoints)
            {
                chart.Series[0].Points.AddXY(point.Month, point.Percentage);
                chart.Series[1].Points.AddXY(point.Month, model.MedianValue);
            }
        }
    }
}