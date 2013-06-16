#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class PartSelectedEventArgs : EventArgs
    {
        public PartSelectedEventArgs(Part selectdPart)
        {
            SelectedPart = selectdPart;
        }

        public Part SelectedPart { get; private set; }
    }
}