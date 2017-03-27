using System;
using System.Collections.Generic;

namespace CPECentral.ViewModels.Quality
{
    public class CalibrationResultsViewModel
    {
        public DateTime CalibrationDate { get; set; }
        public string CalibratedBy { get; set; }
        public double? M1Deviation { get; set; }
        public double? M2Deviation { get; set; }
        public double? M3Deviation { get; set; }
        public double? M4Deviation { get; set; }

        public List<Result> Deviations { get; } = new List<Result>();
        public bool ExternalAndInternal;

        public class Result
        {
            public Result(double m1Deviation, double m2Deviation, double m3Deviation, double m4Deviation, bool isInternalMeasurement)
            {
                M1Deviation = m1Deviation;
                M2Deviation = m2Deviation;
                M3Deviation = m3Deviation;
                M4Deviation = m4Deviation;
                IsInternalMeasurement = isInternalMeasurement;
            }

            bool IsInternalMeasurement { get; }
            public string Column1Text { get; } = "-";
            public string Column2Text { get; set; } = "-";
            public double M1Deviation { get; }
            public double? M2Deviation { get; }
            public double? M3Deviation { get; }
            public double? M4Deviation { get; }
        }
    }
}