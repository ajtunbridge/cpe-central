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
    
    public partial class WOTool
    {
        public int WOTool_Reference { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Total_Cost { get; set; }
        public string Notes { get; set; }
        public Nullable<int> Supplier_Reference { get; set; }
        public int WOrder_Reference { get; set; }
        public Nullable<int> PItem_Reference { get; set; }
        public Nullable<double> Quantity_Sourced { get; set; }
        public Nullable<System.DateTime> Delivery_Date { get; set; }
        public int Client_Reference { get; set; }
        public System.DateTime Date_Created { get; set; }
        public System.DateTime Date_Last_Modified { get; set; }
        public Nullable<double> Uplift_Percentage { get; set; }
        public Nullable<decimal> Surcharge { get; set; }
    
        public virtual WOrder WOrder { get; set; }
    }
}
