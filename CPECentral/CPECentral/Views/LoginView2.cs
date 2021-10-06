#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.Properties;

#endregion

namespace CPECentral.Views
{
    public interface ILoginView2 : IView
    {
        event EventHandler LoadEmployees;
        void DisplayEmployees(IEnumerable<Employee> employees);
    }

    public sealed partial class LoginView2 : ViewBase, ILoginView2
    {
        private readonly Login2Presenter _presenter;

        private readonly string[] _timeMessages = {
            "sorry. this appears to be taking a while...",
            "just a little bit longer....",
            "guess you're still running Windows XP?",
            "might as well go make yourself a cuppa..."
        };

        private int _timerTickCount;
        private Timer _tooLongTimer;

        public LoginView2()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new Login2Presenter(this);
                qmsWarningLabel.Visible = Session.QmsInUse;
            }
        }

        #region ILoginView2 Members

        public event EventHandler LoadEmployees;

        public void DisplayEmployees(IEnumerable<Employee> employees)
        {
            // shut down the application if we cannot connect to the server
            if (employees == null) {
                Application.Exit();
            }

            if (_tooLongTimer != null) {
                _timerTickCount = 0;
                _tooLongTimer.Dispose();
            }

            statusLabel.Visible = false;
            timeMessageLabel.Visible = false;
            preloaderPictureBox.Visible = false;
            appLogoPictureBox.Visible = true;

            loginIndicatorPictureBox.Visible = true;
            appLogoPictureBox.Visible = true;

            loginToolStripDropDownButton.DropDownItems.Clear();

            foreach (Employee employee in employees) {
                if (employee.UserName == "admin" || !employee.IsEnabled) {
                    continue;
                }

                var menuItem = new ToolStripMenuItem(employee.ToString());
                menuItem.Image = Resources.EmployeeIcon_32x32;
                menuItem.Tag = employee;
                loginToolStripDropDownButton.DropDownItems.Add(menuItem);
            }

            loginToolStripDropDownButton.Enabled = loginToolStripDropDownButton.DropDownItems.Count > 0;
        }

        #endregion

        private void OnLoadEmployees()
        {
            EventHandler handler = LoadEmployees;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void LoginView2_Resize(object sender, EventArgs e)
        {
            centralPanel.Top = ((Height - centralPanel.Height)/2);
            centralPanel.Left = (Width - centralPanel.Width)/2;
        }

        private void LoginView2_Load(object sender, EventArgs e)
        {
            OnLoadEmployees();

            _tooLongTimer = new Timer();

            _tooLongTimer.Interval = 6000;

            _tooLongTimer.Tick += (obj, args) => {
                if (_timerTickCount > _timeMessages.Length - 1) {
                    _timerTickCount = 0;
                    _tooLongTimer.Dispose();
                    return;
                }
                timeMessageLabel.Text = _timeMessages[_timerTickCount];
                _timerTickCount += 1;
            };

            _tooLongTimer.Start();
        }

        private void loginToolStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var employee = e.ClickedItem.Tag as Employee;

            //using (var passwordDialog = new EmployeeLoginDialog(employee)) {
            //    if (passwordDialog.ShowDialog(ParentForm) != DialogResult.OK) {
            //        return;
            //    }

                Session.CurrentEmployee = employee;

                Session.MessageBus.Publish(new EmployeeLoggedInMessage(employee));
            //}
        }

        private void gaugesView1_GaugeSelected(object sender, CustomEventArgs.GaugeEventArgs e)
        {
            MessageBox.Show(e.Gauge.Name);
        }
    }
}