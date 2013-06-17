#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class PartVersionEventArgs : EventArgs
    {
        public PartVersionEventArgs(PartVersion part)
        {
            PartVersion = part;
        }

        public PartVersion PartVersion { get; private set; }
    }
}