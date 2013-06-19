using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.Messages
{
    public class DocumentsChangedMessage
    {
        public DocumentsChangedMessage(IEntity entity)
        {
            Entity = entity;
        }

        public IEntity Entity { get; private set; }
    }
}
