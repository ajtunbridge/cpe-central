﻿#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
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
            Font = Settings.Default.AppFont;

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime) {
                Session.MessageBus.Subscribe<EmployeeSwitchedMessage>(msg => Text = "CPE Central: Logged in as " + msg.Employee);
            }
        }

        private void ShowLoginView()
        {
            using (NoFlicker.On(this)) {
                Controls.Clear();

                var loginView = new LoginView2();
                loginView.TabIndex = 0;
                loginView.Dock = DockStyle.Fill;
                Controls.Add(loginView);
            }
        }

        private void ShowMainView()
        {
            using (NoFlicker.On(this)) {
                Controls.Clear();

                var mainView = new MainView();

                Controls.Add(mainView);

                mainView.Select();
                mainView.Focus();
            }
        }

        private void EmployeeLoggedInMessage_Published(EmployeeLoggedInMessage message)
        {
            if (InvokeRequired) {
                Invoke((MethodInvoker) (() => EmployeeLoggedInMessage_Published(message)));
                return;
            }

            Session.CurrentEmployee = message.Employee;

            Text = "CPE Central: Logged in as " + Session.CurrentEmployee;

            ShowMainView();
        }

        private void EmployeeLoggedOutMessage_Published(EmployeeLoggedOutMessage message)
        {
            if (InvokeRequired) {
                Invoke((MethodInvoker) (() => EmployeeLoggedOutMessage_Published(message)));
                return;
            }

            List<Form> formsToClose = (from Form f in Application.OpenForms where !f.Equals(this) select f).ToList();

            formsToClose.ForEach(f => f.Close());

            Session.CurrentEmployee = null;

            Text = "CPE Central";

            ShowLoginView();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // set SynchronizationContext to allow document service to show dialogs on main UI thread
            Session.DocumentService.SyncContext = SynchronizationContext.Current;

            ShowLoginView();

            Location = Settings.Default.MainFormLocation;
            Size = Settings.Default.MainFormSize;
            WindowState = Settings.Default.MainFormState;

            Session.MessageBus.Subscribe<EmployeeLoggedInMessage>(EmployeeLoggedInMessage_Published);
            Session.MessageBus.Subscribe<EmployeeLoggedOutMessage>(EmployeeLoggedOutMessage_Published);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.MainFormState = WindowState;

            if (WindowState != FormWindowState.Maximized && WindowState != FormWindowState.Minimized) {
                Settings.Default.MainFormLocation = Location;
                Settings.Default.MainFormSize = Size;
            }

            Settings.Default.Save();
        }
    }
}