//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tricorn
{
    using System;
    using System.Collections.Generic;
    
    public partial class CP_Daily
    {
        public int ID { get; set; }
        public int WCentre_Reference { get; set; }
        public System.DateTime TheDate { get; set; }
        public Nullable<int> Week_No { get; set; }
        public Nullable<int> Year_No { get; set; }
        public Nullable<int> Time_Available { get; set; }
        public Nullable<int> Time_Used { get; set; }
        public string YearWeek { get; set; }
        public Nullable<decimal> Time_Percent { get; set; }
    }
}
