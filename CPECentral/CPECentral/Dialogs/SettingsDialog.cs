#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.Controls;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Dialogs
{
    public partial class SettingsDialog : Form
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();

        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void categoriesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (selectedCategoryPanel.Controls.Count > 0) {
                selectedCategoryPanel.Controls.Clear();
            }

            UserControl categoryControl = null;

            switch (e.Node.Name) {
                case "pathsTreeNode":
                    categoryControl = new SettingsPathsUserControl();
                    break;
                case "generalTreeNode":
                    break;
                case "employeesTreeNode":
                    categoryControl = new SettingsEmployeesUserControl();
                    if (!AppSecurity.Check(AppPermission.ManageEmployees, true)) {
                        categoryControl.Enabled = false;    
                    }
                    break;
            }

            // TODO: remove this logic when settings dialog completed
            if (categoryControl == null) {
                return;
            }

            selectedCategoryPanel.Controls.Add(categoryControl);
            categoryControl.Dock = DockStyle.Fill;
        }

        private void okayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void okayCancelFooter_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            categoriesTreeView.SelectedNode = categoriesTreeView.Nodes[0];
        }
    }
}