﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CPECentralEntities : DbContext
    {
        public CPECentralEntities()
            : base("name=CPECentralEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<EmployeeGroup> EmployeeGroups { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HolderGroup> HolderGroups { get; set; }
        public DbSet<Holder> Holders { get; set; }
        public DbSet<HolderTool> HolderTools { get; set; }
        public DbSet<MachineGroup> MachineGroups { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Method> Methods { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationTool> OperationTools { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartVersion> PartVersions { get; set; }
        public DbSet<ToolGroup> ToolGroups { get; set; }
        public DbSet<Tool> Tools { get; set; }
    }
}
