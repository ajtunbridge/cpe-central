
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
    
public partial class Dash_Invoice_Items
{

    public Nullable<int> Invoice_Reference { get; set; }

    public string User_Reference { get; set; }

    public Nullable<System.DateTime> Date_Created { get; set; }

    public Nullable<System.DateTime> Invoice_Date { get; set; }

    public Nullable<System.DateTime> Invoice_Due_Date { get; set; }

    public Nullable<int> Invoice_Month { get; set; }

    public Nullable<int> Invoice_Year { get; set; }

    public Nullable<int> Invoice_Due_Month { get; set; }

    public Nullable<int> Invoice_Due_Year { get; set; }

    public Nullable<int> Customer_Reference { get; set; }

    public string Customer { get; set; }

    public Nullable<int> Invoice_Location_Reference { get; set; }

    public Nullable<int> Invoice_Contact_Reference { get; set; }

    public Nullable<decimal> Total_Delivery_Charge { get; set; }

    public Nullable<double> Delivery_VAT_Rate { get; set; }

    public string Default_Nominal { get; set; }

    public string WO_Nominal_Code { get; set; }

    public bool Proforma { get; set; }

    public bool Credit_Note { get; set; }

    public bool Issued { get; set; }

    public bool Exported { get; set; }

    public bool Cancelled { get; set; }

    public Nullable<double> Exchange_Rate { get; set; }

    public Nullable<double> VAT_Rate { get; set; }

    public string Invoice_Notes { get; set; }

    public string Customer_Terms_Code { get; set; }

    public string Customer_Terms { get; set; }

    public int Invitem_Reference { get; set; }

    public Nullable<int> Batch_Reference { get; set; }

    public Nullable<int> WOrder_Reference { get; set; }

    public string WO_User_Reference { get; set; }

    public string Description { get; set; }

    public double Quantity { get; set; }

    public Nullable<decimal> Line_Value { get; set; }

    public Nullable<double> Unit_Price { get; set; }

    public Nullable<decimal> Line_Value_InvOrCr { get; set; }

    public Nullable<double> Line_Vat { get; set; }

    public Nullable<double> Line_Value_Inc_Vat { get; set; }

    public Nullable<double> Line_Value_InvOrCr_Inc_Vat { get; set; }

    public Nullable<double> Unit_Price_InvOrCr { get; set; }

    public bool Delivery { get; set; }

    public string Invoice_Item_Notes { get; set; }

    public string Effective_Nominal { get; set; }

    public Nullable<int> PlanningColour { get; set; }

}

}
