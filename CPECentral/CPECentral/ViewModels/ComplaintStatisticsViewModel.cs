using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.ViewModels
{
    public class ComplaintStatisticsViewModel
    {
        public class CategoryAndPercentage
        {
            public string Category { get; set; }
            public double Percentage { get; set; }
        }

        public List<CategoryAndPercentage> CustomerResults { get; } = new List<CategoryAndPercentage>();

        public List<CategoryAndPercentage> InternalResults { get; } = new List<CategoryAndPercentage>();

        public List<CategoryAndPercentage> SupplierResults { get; } = new List<CategoryAndPercentage>();
    }
}
