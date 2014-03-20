#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.Properties;

#endregion

namespace CPECentral.Views
{
    public interface ILoginView : IView
    {
        string UserName { get; set; }
        string Password { get; }

        event EventHandler Login;

        void LoginComplete(Employee employee);
    }

    public partial class LoginView : ViewBase, ILoginView
    {
        private readonly LoginViewPresenter _presenter;

        public LoginView()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            if (!IsInDesignMode) {
                _presenter = new LoginViewPresenter(this);
            }
        }

        #region ILoginView Members

        public string UserName
        {
            get { return userNameTextBox.Text.Trim(); }
            set { userNameTextBox.Text = value; }
        }

        public string Password
        {
            get { return passwordTextBox.Text.Trim(); }
        }

        public event EventHandler Login;

        public void LoginComplete(Employee employee)
        {
            if (employee == null) {
                preloaderPictureBox.Visible = false;
                verifyingLabel.Visible = false;

                userNameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                loginButton.Enabled = true;

                userNameTextBox.SelectAll();
                userNameTextBox.Focus();

                return;
            }

            Session.MessageBus.Publish(new EmployeeLoggedInMessage(employee));
        }

        #endregion

        protected virtual void OnLogin()
        {
            var handler = Login;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void LoginView_Resize(object sender, EventArgs e)
        {
            centralPanel.Top = ((Height - centralPanel.Height)/2) - preloaderPictureBox.Height;
            centralPanel.Left = (Width - centralPanel.Width)/2;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            var lastUserName = Settings.Default.LastUserName;

            if (string.IsNullOrWhiteSpace(lastUserName)) {
                return;
            }

            userNameTextBox.Text = lastUserName;
        }

        private void TextBoxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                DoLogin();
            }
        }

        private void DoLogin()
        {
            preloaderPictureBox.Visible = true;
            verifyingLabel.Visible = true;

            userNameTextBox.Enabled = false;
            passwordTextBox.Enabled = false;
            loginButton.Enabled = false;

            OnLogin();
        }

        private void passwordTextBox_EnterKeyPressed(object sender, EventArgs e)
        {
            DoLogin();
        }
    }
}