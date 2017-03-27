using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.ViewModels
{
    public class PartWorksOrdersViewModel
    {
        public string WorksOrderNumber { get; set; }

        public DateTime? DueOn { get; set; }

        public int Quantity { get; set; }

        public int BuildQuantity { get; set; }

        public string OrderNumber { get; set; }
    }
}
