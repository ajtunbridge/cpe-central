using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.CustomEventArgs
{
    public class TransferStartedEventArgs : EventArgs
    {
        public string FileName { get; private set; }

        public TransferStartedEventArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}
