#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using nGenLibrary.Security;

#endregion

namespace CPECentral.Dialogs
{
    public partial class SwitchEmployeeDialog : Form
    {
        private readonly Employee _employeeToSwitchTo;

        public SwitchEmployeeDialog(Employee employeeToSwitchTo)
        {
            InitializeComponent();

            _employeeToSwitchTo = employeeToSwitchTo;

            employeeNameLabel.Text = string.Format("Switching to {0}", _employeeToSwitchTo);
        }

        private void okayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            var passwordService = Session.GetInstanceOf<IPasswordService>();

            if (passwordService.AreEqual(passwordEnhancedTextBox.Text, _employeeToSwitchTo.Password,
                _employeeToSwitchTo.Salt)) {
                //Session.MessageBus.Publish(new EmployeeLoggedInMessage(_employeeToSwitchTo));

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
    }
}