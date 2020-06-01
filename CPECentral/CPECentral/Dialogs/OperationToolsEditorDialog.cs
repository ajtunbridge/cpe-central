using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;

namespace CPECentral.Dialogs
{
    public partial class OperationToolsEditorDialog : Form
    {
        private readonly CPEUnitOfWork _cpe = new CPEUnitOfWork();
        private readonly List<OperationTool> _deletedOperationTools = new List<OperationTool>();
        private readonly IDialogService _dialogService;
        private readonly List<OperationTool> _newOperationTools = new List<OperationTool>();
        private readonly int _operationId;
        private readonly List<OperationTool> _updatedOperationTools = new List<OperationTool>();
        private bool _isNewToolList;
        private bool _isSelectingTool;
        private ListViewItem _selectedItem;
        private OperationTool _selectedOperationTool;

        public OperationToolsEditorDialog(int operationId)
        {
            InitializeComponent();

            _operationId = operationId;

            _dialogService = Session.GetInstanceOf<IDialogService>();
        }

        public OperationToolsEditorDialog(Operation operation) : this(operation.Id)
        {
        }

        private bool IsNotInDesignMode => !DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Runtime;

        private void OperationToolsEditorDialog_Load(object sender, EventArgs e)
        {
            if (IsNotInDesignMode)
            {
                LoadCurrentToolList();

                if (toolsEnhancedListView.Items.Count == 0)
                {
                    _isNewToolList = true;
                    addButton_Click(this, e);
                }
            }
        }

        private void LoadCurrentToolList()
        {
            toolsEnhancedListView.Items.Clear();

            var existingOpTools = _cpe.OperationTools.GetByOperation(_operationId);

            var newAndExisting =
                existingOpTools.Concat(_newOperationTools).OrderBy(ot => ot.Position).ThenBy(ot => ot.Offset);

            foreach (var opTool in newAndExisting)
            {
                Tool tool = null;
                ;
                Holder holder = null;

                if (opTool.ToolId > 0)
                {
                    tool = _cpe.Tools.GetById(opTool.ToolId);
                }

                if (opTool.HolderId != null)
                {
                    holder = _cpe.Holders.GetById(opTool.HolderId.Value);
                }

                ListViewItem item = toolsEnhancedListView.Items.Add(opTool.Position.ToString("D2"));
                item.SubItems.Add(opTool.Offset.ToString("D2"));
                item.SubItems.Add(tool == null ? "PLEASE SELECT A TOOL" : tool.Description);
                item.SubItems.Add(holder == null ? "NO HOLDER" : holder.Name);
                item.Tag = opTool;
                if (opTool == _selectedOperationTool)
                {
                    item.Selected = true;
                }
            }

            toolsEnhancedListView.ListViewItemSorter = new ListViewItemComparer();
            toolsEnhancedListView.Sort();
            toolsEnhancedListView.ListViewItemSorter = null;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            foreach (var opTool in _newOperationTools)
            {
                if (opTool.ToolId == 0)
                {
                    _dialogService.ShowError(
                        $"The tool at position {opTool.Position}, offset {opTool.Offset}, has not been set!");
                    return;
                }

                _cpe.OperationTools.Add(opTool);
            }

            foreach (var opTool in _updatedOperationTools)
            {
                if (opTool.ToolId == 0)
                {
                    _dialogService.ShowError(
                        $"The tool at position {opTool.Position}, offset {opTool.Offset}, has not been set!");
                    return;
                }

                _cpe.OperationTools.Update(opTool);
            }

            foreach (var opTool in _deletedOperationTools)
            {
                _cpe.OperationTools.Delete(opTool);
            }

            _cpe.Commit();

            Close();
        }

        private void toolsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isSelectingTool = true;

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

            toolTextBox.Select();

            _isSelectingTool = false;
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
                toolComboBox.Items.Add("None");
                toolComboBox.BringToFront();
                toolComboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                toolComboBox.Select();
            }
        }

        private void toolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }

        private void TextBoxes_MouseClicked(object sender, MouseEventArgs e)
        {
            var textBox = sender as TextBox;
            textBox.SelectAll();
        }

        private void OnOperationToolUpdated()
        {
            if (_isSelectingTool)
            {
                return;
            }

            if (_updatedOperationTools.Contains(_selectedOperationTool) ||
                _newOperationTools.Contains(_selectedOperationTool))
            {
                return;
            }

            _updatedOperationTools.Add(_selectedOperationTool);
        }

        private void holderComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var holder = holderComboBox.SelectedItem as Holder;

            if (holder == null)
            {
                _selectedOperationTool.HolderId = null;
                _selectedItem.SubItems[3].Text = "NO HOLDER";
                holderTextBox.Text = "NO HOLDER";
                holderTextBox.BringToFront();

                if (_selectedOperationTool.ToolId > 0)
                {
                    AskToAddAnotherTool();

                    return;
                }
            }
            else
            {
                _selectedOperationTool.HolderId = holder.Id;
                _selectedItem.SubItems[3].Text = holder.Name;
                holderTextBox.Text = holder.Name;
                holderTextBox.BringToFront();

                if (_selectedOperationTool.ToolId > 0)
                {
                        AskToAddAnotherTool();

                    return;
                }

                toolComboBox.Items.Clear();
                toolComboBox.Items.Add("NO TOOL");
                _selectedItem.SubItems[2].Text = "NO TOOL";
                _selectedOperationTool.ToolId = 0;

                var holderTools = _cpe.HolderTools.GetByHolder(holder);

                foreach (var holderTool in holderTools)
                {
                    var tool = _cpe.Tools.GetById(holderTool.ToolId);
                    toolComboBox.Items.Add(tool);
                }

                toolComboBox.BringToFront();
                toolComboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                toolComboBox.Select();
            }

            OnOperationToolUpdated();
        }

        private void toolComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var tool = toolComboBox.SelectedItem as Tool;

            if (tool == null)
            {
                    toolTextBox.BringToFront();
                    toolTextBox.Select();
            }
            else
            {
                toolTextBox.Text = tool.Description;
                _selectedItem.SubItems[2].Text = tool.Description;
                _selectedOperationTool.ToolId = tool.Id;
                toolTextBox.BringToFront();

                OnOperationToolUpdated();

                if (_selectedOperationTool.HolderId.HasValue)
                {
                        AskToAddAnotherTool();

                    return;
                }

                holderComboBox.Items.Clear();
                holderComboBox.Items.Add("NO HOLDER");
                _selectedItem.SubItems[3].Text = "NO HOLDER";
                _selectedOperationTool.HolderId = null;

                var holders = _cpe.HolderTools.GetByTool(tool).Select(ht => ht.Holder);

                foreach (var holder in holders)
                {
                    holderComboBox.Items.Add(holder);
                }

                if (holderComboBox.Items.Count == 1)
                {
                    holderComboBox.SelectedIndex = 0;
                    holderTextBox.BringToFront();
                    holderTextBox.Text = "NO HOLDER";
                    
                    AskToAddAnotherTool();
                }
                else
                {
                    holderComboBox.BringToFront();
                    holderComboBox.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                    holderComboBox.Select();
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int nextPosition = 1;

            var positions =
                (from ListViewItem item in toolsEnhancedListView.Items select Convert.ToInt32(item.Text)).ToList();

            for (int i = 1; i < 256; i++)
            {
                if (positions.Any(p => p == i)) continue;
                nextPosition = i;
                break;
            }

            var newOpTool = new OperationTool
            {
                Position = nextPosition,
                Offset = nextPosition,
                OperationId = _operationId
            };

            _newOperationTools.Add(newOpTool);

            _selectedOperationTool = newOpTool;

            LoadCurrentToolList();
        }

        private void AskToAddAnotherTool()
        {
            if (_dialogService.AskQuestion("Do you want to add another tool?"))
            {
                addButton_Click(this, EventArgs.Empty);
            }
        }

        private void positionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            offsetNumericUpDown.Value = positionNumericUpDown.Value;
            _selectedOperationTool.Position = (int) positionNumericUpDown.Value;
            _selectedItem.SubItems[0].Text = _selectedOperationTool.Position.ToString("D2");

            OnOperationToolUpdated();

            toolsEnhancedListView.ListViewItemSorter = new ListViewItemComparer();
            toolsEnhancedListView.Sort();
            toolsEnhancedListView.ListViewItemSorter = null;
        }

        private void offsetNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _selectedOperationTool.Offset = (int) offsetNumericUpDown.Value;
            _selectedItem.SubItems[1].Text = _selectedOperationTool.Offset.ToString("D2");

            OnOperationToolUpdated();

            toolsEnhancedListView.ListViewItemSorter = new ListViewItemComparer();
            toolsEnhancedListView.Sort();
            toolsEnhancedListView.ListViewItemSorter = null;
        }

        private void holderTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var searchValue = holderTextBox.Text.Contains("%")
                    ? holderTextBox.Text
                    : $"%{holderTextBox.Text}%";

                if (searchValue.Length < 4)
                {
                    return;
                }

                var matches = _cpe.Holders.GetWhereNameMatches(searchValue)
                    .OrderBy(t => t.Name);

                holderComboBox.Items.Clear();
                foreach (var match in matches)
                {
                    holderComboBox.Items.Add(match);
                }

                toolComboBox.Items.Add("None");
                holderComboBox.BringToFront();
                holderComboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                holderComboBox.Select();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_newOperationTools.Contains(_selectedOperationTool))
            {
                _newOperationTools.Remove(_selectedOperationTool);
            }
            else
            {
                _deletedOperationTools.Add(_selectedOperationTool);
            }

            toolsEnhancedListView.Items.RemoveAt(toolsEnhancedListView.SelectedIndices[0]);
        }

        private void browseForToolButton_Click(object sender, EventArgs e)
        {
            using (var toolBrowser = new ToolSelectorDialog(false))
            {
                if (toolBrowser.ShowDialog(this) == DialogResult.OK)
                {
                    _selectedOperationTool.ToolId = toolBrowser.SelectedTool.Id;
                    toolTextBox.Text = toolBrowser.SelectedTool.Description;
                    toolsEnhancedListView.SelectedItems[0].SubItems[2].Text = toolBrowser.SelectedTool.Description;

                    if (toolBrowser.SelectedHolder != null)
                    {
                        _selectedOperationTool.HolderId = toolBrowser.SelectedHolder.Id;
                        holderTextBox.Text = toolBrowser.SelectedHolder.Name;
                        toolsEnhancedListView.SelectedItems[0].SubItems[3].Text = toolBrowser.SelectedHolder.Name;
                    }
                    else
                    {
                        _selectedOperationTool.HolderId = null;
                        holderTextBox.Text = "NO HOLDER";
                        toolsEnhancedListView.SelectedItems[0].SubItems[3].Text = "NO HOLDER";
                    }
                }
            }
        }

        private class ListViewItemComparer : IComparer
        {
            private int _col;

            public ListViewItemComparer()
            {
                _col = 0;
            }

            public int Compare(object x, object y)
            {
                var firstItem = (ListViewItem) x;
                var secondItem = (ListViewItem) y;

                var firstPosition = Convert.ToInt32(firstItem.SubItems[0].Text);
                var secondPosition = Convert.ToInt32(secondItem.SubItems[0].Text);

                if (firstPosition < secondPosition)
                {
                    return -1;
                }

                if (firstPosition > secondPosition)
                {
                    return 1;
                }

                var firstOffset = Convert.ToInt32(firstItem.SubItems[1].Text);
                var secondOffset = Convert.ToInt32(secondItem.SubItems[1].Text);

                if (firstOffset < secondOffset)
                {
                    return -1;
                }

                if (firstOffset > secondOffset)
                {
                    return 1;
                }

                return 0;
            }
        }
    }
}