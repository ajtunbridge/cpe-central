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
    
    public partial class DNoteSearchView
    {
        public int DNote_Reference { get; set; }
        public System.DateTime Delivery_Date { get; set; }
        public string User_Reference { get; set; }
        public bool Issued { get; set; }
        public bool Cancelled { get; set; }
        public Nullable<int> Customer_Reference { get; set; }
        public Nullable<int> Sup_Ref { get; set; }
        public string Document_Type { get; set; }
        public string Customer_Name { get; set; }
        public string Supplier_Name { get; set; }
        public string WO_UserRef_Seq { get; set; }
        public string Part_Number { get; set; }
        public string Part_Issue { get; set; }
        public string Drawing_Number { get; set; }
        public string Drawing_Issue { get; set; }
        public Nullable<double> Method { get; set; }
    }
}
