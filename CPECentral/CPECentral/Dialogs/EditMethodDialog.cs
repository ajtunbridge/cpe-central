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
    public partial class EditMethodDialog : Form
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();

        public EditMethodDialog()
        {
            InitializeComponent();
        }

        public EditMethodDialog(Method methodToEdit)
        {
            InitializeComponent();

            descriptionTextBox.Text = methodToEdit.Description;
            isPreferredMethodCheckBox.Checked = methodToEdit.IsPreferred;
        }

        public string Description
        {
            get { return descriptionTextBox.Text; }
        }

        public bool IsPreferred
        {
            get { return isPreferredMethodCheckBox.Checked; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                OkayCancelFooter_OkayClicked(okayCancelFooter, EventArgs.Empty);
            }
            else if (keyData == Keys.Escape)
            {
                OkayCancelFooter_CancelClicked(okayCancelFooter, EventArgs.Empty);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OkayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                const string noDescriptionMessage = "You must provide a description of this method!";

                _dialogService.Notify(noDescriptionMessage);

                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void OkayCancelFooter_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
