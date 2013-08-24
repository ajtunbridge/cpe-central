#region Using directives

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
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
        event EventHandler<PartVersionEventArgs> VersionSelected;
        event EventHandler SaveChanges;
        void LoadPart(Part part);
        void DisplayModel(PartInformationViewModel model);
        void SaveCompleted(bool successful);
    }

    [DefaultEvent("VersionSelected")]
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
        public event EventHandler<PartVersionEventArgs> VersionSelected;
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

                customerTextBox.ReadOnly = model.ReadOnly;
                drawingNumberTextBox.ReadOnly = model.ReadOnly;
                nameTextBox.ReadOnly = model.ReadOnly;
                toolingLocationTextBox.ReadOnly = model.ReadOnly;
                versionOptionsButton.Enabled = !model.ReadOnly;

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

                var status = "Updated " + Part.DrawingNumber + " successfully!";

                Session.MessageBus.Publish(new StatusUpdateMessage(status));
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

        protected virtual void OnVersionSelected(PartVersionEventArgs e)
        {
            EventHandler<PartVersionEventArgs> handler = VersionSelected;
            if (handler != null) handler(this, e);
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

        private void versionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedVersion = versionsComboBox.SelectedItem as PartVersion;

            OnVersionSelected(new PartVersionEventArgs(SelectedVersion));
        }
    }
}