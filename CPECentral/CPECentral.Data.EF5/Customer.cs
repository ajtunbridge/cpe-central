//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CPECentral.Data.EF5
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.Parts = new HashSet<Part>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> TricornReference { get; set; }
        public byte[] LogoBlob { get; set; }
        public byte[] SalesOrderParserSettings { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    
        public virtual ICollection<Part> Parts { get; set; }
    }
}
