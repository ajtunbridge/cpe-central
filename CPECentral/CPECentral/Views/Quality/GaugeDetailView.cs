#region Using directives

using System;
using System.Drawing;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.Presenters.Quality;
using CPECentral.Properties;
using CPECentral.ViewModels.Quality;

#endregion

namespace CPECentral.Views.Quality
{
    public partial class GaugeDetailView : ViewBase
    {
        private readonly GaugeDetailPresenter _presenter;
        private bool _isBindingToModel;

        public GaugeDetailView()
        {
            InitializeComponent();
            _presenter = new GaugeDetailPresenter(this);
        }

        public GaugeDetailViewModel Model { get; private set; }
        public Gauge CurrentGauge { get; private set; }
        public event EventHandler<GaugeEventArgs> GaugeChanged;
        public event EventHandler SaveChanges;
        public event EventHandler SetPhoto;
        public event EventHandler<GaugeEventArgs> GaugeDataUpdated;

        public void LoadGauge(Gauge gauge)
        {
            CurrentGauge = gauge;
            OnGaugeChanged(new GaugeEventArgs(gauge));
        }

        public void DisplayModel(GaugeDetailViewModel model)
        {
            _isBindingToModel = true;

            Model = model;

            referenceTextBox.DataBindings.Clear();
            gaugeTypeComboBox.DataBindings.Clear();
            nameTextBox.DataBindings.Clear();
            heldByComboBox.DataBindings.Clear();
            dueForCalibrationTextBox.DataBindings.Clear();
            referenceOnlyCheckBox.DataBindings.Clear();

            heldByComboBox.DataSource = Model.Employees;
            gaugeTypeComboBox.DataSource = Model.GaugeTypes;

            referenceTextBox.DataBindings.Add("Text", Model, "Reference");
            gaugeTypeComboBox.DataBindings.Add("SelectedItem", Model, "GaugeType");
            nameTextBox.DataBindings.Add("Text", Model, "Name");
            heldByComboBox.DataBindings.Add("SelectedItem", Model, "HeldBy");

            if (Model.DueForCalibrationOn.HasValue)
            {
                dueForCalibrationTextBox.DataBindings.Add("Value", Model, "DueForCalibrationOn");
            }

            referenceOnlyCheckBox.DataBindings.Add("Checked", Model, "IsReferenceOnly");

            photoPictureBox.Image = Model.Photo ?? Resources.NoImageAvailableImage;

            removePhotoButton.Enabled = Model.Photo != null;

            saveChangesButton.Enabled = false;

            _isBindingToModel = false;
        }

        public void SaveComplete(bool successful)
        {
            if (successful)
            {
                saveChangesButton.Enabled = false;
            }
        }

        protected virtual void OnGaugeChanged(GaugeEventArgs e)
        {
            GaugeChanged?.Invoke(this, e);
        }

        protected virtual void OnSaveChanges()
        {
            SaveChanges?.Invoke(this, EventArgs.Empty);
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            OnSaveChanges();
        }

        private void setPhotoButton_Click(object sender, EventArgs e)
        {
            OnSetPhoto();

            DisplayModel(Model);
        }

        protected virtual void OnSetPhoto()
        {
            SetPhoto?.Invoke(this, EventArgs.Empty);
        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            if (_isBindingToModel)
            {
                return;
            }

            saveChangesButton.Enabled = true;
        }

        private void ComboBoxes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_isBindingToModel)
            {
                return;
            }

            saveChangesButton.Enabled = true;
        }

        private void referenceOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_isBindingToModel)
            {
                return;
            }

            saveChangesButton.Enabled = true;
        }

        private void photoPictureBox_DoubleClick(object sender, EventArgs e)
        {
            new PhotoViewerDialog(photoPictureBox.Image).ShowDialog(ParentForm);
        }

        private void photoPictureBox_MouseHover(object sender, EventArgs e)
        {
        }
    }
}