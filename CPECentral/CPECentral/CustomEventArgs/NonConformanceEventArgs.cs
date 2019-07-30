#region Using directives

using System;
using CPECentral.Data.EF5;
using CPECentral.QMS.Model;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class NonConformanceEventArgs : EventArgs
    {
        public NonConformanceEventArgs(Complaint nonConformance)
        {
            NonConformance = nonConformance;
        }

        public Complaint NonConformance { get; private set; }
    }
}