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
    
    public partial class DNote
    {
        public DNote()
        {
            this.DItems = new HashSet<DItem>();
        }
    
        public int DNote_Reference { get; set; }
        public System.DateTime Delivery_Date { get; set; }
        public Nullable<int> Del_Location_Reference { get; set; }
        public Nullable<int> CoC_Location_Reference { get; set; }
        public string User_Reference { get; set; }
        public string Notes { get; set; }
        public bool Issued { get; set; }
        public bool Cancelled { get; set; }
        public Nullable<int> DMethod_Reference { get; set; }
        public Nullable<int> Customer_Reference { get; set; }
        public int Client_Reference { get; set; }
        public System.DateTime Date_Created { get; set; }
        public System.DateTime Date_Last_Modified { get; set; }
        public Nullable<int> Sup_Ref { get; set; }
        public Nullable<int> Sup_Del_Locn_Ref { get; set; }
        public Nullable<int> Sup_CoC_Locn_Ref { get; set; }
        public string Document_Type { get; set; }
        public Nullable<int> Contact_Reference { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<int> Owned_By { get; set; }
        public Nullable<int> Last_Modified { get; set; }
        public Nullable<System.DateTime> Despatch_Date { get; set; }
        public string Tracking_Number { get; set; }
        public Nullable<int> Days_Early { get; set; }
        public Nullable<int> Days_Late { get; set; }
        public Nullable<int> NumFileAttachments { get; set; }
        public Nullable<int> NumBrokenLinks { get; set; }
        public Nullable<bool> BatchTrace { get; set; }
        public string UDF01 { get; set; }
        public string UDF02 { get; set; }
        public string UDF03 { get; set; }
        public string UDF04 { get; set; }
        public string UDF05 { get; set; }
        public string UDF06 { get; set; }
        public Nullable<System.DateTime> UDFD01 { get; set; }
        public Nullable<System.DateTime> UDFD02 { get; set; }
    
        public virtual ICollection<DItem> DItems { get; set; }
    }
}
