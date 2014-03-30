#region Using directives

using System;
using System.Windows.Forms;

#endregion

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
            const double sin60 = 0.866;

            double dia = (double) acrossFlatsNumericUpDown.Value/sin60;

            minimumDiameterLabel.Text = dia.ToString("Ø##0.000");
        }
    }
}