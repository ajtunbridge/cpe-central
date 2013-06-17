#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class PartEventArgs : EventArgs
    {
        public PartEventArgs(Part part)
        {
            Part = part;
        }

        public Part Part { get; private set; }
    }
}