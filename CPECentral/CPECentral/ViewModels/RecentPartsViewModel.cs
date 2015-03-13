using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.ViewModels
{
    public class RecentPartsViewModel
    {
        public Part Part { get; set; }

        public Image CurrentVersionPhoto { get; set; }
    }
}
