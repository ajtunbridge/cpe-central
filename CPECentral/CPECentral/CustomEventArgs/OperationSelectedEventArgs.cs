#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class OperationSelectedEventArgs : EventArgs
    {
        public OperationSelectedEventArgs(Operation selectedOperation)
        {
            SelectedOperation = selectedOperation;
        }

        public Operation SelectedOperation { get; private set; }
    }
}