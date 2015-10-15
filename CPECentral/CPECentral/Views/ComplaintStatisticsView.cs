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

            timePeriodComboBox.SelectedIndex = 1;
            typeComboBox.SelectedIndex = 0;

            if (!IsInDesignMode)
            {
                _presenter = new ComplaintStatisticsPresenter(this);
            }

            _isInitializing = false;
        }

        public TimePeriod SelectedTimePeriod { get; private set; }
        public ComplaintType SelectedComplaintType { get; private set; }
        public event EventHandler ParametersChanged;

        protected virtual void OnParametersChanged()
        {
            pieChart.Series[0].Points.Clear();
            pieChart.Series[0].Points.AddXY("refreshing...", 0);

            UpdateChartTitle("Retrieving data...");

            ParametersChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateChartTitle(string title)
        {
            pieChart.Titles.Clear();
            pieChart.Titles.Add(title);
            pieChart.Titles[0].Alignment = ContentAlignment.TopLeft;
            pieChart.Titles[0].Font = new Font(Font.FontFamily, 16f, FontStyle.Bold);
        }

        public void DisplayModel(ComplaintStatisticsViewModel model)
        {
            pieChart.Series[0].Points.Clear();

            if (model.Results.Count == 0)
            {
                noComplaintsLabel.BringToFront();
                return;
            }

            foreach (var result in model.Results.OrderByDescending(r => r.Percentage))
            {
                pieChart.Series[0].Points.AddXY(result.Category, result.Percentage);
            }

            switch (SelectedComplaintType)
            {
                case ComplaintType.Customer:
                    UpdateChartTitle("Customer N.C.R's");
                    break;
                case ComplaintType.Internal:
                    UpdateChartTitle("Internal N.C.R's");
                    break;
                case ComplaintType.Supplier:
                    UpdateChartTitle("Supplier N.C.R's");
                    break;
            }

            noComplaintsLabel.SendToBack();
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

            OnParametersChanged();
        }

        private void pieChart_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = pieChart.HitTest(e.X, e.Y);
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

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (typeComboBox.SelectedIndex)
            {
                case 0:
                    SelectedComplaintType = ComplaintType.Customer;
                    break;
                case 1:
                    SelectedComplaintType = ComplaintType.Internal;
                    break;
                case 2:
                    SelectedComplaintType = ComplaintType.Supplier;
                    break;
            }

            if (_isInitializing)
            {
                return;
            }

            OnParametersChanged();
        }

        private void QMSNcrStatisticsView_Load(object sender, EventArgs e)
        {
            if (!IsInDesignMode)
            {
                OnParametersChanged();
            }
        }
    }
}