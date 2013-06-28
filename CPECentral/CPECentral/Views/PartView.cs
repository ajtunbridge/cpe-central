#region Using directives

using System;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.Properties;
using CPECentral.ViewModels;
using nGenLibrary;

#endregion

namespace CPECentral.Views
{
    public interface IPartView : IView
    {
        Part Part { get; }
        event EventHandler ReloadData;

        void LoadPart(Part part);

        void DisplayModel(PartViewModel model);
    }

    public partial class PartView : ViewBase, IPartView
    {
        private readonly PartViewPresenter _presenter;

        public PartView()
        {
            InitializeComponent();

            base.Dock = DockStyle.Fill;

            if (!IsInDesignMode)
            {
                _presenter = new PartViewPresenter(this);
                Session.MessageBus.Subscribe<PartEditedMessage>(PartEditedMessage_Published);
            }
        }

        #region IPartView Members

        public event EventHandler ReloadData;

        public Part Part { get; private set; }

        public void LoadPart(Part part)
        {
            Part = part;

            partInformationView.LoadPart(Part);
            partDocumentsView.LoadDocuments(Part);
            operationDocumentsView.ClearDocuments();

            using (BusyCursor.Show())
            {
                Settings.Default.LastViewedPartId = part.Id;
                Settings.Default.Save();
            }

            RefreshData();
        }

        public void DisplayModel(PartViewModel model)
        {
            createdByLabel.Text = "Created by: " + model.CreatedBy;
            modifiedByLabel.Text = "Modified by: " + model.ModifiedBy;

            RepositionHeaderLabels();
        }

        #endregion

        protected virtual void OnReloadData()
        {
            var handler = ReloadData;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void PartEditedMessage_Published(PartEditedMessage message)
        {
            if (!Equals(Part, message.EditedPart))
                return;

            RefreshData();
        }

        private void RefreshData()
        {
            selectedDocumentPreviewPanel.ClearPreview();
            
            createdByLabel.Text = "Created by: N/A";
            modifiedByLabel.Text = "Modified by: N/A";

            RepositionHeaderLabels();

            OnReloadData();
        }

        private void RepositionHeaderLabels()
        {
            createdByLabel.Left = Right - createdByLabel.Width - 3;
            modifiedByLabel.Left = Right - modifiedByLabel.Width - 3;
        }

        private void partInformationView_VersionSelected(object sender, CustomEventArgs.PartVersionEventArgs e)
        {
            operationsView.LoadMethods(e.PartVersion);

            versionDocumentsView.LoadDocuments(e.PartVersion);
        }

        private void DocumentViews_SelectionChanged(object sender, EventArgs e)
        {
            var documentsView = (DocumentsView)sender;

            if (documentsView.SelectionCount != 1)
            {
                selectedDocumentPreviewPanel.ClearPreview();
                return;
            }

            var selectedDocument = documentsView.SelectedDocuments.First();

            var pathToDocument = Session.DocumentService.GetPathToDocument(selectedDocument);

            selectedDocumentPreviewPanel.ShowFile(pathToDocument);
        }

        private void operationsView_OperationSelected(object sender, CustomEventArgs.OperationEventArgs e)
        {
            if (e.Operation == null)
            {
                operationDescriptionLabel.Text = string.Empty;
                operationsTabControl.Enabled = false;
                return;
            }

            operationDescriptionLabel.Text = e.Operation.Description;
            operationsTabControl.Enabled = true;
            operationDocumentsView.LoadDocuments(e.Operation);
        }
    }
}