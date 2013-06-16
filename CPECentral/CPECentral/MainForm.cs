#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.Messages;
using CPECentral.Properties;
using CPECentral.Views;

#endregion

namespace CPECentral
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                //cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void ShowLoginView()
        {
            Controls.Clear();

            var loginView = new LoginView();

            Controls.Add(loginView);

            loginView.Focus();
        }

        private void ShowMainView()
        {
            Controls.Clear();

            var mainView = new MainView();

            Controls.Add(mainView);

            mainView.Focus();
        }

        private void EmployeeLoggedInMessage_Published(EmployeeLoggedInMessage message)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => EmployeeLoggedInMessage_Published(message)));
                return;
            }

            Session.CurrentEmployee = message.Employee;

            Text = "CPE Central: Logged in as " + Session.CurrentEmployee;

            ShowMainView();
        }

        private void EmployeeLoggedOutMessage_Published(EmployeeLoggedOutMessage message)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => EmployeeLoggedOutMessage_Published(message)));
                return;
            }

            Session.CurrentEmployee = null;

            Text = "CPE Central";

            ShowLoginView();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowLoginView();

            Location = Settings.Default.MainFormLocation;
            Size = Settings.Default.MainFormSize;
            WindowState = Settings.Default.MainFormState;

            Session.MessageBus.Subscribe<EmployeeLoggedInMessage>(EmployeeLoggedInMessage_Published);
            Session.MessageBus.Subscribe<EmployeeLoggedOutMessage>(EmployeeLoggedOutMessage_Published);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.MainFormLocation = Location;
            Settings.Default.MainFormSize = Size;
            Settings.Default.MainFormState = WindowState;

            Settings.Default.Save();
        }
    }
}