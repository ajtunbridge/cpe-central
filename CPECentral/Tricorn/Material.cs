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
    
    public partial class Material
    {
        public int Material_Reference { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public int Cost_Quantity { get; set; }
        public string Specification { get; set; }
        public string Thickness_Diameter { get; set; }
        public Nullable<decimal> Minimum_Charge { get; set; }
        public Nullable<double> Size { get; set; }
        public string Form { get; set; }
        public Nullable<double> Length { get; set; }
        public string Location { get; set; }
        public Nullable<double> Replenish_Level { get; set; }
        public Nullable<double> Existing_Stock { get; set; }
        public Nullable<double> Minimum_Stock { get; set; }
        public Nullable<double> Maximum_Stock { get; set; }
        public string Drawing_Number { get; set; }
        public string Drawing_Issue { get; set; }
        public string Notes { get; set; }
        public Nullable<int> Supplier_Reference { get; set; }
        public int Client_Reference { get; set; }
        public System.DateTime Date_Created { get; set; }
        public System.DateTime Date_Last_Modified { get; set; }
        public Nullable<double> Uplift_Percentage { get; set; }
        public string Unit_Of_Measurement { get; set; }
        public string Part_Number { get; set; }
        public string Part_Issue { get; set; }
        public Nullable<int> Customer_Reference { get; set; }
        public Nullable<double> Existing_Quarantine { get; set; }
        public Nullable<int> Delivery_Lead_Time { get; set; }
        public Nullable<decimal> Minimum_Selling_Price { get; set; }
        public Nullable<decimal> Recommended_Selling_Price { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<int> Owned_By { get; set; }
        public Nullable<int> Last_Modified { get; set; }
        public Nullable<int> NominalCode_Reference { get; set; }
        public string Expiry_Period { get; set; }
        public Nullable<int> Expiry_Interval { get; set; }
        public string Stock_Category { get; set; }
    }
}