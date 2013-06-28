#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Properties;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class DocumentsViewPresenter
    {
        private readonly IDocumentsView _documentsView;
        private readonly object _refreshLocker = new object();
        private BackgroundWorker _refreshDocumentsWorker;

        public DocumentsViewPresenter(IDocumentsView documentsView)
        {
            _documentsView = documentsView;

            _documentsView.AddDocuments += _documentsView_AddDocuments;
            _documentsView.RefreshDocuments += _documentsView_RefreshDocuments;
            _documentsView.OpenDocument += _documentsView_OpenDocument;
            _documentsView.DeleteSelectedDocuments += _documentsView_DeleteSelectedDocuments;
            _documentsView.FilesDropped += _documentsView_FilesDropped;

            _documentsView.NewFeatureCAMFile += _documentsView_NewFeatureCAMFile;
            _documentsView.NewTurningProgram += _documentsView_NewTurningProgram;
            _documentsView.ImportMillingFile += _documentsView_ImportMillingFile;

            _documentsView.RenameDocument += _documentsView_RenameDocument;
        }

        void _documentsView_RenameDocument(object sender, RenameDocumentEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewFileName))
            {
                _documentsView.DialogService.ShowError("A file name must be provided!");
                return;
            }

            var invalidChars = Path.GetInvalidFileNameChars();

            if (e.NewFileName.Any(invalidChars.Contains))
            {
                _documentsView.DialogService.ShowError("You entered illegal characters into the file name!");
                return;
            }

            try
            {
                Session.DocumentService.RenameDocument(e.Document, e.NewFileName);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void _documentsView_ImportMillingFile(object sender, EventArgs e)
        {
            var parentForm = ((UserControl) _documentsView).ParentForm;

            var operation = _documentsView.CurrentEntity as Operation;

            using (var importDialog = new ImportMillingProgramDialog(operation))
            {
                importDialog.ShowDialog(parentForm);
            }
        }

        private void _documentsView_AddDocuments(object sender, EventArgs e)
        {
            if (!Directory.Exists(Settings.Default.SharedAppDir))
            {
                _documentsView.DialogService.ShowError("The shared application directory could not be located!");
                return;
            }

            using (var fileDialog = new OpenFileDialog())
            {
                var parentForm = ((UserControl) _documentsView).ParentForm;

                fileDialog.Filter = "All files|*.*";
                fileDialog.Title = "Please select documents to upload";
                fileDialog.InitialDirectory = Settings.Default.DefaultDirectory;

                if (fileDialog.ShowDialog(parentForm) != DialogResult.OK)
                    return;

                foreach (var fileName in fileDialog.FileNames)
                    Session.DocumentService.QueueUpload(fileName, _documentsView.CurrentEntity);
            }
        }

        private void _documentsView_NewFeatureCAMFile(object sender, EventArgs e)
        {
            if (!Directory.Exists(Settings.Default.SharedAppDir))
            {
                _documentsView.DialogService.ShowError("The shared application directory could not be located!");
                return;
            }

            try
            {
                using (BusyCursor.Show())
                {
                    using (var uow = new UnitOfWork())
                    {
                        var op = _documentsView.CurrentEntity as Operation;

                        var method = uow.Methods.GetById(op.MethodId);

                        var drawingNo = method.PartVersion.Part.DrawingNumber;
                        var version = method.PartVersion.VersionNumber;
                        var opNumber = op.Sequence;

                        var fileName = string.Format("{0} Version {1} Op {2:00}.fm", drawingNo, version, opNumber);

                        var pathToFile = Path.Combine(Path.GetTempPath(), fileName);

                        var machineGroup = uow.Machines.GetById(op.MachineId).MachineGroup.Name;

                        byte[] data = null;

                        switch (machineGroup.ToLower())
                        {
                            case "cnc mills":
                                data = Resources.CAM_Template_Milling;
                                break;
                            case "cnc lathes":
                                data = Resources.CAM_Template_Turning;
                                break;
                        }

                        File.WriteAllBytes(pathToFile, data);

                        Session.DocumentService.QueueUpload(pathToFile, op, true);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void _documentsView_NewTurningProgram(object sender, EventArgs e)
        {
            if (!_documentsView.DialogService.AskQuestion("Are you sure you want to create a new turning program?"))
                return;

            if (!Directory.Exists(Settings.Default.SharedAppDir))
            {
                _documentsView.DialogService.ShowError("The shared application directory could not be located!");
                return;
            }

            try
            {
                using (BusyCursor.Show())
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
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void _documentsView_DeleteSelectedDocuments(object sender, EventArgs e)
        {
            const string question = "Are you sure you want to delete these documents?\n\nThis cannot be undone!";

            if (!_documentsView.DialogService.AskQuestion(question))
                return;

            Session.DocumentService.DeleteDocuments(_documentsView.SelectedDocuments);
        }

        private void _documentsView_OpenDocument(object sender, EventArgs e)
        {
            var document = _documentsView.SelectedDocuments.First();

            Session.DocumentService.OpenDocument(document);
        }

        private void _documentsView_FilesDropped(object sender, FileDropEventArgs e)
        {
            if (!Directory.Exists(Settings.Default.SharedAppDir))
            {
                _documentsView.DialogService.ShowError("The shared application directory could not be located!");
                return;
            }

            foreach (var file in e.DroppedFiles)
            {
                Session.DocumentService.QueueUpload(file, _documentsView.CurrentEntity);
            }
        }

        private void _documentsView_RefreshDocuments(object sender, EventArgs e)
        {
            _refreshDocumentsWorker = new BackgroundWorker();
            _refreshDocumentsWorker.DoWork += _refreshDocumentsWorker_DoWork;
            _refreshDocumentsWorker.RunWorkerCompleted += _refreshDocumentsWorker_RunWorkerCompleted;
            _refreshDocumentsWorker.RunWorkerAsync(_documentsView.CurrentEntity);
        }

        private void _refreshDocumentsWorker_DoWork(object sender, DoWorkEventArgs e)
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

        private void _refreshDocumentsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

            var model = (DocumentsViewModel) e.Result;

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