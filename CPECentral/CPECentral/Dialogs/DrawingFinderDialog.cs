using CPECentral.Data.EF5;
using CPECentral.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPECentral.Dialogs
{
    public partial class DrawingFinderDialog : Form
    {
        private BackgroundWorker _scanServerWorker;
        private bool _isScanningForFiles;
        private IDialogService _dialogService;
        private PartVersion _partVersion;

        public IEnumerable<string> FilesToImport
        {
            get { return from ListViewItem item in filesListView.CheckedItems select (string)item.Tag; }
        }

        public DrawingFinderDialog(string drawingNumber, PartVersion version)
        {
            InitializeComponent();
            _partVersion = version;
            searchTermTextBox.Text = drawingNumber;
            ScanServerButton_Click(this, null);
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

            if (string.IsNullOrWhiteSpace(searchTermTextBox.Text))
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
            string scanDir = Settings.Default.DrawingFileDirectory;

            if (!Directory.Exists(scanDir))
            {
                _dialogService.ShowError("The drawing file directory could not be located!");
                return;
            }

            string searchPattern = "*" + (string)e.Argument + "*";

            var dirStack = new Stack<DirectoryInfo>();
            dirStack.Push(new DirectoryInfo(scanDir));

            string[] validExtensions = Settings.Default.DrawingFileExtensions.Split(new[] { "|" }, StringSplitOptions.None);

            while (dirStack.Count > 0)
            {
                if (_scanServerWorker.CancellationPending)
                {
                    return;
                }

                var currentDir = dirStack.Pop();

                var subDirs = currentDir.GetDirectories();

                if (_scanServerWorker.CancellationPending)
                {
                    return;
                }

                foreach (var subDir in subDirs)
                {
                    dirStack.Push(subDir);
                }

                if (_scanServerWorker.CancellationPending)
                {
                    return;
                }

                IEnumerable<FileInfo> matches = currentDir.GetFiles(searchPattern)
                    .OrderByDescending(f => f.LastWriteTime)
                    .Where(fi =>
                    {
                        string ext = fi.Extension;
                        return
                            validExtensions.Any(
                                validExt => validExt.Equals(ext, StringComparison.OrdinalIgnoreCase));
                    });


                if (_scanServerWorker.CancellationPending)
                {
                    return;
                }

                filesListView.Invoke((MethodInvoker)delegate {
                    foreach (var match in matches)
                    {
                        if (_scanServerWorker.CancellationPending)
                        {
                            return;
                        }
                        filesListView.AddFile(match.FullName, match.FullName);
                    }
                });

                if (_scanServerWorker.CancellationPending)
                {
                    return;
                }
            }
        }

        private void ScanServerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _isScanningForFiles = false;

            scanServerButton.Text = "Search";
            scanServerButton.Enabled = true;
            progressBar.Style = ProgressBarStyle.Blocks;

            // if no drawing files were found
            if (filesListView.Items.Count == 0)
            {
                filesListView.Items.Add("No matches!");
                return;
            }

            filesListView.Sort();
        }

        private void importSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (string file in FilesToImport)
            {
                Session.DocumentService.QueueUpload(file, _partVersion);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void filesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            importSelectedButton.Enabled = FilesToImport.Count() > 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
