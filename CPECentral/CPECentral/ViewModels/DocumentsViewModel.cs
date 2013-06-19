using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.ViewModels
{
    public class DocumentsViewModel
    {
        public Document Document { get; private set; }
        public string FileName { get; private set; }

        public DocumentsViewModel(Document document, string fileName)
        {
            Document = document;
            FileName = fileName;
        }
    }
}
