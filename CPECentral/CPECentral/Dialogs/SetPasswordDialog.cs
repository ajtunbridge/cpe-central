#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using nGenLibrary;
using nGenLibrary.Security;

#endregion

namespace CPECentral.Dialogs
{
    public partial class SetPasswordDialog : Form
    {
        private readonly IDialogService _dialogService;
        private readonly IPasswordService _passwordService;

        public SetPasswordDialog()
        {
            InitializeComponent();

            _passwordService = Session.GetInstanceOf<IPasswordService>();
            _dialogService = Session.GetInstanceOf<IDialogService>();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            string currentPassword = currentPasswordTextBox.Text;

            if (currentPassword.IsNullOrWhitespace()) {
                _dialogService.Notify("Please enter your current password!");
                currentPasswordTextBox.Select();
                return;
            }

            bool isCorrectPassword = _passwordService.AreEqual(currentPassword, Session.CurrentEmployee.Password,
                Session.CurrentEmployee.Salt);

            if (!isCorrectPassword) {
                _dialogService.ShowError("The current password you entered is incorrect!");
                currentPasswordTextBox.Select();
                currentPasswordTextBox.SelectAll();
                return;
            }

            string newPassword = newPasswordTextBox.Text;
            string confirmNewPassword = reenterPasswordTextBox.Text;

            if (newPassword != confirmNewPassword) {
                _dialogService.ShowError("The new passwords you entered do not match!");
                newPasswordTextBox.Select();
                newPasswordTextBox.SelectAll();
                return;
            }

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        Password securePassword = _passwordService.SecurePassword(newPassword);
                        Employee employee = cpe.Employees.GetById(Session.CurrentEmployee.Id);
                        employee.Password = securePassword.Hash;
                        employee.Salt = securePassword.Salt;
                        cpe.Employees.Update(employee);
                        cpe.Commit();
                        Session.CurrentEmployee = employee;
                    }
                }

                _dialogService.Notify("Your password has been changed successfully!");

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex) {
                string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                _dialogService.ShowError(msg);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}