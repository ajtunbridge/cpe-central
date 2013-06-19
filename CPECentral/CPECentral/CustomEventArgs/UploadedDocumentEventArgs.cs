#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public class UploadedDocumentEventArgs : EventArgs
    {
        public UploadedDocumentEventArgs(IEntity entity)
        {
            Entity = entity;
        }

        public IEntity Entity { get; private set; }
    }
}