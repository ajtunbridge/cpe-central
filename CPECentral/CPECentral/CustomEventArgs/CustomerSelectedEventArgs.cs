#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class CustomerSelectedEventArgs : EventArgs
    {
        public CustomerSelectedEventArgs(Customer selectedCustomer)
        {
            SelectedCustomer = selectedCustomer;
        }

        public Customer SelectedCustomer { get; private set; }
    }
}