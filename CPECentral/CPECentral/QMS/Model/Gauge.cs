using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.QMS.Model
{
    public class Gauge
    {
        public string GaugeNumber { get; set; }

        public string SizeRange { get; set; }

        public string Description { get; set; }

        public string HeldBy { get; set; }

        public DateTime CalibrationDueOn { get; set; }
    }
}
