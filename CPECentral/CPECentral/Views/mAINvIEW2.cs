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
    public interface IMainView2 : IView
    {
        event EventHandler RetrieveEmployeeAccounts;

        void PopulateSwitchUserDropDownButton(IEnumerable<Employee> employees);
    }

    public sealed partial class MainView2 : ViewBase, IMainView2
    {
        private readonly MainView2Presenter _presenter;

        private readonly List<EmployeeSessionView> _sessionViews = new List<EmployeeSessionView>();

        private bool _alreadyLoaded;

        public MainView2()
        {
            InitializeComponent();

            base.Dock = DockStyle.Fill;

            Font = Session.AppFont;

            if (!IsInDesignMode) {
                _presenter = new MainView2Presenter(this);

                Session.MessageBus.Subscribe<StatusUpdateMessage>(StatusUpdateMessage_Published);
                //Session.MessageBus.Subscribe<EmployeeLoggedInMessage>(EmployeeLoggedInMessage_Published);

                Session.DocumentService.Error += DocumentService_Error;
                Session.DocumentService.TransferStarted += DocumentService_TransferStarted;
                Session.DocumentService.TransferProgress += DocumentService_TransferProgress;
                Session.DocumentService.TransferComplete += DocumentService_TransferComplete;

                /*
                Session.MessageBus.Subscribe<PartEditedMessage>(message => {

                    foreach (TabPage page in flatTabControl.TabPages) {
                        if (page.Tag is Part) {
                            var part = page.Tag as Part;
                            if (part == message.EditedPart) {
                                page.Text = message.EditedPart.DrawingNumber;
                                return;
                            }
                        }
                    }
                });
               * */
            }
        }

        #region IMainView2 Members

        public event EventHandler RetrieveEmployeeAccounts;

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

        private void EmployeeLoggedInMessage_Published(EmployeeLoggedInMessage employeeLoggedInMessage)
        {
            if (employeeSessionPanel.Controls.Count == 1) {
                employeeSessionPanel.Controls.RemoveAt(0);
            }

            EmployeeSessionView sessionView =
                _sessionViews.SingleOrDefault(v => v.SessionEmployee == employeeLoggedInMessage.Employee);

            if (sessionView == null) {
                sessionView = new EmployeeSessionView(employeeLoggedInMessage.Employee);
                _sessionViews.Add(sessionView);
            }

            employeeSessionPanel.Controls.Add(sessionView);

            switchUserToolStripDropDownButton.Enabled = false;

            OnRetrieveEmployeeAccounts();
        }

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

        private void MainMenuStrip_ItemClicked(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem) sender;

            switch (menuItem.Name) {
                case "addNewPartToolStripMenuItem":
                    break;
                case "toolManagementToolStripMenuItem":
                    break;
                case "hexagonCalculatorToolStripMenuItem":
                    break;
                case "settingsToolStripMenuItem":
                    break;
                case "logoutToolStripMenuItem":
                    HandleLogout();
                    break;
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
                    //OnAddPart();
                    break;
                case "toolManagementToolStripButton":
                    //OnLoadToolManagementDialog();
                    break;
                case "logoutToolStripButton":
                    HandleLogout();
                    break;
            }
        }

        private void HandleLogout()
        {
            if (!DialogService.AskQuestion("Are you sure you want to logout?")) {
                return;
            }

            Session.CurrentEmployee = null;

            Session.MessageBus.Publish<EmployeeLoggedOutMessage>();
        }

        private void logoutToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void MainView2_Load(object sender, EventArgs e)
        {
            if (!IsInDesignMode) {
                if (!_alreadyLoaded) {
                    OnRetrieveEmployeeAccounts();

                    var sessionView = new EmployeeSessionView(Session.CurrentEmployee);
                    _sessionViews.Add(sessionView);
                    employeeSessionPanel.Controls.Add(sessionView);

                    _alreadyLoaded = true;
                }
            }
        }

        private void switchUserToolStripDropDownButton_DropDownItemClicked(object sender,
            ToolStripItemClickedEventArgs e)
        {
            var employee = e.ClickedItem.Tag as Employee;

            using (var passwordDialog = new SwitchEmployeeDialog(employee)) {
                if (passwordDialog.ShowDialog(ParentForm) != DialogResult.OK) {
                    return;
                }

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
            }
        }
    }
}