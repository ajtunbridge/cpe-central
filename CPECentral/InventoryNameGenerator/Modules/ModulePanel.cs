#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace InventoryNameGenerator.Modules
{
    /// <summary>
    ///   Module data files are stored in Application.StartupPath\modules\ModuleName\
    /// </summary>
    public partial class ModulePanel : UserControl
    {
        public ModulePanel()
        {
            InitializeComponent();
        }

        public string ModuleName
        {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }

        public string GeneratedName
        {
            get { return generatedNameTextBox.Text; }
            set { generatedNameTextBox.Text = value; }
        }

        private void CopyButtonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(generatedNameTextBox.Text))
            {
                Clipboard.SetText(generatedNameTextBox.Text);

                if (ParentForm != null) ParentForm.WindowState = FormWindowState.Minimized;
            }
        }
    }
}