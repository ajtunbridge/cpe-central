
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
    
public partial class Tricorn_Access_Rights
{

    public int TUAR_Record_ID { get; set; }

    public string User_Or_Role { get; set; }

    public int User_Role_Reference { get; set; }

    public int TAF_Record_ID { get; set; }

    public bool Access_Rights_Value { get; set; }



    public virtual Tricorn_Access_Flags Tricorn_Access_Flags { get; set; }

}

}
