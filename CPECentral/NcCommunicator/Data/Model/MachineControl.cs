#region Using directives

using System.IO.Ports;

#endregion

namespace NcCommunicator.Data.Model
{
    public class MachineControl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StopBits StopBits { get; set; }
        public Parity Parity { get; set; }
        public Handshake Handshake { get; set; }
        public int DataBits { get; set; }
        public int BaudRate { get; set; }
        public bool DtrEnable { get; set; }
        public bool RtsEnable { get; set; }
        public char XOnChar { get; set; }
        public char XOffChar { get; set; }
        public char XOnChar2 { get; set; }
        public char XOffChar2 { get; set; }
        public char ProgramStartChar { get; set; }
        public char ProgramEndChar { get; set; }
        public string NewLine { get; set; }
    }
}