using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Presenters;
using CPECentral.QMS.Model;

namespace CPECentral.Views
{
    public partial class GaugesView : ViewBase
    {
        private bool _isInitializing = true;
        private readonly GaugesPresenter _presenter;

        public GaugesView()
        {
            InitializeComponent();

            _isInitializing = false;

            if (!IsInDesignMode)
            {
                _presenter = new GaugesPresenter(this);

                filterComboBox.SelectedIndex = 0;

                OnFilterValueChanged();
            }
        }

        public event EventHandler FilterValueChanged;

        public enum FilterValue
        {
            AllGauges,
            DueForCalibration
        }

        public FilterValue SelectedFilterValue { get; private set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void DisplayGauges(IEnumerable<Gauge> gauges)
        {
            resultsObjectListView.SetObjects(gauges);
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (filterComboBox.SelectedIndex)
            {
                case 0:
                    SelectedFilterValue = FilterValue.DueForCalibration;
                    break;
                case 1:
                    SelectedFilterValue = FilterValue.AllGauges;
                    break;
            }

            if (_isInitializing)
            {
                return;
            }

            OnFilterValueChanged();
        }

        protected virtual void OnFilterValueChanged()
        {
            resultsObjectListView.ClearObjects();

            FilterValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
