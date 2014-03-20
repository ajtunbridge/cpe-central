#region Using directives

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace nGenLibrary.Controls
{
    public partial class EnhancedTextBox : TextBox
    {
        public EnhancedTextBox()
        {
            InitializeComponent();
        }

        [Category("Key")]
        [Description("Fired when not multiline and the enter key is pressed")]
        public event EventHandler EnterKeyPressed;

        [Category("Behavior")]
        [Description("If true, there cannot be a space at the start of the text")]
        public bool DisableLeadingSpace { get; set; }

        [Category("Behavior")]
        [Description("If true, the user cannot enter two spaces next to each other")]
        public bool DisableDoubleSpace { get; set; }

        [Category("Behavior")]
        [Description("Set to true to stop the 'ding' when pressing enter key")]
        public bool SuppressEnterKey { get; set; }

        [Category("Behavior")]
        [Description("Set to true to enable only numeric characters to be entered")]
        public bool NumericCharactersOnly { get; set; }

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

            if (NumericCharactersOnly) {
                if (e.KeyChar == 8 || char.IsDigit(e.KeyChar)) {
                    // do nothing
                }
                else {
                    e.Handled = true;
                }
            }

            if (e.KeyChar == 32 && DisableLeadingSpace && Text.Length == 0)
                e.Handled = true;
        }

        private void EnhancedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SuppressEnterKey)
                    e.SuppressKeyPress = true;

                if (!Multiline)
                    OnEnterKeyPressed();
            }
        }

        protected virtual void OnEnterKeyPressed()
        {
            EventHandler handler = EnterKeyPressed;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}