﻿#region Using directives

using System;
using System.Collections.Generic;
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
        OperationType OpType { get; }

        event EventHandler AddDocuments;
        event EventHandler DeleteSelectedDocuments;
        event EventHandler OpenDocument;
        event EventHandler RefreshDocuments;
        event EventHandler SelectionChanged;
        event EventHandler<FileDropEventArgs> FilesDropped;
        event EventHandler NewTurningProgram;
        event EventHandler NewFeatureCAMFile;
        event EventHandler ImportMillingFile;

        void LoadDocuments(IEntity entity);
        void DisplayDocuments(DocumentsViewModel model);
        void ClearDocuments();
    }

    public partial class DocumentsView : ViewBase, IDocumentsView
    {
        private readonly DocumentsViewPresenter _presenter;
        private OperationType _opType;

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

        public OperationType OpType
        {
            get { return _opType; }
        }

        public event EventHandler AddDocuments;
        public event EventHandler DeleteSelectedDocuments;
        public event EventHandler OpenDocument;
        public event EventHandler RefreshDocuments;
        public event EventHandler SelectionChanged;
        public event EventHandler<FileDropEventArgs> FilesDropped;
        public event EventHandler NewTurningProgram;
        public event EventHandler NewFeatureCAMFile;
        public event EventHandler ImportMillingFile;

        public void DisplayDocuments(DocumentsViewModel model)
        {
            filesListView.Items.Clear();

            _opType = model.OpType;

            importMillingProgramToolStripButton.Visible = _opType == OperationType.Milling;
            newTurningProgramToolStripButton.Visible = _opType == OperationType.Turning;
            newFeatureCAMFileToolStripButton.Visible = _opType != OperationType.None;

            foreach (var documentModel in model.DocumentModels)
            {
                filesListView.AddFile(documentModel.FileName, documentModel.Document);
            }

            toolStrip.Enabled = true;

            deleteDocumentsToolStripButton.Enabled = false;
            openDocumentToolStripButton.Enabled = false;
            renameToolStripButton.Enabled = false;

            OnSelectionChanged();
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

        protected virtual void OnAddDocuments()
        {
            EventHandler handler = AddDocuments;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnDeleteSelectedDocuments()
        {
            var handler = DeleteSelectedDocuments;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnOpenDocument()
        {
            var handler = OpenDocument;
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

        protected virtual void OnNewTurningProgram()
        {
            var handler = NewTurningProgram;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnNewFeatureCAMFile()
        {
            var handler = NewFeatureCAMFile;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnImportMillingFile()
        {
            EventHandler handler = ImportMillingFile;
            if (handler != null) handler(this, EventArgs.Empty);
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
            renameToolStripButton.Enabled = selectionCount == 1;

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