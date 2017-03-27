using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tricorn
{
    public partial class WCentre
    {
        public override string ToString()
        {
            return Name;
        }
    }

    public partial class WOrder
    {
        public DateTime ScheduledStart { get; set; }
    }
}
