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
    
    public partial class DiscountDetail
    {
        public int Discount_Reference { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
        public bool IsDefault { get; set; }
        public Nullable<int> Client_Reference { get; set; }
        public Nullable<System.DateTime> Date_Created { get; set; }
        public Nullable<System.DateTime> Date_Last_Modified { get; set; }
    }
}