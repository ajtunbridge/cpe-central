using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CPECentral.Presenters;
using CPECentral.ViewModels;

namespace CPECentral.Views
{
    public partial class ComplaintStatisticsView : ViewBase
    {
        public enum ComplaintType
        {
            Internal,
            Customer,
            Supplier
        }

        public enum TimePeriod
        {
            ThisMonth,
            PastThreeMonths,
            PastSixMonths,
            PastYear,
            AllTime
        }

        private readonly bool _isInitializing = true;
        private readonly ComplaintStatisticsPresenter _presenter;

        public ComplaintStatisticsView()
        {
            InitializeComponent();

            timePeriodComboBox.SelectedIndex = 3;

            if (!IsInDesignMode)
            {
                _presenter = new ComplaintStatisticsPresenter(this);
            }

            _isInitializing = false;
        }

        public TimePeriod SelectedTimePeriod { get; private set; }
        public ComplaintType SelectedComplaintType { get; private set; }
        public event EventHandler TimePeriodChanged;

        protected virtual void OnTimePeriodChanged()
        {
            customerPieChart.Series[0].Points.Clear();
            customerPieChart.Series[0].Points.AddXY("refreshing...", 0);

            customerPieChart.Titles.Clear();
            internalPieChart.Titles.Clear();
            supplierPieChart.Titles.Clear();

            customerPieChart.Titles.Add("Retrieving data...");
            customerPieChart.Titles[0].Alignment = ContentAlignment.TopLeft;
            customerPieChart.Titles[0].Font = new Font(Font.FontFamily, 16f, FontStyle.Bold);

            TimePeriodChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateChartTitles()
        {
            customerPieChart.Titles.Clear();
            customerPieChart.Titles.Add("Customer N.C.R's");
            customerPieChart.Titles[0].Alignment = ContentAlignment.TopLeft;
            customerPieChart.Titles[0].Font = new Font(Font.FontFamily, 16f, FontStyle.Bold);

            internalPieChart.Titles.Clear();
            internalPieChart.Titles.Add("Internal N.C.R's");
            internalPieChart.Titles[0].Alignment = ContentAlignment.TopLeft;
            internalPieChart.Titles[0].Font = new Font(Font.FontFamily, 16f, FontStyle.Bold);

            supplierPieChart.Titles.Clear();
            supplierPieChart.Titles.Add("Supplier N.C.R's");
            supplierPieChart.Titles[0].Alignment = ContentAlignment.TopLeft;
            supplierPieChart.Titles[0].Font = new Font(Font.FontFamily, 16f, FontStyle.Bold);

            DateTime today = DateTime.Today;

            DateTime startDate = today;

            switch (SelectedTimePeriod)
            {
                case ComplaintStatisticsView.TimePeriod.ThisMonth:
                    startDate = new DateTime(today.Year, today.Month, 1);
                    break;
                case ComplaintStatisticsView.TimePeriod.PastThreeMonths:
                    startDate = today.AddMonths(-3);
                    break;
                case ComplaintStatisticsView.TimePeriod.PastSixMonths:
                    startDate = today.AddMonths(-6);
                    break;
                case ComplaintStatisticsView.TimePeriod.PastYear:
                    startDate = today.AddYears(-1);
                    break;
                case ComplaintStatisticsView.TimePeriod.AllTime:
                    startDate = DateTime.MinValue;
                    break;
            }

            var charts = new[] {customerPieChart, internalPieChart, supplierPieChart};

            foreach (var chart in charts)
            {
                chart.Titles.Add($"From {startDate:dd-MM-yy} to {today:dd-MM-yy}");
                chart.Titles[1].Alignment = ContentAlignment.TopLeft;
                chart.Titles[1].Font = new Font(Font.FontFamily, 10f, FontStyle.Bold);
            }
        }

        public void DisplayModel(ComplaintStatisticsViewModel model)
        {
            customerPieChart.Series[0].Points.Clear();
            internalPieChart.Series[0].Points.Clear();
            supplierPieChart.Series[0].Points.Clear();
            
            foreach (var result in model.CustomerResults.OrderByDescending(r => r.Percentage))
            {
                customerPieChart.Series[0].Points.AddXY(result.Category, result.Percentage);
            }

            foreach (var result in model.InternalResults.OrderByDescending(r => r.Percentage))
            {
                internalPieChart.Series[0].Points.AddXY(result.Category, result.Percentage);
            }

            foreach (var result in model.SupplierResults.OrderByDescending(r => r.Percentage))
            {
                supplierPieChart.Series[0].Points.AddXY(result.Category, result.Percentage);
            }

            UpdateChartTitles();
        }

        private void timePeriodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (timePeriodComboBox.SelectedIndex)
            {
                case 0:
                    SelectedTimePeriod = TimePeriod.ThisMonth;
                    break;
                case 1:
                    SelectedTimePeriod = TimePeriod.PastThreeMonths;
                    break;
                case 2:
                    SelectedTimePeriod = TimePeriod.PastSixMonths;
                    break;
                case 3:
                    SelectedTimePeriod = TimePeriod.PastYear;
                    break;
                case 4:
                    SelectedTimePeriod = TimePeriod.AllTime;
                    break;
            }

            if (_isInitializing)
            {
                return;
            }

            OnTimePeriodChanged();
        }

        private void pieChart_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = customerPieChart.HitTest(e.X, e.Y);
            if (result != null && result.Object != null)
            {
                // When user hits the LegendItem
                if (result.Object is LegendItem)
                {
                    // Legend item result
                    LegendItem legendItem = (LegendItem) result.Object;
                    MessageBox.Show(legendItem.Name);
                }
            }
        }
        
        private void QMSNcrStatisticsView_Load(object sender, EventArgs e)
        {
            if (!IsInDesignMode)
            {
                OnTimePeriodChanged();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customerPieChart.Printing.PrintPreview();
        }
    }
}