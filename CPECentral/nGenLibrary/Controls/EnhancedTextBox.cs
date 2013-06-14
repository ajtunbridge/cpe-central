using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nGenLibrary.Controls
{
    public partial class EnhancedTextBox : TextBox
    {
        public EnhancedTextBox()
        {
            InitializeComponent();
        }

        [Category("Behavior")]
        [Description("If true, the user cannot enter two spaces next to each other")]
        public bool DisableDoubleSpace { get; set; }

        private void EnhancedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DisableDoubleSpace)
            {
                if (Text.Length > 1)
                {
                    var previousChar = Text[Text.Length - 1];

                    if (previousChar == 32 && e.KeyChar == 32)
                        e.Handled = true;
                }
            }
        }
    }
}
