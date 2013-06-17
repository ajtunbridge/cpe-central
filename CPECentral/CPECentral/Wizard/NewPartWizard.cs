#region Using directives

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Wizard
{
    public partial class NewPartWizard : Form
    {
        private readonly IDialogService _dialogService;
        private readonly Size _partInformationPageFormSize = new Size(370, 390);
        private readonly Size _versionDocumentsPageFormSize = new Size(500, 480);
        private readonly Size _summaryPageFormSize = new Size(430, 480);

        private BackgroundWorker _fileSearchBackgroundWorker;

        public NewPartWizard()
        {
            InitializeComponent();

            Size = _partInformationPageFormSize;
            CentralizeFormToParent();

            _dialogService = Session.GetInstanceOf<IDialogService>();
        }

        private void WizardPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wizardPages.SelectedTab.Name == "partInformationPage")
                Size = _partInformationPageFormSize;

            switch (wizardPages.SelectedTab.Name)
            {
                case "partInformationPage":
                    Size = _partInformationPageFormSize;
                    break;
                case "scanForDocumentsPage":
                    Size = _versionDocumentsPageFormSize;
                    break;
                case "summaryPage":
                    Size = _summaryPageFormSize;
                    UpdateSummaryPage();
                    break;
            }

            CentralizeFormToParent();

            var isOnFirstPage = wizardPages.SelectedIndex == 0;
            var isOnLastPage = wizardPages.SelectedIndex == wizardPages.TabCount - 1;

            previousButton.Enabled = !isOnFirstPage;

            nextFinishButton.Text = isOnLastPage ? "Finish" : "Next";

            headerLabel.Text = wizardPages.SelectedTab.Text;
        }

        private void NextFinishButton_Click(object sender, EventArgs e)
        {
            if (nextFinishButton.Text == "Finish")
            {
                return;
            }

            var goToNextPage = true;

            switch (wizardPages.SelectedIndex)
            {
                case 0:
                    goToNextPage = PartInformationPageIsValid();
                    break;
                case 1:
                    if (filesListView.CheckedCount > 0)
                        goToNextPage = _dialogService.AskQuestion("Have you verified these files are for this version!");
                    break;
            }

            if (!goToNextPage)
                return;

            wizardPages.SelectedIndex = wizardPages.SelectedIndex + 1;
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            wizardPages.SelectedIndex = wizardPages.SelectedIndex - 1;
        }

        private void NewPartWizard_Load(object sender, EventArgs e)
        {
            Height -= 25;

            LoadCustomers();
        }

        private void IsNewCustomerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isNewCustomerCheckBox.Checked)
                customerTextBox.BringToFront();
            else
                customerComboBox.BringToFront();
        }

        private void scanOrCancelButton_Click(object sender, EventArgs e)
        {
            if (scanOrCancelButton.Text == "Scan")
            {
                filesListView.Items.Clear();

                progressBar.Style = ProgressBarStyle.Marquee;

                scanOrCancelButton.Text = "Cancel";

                _fileSearchBackgroundWorker = new BackgroundWorker();
                _fileSearchBackgroundWorker.WorkerSupportsCancellation = true;
                _fileSearchBackgroundWorker.DoWork += FileSearchBackgroundWorker_DoWork;
                _fileSearchBackgroundWorker.RunWorkerCompleted += FileSearchBackgroundWorker_RunWorkerCompleted;
                _fileSearchBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                _fileSearchBackgroundWorker.CancelAsync();

                scanOrCancelButton.Text = "Cancelling...";
                scanOrCancelButton.Enabled = false;
            }
        }

        private void FileSearchBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Style = ProgressBarStyle.Blocks;
            scanOrCancelButton.Text = "Scan";
            scanOrCancelButton.Enabled = true;
        }

        private void FileSearchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var file in Directory.GetFiles(@"S:\Adam\Documents"))
            {
                var currentFile = file;

                filesListView.BeginInvoke((MethodInvoker) (() => filesListView.AddFile(currentFile, currentFile)));
            }
        }

        private void FilesListView_ItemActivate(object sender, EventArgs e)
        {
            var fileName = (string) filesListView.SelectedItems[0].Tag;

            try
            {
                Process.Start(fileName);
            }
            catch
            {
            }
        }

        private void LoadCustomers()
        {
            using (var uow = new UnitOfWork())
            {
                var customers = uow.Customers.GetAll().OrderBy(c => c.Name);

                customerComboBox.Items.AddRange(customers.ToArray());

                if (customerComboBox.Items.Count > 0)
                    customerComboBox.SelectedIndex = 0;
                else
                {
                    isNewCustomerCheckBox.Checked = true;
                    isNewCustomerCheckBox.Enabled = false;
                }
            }
        }

        private bool PartInformationPageIsValid()
        {
            if (isNewCustomerCheckBox.Checked)
            {
                if (string.IsNullOrWhiteSpace(customerTextBox.Text))
                {
                    _dialogService.ShowError("You must provide a customer name!");
                    customerTextBox.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(drawingNumberTextBox.Text))
            {
                _dialogService.ShowError("You must enter a drawing number!");
                drawingNumberTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                _dialogService.ShowError("You must provide a name for this part!");
                nameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(versionTextBox.Text))
            {
                _dialogService.ShowError("You must enter a version number for this part!");
                drawingNumberTextBox.Focus();
                return false;
            }

            return true;
        }

        private void CentralizeFormToParent()
        {
            if (Parent == null)
                return;

            Left = (Parent.Width - Width) / 2;
            Top = (Parent.Height - Height) / 2;
        }

        private void UpdateSummaryPage()
        {
            customerLabel.Text = isNewCustomerCheckBox.Checked ? customerTextBox.Text : customerComboBox.Text;
            drawingNumberLabel.Text = drawingNumberTextBox.Text;
            nameLabel.Text = nameTextBox.Text;
            versionLabel.Text = versionTextBox.Text;

            toolingLocationLabel.Text = string.IsNullOrWhiteSpace(toolingLocationTextBox.Text)
                                       ? "NO TOOLING LOCATION PROVIDED"
                                       : toolingLocationTextBox.Text;

            filesToImportListView.Items.Clear();

            foreach (ListViewItem item in filesListView.CheckedItems)
            {
                var fileName = (string) item.Tag;

                ListViewItem importItem = filesToImportListView.Items.Add(Path.GetFileName(fileName));
                importItem.SubItems.Add("...");
                importItem.Tag = fileName;
            }
        }
    }
}