using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcCommunicator.Data.Model
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ComPort { get; set; }
        public int MachineControlId { get; set; }
    }
}