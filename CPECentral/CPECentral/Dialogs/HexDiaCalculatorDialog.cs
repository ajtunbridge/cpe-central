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
    public partial class HexDiaCalculatorDialog : Form
    {
        public HexDiaCalculatorDialog()
        {
            InitializeComponent();
        }

        private void HexDiaCalculatorDialog_Load(object sender, EventArgs e)
        {

        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acrossFlatsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var figure = Math.Sin(60);

            var dia = (double)acrossFlatsNumericUpDown.Value * figure;

            minimumDiameterLabel.Text = dia.ToString("0:0.000");
        }
    }
}
