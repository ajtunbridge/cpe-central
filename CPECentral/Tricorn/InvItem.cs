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
    
    public partial class InvItem
    {
        public int InvItem_Reference { get; set; }
        public int Invoice_Reference { get; set; }
        public Nullable<int> Batch_Reference { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public string Drawing_Number { get; set; }
        public string Drawing_Issue { get; set; }
        public string Notes { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public int Client_Reference { get; set; }
        public System.DateTime Date_Created { get; set; }
        public System.DateTime Date_Last_Modified { get; set; }
    }
}
