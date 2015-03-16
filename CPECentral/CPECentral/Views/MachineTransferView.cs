#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CPECentral.Messages;
using CPECentral.Properties;
using NcCommunicator.Data;
using NcCommunicator.Data.Model;
using nGenLibrary;

#endregion

namespace CPECentral.Views
{
    public partial class MachineTransferView : ViewBase
    {
        private const string EmptyFilterTextBoxText = "filter by machine name here...";
        private List<Machine> _allMachines;

        private Collection _currentCollection;
        private int _currentIndex;
        private List<Machine> _favouriteMachines;
        private List<Machine> _filteredMachineList;

        public MachineTransferView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                Session.MessageBus.Subscribe<FavouriteMachinesChangedMessage>(m => {
                    _favouriteMachines =
                        new NcUnitOfWork().Machines.GetFavouriteMachines(Session.CurrentEmployee.Id).ToList();
                    if ((string) filterComboBox.SelectedItem == "Favourites") {
                        filterComboBox_SelectedIndexChanged(null, EventArgs.Empty);
                    }
                });
            }
        }

        public int MachineCount
        {
            get { return _allMachines.Count; }
        }

        private void MachineTransferView_SizeChanged(object sender, EventArgs e)
        {
        }

        private void MachineTransferView_Load(object sender, EventArgs e)
        {
        }

        public void RefreshMachineList()
        {
            using (BusyCursor.Show()) {
                _allMachines = new NcUnitOfWork().Machines.GetAll().ToList();
                _favouriteMachines =
                    new NcUnitOfWork().Machines.GetFavouriteMachines(Session.CurrentEmployee.Id).ToList();

                filterComboBox.SelectedIndex = Settings.Default.DefaultMachineTransferView == "All" ? 0 : 1;
            }
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterTextBox.Text = string.Empty;

            switch ((string) filterComboBox.SelectedItem) {
                case "All":
                    _currentCollection = Collection.All;
                    previousButton.Enabled = false;
                    nextButton.Enabled = _allMachines.Count > 1;
                    _currentIndex = 0;
                    _filteredMachineList = _allMachines;

                    if (_allMachines.Any()) {
                        machineView.Machine = _allMachines.First();
                    }
                    break;
                case "Favourites":
                    _currentCollection = Collection.Favourites;
                    if (!_favouriteMachines.Any()) {
                        _currentCollection = Collection.Favourites;
                        DialogService.Notify("You have no favourite machines set!");
                        return;
                    }
                    previousButton.Enabled = false;
                    nextButton.Enabled = _favouriteMachines.Count > 1;
                    _currentIndex = 0;
                    _filteredMachineList = _favouriteMachines;

                    if (_favouriteMachines.Any()) {
                        machineView.Machine = _favouriteMachines.First();
                    }
                    break;
            }

            filterTextBox.Select();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            _currentIndex += 1;
            machineView.Machine = _filteredMachineList[_currentIndex];

            previousButton.Enabled = true;
            nextButton.Enabled = _filteredMachineList.Count > _currentIndex + 1;
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            _currentIndex -= 1;
            machineView.Machine = _filteredMachineList[_currentIndex];

            nextButton.Enabled = true;
            previousButton.Enabled = _currentIndex > 0;
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (filterTextBox.Text == EmptyFilterTextBoxText) {
                filterTextBox.ForeColor = Color.LightGray;
                return;
            }

            filterTextBox.ForeColor = SystemColors.ControlText;

            string filterValue = filterTextBox.Text.Trim().ToUpper();

            switch (_currentCollection) {
                case Collection.All:
                    _filteredMachineList = string.IsNullOrWhiteSpace(filterValue)
                        ? _allMachines
                        : _allMachines.Where(m => m.Name.ToUpper().Contains(filterValue)).ToList();
                    break;
                case Collection.Favourites:
                    _filteredMachineList = string.IsNullOrWhiteSpace(filterValue)
                        ? _favouriteMachines
                        : _favouriteMachines.Where(m => m.Name.ToUpper().Contains(filterValue)).ToList();
                    break;
            }

            _currentIndex = 0;
            previousButton.Enabled = false;
            nextButton.Enabled = _filteredMachineList.Count > 1;

            if (_filteredMachineList.Count > 0) {
                machineView.Machine = _filteredMachineList.First();
            }
        }

        private void filterTextBox_Enter(object sender, EventArgs e)
        {
            if (filterTextBox.Text == EmptyFilterTextBoxText) {
                filterTextBox.Text = string.Empty;
            }
        }

        private void filterTextBox_Leave(object sender, EventArgs e)
        {
            if (filterTextBox.Text == string.Empty) {
                filterTextBox.Text = EmptyFilterTextBoxText;
            }
        }

        #region Nested type: Collection

        private enum Collection
        {
            All,
            Favourites
        }

        #endregion
    }
}