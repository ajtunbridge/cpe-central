#region Using directives

using System;

#endregion

namespace NcCommunicator
{
    public class TransmitProgressEventArgs : EventArgs
    {
        public TransmitProgressEventArgs(byte[] transmittedData, int progress)
        {
            TransmittedData = transmittedData;
            Progress = progress;
        }

        public int Progress { get; private set; }

        public byte[] TransmittedData { get; private set; }
    }
}