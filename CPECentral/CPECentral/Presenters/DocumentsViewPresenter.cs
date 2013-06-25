using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;
using CPECentral.Properties;
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

            _documentsView.NewFeatureCAMFile += _documentsView_NewFeatureCAMFile;
            _documentsView.NewTurningProgram += _documentsView_NewTurningProgram;
        }

        void _documentsView_NewFeatureCAMFile(object sender, EventArgs e)
        {
            using (var uow = new UnitOfWork())
            {

            }
        }

        void _documentsView_NewTurningProgram(object sender, EventArgs e)
        {
            using (var uow = new UnitOfWork())
            {
                var group = uow.MachineGroups.GetByName("CNC Lathes");

                if (group == null)
                    throw new InvalidOperationException("There isn't a machine group for lathes!");

                var op = _documentsView.CurrentEntity as Operation;

                var method = uow.Methods.GetById(op.MethodId);

                var tempPath = Path.GetTempPath();

                var tempFileName = string.Format("{0}\\{1:0000}.nc", tempPath, group.NextNumber);

                var header = new StringBuilder(Settings.Default.TurningProgramHeader);
                header.Replace("{prog}", group.NextNumber.ToString("D4"));
                header.Replace("{dwg}", method.PartVersion.Part.DrawingNumber);
                header.Replace("{ver}", method.PartVersion.VersionNumber);
                header.Replace("{op}", op.Sequence.ToString("D2"));
                header.Replace("{cust}", method.PartVersion.Part.Customer.Name);
                header.Replace("{name}", method.PartVersion.Part.Name);

                File.WriteAllText(tempFileName, header.ToString());

                Session.DocumentService.QueueUpload(tempFileName, op);

                group.NextNumber += 1;

                uow.MachineGroups.Update(group);

                uow.Commit();
            }
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
                    using (var uow = new UnitOfWork())
                    {
                        uow.OpenConnection();

                        IEnumerable<Document> documents = null;

                        var model = new DocumentsViewModel(OperationType.None);

                        if (entity is Operation)
                        {
                            var op = entity as Operation;

                            var machine = uow.Machines.GetById(op.MachineId);

                            switch (machine.MachineGroup.Name.ToLower())
                            {
                                case "cnc mills":
                                    model.OpType = OperationType.Milling;
                                    break;
                                case "cnc lathes":
                                    model.OpType = OperationType.Turning;
                                    break;
                                default:
                                    model.OpType = OperationType.None;
                                    break;
                            }

                            documents = uow.Documents.GetByOperation(entity.Id);                      
                        }
                        else if (entity is Part)
                            documents = uow.Documents.GetByPart(entity.Id);
                        else if (entity is PartVersion)
                            documents = uow.Documents.GetByPartVersion(entity.Id);

                        foreach (var document in documents.OrderBy(d => d.FileName))
                        {
                            var pathToFile = Session.DocumentService.GetPathToDocument(document, uow);

                            model.AddDocumentModel(document, pathToFile);
                        }

                        e.Result = model;
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

            var model = (DocumentsViewModel)e.Result;

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
