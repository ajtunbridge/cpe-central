
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
    
public partial class WOrder
{

    public WOrder()
    {

        this.Batches = new HashSet<Batch>();

        this.WOComponents = new HashSet<WOComponent>();

        this.WOMaterials = new HashSet<WOMaterial>();

        this.WOParts = new HashSet<WOPart>();

        this.WOSubContracts = new HashSet<WOSubContract>();

        this.WOTools = new HashSet<WOTool>();

        this.WOWCentres = new HashSet<WOWCentre>();

    }


    public int WOrder_Reference { get; set; }

    public string Description { get; set; }

    public Nullable<System.DateTime> Prepared { get; set; }

    public Nullable<double> Quantity { get; set; }

    public Nullable<decimal> Price { get; set; }

    public string User_Reference { get; set; }

    public bool Main { get; set; }

    public Nullable<System.DateTime> Delivery { get; set; }

    public string Drawing_Number { get; set; }

    public string Drawing_Issue { get; set; }

    public Nullable<decimal> WCentre_Total_Cost { get; set; }

    public Nullable<decimal> Material_Total_Cost { get; set; }

    public Nullable<decimal> Part_Total_Cost { get; set; }

    public Nullable<decimal> SubContract_Total_Cost { get; set; }

    public Nullable<decimal> Tool_Total_Cost { get; set; }

    public Nullable<decimal> Total_Cost { get; set; }

    public Nullable<decimal> Batch_Total_Cost { get; set; }

    public byte[] Notes { get; set; }

    public byte[] Public_Notes { get; set; }

    public Nullable<int> Quote_Reference { get; set; }

    public string Customer_Order_Number { get; set; }

    public string Customer_Order_Item { get; set; }

    public Nullable<System.DateTime> Customer_Order_Date { get; set; }

    public bool CoC_Required { get; set; }

    public Nullable<double> Quantity_Batched { get; set; }

    public Nullable<int> Customer_Reference { get; set; }

    public Nullable<int> Location_Reference { get; set; }

    public Nullable<int> Contact_Reference { get; set; }

    public Nullable<int> Client_Reference { get; set; }

    public Nullable<System.DateTime> Date_Created { get; set; }

    public Nullable<System.DateTime> Date_Last_Modified { get; set; }

    public string Part_Number { get; set; }

    public string Part_Issue { get; set; }

    public Nullable<double> Method { get; set; }

    public Nullable<System.DateTime> Schedule_Date { get; set; }

    public string Delivery_Confirmed { get; set; }

    public Nullable<double> Total_Order_Quantity { get; set; }

    public Nullable<double> Outstanding_Quantity { get; set; }

    public string Status { get; set; }

    public string Contract_Number { get; set; }

    public string Location { get; set; }

    public bool Locked { get; set; }

    public Nullable<int> Lock_Employee { get; set; }

    public string Method_Description { get; set; }

    public Nullable<int> Sequence { get; set; }

    public Nullable<decimal> Assembly_Cost { get; set; }

    public Nullable<decimal> Assembly_WCentre_Cost { get; set; }

    public Nullable<decimal> Assembly_Material_Cost { get; set; }

    public Nullable<decimal> Assembly_Part_Cost { get; set; }

    public Nullable<decimal> Assembly_SubCon_Cost { get; set; }

    public Nullable<decimal> Assembly_Tool_Cost { get; set; }

    public Nullable<double> Quantity_To_Build { get; set; }

    public Nullable<double> Discount_Applied { get; set; }

    public Nullable<double> Customer_Discount_Applied { get; set; }

    public bool Already_Acknowledged { get; set; }

    public string BITMAP { get; set; }

    public Nullable<System.DateTime> Current_End_Date { get; set; }

    public string Scheduler_Colour { get; set; }

    public byte[] Long_Description { get; set; }

    public string Nominal_Code { get; set; }

    public Nullable<double> Exchange_Rate { get; set; }

    public Nullable<decimal> Converted_Price { get; set; }

    public string Type_Of_Order { get; set; }

    public string Customers_Order_Line_Reference { get; set; }

    public Nullable<int> Created_By { get; set; }

    public Nullable<int> Owned_By { get; set; }

    public Nullable<int> Last_Modified { get; set; }

    public Nullable<double> Estimated_Total_Hours { get; set; }

    public Nullable<decimal> Estimated_Material_Cost { get; set; }

    public Nullable<decimal> Estimated_Part_Costs { get; set; }

    public Nullable<decimal> Estimated_SubContract_Cost { get; set; }

    public Nullable<decimal> Estimated_Tooling_Cost { get; set; }

    public Nullable<decimal> Estimated_Total_Cost { get; set; }

    public Nullable<bool> Scheduler_Queue { get; set; }

    public string Confirmed { get; set; }

    public Nullable<int> NumFileAttachments { get; set; }

    public Nullable<int> NumBrokenLinks { get; set; }

    public Nullable<int> Originating_Worder_Reference { get; set; }

    public Nullable<int> Part_Reference { get; set; }

    public Nullable<int> Issue { get; set; }

    public bool JITCalcRequired { get; set; }

    public Nullable<System.DateTime> Issue_Date { get; set; }

    public Nullable<int> NominalCode_Reference { get; set; }

    public Nullable<decimal> Delivery_Charge { get; set; }

    public Nullable<bool> Delivery_Charge_Per_Batch { get; set; }

    public Nullable<bool> Default_Template { get; set; }

    public Nullable<int> Reworking_WOrder_Reference { get; set; }

    public string Order_Type_Code { get; set; }

    public Nullable<decimal> Total_Part_Price { get; set; }

    public Nullable<int> PList_Reference { get; set; }

    public Nullable<int> Priority { get; set; }

    public string UDF01 { get; set; }

    public string UDF02 { get; set; }

    public string UDF03 { get; set; }

    public string UDF04 { get; set; }

    public string UDFF01 { get; set; }

    public string UDFF02 { get; set; }

    public string UDFF03 { get; set; }

    public string UDFF04 { get; set; }



    public virtual ICollection<Batch> Batches { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual Nominal_codes Nominal_codes { get; set; }

    public virtual ICollection<WOComponent> WOComponents { get; set; }

    public virtual ICollection<WOMaterial> WOMaterials { get; set; }

    public virtual ICollection<WOPart> WOParts { get; set; }

    public virtual ICollection<WOSubContract> WOSubContracts { get; set; }

    public virtual ICollection<WOTool> WOTools { get; set; }

    public virtual ICollection<WOWCentre> WOWCentres { get; set; }

}

}
