
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
    
public partial class CalibrationProcedure
{

    public int Procedure_Reference { get; set; }

    public Nullable<System.DateTime> Dated { get; set; }

    public string Equipment_To_Test { get; set; }

    public string Equipment_To_Use { get; set; }

    public byte[] Calibration_Procedure { get; set; }

    public byte[] Spec_To_Be_Achieved { get; set; }

    public byte[] Notes { get; set; }

    public Nullable<System.DateTime> Date_Created { get; set; }

    public Nullable<System.DateTime> Date_Last_Modified { get; set; }

    public Nullable<int> Client_Reference { get; set; }

    public byte[] Revisions { get; set; }

    public Nullable<System.DateTime> First_Active { get; set; }

    public Nullable<System.DateTime> Last_Active { get; set; }

    public Nullable<System.DateTime> Next_Activity_Date { get; set; }

    public string Prefix { get; set; }

    public Nullable<int> Number { get; set; }

    public string Suffix { get; set; }

}

}
