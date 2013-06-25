using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.ViewModels
{
    public enum OperationType
    {
        Milling,
        Turning,
        None
    }

    public class DocumentsViewModel
    {
        private readonly List<DocumentModel> _documentModels = new List<DocumentModel>();

        public IEnumerable<DocumentModel> DocumentModels
        {
            get { return _documentModels; }
        }

        public OperationType OpType { get; set; }

        public DocumentsViewModel(OperationType opType)
        {
            OpType = opType;
        }

        public void AddDocumentModel(Document document, string fileName)
        {
            _documentModels.Add(new DocumentModel(document, fileName));
        }
    }

    public class DocumentModel
    {
        public Document Document { get; private set; }
        public string FileName { get; private set; }

        public DocumentModel(Document document, string fileName)
        {
            Document = document;
            FileName = fileName;
        }
    }
}
