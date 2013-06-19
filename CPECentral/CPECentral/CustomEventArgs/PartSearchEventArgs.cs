using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Views;

namespace CPECentral.CustomEventArgs
{
    public class PartSearchEventArgs : EventArgs
    {
        public PartSearchArgs SearchArgs { get; set; }

        public PartSearchEventArgs(PartSearchArgs searchArgs)
        {
            SearchArgs = searchArgs;
        }
    }
}
