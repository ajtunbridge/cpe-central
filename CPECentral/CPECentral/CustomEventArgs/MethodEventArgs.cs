#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class MethodEventArgs : EventArgs
    {
        public MethodEventArgs(Method method)
        {
            Method = method;
        }

        public Method Method { get; private set; }
    }
}