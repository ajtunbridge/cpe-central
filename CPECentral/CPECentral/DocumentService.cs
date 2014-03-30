#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Properties;
using nGenLibrary;
using nGenLibrary.IO;

#endregion

namespace CPECentral
{
    public class DocumentService
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private readonly object _locker = new object();
        private readonly List<IQueueItem> _queue = new List<IQueueItem>();
        private BackgroundWorker _worker;
        public bool IsBusy { get; private set; }
        public SynchronizationContext SyncContext { get; set; }
        public event EventHandler<ExceptionEventArgs> Error;
        public event EventHandler<TransferStartedEventArgs> TransferStarted;
        public event CopyFileCallback TransferProgress;
        public event EventHandler TransferComplete;

        public void QueueUpload(string fileName, IEntity entity)
        {
            QueueUpload(fileName, entity, false);
        }

        public void QueueUpload(string fileName, IEntity entity, bool deleteOriginal)
        {
            if (!AppSecurity.Check(AppPermission.ManageDocuments, true)) {
                return;
            }

            if (!Directory.Exists(Settings.Default.SharedAppDir)) {
                _dialogService.ShowError("The shared application directory could not be located!");
                return;
            }

            var uploadItem = new UploadQueueItem(fileName, entity, deleteOriginal);

            if (_queue.Contains(uploadItem)) {
                return;
            }

            lock (_locker) {
                _queue.Add(uploadItem);
            }

            if (_worker == null) {
                StartWorker();
            }
        }

        public void OpenDocument(Document document)
        {
            string fileName = GetPathToDocument(document);

            try {
                Process.Start(fileName);
            }
            catch (Exception ex) {
                string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                _dialogService.ShowError(msg);
            }
        }

        public void DeleteDocuments(IEnumerable<Document> documents)
        {
            if (!AppSecurity.Check(AppPermission.ManageDocuments, true)) {
                return;
            }

            try {
                using (BusyCursor.Show()) {
                    IEntity entity = null;

                    using (var cpe = new CPEUnitOfWork()) {
                        foreach (Document document in documents) {
                            if (document.OperationId.HasValue) {
                                entity = cpe.Operations.GetById(document.OperationId.Value);
                            }
                            else if (document.PartId.HasValue) {
                                entity = cpe.Parts.GetById(document.PartId.Value);
                            }
                            else if (document.PartVersionId.HasValue) {
                                entity = cpe.PartVersions.GetById(document.PartVersionId.Value);
                            }

                            string fileName = GetPathToDocument(document, cpe);

                            if (File.Exists(fileName)) {
                                File.Delete(fileName);
                            }

                            cpe.Documents.Delete(document);

                            cpe.Commit();
                        }
                    }

                    Session.MessageBus.Publish(new DocumentsChangedMessage(entity));
                }
            }
            catch (Exception ex) {
                string message;

                if (ex is DataProviderException) {
                    message = ex.Message;
                }
                else {
                    message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                _dialogService.ShowError(message);
            }
        }

        public void RenameDocument(Document document, string newFileName)
        {
            if (!AppSecurity.Check(AppPermission.ManageDocuments, true)) {
                return;
            }

            bool renamedOk = false;
            string sourceFileName = null, destinationFileName = null;

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        Document documentToUpdate = cpe.Documents.GetById(document.Id);

                        sourceFileName = GetPathToDocument(documentToUpdate, cpe);

                        int lastIndexOfDot = documentToUpdate.FileName.LastIndexOf(".");

                        if (lastIndexOfDot > -1) {
                            string extension = documentToUpdate.FileName.Substring(lastIndexOfDot);
                            documentToUpdate.FileName = newFileName + extension;
                        }

                        destinationFileName = GetPathToDocument(documentToUpdate, cpe);

                        File.Move(sourceFileName, destinationFileName);

                        renamedOk = true;

                        cpe.Documents.Update(documentToUpdate);

                        cpe.Commit();
                    }
                }
            }
            catch {
                if (renamedOk) // must be a database error so un-rename
                {
                    File.Move(destinationFileName, sourceFileName);
                }

                throw;
            }
        }

        public string GetPathToDocument(Document document)
        {
            using (var cpe = new CPEUnitOfWork()) {
                return GetPathToDocument(document, cpe);
            }
        }

        public string GetPathToDocument(Document document, CPEUnitOfWork cpe)
        {
            IEntity entity = GetDocumentEntity(document, cpe);

            string storageDir = GetEntityStorageDirectory(entity, cpe);

            return Path.Combine(storageDir, document.FileName);
        }

        private void StartWorker()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            _worker.RunWorkerAsync();
        }

        private void ConfirmOverwriteOnMainThread(object confirmOverwriteResult)
        {
            var result = confirmOverwriteResult as ConfirmOverwriteArgs;

            result.OkToOverwrite =
                _dialogService.AskQuestion(result.FileName + "\n\nDo you want to overwrite this file?");
        }

        private void DoUpload(UploadQueueItem uploadItem, CPEUnitOfWork cpe)
        {
            string fileName = Path.GetFileName(uploadItem.SourceFile);

            OnTransferStarted(new TransferStartedEventArgs(fileName));

            string destinationFile = null;

            try {
                string storageDir = GetEntityStorageDirectory(uploadItem.Entity, cpe);

                if (!Directory.Exists(storageDir)) {
                    Directory.CreateDirectory(storageDir);
                }

                // convert all extensions to lower case
                string extension = Path.GetExtension(uploadItem.SourceFile);
                string lowerCaseExtension = extension.ToLower();

                fileName = Path.GetFileNameWithoutExtension(fileName) + lowerCaseExtension;

                destinationFile = Path.Combine(storageDir, fileName);

                bool overwriting = File.Exists(destinationFile);

                if (overwriting) {
                    var args = new ConfirmOverwriteArgs();
                    args.FileName = fileName;
                    SyncContext.Send(ConfirmOverwriteOnMainThread, args);
                    if (!args.OkToOverwrite) {
                        OnTransferComplete();
                        return;
                    }
                }

                FileCopier.Copy(uploadItem.SourceFile, destinationFile, FileCopyCallback);

                IEntity entity = uploadItem.Entity;

                if (!overwriting) {
                    var newDoc = new Document();
                    newDoc.FileName = fileName;
                    newDoc.CreatedBy = Session.CurrentEmployee.Id;
                    newDoc.ModifiedBy = Session.CurrentEmployee.Id;

                    if (entity is Operation) {
                        newDoc.OperationId = entity.Id;
                    }
                    else if (entity is Part) {
                        newDoc.PartId = entity.Id;
                    }
                    else if (entity is PartVersion) {
                        newDoc.PartVersionId = entity.Id;
                    }

                    cpe.Documents.Add(newDoc);

                    cpe.Commit();
                }

                if (uploadItem.DeleteOriginal) {
                    File.Delete(uploadItem.SourceFile);
                }

                // this is for when creating a new part, it gives the view time
                // to load before firing the message
                //Thread.Sleep(500);

                Session.MessageBus.Publish(new DocumentsChangedMessage(entity));

                OnTransferComplete();
            }
            catch (Exception ex) {
                if (destinationFile != null) {
                    if (File.Exists(destinationFile)) {
                        File.Delete(destinationFile);
                    }
                }

                OnError(new ExceptionEventArgs(ex));
            }
        }

        private IQueueItem DequeueItem()
        {
            IQueueItem item;

            lock (_locker) {
                item = _queue[0];
                _queue.RemoveAt(0);
            }

            return item;
        }

        private IEntity GetDocumentEntity(Document document, CPEUnitOfWork cpe)
        {
            IEntity entity = null;

            if (document.OperationId.HasValue) {
                entity = cpe.Operations.GetById(document.OperationId.Value);
            }
            else if (document.PartId.HasValue) {
                entity = cpe.Parts.GetById(document.PartId.Value);
            }
            else if (document.PartVersionId.HasValue) {
                entity = cpe.PartVersions.GetById(document.PartVersionId.Value);
            }

            return entity;
        }

        private string GetEntityStorageDirectory(IEntity entity, CPEUnitOfWork cpe)
        {
            if (entity is Part) {
                string appDir = Settings.Default.SharedAppDir;

                return string.Format("{0}\\Documents\\PID{1}", appDir, entity.Id);
            }

            if (entity is PartVersion) {
                var version = entity as PartVersion;

                Part part = cpe.Parts.GetById(version.PartId);

                string partDir = GetEntityStorageDirectory(part, cpe);

                return string.Format("{0}\\VER{1}", partDir, entity.Id);
            }

            if (entity is Operation) {
                var op = entity as Operation;

                Method method = cpe.Methods.GetById(op.MethodId);

                string versionDir = GetEntityStorageDirectory(method.PartVersion, cpe);

                return string.Format("{0}\\OP{1}", versionDir, entity.Id);
            }

            throw new ArgumentException("You cannot store documents for this type!");
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            IsBusy = true;

            using (var cpe = new CPEUnitOfWork()) {
                while (_queue.Count > 0) {
                    IQueueItem item = DequeueItem();

                    if (item is UploadQueueItem) {
                        DoUpload(item as UploadQueueItem, cpe);
                    }
                }
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsBusy = false;

            _worker.Dispose();
            _worker = null;
        }

        private CopyFileCallbackAction FileCopyCallback(string fileName, string destinationDirectory, int progress)
        {
            return OnTransferProgress(fileName, destinationDirectory, progress);
        }

        #region Event invocators

        protected virtual void OnError(ExceptionEventArgs e)
        {
            EventHandler<ExceptionEventArgs> handler = Error;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnTransferStarted(TransferStartedEventArgs e)
        {
            EventHandler<TransferStartedEventArgs> handler = TransferStarted;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnTransferComplete()
        {
            EventHandler handler = TransferComplete;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual CopyFileCallbackAction OnTransferProgress(string filename, string destinationdirectory,
            int percentcomplete)
        {
            CopyFileCallback handler = TransferProgress;

            if (handler != null) {
                return handler(filename, destinationdirectory, percentcomplete);
            }

            return CopyFileCallbackAction.Continue;
        }

        #endregion

        #region Nested type: ConfirmOverwriteArgs

        private class ConfirmOverwriteArgs
        {
            public string FileName { get; set; }
            public bool OkToOverwrite { get; set; }
        }

        #endregion

        #region Nested type: IQueueItem

        private interface IQueueItem
        {
        }

        #endregion

        #region Nested type: UploadQueueItem

        private class UploadQueueItem : IQueueItem, IEquatable<UploadQueueItem>
        {
            public UploadQueueItem(string sourceFile, IEntity entity, bool deleteOriginal)
            {
                SourceFile = sourceFile;
                Entity = entity;
                DeleteOriginal = deleteOriginal;
            }

            public string SourceFile { get; set; }
            public IEntity Entity { get; set; }
            public bool DeleteOriginal { get; set; }

            #region IEquatable<UploadQueueItem> Members

            public bool Equals(UploadQueueItem other)
            {
                if (ReferenceEquals(null, other)) {
                    return false;
                }
                if (ReferenceEquals(this, other)) {
                    return true;
                }
                return string.Equals(SourceFile, other.SourceFile) && Equals(Entity, other.Entity);
            }

            #endregion

            public override int GetHashCode()
            {
                unchecked {
                    return ((SourceFile != null ? SourceFile.GetHashCode() : 0)*397) ^
                           (Entity != null ? Entity.GetHashCode() : 0);
                }
            }

            public static bool operator ==(UploadQueueItem left, UploadQueueItem right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(UploadQueueItem left, UploadQueueItem right)
            {
                return !Equals(left, right);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) {
                    return false;
                }
                if (ReferenceEquals(this, obj)) {
                    return true;
                }
                if (obj.GetType() != GetType()) {
                    return false;
                }
                return Equals((UploadQueueItem) obj);
            }
        }

        #endregion
    }
}