using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.CustomEventArgs
{
    public class MoveToolsToNewGroupEventArgs : EventArgs
    {
        public MoveToolsToNewGroupEventArgs(IEnumerable<Tool> toolsToMove, ToolGroup newGroup)
        {
            ToolsToMove = toolsToMove;
            NewGroup = newGroup;
        }

        public IEnumerable<Tool> ToolsToMove { get; set; }

        public ToolGroup NewGroup { get; set; }
    }
}
