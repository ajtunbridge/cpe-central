#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Properties;

#endregion

namespace CPECentral.Dialogs
{
    public partial class ToolManagementDialog : Form
    {
        public ToolManagementDialog()
        {
            InitializeComponent();
        }

        private void toolGroupsView_ToolGroupSelected(object sender, ToolGroupEventArgs e)
        {
            toolsView.LoadTools(e.ToolGroup);
        }

        private void HoldersView_HolderSelectionChanged(object sender, HolderEventArgs e)
        {
            holderToolsView.LoadHolderTools(e.Holder);
        }

        private void ToolManagementDialog_Load(object sender, EventArgs e)
        {
            Size = Settings.Default.ToolManagementDialogFormSize;
        }

        private void ToolManagementDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.ToolManagementDialogFormSize = Size;
            Settings.Default.Save();
        }
    }
}