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
    
    public partial class MStock
    {
        public int MStock_Reference { get; set; }
        public Nullable<double> Quantity_Expected { get; set; }
        public Nullable<double> Quantity_Received { get; set; }
        public Nullable<decimal> Unit_Cost { get; set; }
        public Nullable<double> Quantity_In_Stock { get; set; }
        public string Batch_Number { get; set; }
        public string CoC { get; set; }
        public string Supplier_Batch_Number { get; set; }
        public string Advice_Note { get; set; }
        public string Notes { get; set; }
        public string Source { get; set; }
        public string Source_Reference { get; set; }
        public string Supplier_Name { get; set; }
        public Nullable<System.DateTime> Received_Date { get; set; }
        public Nullable<int> PItem_Reference { get; set; }
        public Nullable<int> Material_Reference { get; set; }
        public Nullable<int> WOrder_Reference { get; set; }
        public Nullable<int> Customer_Reference { get; set; }
        public Nullable<int> Client_Reference { get; set; }
        public Nullable<System.DateTime> Date_Created { get; set; }
        public Nullable<System.DateTime> Date_Last_Modified { get; set; }
        public Nullable<double> Cost_Quantity { get; set; }
        public Nullable<double> Quantity_Rejected { get; set; }
        public bool Quarantined { get; set; }
        public string Location { get; set; }
        public bool Consolidated { get; set; }
        public Nullable<System.DateTime> Expiry_Date { get; set; }
        public Nullable<int> NumFileAttachments { get; set; }
        public Nullable<int> NumBrokenLinks { get; set; }
        public Nullable<int> PIA_Reference { get; set; }
    }
}
