#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        private const string MillingGroupName = "MILLS";
        private const string TurningGroupName = "LATHES";

        private readonly IDocumentsView _documentsView;
        private readonly object _refreshLocker = new object();
        private BackgroundWorker _refreshDocumentsWorker;

        public DocumentsViewPresenter(IDocumentsView documentsView)
        {
            _documentsView = documentsView;

            _documentsView.AddDocuments += _documentsView_AddDocuments;
            _documentsView.CopyDocuments += _documentsView_CopyDocuments;
            _documentsView.DeleteSelectedDocuments += _documentsView_DeleteSelectedDocuments;
            _documentsView.FilesDropped += _documentsView_FilesDropped;
            _documentsView.OpenDocument += _documentsView_OpenDocument;
            _documentsView.PasteDocuments += _documentsView_PasteDocuments;
            _documentsView.RefreshDocuments += _documentsView_RefreshDocuments;

            _documentsView.NewFeatureCAMFile += _documentsView_NewFeatureCAMFile;
            _documentsView.NewTurningProgram += _documentsView_NewTurningProgram;
            _documentsView.ImportMillingFile += _documentsView_ImportMillingFile;

            _documentsView.RenameDocument += _documentsView_RenameDocument;
        }

        private void _documentsView_PasteDocuments(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageDocuments, true)) {
                return;
            }

            StringCollection filePaths = Clipboard.GetFileDropList();

            if (filePaths.Count == 0) {
                return;
            }

            IEnumerable<Document> docs = GetDocuments();

            var existingDocuments = new List<Document>();

            foreach (string path in filePaths) {
                string fileName = Path.GetFileName(path);

                Document existing = docs.FirstOrDefault(d => d.FileName == fileName);

                if (existing == null) {
                    continue;
                }

                existingDocuments.Add(existing);
            }

            if (existingDocuments.Count > 0) {
                // TODO: improve the UI for overwriting 
                string question = string.Format("Do you want to overwrite the following documents:\n\n");

                int count = 1;

                foreach (Document doc in existingDocuments) {
                    question += string.Format("{0}) {1}\n", count, doc.FileName);
                    count++;
                }

                if (_documentsView.DialogService.AskQuestion(question) == false) {
                    return;
                }
            }

            foreach (string fileName in filePaths) {
                Session.DocumentService.QueueUpload(fileName, _documentsView.CurrentEntity);
            }
        }

        private void _documentsView_CopyDocuments(object sender, EventArgs e)
        {
            var fileNames = new StringCollection();

            foreach (Document document in _documentsView.SelectedDocuments) {
                fileNames.Add(Session.DocumentService.GetPathToDocument(document));
            }

            Clipboard.SetFileDropList(fileNames);
        }

        private void _documentsView_RenameDocument(object sender, RenameDocumentEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewFileName)) {
                _documentsView.DialogService.ShowError("A file name must be provided!");
                return;
            }

            char[] invalidChars = Path.GetInvalidFileNameChars();

            if (e.NewFileName.Any(invalidChars.Contains)) {
                _documentsView.DialogService.ShowError("You entered illegal characters into the file name!");
                return;
            }

            try {
                Session.DocumentService.RenameDocument(e.Document, e.NewFileName);
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void _documentsView_ImportMillingFile(object sender, EventArgs e)
        {
            Form parentForm = ((UserControl) _documentsView).ParentForm;

            var operation = _documentsView.CurrentEntity as Operation;

            using (var importDialog = new ImportMillingProgramDialog(operation)) {
                importDialog.ShowDialog(parentForm);
            }
        }

        private void _documentsView_AddDocuments(object sender, EventArgs e)
        {
            if (!Directory.Exists(Settings.Default.SharedAppDir)) {
                _documentsView.DialogService.ShowError("The shared application directory could not be located!");
                return;
            }

            using (var fileDialog = new OpenFileDialog()) {
                Form parentForm = ((UserControl) _documentsView).ParentForm;

                fileDialog.Filter = "All files|*.*";
                fileDialog.Title = "Please select documents to upload";
                fileDialog.InitialDirectory = Settings.Default.DefaultDirectory;

                if (fileDialog.ShowDialog(parentForm) != DialogResult.OK) {
                    return;
                }

                foreach (string fileName in fileDialog.FileNames) {
                    Session.DocumentService.QueueUpload(fileName, _documentsView.CurrentEntity);
                }
            }
        }

        private void _documentsView_NewFeatureCAMFile(object sender, EventArgs e)
        {
            if (!Directory.Exists(Settings.Default.SharedAppDir)) {
                _documentsView.DialogService.ShowError("The shared application directory could not be located!");
                return;
            }

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        var op = _documentsView.CurrentEntity as Operation;

                        Method method = cpe.Methods.GetById(op.MethodId);

                        string drawingNo = method.PartVersion.Part.DrawingNumber;
                        string version = method.PartVersion.VersionNumber;
                        int opNumber = op.Sequence;

                        string fileName = string.Format("{0} Version {1} Op {2:00}.fm", drawingNo, version, opNumber);

                        string pathToFile = Path.Combine(Path.GetTempPath(), fileName);

                        string machineGroup = cpe.MachineGroups.GetById(op.MachineGroupId).Name;

                        string templateFileName = null;

                        switch (machineGroup.ToLower()) {
                            case "mills":
                                templateFileName = Settings.Default.CamTemplateMilling;
                                break;
                            case "lathes":
                                templateFileName = Settings.Default.CamTemplateTurning;
                                break;
                        }

                        if (!File.Exists(templateFileName)) {
                            _documentsView.DialogService.ShowError("The CAM template file could not be found!");
                            return;
                        }

                        try {
                            using (BusyCursor.Show()) {
                                byte[] data = File.ReadAllBytes(templateFileName);

                                File.WriteAllBytes(pathToFile, data);
                            }
                        }
                        catch (Exception ex) {
                            HandleException(ex);
                            return;
                        }

                        Session.DocumentService.QueueUpload(pathToFile, op, true);
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void _documentsView_NewTurningProgram(object sender, EventArgs e)
        {
            if (!_documentsView.DialogService.AskQuestion("Are you sure you want to create a new turning program?")) {
                return;
            }

            if (!Directory.Exists(Settings.Default.SharedAppDir)) {
                _documentsView.DialogService.ShowError("The shared application directory could not be located!");
                return;
            }

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        MachineGroup group = cpe.MachineGroups.GetByName("LATHES");

                        if (group == null) {
                            throw new InvalidOperationException("There isn't a machine group for lathes!");
                        }

                        var op = _documentsView.CurrentEntity as Operation;

                        Method method = cpe.Methods.GetById(op.MethodId);

                        string tempPath = Path.GetTempPath();

                        string tempFileName = string.Format("{0}\\{1:0000}.nc", tempPath, group.NextNumber);

                        var header = new StringBuilder(Settings.Default.TurningProgramHeaderFormat);
                        header.Replace("{prog}", group.NextNumber.ToString("D4"));
                        header.Replace("{dwg}", method.PartVersion.Part.DrawingNumber);
                        header.Replace("{ver}", method.PartVersion.VersionNumber);
                        header.Replace("{op}", op.Sequence.ToString("D2"));
                        header.Replace("{cust}", method.PartVersion.Part.Customer.Name);
                        header.Replace("{name}", method.PartVersion.Part.Name);

                        IOrderedEnumerable<OperationTool> opTools = cpe.OperationTools.GetByOperation(
                            _documentsView.CurrentEntity as Operation)
                            .OrderBy(t => t.Position)
                            .ThenBy(t => t.Offset);

                        if (opTools.Any()) {
                            foreach (OperationTool opTool in opTools) {
                                string line = Settings.Default.TurningProgramToolFormat
                                    .Replace("{position}", opTool.Position.ToString("00"))
                                    .Replace("{offset}", opTool.Offset.ToString("00"))
                                    .Replace("{tool}", opTool.Tool.Description.Replace(":", ""));

                                header.AppendLine(line);

                                if (opTool.HolderId.HasValue) {
                                    string holderLine = Settings.Default.TurningProgramHolderFormat
                                        .Replace("{holder}", opTool.Holder.Name);
                                    header.AppendLine(holderLine);
                                }

                                header.AppendLine();
                            }
                        }

                        File.WriteAllText(tempFileName, header.ToString());

                        Session.DocumentService.QueueUpload(tempFileName, op);

                        group.NextNumber += 1;

                        cpe.MachineGroups.Update(group);

                        cpe.Commit();
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void _documentsView_DeleteSelectedDocuments(object sender, EventArgs e)
        {
            const string question = "Are you sure you want to delete these documents?\n\nThis cannot be undone!";

            if (!_documentsView.DialogService.AskQuestion(question)) {
                return;
            }

            Session.DocumentService.DeleteDocuments(_documentsView.SelectedDocuments);
        }

        private void _documentsView_OpenDocument(object sender, EventArgs e)
        {
            //var document = _documentsView.SelectedDocuments.First();

            //Session.DocumentService.OpenDocument(document);
        }

        private void _documentsView_FilesDropped(object sender, FileDropEventArgs e)
        {
            if (!Directory.Exists(Settings.Default.SharedAppDir)) {
                _documentsView.DialogService.ShowError("The shared application directory could not be located!");
                return;
            }

            foreach (string file in e.DroppedFiles) {
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
            lock (_refreshLocker) {
                var entity = e.Argument as IEntity;

                try {
                    using (var cpe = new CPEUnitOfWork()) {
                        cpe.OpenConnection();

                        IEnumerable<Document> documents = null;

                        var model = new DocumentsViewModel(OperationType.None);

                        if (entity is Operation) {
                            var op = entity as Operation;

                            MachineGroup machineGroup = cpe.MachineGroups.GetById(op.MachineGroupId);

                            model.OpType = OperationType.None;

                            if (machineGroup.Name == MillingGroupName) {
                                model.OpType = OperationType.Milling;
                            }
                            else if (machineGroup.Name == TurningGroupName) {
                                model.OpType = OperationType.Turning;
                            }

                            documents = cpe.Documents.GetByOperation(entity.Id);
                        }
                        else if (entity is Part) {
                            documents = cpe.Documents.GetByPart(entity.Id);
                        }
                        else if (entity is PartVersion) {
                            documents = cpe.Documents.GetByPartVersion(entity.Id);
                        }

                        foreach (Document document in documents.OrderBy(d => d.FileName)) {
                            string pathToFile = Session.DocumentService.GetPathToDocument(document, cpe);

                            model.AddDocumentModel(document, pathToFile);
                        }

                        e.Result = model;
                    }
                }
                catch (Exception ex) {
                    e.Result = ex;
                }
            }
        }

        private void _refreshDocumentsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // BUG: find out why this happens when refreshing the library!
            if (_refreshDocumentsWorker == null) {
                return;
            }

            _refreshDocumentsWorker.Dispose();
            _refreshDocumentsWorker = null;

            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                return;
            }

            var model = (DocumentsViewModel) e.Result;

            _documentsView.DisplayDocuments(model);
        }

        private IEnumerable<Document> GetDocuments()
        {
            IEnumerable<Document> docs;

            using (var cpe = new CPEUnitOfWork()) {
                using (BusyCursor.Show()) {
                    if (_documentsView.CurrentEntity is Operation) {
                        docs = cpe.Documents.GetByOperation((Operation) _documentsView.CurrentEntity);
                    }
                    else if (_documentsView.CurrentEntity is Part) {
                        docs = cpe.Documents.GetByPart((Part) _documentsView.CurrentEntity);
                    }
                    else // is IPartVersion
                    {
                        docs = cpe.Documents.GetByPartVersion((PartVersion) _documentsView.CurrentEntity);
                    }
                }
            }

            var existingDocs = new List<Document>();

            foreach (Document doc in docs) {
                string pathToFile = Session.DocumentService.GetPathToDocument(doc);

                if (!File.Exists(pathToFile)) {
                    // TODO: Handle missing documents
                    continue;
                }

                existingDocs.Add(doc);
            }

            return existingDocs;
        }

        private void HandleException(Exception exception)
        {
            string message;

            if (exception is DataProviderException) {
                message = exception.Message;
            }
            else {
                message = exception.InnerException == null
                    ? exception.Message
                    : exception.InnerException.Message;
            }

            _documentsView.DialogService.ShowError(message);
        }
    }
}