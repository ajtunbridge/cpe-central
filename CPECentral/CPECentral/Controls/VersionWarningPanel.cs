using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPECentral.Controls
{
    public partial class VersionWarningPanel : UserControl
    {
        public VersionWarningPanel()
        {
            InitializeComponent();
        }

        private void VersionWarningPanel_Resize(object sender, EventArgs e)
        {
            centralPanel.Left = (Width - centralPanel.Width)/2;
            centralPanel.Top = (Height - centralPanel.Height)/2;
        }

        private void dismissButton_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
