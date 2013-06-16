﻿#region Using directives

using System;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IPartInformationView : IView
    {
        Part Part { get; }
        PartVersion SelectedVersion { get; }
        event EventHandler ReloadData;
        event EventHandler SaveChanges;
        void LoadPart(Part part);
        void DisplayModel(PartInformationViewModel model);
        void SaveCompleted(bool successful);
    }

    public partial class PartInformationView : ViewBase, IPartInformationView
    {
        private readonly PartInformationViewPresenter _presenter;
        private bool _isLoadingData;

        public PartInformationView()
        {
            InitializeComponent();

            if (!IsInDesignMode)
            {
                _presenter = new PartInformationViewPresenter(this);
            }
        }

        #region IPartInformationView Members

        public Part Part { get; private set; }
        public PartVersion SelectedVersion { get; private set; }

        public event EventHandler ReloadData;
        public event EventHandler SaveChanges;

        public void LoadPart(Part part)
        {
            Part = part;
            Enabled = false;
            _isLoadingData = true;

            foreach (var control in Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Text = "retrieving...";
                }
            }

            versionsComboBox.Items.Clear();

            OnReloadData();
        }

        public void DisplayModel(PartInformationViewModel model)
        {
            if (model != null)
            {
                Enabled = true;

                customerTextBox.Text = model.Customer;
                drawingNumberTextBox.Text = model.DrawingNumber;
                nameTextBox.Text = model.Name;
                toolingLocationTextBox.Text = model.ToolingLocation;

                versionsComboBox.Items.Clear();

                versionsComboBox.Items.AddRange(model.AllVersions.ToArray());

                versionsComboBox.SelectedIndex = 0;
            }

            _isLoadingData = false;
        }

        public void SaveCompleted(bool successful)
        {
            Enabled = true;
            _isLoadingData = false;

            if (successful)
            {
                saveChangesButton.Text = "No changes";

                Session.MessageBus.Publish(new PartEditedMessage(Part));
            }
            else
            {
                saveChangesButton.Text = "Save changes";
            }
        }

        #endregion

        protected virtual void OnSaveChanges()
        {
            var handler = SaveChanges;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnReloadData()
        {
            var handler = ReloadData;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void PartInformationView_Load(object sender, EventArgs e)
        {
        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            if (_isLoadingData)
                return;

            saveChangesButton.Text = "Save changes";
            saveChangesButton.Enabled = true;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            saveChangesButton.Text = "Saving...";
            saveChangesButton.Enabled = false;
            Enabled = false;

            Part.DrawingNumber = drawingNumberTextBox.Text.Trim();
            Part.Name = nameTextBox.Text.Trim();
            Part.ToolingLocation = toolingLocationTextBox.Text.Trim();

            OnSaveChanges();
        }
    }
}