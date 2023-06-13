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
    
    public partial class WOInspection
    {
        public int WOinspection_Reference { get; set; }
        public Nullable<int> WOrder_Reference { get; set; }
        public string User_Reference { get; set; }
        public Nullable<int> Customer_Reference { get; set; }
        public Nullable<System.DateTime> Date_Raised { get; set; }
        public Nullable<System.DateTime> Date_Completed { get; set; }
        public string Description { get; set; }
        public string Drawing_Number { get; set; }
        public string Drawing_Issue { get; set; }
        public Nullable<System.DateTime> Delivery_Date { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string Order_Notes2 { get; set; }
        public Nullable<double> Quantity_Built { get; set; }
        public Nullable<double> Quantity_Passed { get; set; }
        public Nullable<int> Percentage { get; set; }
        public string Rating { get; set; }
        public Nullable<double> Inspection_High { get; set; }
        public Nullable<double> Inspection_Low { get; set; }
        public bool Concession_Applies { get; set; }
        public Nullable<int> Concession_Reference { get; set; }
        public bool NonConformance_Applies { get; set; }
        public Nullable<int> NonConformance_Reference { get; set; }
        public string Inspection_Notes2 { get; set; }
        public Nullable<System.DateTime> Date_Created { get; set; }
        public Nullable<System.DateTime> Date_Last_Modified { get; set; }
        public Nullable<int> Client_Reference { get; set; }
        public Nullable<int> Procedure_Reference { get; set; }
        public bool Reject_Applies { get; set; }
        public Nullable<int> Reject_Reference { get; set; }
        public bool Complaint_Applies { get; set; }
        public Nullable<int> Complaint_Reference { get; set; }
        public Nullable<System.DateTime> Next_Activity_Date { get; set; }
        public string Prefix { get; set; }
        public Nullable<int> Number { get; set; }
        public string Suffix { get; set; }
        public byte[] Inspection_Notes { get; set; }
        public byte[] Order_Notes { get; set; }
    }
}
