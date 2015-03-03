﻿#region Using directives

using System;
using System.IO;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.Properties;
using nGenLibrary.IO;

#endregion

namespace CPECentral.Views
{
    public interface IMainView2 : IView
    {
        event EventHandler AddPart;
        event EventHandler<StringEventArgs> AddPartByWorksOrder;
        event EventHandler LoadHexagonCalculator;
        event EventHandler LoadSettingsDialog;
        event EventHandler LoadToolManagementDialog;
    }

    public sealed partial class MainView2 : ViewBase, IMainView
    {
        private readonly MainViewPresenter _presenter;

        public MainView2()
        {
            InitializeComponent();

            base.Dock = DockStyle.Fill;

            Font = Session.AppFont;
            /*
            if (!DesignMode) {

                _presenter = new MainViewPresenter(this);

                Session.MessageBus.Subscribe<StatusUpdateMessage>(StatusUpdateMessage_Published);

                Session.DocumentService.Error += DocumentService_Error;
                Session.DocumentService.TransferStarted += DocumentService_TransferStarted;
                Session.DocumentService.TransferProgress += DocumentService_TransferProgress;
                Session.DocumentService.TransferComplete += DocumentService_TransferComplete;
            }
             * */
        }

        #region IMainView Members

        public event EventHandler AddPart;
        public event EventHandler<StringEventArgs> AddPartByWorksOrder;
        public event EventHandler LoadHexagonCalculator;
        public event EventHandler LoadSettingsDialog;
        public event EventHandler LoadToolManagementDialog;

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

        private void OnAddPart()
        {
            EventHandler handler = AddPart;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnAddPartByWorksOrder(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = AddPartByWorksOrder;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnLoadHexagonCalculator()
        {
            EventHandler handler = LoadHexagonCalculator;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnLoadSettingsDialog()
        {
            EventHandler handler = LoadSettingsDialog;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnLoadToolManagementDialog()
        {
            EventHandler handler = LoadToolManagementDialog;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void MainMenuStrip_ItemClicked(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem) sender;

            switch (menuItem.Name) {
                case "addNewPartToolStripMenuItem":
                    OnAddPart();
                    break;
                case "toolManagementToolStripMenuItem":
                    OnLoadToolManagementDialog();
                    break;
                case "hexagonCalculatorToolStripMenuItem":
                    OnLoadHexagonCalculator();
                    break;
                case "settingsToolStripMenuItem":
                    OnLoadSettingsDialog();
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
                    OnAddPart();
                    break;
                case "toolManagementToolStripButton":
                    OnLoadToolManagementDialog();
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
    }
}