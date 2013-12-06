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

        public MachineGroup SelectedMachineGroup
        {
            get { return (MachineGroup) machineGroupComboBox.SelectedItem; }
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
            try
            {
                using (BusyCursor.Show())
                {
                    using (var uow = new UnitOfWork())
                    {
                        var machineGroups = uow.MachineGroups.GetAll().OrderBy(m => m.Name);

                        machineGroupComboBox.Items.AddRange(machineGroups.ToArray());

                        if (_operation == null)
                        {
                            machineGroupComboBox.SelectedIndex = 0;
                            return;
                        }

                        sequenceNumericUpDown.Value = _operation.Sequence;
                        setupNumericUpDown.Value = _operation.SetupTime.HasValue ? _operation.SetupTime.Value : 0;
                        cycleNumericUpDown.Value = _operation.CycleTime.HasValue ? (decimal)_operation.CycleTime.Value : 0;
                        descriptionTextBox.Text = _operation.Description;
                        machineGroupComboBox.SelectedItem = uow.MachineGroups.GetById(_operation.MachineGroupId);
                    }
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
