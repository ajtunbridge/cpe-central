#region Using directives

using System;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.CustomEventArgs
{
    public sealed class ToolGroupEventArgs : EventArgs
    {
        public ToolGroupEventArgs(ToolGroup toolGroup)
        {
            ToolGroup = toolGroup;
        }

        public ToolGroup ToolGroup { get; private set; }
    }
}