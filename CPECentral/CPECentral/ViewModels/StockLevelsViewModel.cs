#region Using directives

using System.Collections.Generic;

#endregion

namespace CPECentral.ViewModels
{
    public class StockLevelsViewModel
    {
        public IEnumerable<TricornBatch> Batches { get; set; }
    }

    public class TricornBatch
    {
        public string BatchNumber { get; set; }
        public double Quantity { get; set; }
        public string Location { get; set; }
    }
}