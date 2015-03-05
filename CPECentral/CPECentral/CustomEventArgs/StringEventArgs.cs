#region Using directives

using System;

#endregion

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