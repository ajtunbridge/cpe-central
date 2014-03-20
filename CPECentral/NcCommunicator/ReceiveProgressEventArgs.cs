using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NcCommunicator
{
    public class ReceiveProgressEventArgs : EventArgs
    {
        public ReceiveProgressEventArgs(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}
