#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.Properties;
using nGenLibrary.IO;

#endregion

namespace CPECentral.Views
{
    public interface IMainView : IView
    {
        event EventHandler RetrieveEmployeeAccounts;
        event EventHandler AddNewPart;
        event EventHandler LoadToolManagementDialog;
        event EventHandler LoadSettingsDialog;
        event EventHandler LoadSuperDumpDialog;

        void PopulateSwitchUserDropDownButton(IEnumerable<Employee> employees);
    }

    public sealed partial class MainView : ViewBase, IMainView
    {
        private readonly MainPresenter _presenter;

        private readonly List<EmployeeSessionView> _sessionViews = new List<EmployeeSessionView>();

        private bool _alreadyLoaded;

        public MainView()
        {
            InitializeComponent();

            base.Dock = DockStyle.Fill;

            Font = Session.AppFont;

            if (!IsInDesignMode) {
                _presenter = new MainPresenter(this);

                if (!Settings.Default.ShowSuperDump)
                {
                    superDumpToolStripButton.Visible = false;
                }

                Session.MessageBus.Subscribe<StatusUpdateMessage>(StatusUpdateMessage_Published);
                Session.DocumentService.Error += DocumentService_Error;
                Session.DocumentService.TransferStarted += DocumentService_TransferStarted;
                Session.DocumentService.TransferProgress += DocumentService_TransferProgress;
                Session.DocumentService.TransferComplete += DocumentService_TransferComplete;
            }
        }

        #region IMainView Members

        public event EventHandler RetrieveEmployeeAccounts;
        public event EventHandler AddNewPart;
        public event EventHandler LoadToolManagementDialog;
        public event EventHandler LoadSettingsDialog;
        public event EventHandler LoadSuperDumpDialog;

        public void PopulateSwitchUserDropDownButton(IEnumerable<Employee> employees)
        {
            switchUserToolStripDropDownButton.DropDownItems.Clear();

            foreach (Employee employee in employees) {
                if (employee.UserName == "admin" || employee == Session.CurrentEmployee) {
                    //continue;
                }
                var menuItem = new ToolStripMenuItem(employee.ToString());
                menuItem.Image = Resources.EmployeeIcon_32x32;
                menuItem.Tag = employee;
                switchUserToolStripDropDownButton.DropDownItems.Add(menuItem);
            }

            switchUserToolStripDropDownButton.Enabled = switchUserToolStripDropDownButton.DropDownItems.Count > 0;
        }

        #endregion

        private void StatusUpdateMessage_Published(StatusUpdateMessage message)
        {
            if (InvokeRequired) {
                mainStatusStrip.InvokeEx(() => StatusUpdateMessage_Published(message));
                return;
            }

            mainToolStripStatusLabel.Text = message.Status;
        }

        private void DocumentService_Error(object sender, ExceptionEventArgs e)
        {
            string message;

            if (e.Exception is DataProviderException) {
                message = e.Exception.Message;
            }
            else {
                message = e.Exception.InnerException == null ? e.Exception.Message : e.Exception.InnerException.Message;
            }

            Invoke((MethodInvoker) (() => DialogService.ShowError(message)));
        }


        private void OnRetrieveEmployeeAccounts()
        {
            EventHandler handler = RetrieveEmployeeAccounts;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnAddNewPart()
        {
            EventHandler handler = AddNewPart;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnLoadToolManagementDialog()
        {
            EventHandler handler = LoadToolManagementDialog;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnLoadSettingsDialog()
        {
            EventHandler handler = LoadSettingsDialog;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void DocumentService_TransferComplete(object sender, EventArgs e)
        {
            Invoke((MethodInvoker) delegate {
                documentTransferToolStripProgressBar.Value = 0;
                documentTransferToolStripProgressBar.Visible = false;
                documentTransferStatusLabel.Text = "No documents pending upload";
            });
        }

        private CopyFileCallbackAction DocumentService_TransferProgress(string fileName, string destinationDirectory,
            int percentComplete)
        {
            Invoke(
                (MethodInvoker)
                    delegate {
                        documentTransferToolStripProgressBar.Value = percentComplete > 100 ? 100 : percentComplete;
                    });

            return CopyFileCallbackAction.Continue;
        }

        private void DocumentService_TransferStarted(object sender, TransferStartedEventArgs e)
        {
            Invoke((MethodInvoker) delegate {
                documentTransferToolStripProgressBar.Visible = true;
                documentTransferStatusLabel.Text = "Uploading " + Path.GetFileName(e.FileName);
            });
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addPartToolStripButton":
                    OnAddNewPart();
                    break;
                case "toolManagementToolStripButton":
                    OnLoadToolManagementDialog();
                    break;
                case "settingsToolStripButton":
                    OnLoadSettingsDialog();
                    break;
                case "superDumpToolStripButton":
                    OnLoadSuperDumpDialog();
                    break;
            }
        }

        private void HandleLogout()
        {
            if (MessageBox.Show("Are you sure you want to end your session?", "Confirm logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes)
            {
                return;
            }

            Session.MessageBus.Publish<EmployeeLoggedOutMessage>();
        }

        private void logoutToolStripButton_Click(object sender, EventArgs e)
        {
            HandleLogout();
        }

        private void MainView2_Load(object sender, EventArgs e)
        {
            if (!IsInDesignMode) {
                if (!_alreadyLoaded) {
                    OnRetrieveEmployeeAccounts();

                    var sessionView = new EmployeeSessionView(Session.CurrentEmployee);
                    _sessionViews.Add(sessionView);

                    using (NoFlicker.On(this)) {
                        employeeSessionPanel.Controls.Add(sessionView);
                    }

                    _alreadyLoaded = true;
                }
            }
        }

        private void switchUserToolStripDropDownButton_DropDownItemClicked(object sender,
            ToolStripItemClickedEventArgs e)
        {
            var employee = e.ClickedItem.Tag as Employee;

            using (var passwordDialog = new EmployeeLoginDialog(employee)) {
                if (passwordDialog.ShowDialog(ParentForm) != DialogResult.OK) {
                    return;
                }

                Session.CurrentEmployee = employee;

                using (NoFlicker.On(this)) {
                    if (employeeSessionPanel.Controls.Count == 1) {
                        employeeSessionPanel.Controls.RemoveAt(0);
                    }

                    EmployeeSessionView sessionView = _sessionViews.SingleOrDefault(v => v.SessionEmployee == employee);

                    if (sessionView == null) {
                        sessionView = new EmployeeSessionView(employee);
                        _sessionViews.Add(sessionView);
                    }

                    employeeSessionPanel.Controls.Add(sessionView);

                    switchUserToolStripDropDownButton.Enabled = false;

                    OnRetrieveEmployeeAccounts();

                    Session.MessageBus.Publish(new EmployeeSwitchedMessage(employee));
                }
            }
        }

        private void OnLoadSuperDumpDialog()
        {
            LoadSuperDumpDialog?.Invoke(this, EventArgs.Empty);
        }
    }
}