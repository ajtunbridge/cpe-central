#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
            var fileName = GetPathToDocument(document);

            try {
                Process.Start(fileName);
            }
            catch (Exception ex) {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

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

                    using (var uow = new UnitOfWork()) {
                        foreach (var document in documents) {
                            if (document.OperationId.HasValue) {
                                entity = uow.Operations.GetById(document.OperationId.Value);
                            }
                            else if (document.PartId.HasValue) {
                                entity = uow.Parts.GetById(document.PartId.Value);
                            }
                            else if (document.PartVersionId.HasValue) {
                                entity = uow.PartVersions.GetById(document.PartVersionId.Value);
                            }

                            var fileName = GetPathToDocument(document, uow);

                            if (File.Exists(fileName)) {
                                File.Delete(fileName);
                            }

                            uow.Documents.Delete(document);

                            uow.Commit();
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

            var renamedOk = false;
            string sourceFileName = null, destinationFileName = null;

            try {
                using (BusyCursor.Show()) {
                    using (var uow = new UnitOfWork()) {
                        var documentToUpdate = uow.Documents.GetById(document.Id);

                        sourceFileName = GetPathToDocument(documentToUpdate, uow);

                        var lastIndexOfDot = documentToUpdate.FileName.LastIndexOf(".");

                        if (lastIndexOfDot > -1) {
                            var extension = documentToUpdate.FileName.Substring(lastIndexOfDot);
                            documentToUpdate.FileName = newFileName + extension;
                        }

                        destinationFileName = GetPathToDocument(documentToUpdate, uow);

                        File.Move(sourceFileName, destinationFileName);

                        renamedOk = true;

                        uow.Documents.Update(documentToUpdate);

                        uow.Commit();
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
            using (var uow = new UnitOfWork()) {
                return GetPathToDocument(document, uow);
            }
        }

        public string GetPathToDocument(Document document, UnitOfWork uow)
        {
            var entity = GetDocumentEntity(document, uow);

            var storageDir = GetEntityStorageDirectory(entity, uow);

            return Path.Combine(storageDir, document.FileName);
        }

        private void StartWorker()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            _worker.RunWorkerAsync();
        }

        private void DoUpload(UploadQueueItem uploadItem, UnitOfWork uow)
        {
            var fileName = Path.GetFileName(uploadItem.SourceFile);

            OnTransferStarted(new TransferStartedEventArgs(fileName));

            string destinationFile = null;

            try {
                var storageDir = GetEntityStorageDirectory(uploadItem.Entity, uow);

                if (!Directory.Exists(storageDir)) {
                    Directory.CreateDirectory(storageDir);
                }

                // convert all extensions to lower case
                var extension = Path.GetExtension(uploadItem.SourceFile);
                var lowerCaseExtension = extension.ToLower();

                fileName = Path.GetFileNameWithoutExtension(fileName) + lowerCaseExtension;

                destinationFile = Path.Combine(storageDir, fileName);

                var overwriting = File.Exists(destinationFile);

                FileCopier.Copy(uploadItem.SourceFile, destinationFile, FileCopyCallback);

                var entity = uploadItem.Entity;

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

                    uow.Documents.Add(newDoc);

                    uow.Commit();
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

        private IEntity GetDocumentEntity(Document document, UnitOfWork uow)
        {
            IEntity entity = null;

            if (document.OperationId.HasValue) {
                entity = uow.Operations.GetById(document.OperationId.Value);
            }
            else if (document.PartId.HasValue) {
                entity = uow.Parts.GetById(document.PartId.Value);
            }
            else if (document.PartVersionId.HasValue) {
                entity = uow.PartVersions.GetById(document.PartVersionId.Value);
            }

            return entity;
        }

        private string GetEntityStorageDirectory(IEntity entity, UnitOfWork uow)
        {
            if (entity is Part) {
                var appDir = Settings.Default.SharedAppDir;

                return string.Format("{0}\\Documents\\PID{1}", appDir, entity.Id);
            }

            if (entity is PartVersion) {
                var version = entity as PartVersion;

                var part = uow.Parts.GetById(version.PartId);

                var partDir = GetEntityStorageDirectory(part, uow);

                return string.Format("{0}\\VER{1}", partDir, entity.Id);
            }

            if (entity is Operation) {
                var op = entity as Operation;

                var method = uow.Methods.GetById(op.MethodId);

                var versionDir = GetEntityStorageDirectory(method.PartVersion, uow);

                return string.Format("{0}\\OP{1}", versionDir, entity.Id);
            }

            throw new ArgumentException("You cannot store documents for this type!");
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            IsBusy = true;

            using (var uow = new UnitOfWork()) {
                while (_queue.Count > 0) {
                    var item = DequeueItem();

                    if (item is UploadQueueItem) {
                        DoUpload(item as UploadQueueItem, uow);
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
            var handler = Error;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnTransferStarted(TransferStartedEventArgs e)
        {
            var handler = TransferStarted;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnTransferComplete()
        {
            var handler = TransferComplete;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual CopyFileCallbackAction OnTransferProgress(string filename, string destinationdirectory,
                                                                    int percentcomplete)
        {
            var handler = TransferProgress;

            if (handler != null) {
                return handler(filename, destinationdirectory, percentcomplete);
            }

            return CopyFileCallbackAction.Continue;
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