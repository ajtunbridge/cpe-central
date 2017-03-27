using System;

namespace CPECentral.QMS.Model
{
    public class Complaint
    {
        public int ReportNumber { get; set; }

        public string RaisedBy { get; set; }

        public DateTime? RaisedOn { get; set; }

        public string Contact { get; set; }

        public string Category { get; set; }

        public string ResultsOfInspection { get; set; }

        public string Reason { get; set; }

        public string Description { get; set; }

        public string Employee { get; set; }

        public string AuthorizedBy { get; set; }

        public string CorrectiveAction { get; set; }

        public string PreventativeAction { get; set; }

        public string Conclusion { get; set; }
    }
}
