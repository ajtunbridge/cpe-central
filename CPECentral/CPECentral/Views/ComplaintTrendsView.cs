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

        private Dictionary<string, Color> _seriesOriginalColorsDictionary = new Dictionary<string, Color>();

        private void charts_MouseMove(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;

            Cursor = Cursors.Default;

            var result = chart.HitTest(e.X, e.Y);
            if (result != null && result.Object != null)
            {
                if (result.Object is LegendItem)
                {
                    Cursor = Cursors.Hand;
                }
            }
        }

        private void charts_MouseClick(object sender, MouseEventArgs e)
        {
            var chart = (Chart) sender;

            var result = chart.HitTest(e.X, e.Y);
            if (result != null && result.Object != null)
            {
                if (result.Object is LegendItem)
                {
                    LegendItem legendItem = (LegendItem)result.Object;

                    var series = chart.Series[legendItem.SeriesName];

                    if (series.Color == Color.WhiteSmoke)
                    {
                        series.Color = _seriesOriginalColorsDictionary[series.Name];
                        _seriesOriginalColorsDictionary.Remove(series.Name);
                    }
                    else
                    {
                        _seriesOriginalColorsDictionary.Add(series.Name, series.Color);
                        series.Color = Color.WhiteSmoke;
                    }
                }
            }
        }
    }
}
