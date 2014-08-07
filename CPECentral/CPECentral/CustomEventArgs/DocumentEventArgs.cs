#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class DocumentEventArgs : EventArgs
    {
        public DocumentEventArgs(Document document)
        {
            Document = document;
        }

        public Document Document { get; private set; }
    }
}