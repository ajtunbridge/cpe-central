using System;
using CPECentral.Views;

namespace CPECentral.CustomEventArgs
{
    public sealed class TimePeriodChangedEventArgs : EventArgs
    {
        public TimePeriodChangedEventArgs(ComplaintStatisticsView.TimePeriod timePeriod)
        {
            TimePeriod = timePeriod;
        }

        public ComplaintStatisticsView.TimePeriod TimePeriod { get; }
    }
}