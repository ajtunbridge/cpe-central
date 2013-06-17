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
    [DefaultEvent("OkayClicked")]
    public partial class OkayCancelFooter : UserControl
    {
        public event EventHandler OkayClicked;

        public event EventHandler CancelClicked;

        public OkayCancelFooter()
        {
            InitializeComponent();

            base.Dock = DockStyle.Bottom;
        }

        protected virtual void OnOkayClicked()
        {
            EventHandler handler = OkayClicked;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnCancelClicked()
        {
            EventHandler handler = CancelClicked;
            if (handler != null) handler(this, EventArgs.Empty);
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
