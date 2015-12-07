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
    
    public partial class QWCentre
    {
        public int QWCentre_Reference { get; set; }
        public int Sequence { get; set; }
        public double Quantity { get; set; }
        public Nullable<int> Display_Sequence { get; set; }
        public Nullable<double> Setting_Time { get; set; }
        public Nullable<double> Run_Time { get; set; }
        public Nullable<decimal> Cost_Per_Hour { get; set; }
        public Nullable<double> Total_Hours { get; set; }
        public Nullable<decimal> Total_Cost { get; set; }
        public Nullable<int> Inspection_Level { get; set; }
        public Nullable<double> Uplift { get; set; }
        public byte[] Notes { get; set; }
        public int Quote_Reference { get; set; }
        public int WCentre_Reference { get; set; }
        public int Client_Reference { get; set; }
        public System.DateTime Date_Created { get; set; }
        public System.DateTime Date_Last_Modified { get; set; }
        public string Centre_Id { get; set; }
        public Nullable<double> Schedule_Days { get; set; }
        public Nullable<int> Operation_Number { get; set; }
        public bool External_Work { get; set; }
    
        public virtual Quote Quote { get; set; }
    }
}
