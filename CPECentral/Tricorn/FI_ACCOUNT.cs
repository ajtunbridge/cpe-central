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
    
    public partial class FI_ACCOUNT
    {
        public decimal PKNO { get; set; }
        public string DESCR { get; set; }
        public Nullable<decimal> TYP { get; set; }
        public Nullable<decimal> TAXRATE { get; set; }
        public string TAXKEY_SALESTAX { get; set; }
        public string TAXKEY_INPUTTAX { get; set; }
        public string SALESTAX { get; set; }
        public string INPUTTAX { get; set; }
        public string REVENUES { get; set; }
        public string REVENUES_ECONOMIC_AREA { get; set; }
        public string REVENUES_NOT_ECONOMIC_AREA { get; set; }
        public string EXPENSE { get; set; }
        public string EXPENSE_ECONOMIC_AREA { get; set; }
        public string EXPENSE_NOT_ECONOMIC_AREA { get; set; }
        public string CNAME { get; set; }
        public string CHNAME { get; set; }
        public Nullable<System.DateTime> CDATE { get; set; }
        public Nullable<System.DateTime> CHDATE { get; set; }
        public Nullable<decimal> MANDANTNO { get; set; }
    }
}