using CPECentral.Data.EF5;
using nGenLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPECentral.Dialogs
{
    public partial class PartAlertsDialog : Form
    {
        private readonly Part _part;
        private PartAlert _selectedAlert;
        private List<PartAlert> _deletedAlerts = new List<PartAlert>();
        private List<PartAlert> _newAlerts = new List<PartAlert>();
        private List<PartAlert> _modifiedAlerts = new List<PartAlert>();
        private Dictionary<int, string> _employeeDictionary = new Dictionary<int, string>();

        public PartAlertsDialog(Part part)
        {
            InitializeComponent();

            _part = part;
        }

        public bool HasAlerts => alertsListView.Items.Count > 0;

        private void PartAlertsDialog_Load(object sender, EventArgs e)
        {
            Text = $"Showing alerts for {_part.DrawingNumber}: {_part.Name}";

            using (BusyCursor.Show())
            {
                using (var cpe = new CPEUnitOfWork())
                {
                    foreach (var employee in cpe.Employees.GetAll())
                    {
                        _employeeDictionary.Add(employee.Id, employee.ToString());
                    }

                    foreach (var alert in cpe.PartsAlerts.GetAlerts(_part))
                    {
                        var item = new ListViewItem();
                        item.Text = GenerateItemLabel(alert);
                        item.Tag = alert;

                        alertsListView.Items.Add(item);
                    }
                }

                if (alertsListView.Items.Count > 0)
                    alertsListView.Items[0].Selected = true;
            }
        }

        private void newAlertButton_Click(object sender, EventArgs e)
        {
            var alert = new PartAlert();
            alert.CreatedBy = Session.CurrentEmployee.Id;
            alert.CreatedAt = DateTime.Now;
            alert.PartId = _part.Id;

            var item = new ListViewItem();
            item.Text = GenerateItemLabel(alert);
            item.Tag = alert;

            alertsListView.Items.Add(item);

            _newAlerts.Add(alert);

            item.Selected = true;
        }

        private string GenerateItemLabel(PartAlert alert)
        {
            return $"{alert.CreatedAt.ToShortDateString()} @ {alert.CreatedAt.ToShortTimeString()}";
        }

        private void alertsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteAlertButton.Enabled = alertsListView.SelectedItems.Count == 1;

            _selectedAlert = null;

            alertDescriptionTextBox.Text = null;
            createdByLabel.Text = null;

            if (alertsListView.SelectedItems.Count == 1)
            {
                _selectedAlert = alertsListView.SelectedItems[0].Tag as PartAlert;

                selectedAlertGroupBox.Enabled = true;

                alertDescriptionTextBox.Text = _selectedAlert.Description;

                var employeeName = _employeeDictionary[_selectedAlert.CreatedBy];

                alertDescriptionTextBox.ReadOnly = _selectedAlert.CreatedBy != Session.CurrentEmployee.Id;

                alertDescriptionTextBox.Select();
                alertDescriptionTextBox.SelectionStart = alertDescriptionTextBox.Text.Length;

                createdByLabel.Text = $"This alert was created by {employeeName}";
            }
            else
            {
                selectedAlertGroupBox.Enabled = false;
            }
        }

        private void alertDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedAlert == null)
                return;

            if (_selectedAlert.Description == alertDescriptionTextBox.Text)
                return;

            _selectedAlert.Description = alertDescriptionTextBox.Text;

            if (_selectedAlert.Id == 0) // if the alert is new, no need to add it modified list
                return;

            if (!_modifiedAlerts.Contains(_selectedAlert))
            {
                _modifiedAlerts.Add(_selectedAlert);
            }
        }

        private void PartAlertsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var cpe = new CPEUnitOfWork())
            {
                foreach (var deletedAlert in _deletedAlerts)
                    cpe.PartsAlerts.Delete(deletedAlert);

                foreach (var modifiedAlert in _modifiedAlerts)
                    cpe.PartsAlerts.Update(modifiedAlert);

                foreach (var newAlert in _newAlerts)
                {
                    if (!newAlert.Description.IsNullOrWhitespace())
                        cpe.PartsAlerts.Add(newAlert);
                }

                using (BusyCursor.Show())
                {
                    cpe.Commit();
                }
            }
        }

        private void deleteAlertButton_Click(object sender, EventArgs e)
        {
            var alertToDelete = alertsListView.SelectedItems[0].Tag as PartAlert;

            if (Session.CurrentEmployee.Id != alertToDelete.CreatedBy)
            {
                var employeeName = _employeeDictionary[alertToDelete.CreatedBy];

                MessageBox.Show($"You cannot delete an alert that you didn't create.\n\nThis alert was created by {employeeName}.");

                return;
            }
         
            if (alertToDelete.Id != 0) // Id will be zero if it hasn't been saved yet
            {
                _deletedAlerts.Add(alertToDelete);
            }

            alertsListView.Items.Remove(alertsListView.SelectedItems[0]);
        }
    }
}
