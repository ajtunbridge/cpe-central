
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
    
public partial class Location
{

    public int Location_Reference { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string Postcode { get; set; }

    public string Notes { get; set; }

    public string UsedFor { get; set; }

    public Nullable<int> Customer_Reference { get; set; }

    public Nullable<int> Supplier_Reference { get; set; }

    public int Client_Reference { get; set; }

    public System.DateTime Date_Created { get; set; }

    public System.DateTime Date_Last_Modified { get; set; }

    public string Country_Code { get; set; }

}

}
