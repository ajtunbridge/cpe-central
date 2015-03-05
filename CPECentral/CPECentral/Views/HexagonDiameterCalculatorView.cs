#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace CPECentral.Views
{
    public partial class HexagonDiameterCalculatorView : UserControl
    {
        public HexagonDiameterCalculatorView()
        {
            InitializeComponent();
        }

        private void acrossFlatsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            const double sin60 = 0.866;

            double dia = (double) acrossFlatsNumericUpDown.Value/sin60;

            string value = dia.ToString("Ø##0.00");

            hexagonDiameterPanel1.Diameter = value;
        }

        private void HexagonDiameterCalculatorView_SizeChanged(object sender, EventArgs e)
        {
            hexagonPanel1.Invalidate();
        }
    }
}