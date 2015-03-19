#region Using directives

using System;
using System.Collections.Generic;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.ViewModels
{
    [Flags]
    public enum OperationType
    {
        CncMilling = 2,
        CncTurning = 4,
        NotSpecified = 0
    }

    public class DocumentsViewModel
    {
        private readonly List<DocumentModel> _documentModels = new List<DocumentModel>();
        private readonly List<string> _missingFiles = new List<string>();

        public DocumentsViewModel(OperationType opType)
        {
            OpType = opType;
        }

        public IEnumerable<DocumentModel> DocumentModels
        {
            get { return _documentModels; }
        }

        public OperationType OpType { get; set; }

        public List<string> MissingFiles
        {
            get { return _missingFiles; }
        }

        public void AddDocumentModel(Document document, string fileName)
        {
            _documentModels.Add(new DocumentModel(document, fileName));
        }
    }

    public class DocumentModel
    {
        public DocumentModel(Document document, string fileName)
        {
            Document = document;
            FileName = fileName;
        }

        public Document Document { get; private set; }
        public string FileName { get; private set; }
    }
}