#region Using directives

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.Properties;
using CPECentral.ViewModels;

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
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private readonly PartViewPresenter _presenter;

        public PartView()
        {
            InitializeComponent();

            Font = Session.AppFont;

            base.Dock = DockStyle.Fill;

            if (!IsInDesignMode) {
                _presenter = new PartViewPresenter(this);
                Session.MessageBus.Subscribe<PartEditedMessage>(PartEditedMessage_Published);
            }
        }

        #region IPartView Members

        public event EventHandler ReloadData;

        public Part Part { get; private set; }

        public void LoadPart(Part part)
        {
            filePreviewTabControl.Clear();

            Part = part;

            partInformationView.LoadPart(Part);
            partDocumentsView.LoadDocuments(Part);
            operationDocumentsView.ClearDocuments();

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
            EventHandler handler = ReloadData;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void PartEditedMessage_Published(PartEditedMessage message)
        {
            if (!Equals(Part, message.EditedPart)) {
                return;
            }

            RefreshData();
        }

        private void RefreshData()
        {
            filePreviewTabControl.Clear();

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

        private void partInformationView_VersionSelected(object sender, PartVersionEventArgs e)
        {
            operationsView.LoadMethods(e.PartVersion);

            versionDocumentsView.LoadDocuments(e.PartVersion);
        }

        private void operationsView_OperationSelected(object sender, OperationEventArgs e)
        {
            operationToolsView1.RetrieveOperationTools(e.Operation);

            if (e.Operation == null) {
                operationDescriptionLabel.Text = string.Empty;
                operationsTabControl.Enabled = false;
                return;
            }

            operationDescriptionLabel.Text = e.Operation.Description;
            operationsTabControl.Enabled = true;
            operationDocumentsView.LoadDocuments(e.Operation);
        }

        private void documentsView_OpenDocument(object sender, EventArgs e)
        {
            var view = (DocumentsView) sender;

            Document doc = view.SelectedDocuments.First();

            string[] viewInternallyFileExtensions = Settings.Default.ViewInternallyFileExtensions.Split(new[] {"|"},
                StringSplitOptions.None);

            string docExt = doc.FileName.Substring(doc.FileName.LastIndexOf("."));

            if (!viewInternallyFileExtensions.Any(ext => ext.Equals(docExt, StringComparison.OrdinalIgnoreCase))) {
                documentsView_OpenDocumentExternally(sender, e);
                return;
            }

            ThreadPool.QueueUserWorkItem(delegate {
                string pathToDocument = Session.DocumentService.GetPathToDocument(doc);

                filePreviewTabControl.InvokeEx(() => filePreviewTabControl.ShowFile(pathToDocument));
            });
        }

        private void documentsView_OpenDocumentExternally(object sender, EventArgs e)
        {
            try {
                var view = (DocumentsView) sender;

                Document doc = view.SelectedDocuments.First();

                Task.Factory.StartNew(() => Session.DocumentService.OpenDocument(doc));
            }
            catch (Exception ex) {
                _dialogService.ShowError(ex.Message);
            }
        }
    }
}