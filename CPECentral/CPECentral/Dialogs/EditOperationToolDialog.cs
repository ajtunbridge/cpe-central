﻿#region Using directives

using System;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using nGenLibrary;

#endregion

namespace CPECentral.Dialogs
{
    public partial class EditOperationToolDialog : Form
    {
        private readonly OperationTool _operationTool;
        private readonly Operation _operation;

        public EditOperationToolDialog(Operation operation) : this(new OperationTool())
        {
            _operation = operation;
        }

        public EditOperationToolDialog(OperationTool operationTool)
        {
            InitializeComponent();

            _operationTool = operationTool;

            if (operationTool.Id > 0) {
                _operationTool = new CPEUnitOfWork().OperationTools.GetById(operationTool.Id);
            }
            else {
                _operationTool.Position = 1;
                _operationTool.Offset = 1;
            }
        }

        public OperationTool OperationTool
        {
            get { return _operationTool; }
        }

        private void SelectToolButton_Click(object sender, EventArgs e)
        {
            using (var toolSelector = new SelectToolDialog()) {
                if (toolSelector.ShowDialog(this) != DialogResult.OK) {
                    return;
                }

                _operationTool.ToolId = toolSelector.SelectedTool.Id;

                if (toolSelector.SelectedHolder == null) {
                    _operationTool.HolderId = null;
                }
                else {
                    _operationTool.HolderId = toolSelector.SelectedHolder.Id;
                }

                toolTextBox.Text = toolSelector.SelectedTool.Description;
                holderTextBox.Text = toolSelector.SelectedHolder == null
                    ? null
                    : toolSelector.SelectedHolder.Name;
            }
        }

        private void PositionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _operationTool.Position = (int) positionNumericUpDown.Value;

            offsetNumericUpDown.Value = positionNumericUpDown.Value;
        }

        private void OffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _operationTool.Offset = (int) offsetNumericUpDown.Value;
        }

        private void UseOnePerNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _operationTool.UseOnePer = (int) useOnePerNumericUpDown.Value;
        }

        private void okayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void okayCancelFooter_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void EditOperationToolDialog_Load(object sender, EventArgs e)
        {
            using (BusyCursor.Show())
            {
                using (var cpe = new CPEUnitOfWork())
                {
                    if (_operationTool.Id > 0)
                    {
                        positionNumericUpDown.Value = _operationTool.Position;
                        offsetNumericUpDown.Value = _operationTool.Offset;
                        useOnePerNumericUpDown.Value = _operationTool.UseOnePer;

                        Tool tool = cpe.Tools.GetById(_operationTool.ToolId);
                        toolTextBox.Text = tool.Description;

                        if (_operationTool.HolderId.HasValue)
                        {
                            Holder holder = cpe.Holders.GetById(_operationTool.HolderId.Value);
                            holderTextBox.Text = holder.Name;
                        }
                    }
                    else
                    {
                        var currentToolPositions = cpe.OperationTools.GetByOperation(_operation).Select(tool => tool.Position).ToList();

                        int nextPos = 1;

                        for (int i = 1; i < 256; i++)
                        {
                            if (currentToolPositions.Any(pos => pos == i))
                            {
                                continue;
                            }

                            nextPos = i;
                            break;
                        }

                        positionNumericUpDown.Value = nextPos;
                    }
                }
            }
        }

        private void toolManagementButton_Click(object sender, EventArgs e)
        {
            new ToolManagementDialog().ShowDialog(this);
        }
    }
}