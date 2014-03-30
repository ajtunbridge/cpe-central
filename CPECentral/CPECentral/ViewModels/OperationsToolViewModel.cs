#region Using directives

using System.Collections.Generic;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.ViewModels
{
    public class OperationToolsViewModel
    {
        public List<OperationToolsViewModelItem> Items { get; set; }
    }

    public class OperationToolsViewModelItem
    {
        public OperationTool OperationTool { get; set; }
        public string ToolName { get; set; }
        public string HolderName { get; set; }
        public double? QuantityInStock { get; set; }
    }
}