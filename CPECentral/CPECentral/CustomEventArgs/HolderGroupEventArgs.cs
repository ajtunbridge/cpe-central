#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class HolderGroupEventArgs : EventArgs
    {
        public HolderGroupEventArgs(HolderGroup holderGroup)
        {
            HolderGroup = holderGroup;
        }

        public HolderGroup HolderGroup { get; private set; }
    }
}