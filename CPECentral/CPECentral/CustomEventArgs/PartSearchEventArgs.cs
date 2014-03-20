#region Using directives

using System;
using CPECentral.Views;

#endregion

namespace CPECentral.CustomEventArgs
{
    public class PartSearchEventArgs : EventArgs
    {
        public PartSearchEventArgs(PartSearchArgs searchArgs)
        {
            SearchArgs = searchArgs;
        }

        public PartSearchArgs SearchArgs { get; set; }
    }
}