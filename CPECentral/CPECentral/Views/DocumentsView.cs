#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IDocumentsView : IView
    {
        IEntity CurrentEntity { get; }
        IEnumerable<Document> SelectedDocuments { get; }
        int SelectionCount { get; }

        event EventHandler DeleteSelectedDocuments;
        event EventHandler OpenDocument;
        event EventHandler RefreshDocuments;
        event EventHandler SelectionChanged;
        event EventHandler<FileDropEventArgs> FilesDropped;

        void DisplayDocuments(IEnumerable<DocumentsViewModel> documentModels);
    }

    public partial class DocumentsView : ViewBase, IDocumentsView
    {
        private readonly DocumentsViewPresenter _presenter;

        public DocumentsView()
        {
            InitializeComponent();

            if (!IsInDesignMode)
            {
                _presenter = new DocumentsViewPresenter(this);

                Session.MessageBus.Subscribe<DocumentsChangedMessage>(DocumentsChangedMessage_Published);
            }
        }

        #region IDocumentsView Members

        public IEntity CurrentEntity { get; private set; }

        public IEnumerable<Document> SelectedDocuments
        {
            get { return from ListViewItem item in filesListView.SelectedItems select item.Tag as Document; }
        }

        public int SelectionCount
        {
            get { return filesListView.SelectionCount; }
        }

        public event EventHandler DeleteSelectedDocuments;
        public event EventHandler OpenDocument;
        public event EventHandler RefreshDocuments;
        public event EventHandler SelectionChanged;
        public event EventHandler<FileDropEventArgs> FilesDropped;

        public void DisplayDocuments(IEnumerable<DocumentsViewModel> documentModels)
        {
            filesListView.Items.Clear();

            foreach (var model in documentModels)
            {
                filesListView.AddFile(model.FileName, model.Document);
            }

            toolStrip.Enabled = true;

            deleteDocumentsToolStripButton.Enabled = false;
            openDocumentToolStripButton.Enabled = false;

            OnSelectionChanged();
        }

        #endregion

        protected virtual void OnDeleteSelectedDocuments()
        {
            EventHandler handler = DeleteSelectedDocuments;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnOpenDocument()
        {
            EventHandler handler = OpenDocument;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnRefreshDocuments()
        {
            var handler = RefreshDocuments;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnSelectionChanged()
        {
            var handler = SelectionChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnFilesDropped(FileDropEventArgs e)
        {
            var handler = FilesDropped;
            if (handler != null) handler(this, e);
        }

        public void LoadDocuments(IEntity entity)
        {
            CurrentEntity = entity;

            if (entity is Operation)
            {
                importMillingProgramToolStripButton.Visible = true;
                newTurningProgramToolStripButton.Visible = true;
                newFeatureCAMFileToolStripButton.Visible = true;
            }
            else if (entity is Part || entity is PartVersion)
            {
                importMillingProgramToolStripButton.Visible = false;
                newTurningProgramToolStripButton.Visible = false;
                newFeatureCAMFileToolStripButton.Visible = false;
            }

            toolStrip.Enabled = false;

            filesListView.Items.Clear();
            filesListView.Items.Add("retrieving...");

            OnRefreshDocuments();
        }

        private void DocumentsChangedMessage_Published(DocumentsChangedMessage message)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) (() => DocumentsChangedMessage_Published(message)));
                return;
            }

                if (message.Entity.Equals(CurrentEntity))
                    OnRefreshDocuments();
        }

        private void filesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectionCount = filesListView.SelectionCount;

            openDocumentToolStripButton.Enabled = selectionCount == 1;
            deleteDocumentsToolStripButton.Enabled = selectionCount > 0;

            OnSelectionChanged();
        }

        private void filesListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
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
            switch (e.ClickedItem.Name)
            {
                case "deleteDocumentsToolStripButton":
                    OnDeleteSelectedDocuments();
                    break;
                case "openDocumentToolStripButton":
                    OnOpenDocument();
                    break;
            }
        }

        private void filesListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (filesListView.SelectionCount > 0 && e.KeyCode == Keys.Delete)
            {
                OnDeleteSelectedDocuments();
                return;
            }
        }
    }
}