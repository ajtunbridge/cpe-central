using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.CustomEventArgs
{
    public class GaugeEventArgs : EventArgs
    {
        public GaugeEventArgs(Gauge gauge)
        {
            Gauge = gauge;
        }

        public Gauge Gauge { get; private set; }
    }
}
