using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

            if (!IsInDesignMode)
            {
                _presenter = new TurnoverGraphPresenter(this);
            }
        }

        private void TurnoverGraphView_Load(object sender, EventArgs e)
        {
            if (!IsInDesignMode)
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
            }
        }
    }
}
