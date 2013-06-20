using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

namespace CPECentral.Presenters
{
    public class DocumentsViewPresenter
    {
        private readonly IDocumentsView _documentsView;
        private BackgroundWorker _refreshDocumentsWorker;
        private readonly object _refreshLocker = new object();

        public DocumentsViewPresenter(IDocumentsView documentsView)
        {
            _documentsView = documentsView;

            _documentsView.RefreshDocuments += _documentsView_RefreshDocuments;
            _documentsView.OpenDocument += _documentsView_OpenDocument;
            _documentsView.DeleteSelectedDocuments += _documentsView_DeleteSelectedDocuments;
            _documentsView.FilesDropped += _documentsView_FilesDropped;
        }

        void _documentsView_DeleteSelectedDocuments(object sender, EventArgs e)
        {
            const string question = "Are you sure you want to delete these documents?\n\nThis cannot be undone!";

            if (!_documentsView.DialogService.AskQuestion(question))
                return;

            Session.DocumentService.DeleteDocuments(_documentsView.SelectedDocuments);
        }

        void _documentsView_OpenDocument(object sender, EventArgs e)
        {
            var document = _documentsView.SelectedDocuments.First();

            Session.DocumentService.OpenDocument(document);
        }

        void _documentsView_FilesDropped(object sender, CustomEventArgs.FileDropEventArgs e)
        {
            foreach (var file in e.DroppedFiles)
            {
                Session.DocumentService.QueueUpload(file, _documentsView.CurrentEntity);
            }
        }

        void _documentsView_RefreshDocuments(object sender, EventArgs e)
        {
            _refreshDocumentsWorker = new BackgroundWorker();
            _refreshDocumentsWorker.DoWork += _refreshDocumentsWorker_DoWork;
            _refreshDocumentsWorker.RunWorkerCompleted += _refreshDocumentsWorker_RunWorkerCompleted;
            _refreshDocumentsWorker.RunWorkerAsync(_documentsView.CurrentEntity);
        }

        void _refreshDocumentsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (_refreshLocker)
            {
                var entity = e.Argument as IEntity;

                try
                {
                    var modelItems = new List<DocumentsViewModel>();

                    using (var uow = new UnitOfWork())
                    {
                        uow.OpenConnection();

                        IEnumerable<Document> documents = null;

                        if (entity is Operation)
                            documents = uow.Documents.GetByOperation(entity.Id);
                        else if (entity is Part)
                            documents = uow.Documents.GetByPart(entity.Id);
                        else if (entity is PartVersion)
                            documents = uow.Documents.GetByPartVersion(entity.Id);


                        foreach (var document in documents.OrderBy(d => d.FileName))
                        {
                            var pathToFile = Session.DocumentService.GetPathToDocument(document, uow);

                            modelItems.Add(new DocumentsViewModel(document, pathToFile));
                        }

                        e.Result = modelItems;
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            }
        }

        void _refreshDocumentsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // BUG: find out why this happens when refreshing the library!
            if (_refreshDocumentsWorker == null)
                return;

            _refreshDocumentsWorker.Dispose();
            _refreshDocumentsWorker = null; 

            if (e.Result is Exception)
            {
                HandleException(e.Result as Exception);
                return;
            }

            var model = (IEnumerable<DocumentsViewModel>)e.Result;

            _documentsView.DisplayDocuments(model);
        }

        private void HandleException(Exception exception)
        {
            string message;

            if (exception is DataProviderException)
                message = exception.Message;
            else
            {
                message = exception.InnerException == null
                              ? exception.Message
                              : exception.InnerException.Message;
            }

            _documentsView.DialogService.ShowError(message);
        }
    }
}
