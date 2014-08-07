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
    
    public partial class Part
    {
        public Part()
        {
            this.PartVersions = new HashSet<PartVersion>();
            this.Documents = new HashSet<Document>();
        }
    
        public int Id { get; set; }
        public string DrawingNumber { get; set; }
        public string Name { get; set; }
        public string ToolingLocation { get; set; }
        public int CustomerId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<PartVersion> PartVersions { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
