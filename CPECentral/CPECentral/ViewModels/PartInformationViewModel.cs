#region Using directives

using System.Collections.Generic;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.ViewModels
{
    public sealed class PartInformationViewModel
    {
        public IEnumerable<PartVersion> AllVersions { get; set; }
        public IEnumerable<Customer> AllCustomers { get; set; }
        public Customer Customer { get; set; }
        public string DrawingNumber { get; set; }
        public string Name { get; set; }
        public string ToolingLocation { get; set; }
        public bool ReadOnly { get; set; }
    }
}