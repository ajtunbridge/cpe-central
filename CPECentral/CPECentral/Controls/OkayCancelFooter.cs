#region Using directives

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace CPECentral.Controls
{
    [DefaultEvent("OkayClicked")]
    public partial class OkayCancelFooter : UserControl
    {
        public OkayCancelFooter()
        {
            InitializeComponent();

            base.Dock = DockStyle.Bottom;
        }

        public event EventHandler OkayClicked;

        public event EventHandler CancelClicked;

        protected virtual void OnOkayClicked()
        {
            var handler = OkayClicked;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnCancelClicked()
        {
            var handler = CancelClicked;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            OnOkayClicked();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OnCancelClicked();
        }
    }
}