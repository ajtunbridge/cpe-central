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
    
    public partial class Holder
    {
        public Holder()
        {
            this.HolderTools = new HashSet<HolderTool>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int HolderGroupId { get; set; }
    
        public virtual HolderGroup HolderGroup { get; set; }
        public virtual ICollection<HolderTool> HolderTools { get; set; }
    }
}