#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.ViewModels.Quality
{
    public sealed class GaugeDetailViewModel
    {
        public string Name { get; set; }
        public GaugeType GaugeType { get; set; }
        public string Reference { get; set; }
        public Employee HeldBy { get; set; }
        public DateTime? DueForCalibrationOn { get; set; }
        public bool IsReferenceOnly { get; set; }
        public double? SizeRangeMin { get; set; }
        public double? SizeRangeMax { get; set; }
        public Image Photo { get; set; }
        public IList<GaugeType> GaugeTypes { get; set; }
        public IList<Employee> Employees { get; set; }  
    }
}