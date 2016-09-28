//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CPECentral.Data.EF5
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.CalibrationResults = new HashSet<CalibrationResult>();
            this.EmployeeWorkCentres = new HashSet<EmployeeWorkCentre>();
            this.NonConformances = new HashSet<NonConformance>();
            this.RecentParts = new HashSet<RecentPart>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int EmployeeGroupId { get; set; }
        public Nullable<int> LastViewedPartId { get; set; }
        public Nullable<int> PreferredMachineGroup { get; set; }
        public bool IsEnabled { get; set; }
    
        public virtual ICollection<CalibrationResult> CalibrationResults { get; set; }
        public virtual EmployeeGroup EmployeeGroup { get; set; }
        public virtual ICollection<EmployeeWorkCentre> EmployeeWorkCentres { get; set; }
        public virtual ICollection<NonConformance> NonConformances { get; set; }
        public virtual ICollection<RecentPart> RecentParts { get; set; }
    }
}
