using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;

namespace CPECentral.Views.Quality
{
    public partial class GaugeDataView : ViewBase
    {
        public GaugeDataView()
        {
            InitializeComponent();
        }

        public void LoadGauge(Gauge gauge)
        {
            noGaugeLabel.Visible = gauge == null;

            if (gauge == null)
            {
                return;
            }

            gaugeDetailView1.LoadGauge(gauge);
            calibrationResultsView.LoadGaugeResults(gauge);
        }
    }
}
