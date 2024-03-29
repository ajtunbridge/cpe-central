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
    
    public partial class Tool
    {
        public Tool()
        {
            this.HolderTools = new HashSet<HolderTool>();
            this.OperationTools = new HashSet<OperationTool>();
            this.TricornTools = new HashSet<TricornTool>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public int ToolGroupId { get; set; }
        public byte[] PhotoBytes { get; set; }
    
        public virtual ICollection<HolderTool> HolderTools { get; set; }
        public virtual ICollection<OperationTool> OperationTools { get; set; }
        public virtual ToolGroup ToolGroup { get; set; }
        public virtual ICollection<TricornTool> TricornTools { get; set; }
    }
}
