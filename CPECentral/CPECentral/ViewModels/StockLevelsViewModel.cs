using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.ViewModels
{
    public class StockLevelsViewModel
    {
        public IEnumerable<StockLevelsViewModelItem> StockLevels { get; set; }
    }

    public class StockLevelsViewModelItem
    {
        public string BatchNumber { get; set; }
        public double Quantity { get; set; }
        public string Location { get; set; }
    }
}
