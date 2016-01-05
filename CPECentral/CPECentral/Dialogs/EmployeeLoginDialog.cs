#region Using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using nGenLibrary.Security;

#endregion

namespace CPECentral.Dialogs
{
    public partial class EmployeeLoginDialog : Form
    {
        private readonly Employee _employeeToLogin;

        public EmployeeLoginDialog(Employee employeeToLogin)
        {
            InitializeComponent();

            _employeeToLogin = employeeToLogin;

            employeeNameLabel.Text = string.Format("Logging in as {0}", _employeeToLogin);
        }

        private void okayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            var passwordService = Session.GetInstanceOf<IPasswordService>();

            if (passwordService.AreEqual(passwordEnhancedTextBox.Text, _employeeToLogin.Password,
                _employeeToLogin.Salt)) {
                DialogResult = DialogResult.OK;
            }
            else {
                var dialogService = Session.GetInstanceOf<IDialogService>();
                dialogService.ShowError("Access denied!\n\nThe password you entered was incorrect.");
            }
        }

        private void okayCancelFooter_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void passwordEnhancedTextBox_EnterKeyPressed(object sender, EventArgs e)
        {
            okayCancelFooter_OkayClicked(passwordEnhancedTextBox, EventArgs.Empty);
        }

        private void passwordEnhancedTextBox_Enter(object sender, EventArgs e)
        {
        }

        private void EmployeeLoginDialog_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }
    }
}