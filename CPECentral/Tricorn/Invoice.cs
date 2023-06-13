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
    
    public partial class Invoice
    {
        public int Invoice_Reference { get; set; }
        public System.DateTime Invoice_Date { get; set; }
        public Nullable<int> Customer_Reference { get; set; }
        public string User_Reference { get; set; }
        public Nullable<double> VAT_Rate { get; set; }
        public Nullable<decimal> Delivery_Charge { get; set; }
        public Nullable<double> Delivery_VAT_Rate { get; set; }
        public string Notes { get; set; }
        public bool Issued { get; set; }
        public bool Credit_Note { get; set; }
        public bool Cancelled { get; set; }
        public string External_Nominal { get; set; }
        public string External_Department { get; set; }
        public string External_Tax_Code { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public int Client_Reference { get; set; }
        public System.DateTime Date_Created { get; set; }
        public System.DateTime Date_Last_Modified { get; set; }
        public Nullable<int> Cross_Reference { get; set; }
        public Nullable<bool> Exported { get; set; }
        public Nullable<bool> Proforma { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<int> Owned_By { get; set; }
        public Nullable<int> Last_Modified { get; set; }
        public Nullable<double> Exchange_Rate { get; set; }
        public Nullable<int> NumFileAttachments { get; set; }
        public Nullable<int> NumBrokenLinks { get; set; }
        public int Invoice_Location_Reference { get; set; }
        public Nullable<int> Invoice_Contact_Reference { get; set; }
        public Nullable<System.DateTime> Invoice_Due_Date { get; set; }
        public string UDFF01 { get; set; }
        public string UDFF02 { get; set; }
        public string UDF03 { get; set; }
        public string UDF04 { get; set; }
        public string UDF05 { get; set; }
        public string UDF06 { get; set; }
        public string UDF07 { get; set; }
        public string UDF08 { get; set; }
        public string UDF01 { get; set; }
        public string UDF02 { get; set; }
        public Nullable<System.DateTime> UDFD01 { get; set; }
        public Nullable<System.DateTime> UDFD02 { get; set; }
    }
}
