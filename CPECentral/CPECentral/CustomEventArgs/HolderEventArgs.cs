#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class HolderEventArgs : EventArgs
    {
        public HolderEventArgs(Holder holder)
        {
            Holder = holder;
        }

        public Holder Holder { get; private set; }
    }
}