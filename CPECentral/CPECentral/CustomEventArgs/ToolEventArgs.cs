#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class ToolEventArgs : EventArgs
    {
        public ToolEventArgs(Tool tool)
        {
            Tool = tool;
        }

        public Tool Tool { get; private set; }
    }
}