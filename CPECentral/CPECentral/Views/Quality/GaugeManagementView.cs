using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPECentral.Views.Quality
{
    public partial class GaugeManagementView : ViewBase
    {
        public GaugeManagementView()
        {
            InitializeComponent();
        }

        private void gaugesView_GaugeSelected(object sender, CustomEventArgs.GaugeEventArgs e)
        {
            gaugeDataView1.LoadGauge(e.Gauge);
        }
    }
}
