using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.CustomEventArgs
{
    public class StringEventArgs : EventArgs
    {
        public StringEventArgs(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
