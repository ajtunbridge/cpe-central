#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Tricorn;

#endregion

namespace CPECentral.Dialogs
{
    public partial class SelectTricornMaterialDialog : Form
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();

        public SelectTricornMaterialDialog()
        {
            InitializeComponent();

            filterValueEnhancedTextBox.SelectionStart = 1;
        }

        public IEnumerable<Material> SelectedMaterials
        {
            get
            {
                List<Material> materials =
                    (from ListViewItem item in resultsEnhancedListView.CheckedItems select item.Tag as Material).ToList();
                return materials;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string filterValue = filterValueEnhancedTextBox.Text;

            if (filterValue.Length == 0) {
                _dialogService.Notify("You haven't entered a search value!");
                return;
            }

            searchButton.Enabled = false;
            progressBar.Style = ProgressBarStyle.Marquee;
            resultsEnhancedListView.Items.Clear();
            resultsEnhancedListView.Items.Add("searching...");

            var searchWorker = new BackgroundWorker();
            searchWorker.DoWork += searchWorker_DoWork;
            searchWorker.RunWorkerCompleted += searchWorker_RunWorkerCompleted;
            searchWorker.RunWorkerAsync(filterValue);
        }

        private void searchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            searchButton.Enabled = true;
            progressBar.Style = ProgressBarStyle.Blocks;
            resultsEnhancedListView.Items.Clear();

            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                return;
            }

            var results = e.Result as IEnumerable<Material>;

            foreach (Material result in results) {
                ListViewItem item = resultsEnhancedListView.Items.Add(result.Name);
                item.Tag = result;
            }
        }

        private void HandleException(Exception exception)
        {
            string msg = exception.InnerException == null ? exception.Message : exception.InnerException.Message;
            _dialogService.ShowError(msg);
        }

        private void searchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var filterValue = (string) e.Argument;
            try {
                using (var tricorn = new TricornDataProvider()) {
                    List<Material> materials = tricorn.GetMaterials(filterValue).OrderBy(m => m.Name).ToList();
                    e.Result = materials;
                }
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private void filterValueEnhancedTextBox_EnterKeyPressed(object sender, EventArgs e)
        {
            searchButton.PerformClick();
        }

        private void okayCancelFooter1_OkayClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void okayCancelFooter1_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}