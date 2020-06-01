#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
    public interface IDocumentsView : IView
    {
        IEntity CurrentEntity { get; }
        IEnumerable<Document> SelectedDocuments { get; }
        int SelectionCount { get; }
        OperationType OpType { get; }

        event EventHandler<DocumentEventArgs> SetVersionDrawingDocument;
        event EventHandler AddDocuments;
        event EventHandler CopyDocuments;
        event EventHandler DeleteSelectedDocuments;
        event EventHandler OpenDocument;
        event EventHandler OpenDocumentExternally;
        event EventHandler PasteDocuments;
        event EventHandler RefreshDocuments;
        event EventHandler SelectionChanged;
        event EventHandler<FileDropEventArgs> FilesDropped;
        event EventHandler NewTurningProgram;
        event EventHandler NewFeatureCAMFile;
        event EventHandler ImportMillingFile;
        event EventHandler<RenameDocumentEventArgs> RenameDocument;
        event EventHandler<DocumentEventArgs> TextFileSelected;
        event EventHandler ScanServerForDrawings;
        event EventHandler<DocumentEventArgs> ExtractSinglePage;

        void LoadDocuments(IEntity entity);
        void DisplayDocuments(DocumentsViewModel model);
        void ClearDocuments();
    }

    public partial class DocumentsView : ViewBase, IDocumentsView
    {
        private readonly DocumentsPresenter _presenter;
        private bool _currentlySelecting;
        private OperationType _opType;

        public DocumentsView()
        {
            InitializeComponent();

            base.Font = Session.AppFont;

            if (!IsInDesignMode) {
                _presenter = new DocumentsPresenter(this);
                filesListView.View = Settings.Default.PreferredDocumentsViewStyle;
                Session.MessageBus.Subscribe<DocumentsChangedMessage>(DocumentsChangedMessage_Published);
            }
        }

        #region IDocumentsView Members

        public IEntity CurrentEntity { get; private set; }

        public IEnumerable<Document> SelectedDocuments
        {
            get { return from ListViewItem item in filesListView.SelectedItems select (item.Tag as DocumentModel).Document; }
        }

        public int SelectionCount
        {
            get { return filesListView.SelectionCount; }
        }

        public OperationType OpType
        {
            get { return _opType; }
        }

        public event EventHandler<DocumentEventArgs> SetVersionDrawingDocument;

        public event EventHandler AddDocuments;
        public event EventHandler DeleteSelectedDocuments;
        public event EventHandler OpenDocument;
        public event EventHandler OpenDocumentExternally;
        public event EventHandler PasteDocuments;
        public event EventHandler RefreshDocuments;
        public event EventHandler CopyDocuments;
        public event EventHandler SelectionChanged;
        public event EventHandler<FileDropEventArgs> FilesDropped;
        public event EventHandler NewTurningProgram;
        public event EventHandler NewFeatureCAMFile;
        public event EventHandler ImportMillingFile;
        public event EventHandler<RenameDocumentEventArgs> RenameDocument;
        public event EventHandler<DocumentEventArgs> TextFileSelected;
        public event EventHandler ScanServerForDrawings;
        public event EventHandler<DocumentEventArgs> ExtractSinglePage;

        public void DisplayDocuments(DocumentsViewModel model)
        {
            filesListView.Items.Clear();

            _opType = model.OpType;

            importMillingProgramToolStripButton.Visible = _opType == OperationType.CncMilling;

            newTurningProgramToolStripButton.Visible = _opType == OperationType.CncTurning;

            newFeatureCAMFileToolStripButton.Visible = _opType == OperationType.CncMilling ||
                                                       _opType == OperationType.CncTurning;

            foreach (DocumentModel documentModel in model.DocumentModels) {
                filesListView.AddFile(documentModel.FileName, documentModel);
            }

            toolStrip.Enabled = true;

            deleteDocumentsToolStripButton.Enabled = false;
            openDocumentToolStripButton.Enabled = false;
            renameToolStripButton.Enabled = false;

            OnSelectionChanged();

            if (!(CurrentEntity is PartVersion)) {
                makePrimaryDrawingFileForThisVersionToolStripMenuItem.Visible = false;
                scanServerForDrawingsmodelsToolStripMenuItem.Visible = false;
            }
            else {
                makePrimaryDrawingFileForThisVersionToolStripMenuItem.Visible = true;
                scanServerForDrawingsmodelsToolStripMenuItem.Visible = true;
            }

            // TODO: (Optional) - Notify user if any documents were missing and removed from database
        }

        public void ClearDocuments()
        {
            filesListView.Items.Clear();
            toolStrip.Enabled = false;
        }

        public void LoadDocuments(IEntity entity)
        {
            CurrentEntity = entity;

            toolStrip.Enabled = false;

            filesListView.Items.Clear();
            filesListView.Items.Add("retrieving...");

            OnRefreshDocuments();
        }

        #endregion

        protected virtual void OnExtractSinglePage(DocumentEventArgs e)
        {
            var handler = ExtractSinglePage;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnTextFileSelected(DocumentEventArgs e)
        {
            EventHandler<DocumentEventArgs> handler = TextFileSelected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSetVersionDrawingDocument(DocumentEventArgs e)
        {
            EventHandler<DocumentEventArgs> handler = SetVersionDrawingDocument;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnScanServerForDrawings()
        {
            EventHandler handler = ScanServerForDrawings;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnAddDocuments()
        {
            EventHandler handler = AddDocuments;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnCopyDocuments()
        {
            EventHandler handler = CopyDocuments;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnDeleteSelectedDocuments()
        {
            EventHandler handler = DeleteSelectedDocuments;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnOpenDocument()
        {
            EventHandler handler = OpenDocument;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnOpenDocumentExternally()
        {
            EventHandler handler = OpenDocumentExternally;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnPasteDocuments()
        {
            EventHandler handler = PasteDocuments;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnRefreshDocuments()
        {
            EventHandler handler = RefreshDocuments;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnSelectionChanged()
        {
            EventHandler handler = SelectionChanged;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnFilesDropped(FileDropEventArgs e)
        {
            EventHandler<FileDropEventArgs> handler = FilesDropped;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnNewTurningProgram()
        {
            EventHandler handler = NewTurningProgram;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnNewFeatureCAMFile()
        {
            EventHandler handler = NewFeatureCAMFile;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnImportMillingFile()
        {
            EventHandler handler = ImportMillingFile;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnRenameDocument(RenameDocumentEventArgs e)
        {
            EventHandler<RenameDocumentEventArgs> handler = RenameDocument;
            if (handler != null) {
                handler(this, e);
            }
        }

        private void DocumentsChangedMessage_Published(DocumentsChangedMessage message)
        {
            if (InvokeRequired) {
                Invoke((MethodInvoker) (() => DocumentsChangedMessage_Published(message)));
                return;
            }

            if (message.Entity.Equals(CurrentEntity)) {
                OnRefreshDocuments();
            }
        }

        private void filesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentlySelecting = true;

            int selectionCount = filesListView.SelectionCount;

            openDocumentToolStripButton.Enabled = selectionCount == 1;
            deleteDocumentsToolStripButton.Enabled = selectionCount > 0;
            renameToolStripButton.Enabled = selectionCount == 1;

            _currentlySelecting = false;

            OnSelectionChanged();

            if (selectionCount == 1) {
                var docModel = filesListView.SelectedItems[0].Tag as DocumentModel;
                var extension = Path.GetExtension(docModel.Document.FileName);

                string[] validTextExtensions = Settings.Default.TextFileExtensions.Split(new[] { "|" },
                    StringSplitOptions.None);

                if (validTextExtensions.Any(textExt => textExt.Equals(extension, StringComparison.OrdinalIgnoreCase))) {
                    OnTextFileSelected(new DocumentEventArgs(docModel.Document));
                }
            }
        }

        private void filesListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void filesListView_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[]) e.Data.GetData(DataFormats.FileDrop);

            OnFilesDropped(new FileDropEventArgs(files));
        }

        private void filesListView_ItemActivate(object sender, EventArgs e)
        {
            OnOpenDocument();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addDocumentToolStripButton":
                    OnAddDocuments();
                    break;
                case "deleteDocumentsToolStripButton":
                    OnDeleteSelectedDocuments();
                    break;
                case "openDocumentToolStripButton":
                    OnOpenDocument();
                    break;
                case "newTurningProgramToolStripButton":
                    OnNewTurningProgram();
                    break;
                case "newFeatureCAMFileToolStripButton":
                    OnNewFeatureCAMFile();
                    break;
                case "refreshToolStripMenuItem":
                    OnRefreshDocuments();
                    break;
                case "importMillingProgramToolStripButton":
                    OnImportMillingFile();
                    break;
                case "renameToolStripButton":
                    filesListView.SelectedItems[0].BeginEdit();
                    break;
            }
        }

        private void filesListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (filesListView.SelectionCount > 0 && e.KeyCode == Keys.Delete) {
                OnDeleteSelectedDocuments();
            }
        }

        private void filesListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Label)) {
                e.CancelEdit = true;
                return;
            }

            var document = filesListView.Items[e.Item].Tag as DocumentModel;

            OnRenameDocument(new RenameDocumentEventArgs(document.Document, e.Label));

            OnRefreshDocuments();
        }

        private void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "largeIconsToolStripMenuItem":
                    filesListView.View = View.LargeIcon;
                    Settings.Default.PreferredDocumentsViewStyle = View.LargeIcon;
                    Settings.Default.Save();
                    break;
                case "detailsToolStripMenuItem":
                    filesListView.View = View.Details;
                    Settings.Default.PreferredDocumentsViewStyle = View.Details;
                    Settings.Default.Save();
                    break;
                case "extractSinglePageForThisPartToolStripMenuItem":
                    OnExtractSinglePage(new DocumentEventArgs(SelectedDocuments.First()));
                    break;
                case "openToolStripMenuItem":
                    OnOpenDocument();
                    break;
                case "makePrimaryDrawingFileForThisVersionToolStripMenuItem":
                    OnSetVersionDrawingDocument(new DocumentEventArgs(SelectedDocuments.First()));
                    break;
                case "deleteToolStripMenuItem":
                    OnDeleteSelectedDocuments();
                    break;
                case "openExternallyToolStripMenuItem":
                    OnOpenDocumentExternally();
                    break;
                case "pasteToolStripMenuItem":
                    OnPasteDocuments();
                    break;
                case "copyToolStripMenuItem":
                    OnCopyDocuments();
                    break;
                case "scanServerForDrawingsmodelsToolStripMenuItem":
                    OnScanServerForDrawings();
                    break;
            }
        }

        private void listViewContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            StringCollection fileNames = Clipboard.GetFileDropList();

            pasteToolStripMenuItem.Enabled = fileNames.Count > 0;
        }

        private void filesListView_DragLeave(object sender, EventArgs e)
        {

        }

        private void filesListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<string> selection = new List<string>();

            foreach (ListViewItem item in filesListView.SelectedItems)
            {
                var model = item.Tag as DocumentModel;

                selection.Add(model.FileName);
            }

            DataObject data = new DataObject(DataFormats.FileDrop, selection.ToArray());
            DoDragDrop(data, DragDropEffects.Copy);
        }

        private void listViewItemContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (filesListView.SelectedItems.Count != 1)
            {
                extractSinglePageForThisPartToolStripMenuItem.Visible = false;
                makePrimaryDrawingFileForThisVersionToolStripMenuItem.Visible = false;
                return;
            }

            var selectedFile = filesListView.SelectedItems[0].Tag as DocumentModel;

            var isPdf = Path.GetExtension(selectedFile.FileName).ToLower() == ".pdf";

            extractSinglePageForThisPartToolStripMenuItem.Visible = isPdf;
        }
    }
}