#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters.Quality;
using CPECentral.ViewModels.Quality;

#endregion

namespace CPECentral.Views.Quality
{
    public partial class GaugesView : ViewBase
    {
        private readonly GaugesPresenter _presenter;
        private Timer _nameTextBoxFilterDelayTimer;

        public GaugesView()
        {
            InitializeComponent();

            if (!DesignMode && !IsInDesignMode)
            {
                _presenter = new GaugesPresenter(this);
                Session.MessageBus.Subscribe<GaugeEditedMessage>(GaugeEditedMessage_Published);
            }
        }

        private void GaugeEditedMessage_Published(GaugeEditedMessage message)
        {
            OnFilterValuesChanged();
            foreach (var obj in gaugesObjectListView.Objects)
            {
                var gaugeItem = obj as GaugesViewModel.Item;
                if (gaugeItem.Id == message.EditedGauge.Id)
                {
                    gaugesObjectListView.SelectedObject = obj;
                    break;
                }
            }
        }

        public string FilterReference => referenceTextBox.Text;
        public string FilterName => nameTextBox.Text;
        public GaugeType FilterGaugeType => gaugeTypesComboBox.SelectedItem as GaugeType;
        public bool FilterDueForCalibration => dueForCalibrationRadioButton.Checked;
        public bool FilterBookedOut => bookedOutRadioButton.Checked;
        public event EventHandler RetrieveGaugeTypes;
        public event EventHandler FilterValuesChanged;
        public event EventHandler<GaugeEventArgs> GaugeSelected;

        private void GaugesView_Load(object sender, EventArgs e)
        {
            OnRetrieveGaugeTypes();
        }

        public void DisplayGaugeTypes(IEnumerable<GaugeType> gaugeTypes)
        {
            gaugeTypesComboBox.Items.Clear();

            gaugeTypesComboBox.Items.Add("All types");

            foreach (var gt in gaugeTypes)
            {
                gaugeTypesComboBox.Items.Add(gt);
            }

            gaugeTypesComboBox.SelectedIndex = 0;
            OnFilterValuesChanged();
        }

        public void DisplayViewModel(GaugesViewModel model)
        {
            if (model.Items.Count == 0)
            {
                gaugesObjectListView.SetObjects(new[] {new {Reference = "No matches", Name="", GaugeType=""}});
            }
            else
            {
                gaugesObjectListView.SetObjects(model.Items);

                gaugesObjectListView.Sort(0);
            }

            gaugesObjectListView.SelectedIndex = 0;
        }

        protected virtual void OnRetrieveGaugeTypes()
        {
            RetrieveGaugeTypes?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnFilterValuesChanged()
        {
            FilterValuesChanged?.Invoke(this, EventArgs.Empty);
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            OnFilterValuesChanged();
        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_nameTextBoxFilterDelayTimer != null)
            {
                _nameTextBoxFilterDelayTimer.Stop();
                _nameTextBoxFilterDelayTimer.Dispose();
            }

            _nameTextBoxFilterDelayTimer = new Timer();
            _nameTextBoxFilterDelayTimer.Tick += _nameTextBoxFilterDelayTimer_Tick;
            _nameTextBoxFilterDelayTimer.Interval = 1000;
            _nameTextBoxFilterDelayTimer.Start();
        }

        private void _nameTextBoxFilterDelayTimer_Tick(object sender, EventArgs e)
        {
            OnFilterValuesChanged();
            _nameTextBoxFilterDelayTimer.Dispose();
        }

        private void gaugeTypesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnFilterValuesChanged();
        }

        protected virtual void OnGaugeSelected(GaugeEventArgs e)
        {
            GaugeSelected?.Invoke(this, e);
        }

        private void gaugesObjectListView_SelectionChanged(object sender, EventArgs e)
        {
            var item = gaugesObjectListView.SelectedObject as GaugesViewModel.Item;

            OnGaugeSelected(item == null ? new GaugeEventArgs(null) : new GaugeEventArgs(item.Gauge));
        }
    }
}