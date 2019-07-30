using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.Messages
{
    public class GaugeEditedMessage
    {
        public Gauge EditedGauge { get; }

        public GaugeEditedMessage(Gauge editedGauge)
        {
            EditedGauge = editedGauge;
        }
    }
}