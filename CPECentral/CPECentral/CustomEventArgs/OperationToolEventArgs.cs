#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class OperationToolEventArgs : EventArgs
    {
        public OperationToolEventArgs(OperationTool operationTool)
        {
            OperationTool = operationTool;
        }

        public OperationTool OperationTool { get; private set; }
    }
}