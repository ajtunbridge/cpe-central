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
    
    public partial class TEvent_Log
    {
        public int Log_Reference { get; set; }
        public System.DateTime Log_Date { get; set; }
        public string Module { get; set; }
        public string Event_Type { get; set; }
        public string Message { get; set; }
        public Nullable<int> Employee_Reference { get; set; }
        public string Who { get; set; }
        public string Entity_Type { get; set; }
        public Nullable<int> Entity_Reference { get; set; }
        public Nullable<System.DateTime> Auto_Expiry_Date { get; set; }
        public string PC_Name { get; set; }
        public string App_Name { get; set; }
        public string Data_Field { get; set; }
    }
}
