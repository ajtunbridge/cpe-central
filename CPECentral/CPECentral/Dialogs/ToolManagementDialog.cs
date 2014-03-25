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
    public partial class ToolManagementDialog : Form
    {
        private Tool _toolToSelect;

        public ToolManagementDialog()
        {
            InitializeComponent();

            toolLibraryView1.LibraryRefreshStarted += toolLibraryView1_LibraryRefreshStarted;
            toolLibraryView1.LibraryRefreshFinished += toolLibraryView1_LibraryRefreshFinished;
        }

        void toolLibraryView1_LibraryRefreshStarted(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "reloading library...";
            toolStripProgressBar.Visible = true;
        }

        private void toolLibraryView1_LibraryRefreshFinished(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "library loaded ok!";
            toolStripProgressBar.Visible = false;

            if (_toolToSelect != null) {
                toolLibraryView1.SelectTool(_toolToSelect);
            }
        }

        private void ToolManagementDialog_Load(object sender, EventArgs e)
        {
        }

    }
}
