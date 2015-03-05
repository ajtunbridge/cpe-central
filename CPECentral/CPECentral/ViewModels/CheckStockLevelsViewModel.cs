#region Using directives

using System.Collections.Generic;

#endregion

namespace CPECentral.ViewModels
{
    public class CheckStockLevelsViewModel
    {
        public CheckStockLevelsViewModel()
        {
            Children = new List<CheckStockLevelsViewModel>();
        }

        public CheckStockLevelsViewModel(string label, string quantity, string location,
            List<CheckStockLevelsViewModel> children)
        {
            Label = label;
            Quantity = quantity;
            Location = location;
            Children = children;
        }

        public List<CheckStockLevelsViewModel> Children { get; private set; }

        public string Label { get; set; }

        public string Quantity { get; set; }

        public string Location { get; set; }
    }
}