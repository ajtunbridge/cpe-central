using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CPECentral.Views
{
    public partial class ComplaintTrendsView : UserControl
    {
        public ComplaintTrendsView()
        {
            InitializeComponent();
        }

        private void complaintCategoryTrendChart_MouseMove(object sender, MouseEventArgs e)
        {
            var result = complaintCategoryTrendChart.HitTest(e.X, e.Y);
            if (result != null && result.Object != null)
            {
                if (result.Object is LegendItem)
                {
                    LegendItem legendItem = (LegendItem)result.Object;

                    // TODO: figure out how to highlight legend item on mouse over
                }
            }
        }
    }
}
