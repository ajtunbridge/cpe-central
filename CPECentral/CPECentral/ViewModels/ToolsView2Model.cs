#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.ViewModels
{
    public class ToolsView2Model
    {
        public Tool Tool { get; set; }

        public double? QuantityInStock { get; set; }
    }
}