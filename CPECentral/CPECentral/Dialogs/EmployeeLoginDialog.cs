#region Using directives

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using nGenLibrary.Security;

#endregion

namespace CPECentral.Dialogs
{
    public partial class EmployeeLoginDialog : Form
    {
        private readonly Employee _employeeToLogin;

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;

        private bool _capsLockWasOn = false;

        public EmployeeLoginDialog(Employee employeeToLogin)
        {
            InitializeComponent();

            _employeeToLogin = employeeToLogin;

            employeeNameLabel.Text = string.Format("Logging in as {0}", _employeeToLogin);

            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
                    (UIntPtr)0);
                _capsLockWasOn = true;
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
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

        private void EmployeeLoginDialog_Load(object sender, EventArgs e)
        {
        }

        private void EmployeeLoginDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_capsLockWasOn)
            {
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
                    (UIntPtr)0);
            }
        }
    }
}