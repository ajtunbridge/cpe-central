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
    public partial class CalibrationShellDialog : Form
    {
        public CalibrationShellDialog()
        {
            InitializeComponent();
        }

        public CalibrationShellDialog(UserControl view) : this()
        {
            Controls.Add(view);
            view.Dock = DockStyle.Fill;
        }
    }
}
