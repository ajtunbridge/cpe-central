#region Using directives

using CPECentral.Data.EF5;
using System.Collections.Generic;

#endregion Using directives

namespace CPECentral.ViewModels
{
    public sealed class PartInformationViewModel
    {
        public IEnumerable<PartVersion> AllVersions { get; set; }
        public IEnumerable<Customer> AllCustomers { get; set; }
        public Customer Customer { get; set; }

        public bool PartHasAlerts { get; set; }

        public string DrawingNumber { get; set; }
        public string Name { get; set; }
        public string ToolingLocation { get; set; }
        public bool ReadOnly { get; set; }
    }
}