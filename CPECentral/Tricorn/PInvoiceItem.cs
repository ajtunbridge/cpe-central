
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
    
public partial class PInvoiceItem
{

    public int PInvoiceItem_Reference { get; set; }

    public int PInvoice_Reference { get; set; }

    public double Quantity { get; set; }

    public string Item_Type { get; set; }

    public Nullable<int> Part_Reference { get; set; }

    public Nullable<int> Material_Reference { get; set; }

    public Nullable<int> SubContract_Reference { get; set; }

    public string Description { get; set; }

    public byte[] Notes { get; set; }

    public Nullable<int> VAT_Reference { get; set; }

    public Nullable<decimal> Unit_Price { get; set; }

    public Nullable<decimal> Discount_Amount { get; set; }

    public Nullable<decimal> Total_Price { get; set; }

    public Nullable<System.DateTime> Date_Created { get; set; }

    public Nullable<System.DateTime> Date_Last_Modified { get; set; }

    public Nullable<int> Last_Modified { get; set; }

    public Nullable<decimal> Tax_Amount { get; set; }

    public Nullable<int> NominalCode_Reference { get; set; }

    public Nullable<decimal> Converted_Unit_Price { get; set; }

    public Nullable<decimal> Converted_Discount_Amount { get; set; }

    public Nullable<decimal> Converted_Total_Price { get; set; }

    public Nullable<decimal> Converted_Tax_Amount { get; set; }

    public Nullable<int> CostCentre_Reference { get; set; }



    public virtual Nominal_codes Nominal_codes { get; set; }

    public virtual PInvoice PInvoice { get; set; }

}

}