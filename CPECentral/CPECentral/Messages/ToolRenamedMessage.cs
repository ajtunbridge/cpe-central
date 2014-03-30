#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Messages
{
    public sealed class ToolRenamedMessage
    {
        public ToolRenamedMessage(Tool renamedTool)
        {
            RenamedTool = renamedTool;
        }

        public Tool RenamedTool { get; private set; }
    }
}