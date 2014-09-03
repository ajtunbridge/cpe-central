#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using nGenLibrary;

#endregion

namespace CPECentral.Dialogs
{
    public partial class EditOperationDialog : Form
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private readonly Operation _operation;
        private readonly int _methodId;
        private bool _altKeyIsDown = false;

        public EditOperationDialog(int methodId)
        {
            InitializeComponent();

            _methodId = methodId;
        }

        public EditOperationDialog(Operation operation)
        {
            InitializeComponent();

            _operation = operation;
        }

        public int Sequence
        {
            get { return (int) sequenceNumericUpDown.Value; }
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

        public List<OperationTool> OperationToolsToCopy { get; set; }

        public MachineGroup SelectedMachineGroup
        {
            get { return (MachineGroup) machineGroupComboBox.SelectedItem; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter) {
                OkayCancelFooter_OkayClicked(okayCancelFooter, EventArgs.Empty);
            }
            else if (keyData == Keys.Escape) {
                OkayCancelFooter_CancelClicked(okayCancelFooter, EventArgs.Empty);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OkayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text)) {
                const string noDescriptionMessage = "You must provide a description of this operation!";

                _dialogService.Notify(noDescriptionMessage);

                return;
            }

            // if it's a new operation, determine if there is a previous operation and ask user if they
            // want to copy the tooling information from it to this operation
            if (_operation == null) {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {

                        int newSequence = (int) sequenceNumericUpDown.Value;

                        var previousOps = cpe.Operations.GetByMethod(_methodId).Where(op => op.Sequence < newSequence);

                        if (previousOps.Any()) {
                            var closestSequence = FindClosest(previousOps.Select(op => op.Sequence), newSequence);

                            var previousOp = previousOps.Single(op => op.Sequence == closestSequence);

                            var copyTools =  _dialogService.AskQuestion("Do you want to copy the tool list from the previous operation?");

                            if (copyTools) {
                                OperationToolsToCopy = new List<OperationTool>();
                                OperationToolsToCopy.AddRange(previousOp.OperationTools.ToList());
                            }
                        }

                    }
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void OkayCancelFooter_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void EditOperationDialog_Load(object sender, EventArgs e)
        {
            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        IOrderedEnumerable<MachineGroup> machineGroups = cpe.MachineGroups.GetAll().OrderBy(m => m.Name);

                        machineGroupComboBox.Items.AddRange(machineGroups.ToArray());

                        if (_operation == null) {
                            int? preferredMachineGroupId = Session.CurrentEmployee.PreferredMachineGroup;
                            if (!preferredMachineGroupId.HasValue) {
                                machineGroupComboBox.SelectedIndex = 0;
                            }
                            else {
                                foreach (MachineGroup group in machineGroups) {
                                    if (group.Id == preferredMachineGroupId) {
                                        machineGroupComboBox.SelectedItem = group;
                                        break;
                                    }
                                }
                            }

                            // determine the next available sequence number
                            var existingSequences = cpe.Operations.GetByMethod(_methodId).Select(op => op.Sequence);

                            int nextAvailable = 1;

                            while (existingSequences.Any(s => s == nextAvailable)) {
                                nextAvailable++;
                            }

                            sequenceNumericUpDown.Value = nextAvailable;

                            return;
                        }

                        sequenceNumericUpDown.Value = _operation.Sequence;
                        setupNumericUpDown.Value = _operation.SetupTime.HasValue ? _operation.SetupTime.Value : 0;
                        cycleNumericUpDown.Value = _operation.CycleTime.HasValue
                            ? (decimal) _operation.CycleTime.Value
                            : 0;
                        descriptionTextBox.Text = _operation.Description;
                        machineGroupComboBox.SelectedItem = cpe.MachineGroups.GetById(_operation.MachineGroupId);
                    }
                }
            }
            catch (Exception ex) {
                string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                _dialogService.ShowError(msg);

                DialogResult = DialogResult.Cancel;
            }
        }

        private int? FindClosest(IEnumerable<int> numbers, int x)
        {
            return
                (from number in numbers
                 let difference = Math.Abs(number - x)
                 orderby difference, Math.Abs(number), number descending
                 select (int?)number)
                .FirstOrDefault();
        }

        private void symbolButtons_Click(object sender, EventArgs e)
        {
            var selectionStart = descriptionTextBox.SelectionStart;

            var newText = descriptionTextBox.Text.Insert(selectionStart, (sender as Button).Text);

            descriptionTextBox.Text = newText;

            descriptionTextBox.SelectionStart = selectionStart + 1;

            descriptionTextBox.Focus();
        }
    }
}