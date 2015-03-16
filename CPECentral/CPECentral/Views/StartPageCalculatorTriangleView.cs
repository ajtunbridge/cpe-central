#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace CPECentral.Views
{
    public partial class StartPageCalculatorTriangleView : ViewBase
    {
        public StartPageCalculatorTriangleView()
        {
            InitializeComponent();
        }

        private void oppTextBox_TextChanged(object sender, EventArgs e)
        {
            trianglePanel.Opposite = string.IsNullOrWhiteSpace(oppTextBox.Text)
                ? 0d
                : Convert.ToDouble(oppTextBox.Text);
        }

        private void adjTextBox_TextChanged(object sender, EventArgs e)
        {
            trianglePanel.Adjacent = string.IsNullOrWhiteSpace(adjTextBox.Text)
                ? 0d
                : Convert.ToDouble(adjTextBox.Text);
        }

        private void hypTextBox_TextChanged(object sender, EventArgs e)
        {
            trianglePanel.Hypotenuse = string.IsNullOrWhiteSpace(hypTextBox.Text)
                ? 0d
                : Convert.ToDouble(hypTextBox.Text);
        }

        private void angleATextBox_TextChanged(object sender, EventArgs e)
        {
            trianglePanel.AngleA = string.IsNullOrWhiteSpace(angleATextBox.Text)
                ? 0d
                : Convert.ToDouble(angleATextBox.Text);
        }

        private void angleBTextBox_TextChanged(object sender, EventArgs e)
        {
            trianglePanel.AngleB = string.IsNullOrWhiteSpace(angleBTextBox.Text)
                ? 0d
                : Convert.ToDouble(angleBTextBox.Text);
        }

        private void oppTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) {
                return;
            }

            if (char.IsNumber(e.KeyChar) || e.KeyChar == 46) {
                var textBox = (TextBox) sender;

                if (e.KeyChar == 46 && textBox.Text.Contains(".")) {
                    e.Handled = true;
                }

                if (textBox.Text.Contains(".")) {
                    int decimalPlaces = textBox.Text.Length - textBox.Text.IndexOf(".");
                    if (decimalPlaces == 4) {
                        e.Handled = true;
                    }
                }
                else {
                    if (textBox.Text.Length == 4 && e.KeyChar != 46) {
                        e.Handled = true;
                    }
                }

                return;
            }

            e.Handled = true;
        }

        private void goResetButton_Click(object sender, EventArgs e)
        {
            if (goResetButton.Text == "Go") {
                trianglePanel.SolveTriangle();
                goResetButton.Text = "Reset";
                foreach (Control c in tableLayoutPanel.Controls) {
                    if (c.GetType() == typeof (TextBox)) {
                        c.Enabled = false;
                    }
                }
            }
            else {
                goResetButton.Text = "Go";

                oppTextBox.Text = string.Empty;
                adjTextBox.Text = string.Empty;
                hypTextBox.Text = string.Empty;
                angleATextBox.Text = string.Empty;
                angleBTextBox.Text = string.Empty;

                trianglePanel.Opposite = 0d;
                trianglePanel.Adjacent = 0d;
                trianglePanel.Hypotenuse = 0d;
                trianglePanel.AngleA = 0d;
                trianglePanel.AngleB = 0d;

                foreach (Control c in tableLayoutPanel.Controls) {
                    if (c.GetType() == typeof (TextBox)) {
                        c.Enabled = true;
                    }
                }

                oppTextBox.Focus();
            }
        }
    }
}