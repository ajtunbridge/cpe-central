#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace CPECentral.Dialogs
{
    public partial class NewVersionDialog : Form
    {
        public NewVersionDialog(string estimatedVersionNumber)
        {
            InitializeComponent();

            base.Font = Session.AppFont;

            newVersionNumberTextBox.Text = estimatedVersionNumber;
            newVersionNumberTextBox.SelectionStart = newVersionNumberTextBox.Text.Length;
        }

        public string VersionNumber
        {
            get { return newVersionNumberTextBox.Text.Trim(); }
        }

        public bool CopyMethodsAndOperations
        {
            get { return copyMethodsAndOperationsCheckBox.Checked; }
        }

        public bool CopyToolLists
        {
            get { return copyToolListsCheckBox.Checked; }
        }

        public bool CopyOperationDocuments
        {
            get { return copyOperationDocumentsCheckBox.Checked; }
        }

        private void copyOperationDocumentsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            const string warningMessage =
                "THIS IS A VERY DANGEROUS OPTION!\n\nOnly select this option if you know what you are doing and fully understand the implications of it!";

            if (copyOperationDocumentsCheckBox.Checked) {
                MessageBox.Show(warningMessage, "WARNING!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void copyMethodsAndOperationsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            copyToolListsCheckBox.Enabled = copyMethodsAndOperationsCheckBox.Checked;
            copyOperationDocumentsCheckBox.Enabled = copyMethodsAndOperationsCheckBox.Checked;
        }

        private void okayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void okayCancelFooter_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                okayCancelFooter_OkayClicked(okayCancelFooter, EventArgs.Empty);
            }
            else if (keyData == Keys.Escape)
            {
                okayCancelFooter_CancelClicked(okayCancelFooter, EventArgs.Empty);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}