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
    
    public partial class TRFQ_Item
    {
        public int RFQItem_Reference { get; set; }
        public int RFQ_Reference { get; set; }
        public string Type { get; set; }
        public Nullable<int> Material_Reference { get; set; }
        public Nullable<int> Part_Reference { get; set; }
        public Nullable<int> Subcontract_Reference { get; set; }
        public decimal Qty { get; set; }
        public string UOM { get; set; }
        public string Note { get; set; }
        public Nullable<int> Best_Supplier_Reference { get; set; }
        public string Other_Description { get; set; }
        public Nullable<bool> Accepted { get; set; }
        public Nullable<System.DateTime> Delivery_Date { get; set; }
        public Nullable<int> LineNumber { get; set; }
    }
}
