using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;

namespace CPECentral.Dialogs
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void toolGroupsView1_ToolGroupSelected(object sender, ToolGroupEventArgs e)
        {
            toolsView1.LoadGroupTools(e.ToolGroup);
        }
    }
}
