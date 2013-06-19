using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;

namespace CPECentral.Presenters
{
    public class DocumentsViewPresenter
    {
        private readonly IDocumentsView _documentsView;
        private BackgroundWorker _refreshDocumentsWorker;

        public DocumentsViewPresenter(IDocumentsView documentsView)
        {
            _documentsView = documentsView;

            _documentsView.RefreshDocuments += _documentsView_RefreshDocuments;
            _documentsView.FilesDropped += _documentsView_FilesDropped;
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

                    foreach (var document in documents)
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
