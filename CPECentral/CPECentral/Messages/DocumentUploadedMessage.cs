﻿#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Messages
{
    public class DocumentUploadedMessage
    {
        public DocumentUploadedMessage(IEntity entity)
        {
            Entity = entity;
        }

        public IEntity Entity { get; private set; }
    }
}