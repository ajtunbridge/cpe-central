using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tricorn
{
    public class QuoteDetail
    {
        public DateTime? Date { get; set; }

        public string QuoteNumber { get; set; }

        public string GroupReference { get; set; }

        public double? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
