using System;
using System.Collections.Generic;
using System.Linq;

namespace CPECentral.ViewModels
{
    public class WorkCentreScheduleViewModel
    {
        private readonly List<ScheduledJob> _nextJobs = new List<ScheduledJob>();
        public IEnumerable<ScheduledJob> NextJobs => _nextJobs.OrderBy(j => j.ScheduledStart);

        public void AddJob(ScheduledJob job)
        {
            _nextJobs.Add(job);
        }

        public class ScheduledJob
        {
            public string WorksOrderNumber { get; set; }
            public string DrawingNumber { get; set; }
            public string Version { get; set; }
            public string Name { get; set; }
            public DateTime DueOn { get; set; }
            public DateTime ScheduledStart { get; set; }
        }
    }
}