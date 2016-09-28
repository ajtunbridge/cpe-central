using System.Collections.Generic;

namespace CPECentral.ViewModels
{
    public class TurnoverGraphViewModel
    {
        public List<GraphPoint> GraphPoints { get; private set; } = new List<GraphPoint>();

        public int MedianValue { get; set; }

        public class GraphPoint
        {
            public GraphPoint(string month, int percentage)
            {
                Month = month;
                Percentage = percentage;
            }

            public string Month { get; private set; }
            public int Percentage { get; private set; }
        }
    }
}