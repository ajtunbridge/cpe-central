﻿#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Properties;
using nGenLibrary;

#endregion

namespace CPECentral.Dialogs
{
    public partial class AddPartDialog : Form
    {
        private readonly IDialogService _dialogService;
        private bool _isScanningForFiles;
        private BackgroundWorker _scanServerWorker;

        public AddPartDialog()
        {
            InitializeComponent();

            if (!DesignMode)
                _dialogService = Session.GetInstanceOf<IDialogService>();
        }

        public bool IsNewCustomer
        {
            get { return isNewCustomerCheckBox.Checked; }
        }

        public Customer SelectedCustomer
        {
            get
            {
                if (isNewCustomerCheckBox.Checked)
                    return null;

                return (Customer) customerComboBox.SelectedItem;
            }
        }

        public string NewCustomerName
        {
            get { return newCustomerNameTextBox.Text.Trim(); }
        }

        public string DrawingNumber
        {
            get { return drawingNumberTextBox.Text; }
        }

        public string PartName
        {
            get { return nameTextBox.Text.Trim(); }
        }

        public string VersionNumber
        {
            get { return versionTextBox.Text.Trim(); }
        }

        public string ToolingLocation
        {
            get { return toolingLocationTextBox.Text.Trim(); }
        }

        public IEnumerable<string> FilesToImport
        {
            get { return from ListViewItem item in filesListView.CheckedItems select (string) item.Tag; }
        }

        private void LoadCustomers()
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    using (BusyCursor.Show())
                    {
                        var customers = uow.Customers.GetAll().OrderBy(c => c.Name);

                        customerComboBox.Items.AddRange(customers.ToArray());

                        if (customerComboBox.Items.Count == 0)
                        {
                            isNewCustomerCheckBox.Checked = true;
                            isNewCustomerCheckBox.Enabled = false;
                        }
                        else
                        {
                            customerComboBox.SelectedIndex = 0;
                            drawingNumberTextBox.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                    _dialogService.ShowError(msg);

                    Close();
                }
            }
        }

        private void OkayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            if (IsNewCustomer && string.IsNullOrWhiteSpace(NewCustomerName))
            {
                _dialogService.ShowError("The name of the customer must be provided!");
                return;
            }

            if (string.IsNullOrWhiteSpace(DrawingNumber))
            {
                _dialogService.ShowError("A drawing number must be provided!");
                return;
            }

            if (string.IsNullOrWhiteSpace(PartName))
            {
                _dialogService.ShowError("The name of this part must be provided!");
                return;
            }

            if (string.IsNullOrWhiteSpace(VersionNumber))
            {
                _dialogService.ShowError("A version number must be provided!");
                return;
            }

            if (filesListView.CheckedCount > 0)
            {
                const string question = "Have you verified these files are the correct version?";

                if (!_dialogService.AskQuestion(question))
                    return;
            }

            DialogResult = DialogResult.OK;
        }

        private void OkayCancelFooter_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                OkayCancelFooter_OkayClicked(okayCancelFooter, EventArgs.Empty);
            }
            else if (keyData == Keys.Escape)
            {
                OkayCancelFooter_CancelClicked(okayCancelFooter, EventArgs.Empty);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AddPartDialog_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void IsNewCustomerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isNewCustomerCheckBox.Checked)
            {
                newCustomerNameTextBox.BringToFront();
                newCustomerNameTextBox.Focus();
            }
            else
            {
                customerComboBox.BringToFront();
                drawingNumberTextBox.Focus();
            }
        }

        private void ScanServerButton_Click(object sender, EventArgs e)
        {
            if (_isScanningForFiles)
            {
                _scanServerWorker.CancelAsync();
                scanServerButton.Text = "Cancelling...";
                scanServerButton.Enabled = false;

                return;
            }

            _isScanningForFiles = true;

            if (string.IsNullOrWhiteSpace(drawingNumberTextBox.Text))
            {
                _dialogService.Notify("You need to enter a drawing number before scanning for files!");
                return;
            }

            filesListView.Items.Clear();

            scanServerButton.Text = "Cancel";

            progressBar.Style = ProgressBarStyle.Marquee;

            _scanServerWorker = new BackgroundWorker();
            _scanServerWorker.WorkerSupportsCancellation = true;
            _scanServerWorker.DoWork += ScanServerWorker_DoWork;
            _scanServerWorker.RunWorkerCompleted += ScanServerWorker_RunWorkerCompleted;

            _scanServerWorker.RunWorkerAsync(searchTermTextBox.Text.Trim());
        }

        private void ScanServerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var scanDir = Settings.Default.ServerScanDirectory;

            var searchPattern = "*" + (string) e.Argument + "*";

            var dirStack = new Stack<string>();
            dirStack.Push(scanDir);

            var validExtensions = Settings.Default.DrawingFileExtensions.Split(new[] { "|" }, StringSplitOptions.None);

            while (dirStack.Count > 0)
            {
                if (_scanServerWorker.CancellationPending)
                    return;

                var currentDir = dirStack.Pop();

                var subDirs = Directory.GetDirectories(currentDir);

                if (_scanServerWorker.CancellationPending)
                    return;

                foreach (var subDir in subDirs)
                {
                    dirStack.Push(subDir);
                }

                if (_scanServerWorker.CancellationPending)
                    return;

                var matches = Directory.GetFiles(currentDir, searchPattern)
                    .Where(fileName =>
                        {
                            var ext = Path.GetExtension(fileName);
                            return validExtensions.Any(validExt => validExt.Equals(ext, StringComparison.OrdinalIgnoreCase));
                        });

                filesListView.Invoke((MethodInvoker) delegate
                    {
                        foreach (var match in matches)
                        {
                            filesListView.AddFile(match, match);
                        }
                    });

                if (_scanServerWorker.CancellationPending)
                    return;
            }
        }

        private void ScanServerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _isScanningForFiles = false;

            scanServerButton.Text = "Scan server for drawings and models";
            scanServerButton.Enabled = true;
            progressBar.Style = ProgressBarStyle.Blocks;

            filesListView.Sort();
        }

        private void FilesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filesListView.SelectionCount == 0)
            {
                filePreviewPanel.Clear();
                return;
            }

            if (filesListView.SelectionCount == 1)
            {
                var fileName = (string) filesListView.SelectedItems[0].Tag;
                filePreviewPanel.ShowFile(fileName);
            }
        }

        private void DrawingNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            searchTermTextBox.Text = drawingNumberTextBox.Text;
        }
    }
}