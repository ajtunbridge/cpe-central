using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPECentral.Dialogs
{
    public partial class ToolManagementDialog : Form
    {
        public ToolManagementDialog()
        {
            InitializeComponent();
        }

        private void toolGroupsView_ToolGroupSelected(object sender, CustomEventArgs.ToolGroupEventArgs e)
        {
            toolsView1.LoadGroupTools(e.ToolGroup);
        }
    }
}
