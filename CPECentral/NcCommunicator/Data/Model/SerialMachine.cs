#region Using directives

using System.IO.Ports;

#endregion

namespace NcCommunicator.Data.Model
{
    public class SerialMachine : Machine
    {
        public string ComPort { get; set; }

        public StopBits StopBits { get; set; }

        public Parity Parity { get; set; }

        public Handshake Handshake { get; set; }

        public byte DataBits { get; set; }

        public int BaudRate { get; set; }

        public bool DtrEnable { get; set; }

        public bool RtsEnable { get; set; }

        public byte XOnChar { get; set; }

        public byte XOffChar { get; set; }

        public byte AltXOnChar { get; set; }

        public byte AltXOffChar { get; set; }

        public string ProgramStart { get; set; }

        public string ProgramEnd { get; set; }

        public string NewLine { get; set; }
    }
}