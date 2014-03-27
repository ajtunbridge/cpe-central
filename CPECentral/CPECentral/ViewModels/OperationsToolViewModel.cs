using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

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
