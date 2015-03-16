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
    public partial class SelectToolDialog : Form
    {
        public Tool SelectedTool { get; private set; }

        public SelectToolDialog()
        {
            InitializeComponent();
        }

        private void toolSelectorView_ToolSelectionChanged(object sender, CustomEventArgs.ToolEventArgs e)
        {
            selectButton.Enabled = e.Tool != null;

            SelectedTool = e.Tool;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void toolSelectorView_ToolSelected(object sender, CustomEventArgs.ToolEventArgs e)
        {
            selectButton.PerformClick();
        }
    }
}
