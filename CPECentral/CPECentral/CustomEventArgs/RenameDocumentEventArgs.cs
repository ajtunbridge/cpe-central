#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class RenameDocumentEventArgs : EventArgs
    {
        public RenameDocumentEventArgs(Document document, string newFileName)
        {
            Document = document;
            NewFileName = newFileName;
        }

        public Document Document { get; set; }
        public string NewFileName { get; set; }
    }
}