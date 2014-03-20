#region Using directives

using System;
using System.ComponentModel;
using CPECentral.Data.EF5;
using CPECentral.Properties;
using CPECentral.Views;
using nGenLibrary.Security;

#endregion

namespace CPECentral.Presenters
{
    public sealed class LoginViewPresenter
    {
        private readonly ILoginView _loginView;
        private BackgroundWorker _loginWorker;

        public LoginViewPresenter(ILoginView loginView)
        {
            _loginView = loginView;

            _loginView.Login += LoginView_Login;
        }

        private void LoginView_Login(object sender, EventArgs e)
        {
            _loginWorker = new BackgroundWorker();
            _loginWorker.WorkerSupportsCancellation = true;
            _loginWorker.DoWork += LoginWorker_DoWork;
            _loginWorker.RunWorkerCompleted += LoginWorker_RunWorkerCompleted;

            var args = new LoginArgs(_loginView.UserName, _loginView.Password);

            _loginWorker.RunWorkerAsync(args);
        }

        private void LoginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                _loginView.LoginComplete(null);
                return;
            }

            if (e.Result == null) {
                _loginView.LoginComplete(null);
                return;
            }

            var employee = (Employee) e.Result;

            Settings.Default.LastUserName = employee.UserName;
            Settings.Default.Save();

            _loginView.LoginComplete(employee);
        }

        private void LoginWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (LoginArgs) e.Argument;

            try {
                var uow = new UnitOfWork();

                var employee = uow.Employees.GetByUserName(args.UserName);

                if (employee == null) {
                    _loginView.DialogService.ShowError("There is no account associated with the user name you entered!");
                    return;
                }

                var passwordService = Session.GetInstanceOf<IPasswordService>();

                var passwordOk = passwordService.AreEqual(args.Password, employee.Password, employee.Salt);

                if (!passwordOk) {
                    _loginView.DialogService.ShowError("The password you provided does not match the one on record!");
                    return;
                }

                e.Result = employee;
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private void HandleException(Exception ex)
        {
            string message;

            if (ex is DataProviderException) {
                message = ex.Message;
            }
            else {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _loginView.DialogService.ShowError(message);
        }

        #region Nested type: LoginArgs

        private class LoginArgs
        {
            public LoginArgs(string userName, string password)
            {
                UserName = userName;
                Password = password;
            }

            public string UserName { get; private set; }
            public string Password { get; private set; }
        }

        #endregion
    }
}