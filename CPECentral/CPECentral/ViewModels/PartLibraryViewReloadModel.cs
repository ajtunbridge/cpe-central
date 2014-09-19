#region Using directives

using System.Collections.Generic;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.ViewModels
{
    public class PartLibraryViewReloadModel
    {
        public int? LastViewedPartId { get; set; }

        public ICollection<CustomerParts> Results { get; set; }

        #region Nested type: CustomerParts

        public class CustomerParts
        {
            public Customer Customer { get; set; }

            public ICollection<Part> Parts { get; set; }
        }

        #endregion
    }
}