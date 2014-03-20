#region Using directives

using System;

#endregion

namespace CPECentral.CustomEventArgs
{
    public class TransferStartedEventArgs : EventArgs
    {
        public TransferStartedEventArgs(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }
    }
}