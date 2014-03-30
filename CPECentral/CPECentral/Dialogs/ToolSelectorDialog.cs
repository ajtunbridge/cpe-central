#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Properties;

#endregion

namespace CPECentral.Dialogs
{
    public partial class ToolSelectorDialog : Form
    {
        private const string HolderFilterText = "TOOL HOLDERS";
        private const string ToolGroupFilterText = "TOOL GROUPS";

        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();

        public ToolSelectorDialog(bool multiSelect)
        {
            InitializeComponent();

            toolsView.MultiSelect = multiSelect;

            filterComboBox.Items.Add(ToolGroupFilterText);
            filterComboBox.Items.Add(HolderFilterText);
            filterComboBox.SelectedIndex = 0;
        }

        public Tool SelectedTool { get; private set; }
        public Holder SelectedHolder { get; private set; }

        public IEnumerable<Tool> SelectedTools
        {
            get { return toolsView.SelectedTools; }
        }

        private void ToolGroupsView_ToolGroupSelected(object sender, ToolGroupEventArgs e)
        {
            if (filterComboBox.Text != ToolGroupFilterText) {
                return;
            }

            toolsView.LoadTools(e.ToolGroup);
        }

        private void ToolsView_ToolSelected(object sender, ToolEventArgs e)
        {
            SelectedTool = e.Tool;
            stockLevelsView.RetrieveToolStockLevels(e.Tool);
        }

        private void ToolsView_ToolPicked(object sender, ToolEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void OkayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            if (SelectedTool == null & !SelectedTools.Any()) {
                _dialogService.Notify("You haven't selected anything!");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void OkayCancelFooter_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolsView.ClearTools();

            switch (filterComboBox.Text) {
                case ToolGroupFilterText:
                    toolGroupsView.BringToFront();
                    break;
                case HolderFilterText:
                    holdersView.BringToFront();
                    break;
            }
        }

        private void holdersView_HolderSelectionChanged(object sender, HolderEventArgs e)
        {
            if (filterComboBox.Text != HolderFilterText) {
                return;
            }

            SelectedHolder = e.Holder;
            toolsView.LoadTools(e.Holder);
        }

        private void ToolSelectorDialog_Load(object sender, EventArgs e)
        {
            Size = Settings.Default.ToolSelectorDialogFormSize;
        }

        private void ToolSelectorDialog_SizeChanged(object sender, EventArgs e)
        {
        }

        private void ToolSelectorDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.ToolSelectorDialogFormSize = Size;
            Settings.Default.Save();
        }
    }
}