#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class CustomerEventArgs : EventArgs
    {
        public CustomerEventArgs(Customer customer)
        {
            Customer = customer;
        }

        public Customer Customer { get; private set; }
    }
}