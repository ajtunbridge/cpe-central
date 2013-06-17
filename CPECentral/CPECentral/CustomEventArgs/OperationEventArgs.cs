#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class OperationEventArgs : EventArgs
    {
        public OperationEventArgs(Operation operation)
        {
            Operation = operation;
        }

        public Operation Operation { get; private set; }
    }
}