#region Using directives

using System;

#endregion

namespace NcCommunicator
{
    [Serializable]
    public class SerialConnectionFailedException : Exception
    {
        // TODO: design exception correctly
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp

        public SerialConnectionFailedException(string comPort, Exception innerException)
            : base("Serial connection failed on " + comPort, innerException)
        {
            ComPort = comPort;
        }

        public string ComPort { get; private set; }
    }
}