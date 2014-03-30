#region Using directives

using System;

#endregion

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