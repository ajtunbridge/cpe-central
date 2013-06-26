using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using nGenLibrary;

namespace CPECentral.Dialogs
{
    public partial class EditOperationDialog : Form
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private readonly Operation _operation;
        private bool _isLoading;

        public EditOperationDialog()
        {
            InitializeComponent();
        }

        public EditOperationDialog(Operation operation)
        {
            InitializeComponent();

            _operation = operation;
        }

        public int Sequence
        {
            get { return (int)sequenceNumericUpDown.Value; }
        }

        public int SetupTime
        {
            get { return (int) setupNumericUpDown.Value; }
        }

        public double CycleTime
        {
            get { return (double) cycleNumericUpDown.Value; }
        }

        public string Description
        {
            get { return descriptionTextBox.Text; }
        }

        public Machine Machine
        {
            get { return (Machine) machineComboBox.SelectedItem; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                OkayCancelFooter_OkayClicked(okayCancelFooter, EventArgs.Empty);
            }
            else if (keyData == Keys.Escape)
            {
                OkayCancelFooter_CancelClicked(okayCancelFooter, EventArgs.Empty);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OkayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                const string noDescriptionMessage = "You must provide a description of this operation!";

                _dialogService.Notify(noDescriptionMessage);

                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void OkayCancelFooter_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void EditOperationDialog_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            try
            {
                using (BusyCursor.Show())
                {
                    using (var uow = new UnitOfWork())
                    {
                        var machineGroups = uow.MachineGroups.GetAll().OrderBy(m => m.Name);

                        machineGroupComboBox.Items.AddRange(machineGroups.ToArray());

                        if (machineGroupComboBox.Items.Count == 0)
                            throw new InvalidOperationException(
                                "Could not find any machines so cannot create an operation!");

                        if (_operation == null)
                        {
                            _isLoading = false;
                            machineGroupComboBox.SelectedIndex = 0;
                            return;
                        }

                        sequenceNumericUpDown.Value = _operation.Sequence;
                        setupNumericUpDown.Value = _operation.SetupTime.HasValue ? _operation.SetupTime.Value : 0;
                        cycleNumericUpDown.Value = _operation.CycleTime.HasValue ? (decimal)_operation.CycleTime.Value : 0;
                        descriptionTextBox.Text = _operation.Description;

                        var opMachine = uow.Machines.GetById(_operation.MachineId);

                        machineGroupComboBox.SelectedItem = opMachine.MachineGroup;

                        var machines = uow.Machines.GetByMachineGroup(opMachine.MachineGroup);

                        machineComboBox.Items.AddRange(machines.ToArray());

                        machineComboBox.SelectedItem = opMachine;
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                _dialogService.ShowError(msg);

                DialogResult = DialogResult.Cancel;
            }

            _isLoading = false;
        }

        private void machineGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            machineComboBox.Items.Clear();
            machineComboBox.Enabled = false;

            try
            {
                using (var uow = new UnitOfWork())
                {
                    var selectedGroup = (MachineGroup) machineGroupComboBox.SelectedItem;

                    var machines = uow.Machines.GetByMachineGroup(selectedGroup).OrderBy(m => m.Name);

                    machineComboBox.Items.AddRange(machines.ToArray());

                    if (machineComboBox.Items.Count == 0)
                        return;


                    machineComboBox.SelectedIndex = 0;
                    machineComboBox.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                _dialogService.ShowError(msg);

                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
