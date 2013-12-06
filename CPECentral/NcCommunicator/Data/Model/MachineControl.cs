using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public byte XonChar { get; set; }
        public byte XoffChar { get; set; }
        public byte ProgramStartChar { get; set; }
        public byte ProgramEndChar { get; set; }
        public string NewLine { get; set; }
    }
}