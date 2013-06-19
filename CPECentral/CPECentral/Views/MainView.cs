﻿#region Using directives

using System;
using System.IO;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using nGenLibrary.IO;

#endregion

namespace CPECentral.Views
{
    public interface IMainView : IView
    {
        event EventHandler AddPart;
    }

    public partial class MainView : ViewBase, IMainView
    {
        private readonly MainViewPresenter _presenter;

        public MainView()
        {
            InitializeComponent();
            base.Dock = DockStyle.Fill;

            if (!DesignMode)
            {
                _presenter = new MainViewPresenter(this);

                Session.DocumentService.Error += DocumentService_Error;
                Session.DocumentService.TransferStarted += DocumentService_TransferStarted;
                Session.DocumentService.TransferProgress += DocumentService_TransferProgress;
                Session.DocumentService.TransferComplete += DocumentService_TransferComplete;
            }
        }

        void DocumentService_Error(object sender, ExceptionEventArgs e)
        {
            string message;

            if (e.Exception is DataProviderException)
                message = e.Exception.Message;
            else
                message = e.Exception.InnerException == null ? e.Exception.Message : e.Exception.InnerException.Message;

            Invoke((MethodInvoker) (() => DialogService.ShowError(message)));
        }

        #region IMainView Members

        public event EventHandler AddPart;

        #endregion

        protected virtual void OnAddPart()
        {
            var handler = AddPart;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void partLibraryView_PartSelected(object sender, PartEventArgs e)
        {
            if (librarySelectionPanel.Controls.Count == 1)
            {
                if (librarySelectionPanel.Controls[0].GetType() == typeof (PartView))
                {
                    var existingView = (PartView) librarySelectionPanel.Controls[0];
                    existingView.LoadPart(e.Part);
                    return;
                }
            }

            var partView = new PartView();

            using (NoFlicker.On(librarySelectionPanel))
            {
                librarySelectionPanel.Controls.Clear();
                librarySelectionPanel.Controls.Add(partView);
            }

            partView.LoadPart(e.Part);
        }

        private void partLibraryView_CustomerSelected(object sender, CustomerEventArgs e)
        {
            var customerView = new CustomerView(e.Customer);

            using (NoFlicker.On(librarySelectionPanel))
            {
                librarySelectionPanel.Controls.Clear();
                librarySelectionPanel.Controls.Add(customerView);
            }
        }

        private void MainMenuStrip_ItemClicked(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem) sender;

            switch (menuItem.Name)
            {
                case "addNewPartToolStripMenuItem":
                    OnAddPart();
                    break;
            }
        }

        private void DocumentService_TransferComplete(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Visible = false;
                toolStripStatusLabel.Text = "Upload complete";
            });
        }

        private CopyFileCallbackAction DocumentService_TransferProgress(string fileName, string destinationDirectory,
                                                                        int percentComplete)
        {
            Invoke((MethodInvoker) delegate
                {
                    toolStripProgressBar.Value = percentComplete > 100 ? 100 : percentComplete;
                });

            return CopyFileCallbackAction.Continue;
        }

        private void DocumentService_TransferStarted(object sender, TransferStartedEventArgs e)
        {
            Invoke((MethodInvoker) delegate
                {
                    toolStripProgressBar.Visible = true;
                    toolStripStatusLabel.Text = "Uploading " + Path.GetFileName(e.FileName);
                });
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "logoutToolStripButton":
                    HandleLogout();
                    break;
            }
        }

        private void HandleLogout()
        {
            if (!DialogService.AskQuestion("Are you sure you want to logout?"))
                return;

            Session.CurrentEmployee = null;

            Session.MessageBus.Publish<EmployeeLoggedOutMessage>();
        }
    }
}