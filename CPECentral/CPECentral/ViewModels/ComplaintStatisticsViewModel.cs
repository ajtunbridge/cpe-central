using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.ViewModels
{
    public class ComplaintStatisticsViewModel
    {
        public class Result
        {
            public string Category { get; set; }
            public double Percentage { get; set; }
        }

        public List<Result> Results { get; } = new List<Result>();
    }
}
