using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;

namespace CPECentral.Dialogs
{
    public partial class OperationToolsEditorDialog : Form
    {
        private readonly int _operationId;
        private readonly CPEUnitOfWork _cpe = new CPEUnitOfWork();
        private OperationTool _selectedOperationTool;
        private ListViewItem _selectedItem;
        private readonly IDialogService _dialogService;

        public OperationToolsEditorDialog(int operationId)
        {
            InitializeComponent();

            _operationId = operationId;

            _dialogService = Session.GetInstanceOf<IDialogService>();
        }

        public OperationToolsEditorDialog(Operation operation) : this(operation.Id)
        {
        }

        private void OperationToolsEditorDialog_Load(object sender, EventArgs e)
        {
            if (IsNotInDesignMode)
            {
                LoadCurrentToolList();
            }
        }

        private void LoadCurrentToolList()
        {
            var opTools = _cpe.OperationTools.GetByOperation(_operationId)
                .OrderBy(ot => ot.Position)
                .ThenBy(ot => ot.Offset);

            foreach (var opTool in opTools)
            {
                var tool = _cpe.Tools.GetById(opTool.ToolId);
                Holder holder = null;
                if (opTool.HolderId != null)
                {
                    holder = _cpe.Holders.GetById(opTool.HolderId.Value);
                }
                ListViewItem item = toolsEnhancedListView.Items.Add(opTool.Position.ToString("D2"));
                item.SubItems.Add(opTool.Offset.ToString("D2"));
                item.SubItems.Add(tool.Description);
                item.SubItems.Add(holder == null ? "N/A" : holder.Name);
                item.Tag = opTool;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private bool IsNotInDesignMode => !DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Runtime;

        private void toolsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedToolGroupBox.Enabled = false;
            deleteButton.Enabled = false;

            _selectedItem = toolsEnhancedListView.SelectedItems.Count == 1
                ? toolsEnhancedListView.SelectedItems[0]
                : null;

            if (_selectedItem == null)
            {
                _selectedOperationTool = null;
                return;
            }

            _selectedOperationTool = _selectedItem.Tag as OperationTool;
            
            deleteButton.Enabled = true;
            selectedToolGroupBox.Enabled = true;
            toolTextBox.Text = _selectedItem.SubItems[2].Text;
            holderTextBox.Text = _selectedItem.SubItems[3].Text;
            positionNumericUpDown.Value = _selectedOperationTool.Position;
            offsetNumericUpDown.Value = _selectedOperationTool.Offset;
        }

        private void TextBoxes_Entered(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.SelectAll();
        }

        private void toolTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var searchValue = toolTextBox.Text.Contains("%")
                    ? toolTextBox.Text
                    : $"%{toolTextBox.Text}%";

                if (searchValue.Length < 4)
                {
                    return;
                }

                var matches = _cpe.Tools.GetWhereDescriptionMatches(searchValue)
                    .OrderBy(t => t.Description);

                toolComboBox.Items.Clear();
                foreach (var match in matches)
                {
                    toolComboBox.Items.Add(match);
                }
                toolComboBox.Items.Add("None of the above");
                toolComboBox.BringToFront();
                toolComboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                toolComboBox.Select();
            }
        }

        private void toolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tool = toolComboBox.SelectedItem as Tool;

            if (tool == null)
            {
                if (_dialogService.AskQuestion("Do you want to find the tool using another method?"))
                {
                    var selector = new SelectToolDialog();
                    selector.ShowDialog(this);
                }
                else
                {
                    toolTextBox.BringToFront();
                    toolTextBox.Select();
                }
            }
            else
            {
                toolTextBox.Text = tool.Description;
                _selectedItem.SubItems[2].Text = tool.Description;
                _selectedOperationTool.ToolId = tool.Id;
                toolTextBox.BringToFront();

                holderComboBox.Items.Clear();
                holderComboBox.Items.Add("No holder");
                _selectedItem.SubItems[3].Text = "N/A";
                _selectedOperationTool.HolderId = null;
                var holders = _cpe.HolderTools.GetByTool(tool).Select(ht => ht.Holder);
                foreach (var holder in holders)
                {
                    holderComboBox.Items.Add(holder);
                }
                holderComboBox.BringToFront();
                holderComboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                holderComboBox.Select();
            }
        }

        private void toolComboBox_DropDown(object sender, EventArgs e)
        {
            if (!(toolComboBox.Items[0] is Tool))
            {
                toolComboBox.Items.RemoveAt(0);
            }
        }

        private void holderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var holder = holderComboBox.SelectedItem as Holder;

            if (holder == null)
            {
                _selectedOperationTool.HolderId = null;
                _selectedItem.SubItems[3].Text = "N/A";
            }
            else
            {
                _selectedOperationTool.HolderId = holder.Id;
                _selectedItem.SubItems[3].Text = holder.Name;
                holderTextBox.BringToFront();
            }
        }

        private void TextBoxes_MouseClicked(object sender, MouseEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.SelectAll();
        }
    }
}
