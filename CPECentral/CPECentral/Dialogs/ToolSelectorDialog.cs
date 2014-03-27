#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Dialogs
{
    public partial class ToolSelectorDialog : Form
    {
        private const string HolderFilterText = "TOOL HOLDERS";
        private const string ToolGroupFilterText = "TOOL GROUPS";

        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();

        public ToolSelectorDialog()
        {
            InitializeComponent();
            filterComboBox.Items.Add(ToolGroupFilterText);
            filterComboBox.Items.Add(HolderFilterText);
            filterComboBox.SelectedIndex = 0;
        }

        public Tool SelectedTool { get; private set; }

        private void ToolGroupsView_ToolGroupSelected(object sender, ToolGroupEventArgs e)
        {
            toolsView.LoadGroupTools(e.ToolGroup);
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
            if (SelectedTool == null) {
                _dialogService.Notify("You haven't selected a tool!");
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
            switch (filterComboBox.Text) {
                case ToolGroupFilterText:
                    break;
                case HolderFilterText:
                    break;
            }
        }
    }
}