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
    
    public partial class PStock_View
    {
        public string Batch_Number { get; set; }
        public Nullable<double> Quantity_In_Stock { get; set; }
        public bool Quarantined { get; set; }
        public string Supplier_Name { get; set; }
        public Nullable<System.DateTime> Received_Date { get; set; }
        public Nullable<double> Quantity_Received { get; set; }
        public int PStock_Reference { get; set; }
        public Nullable<int> Part_Reference { get; set; }
    }
}
