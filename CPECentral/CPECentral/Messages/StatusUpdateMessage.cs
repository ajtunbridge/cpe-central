using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.Messages
{
    public class StatusUpdateMessage
    {
        public string Status { get; private set; }

        public StatusUpdateMessage(string status)
        {
            Status = status;
        }
    }
}
