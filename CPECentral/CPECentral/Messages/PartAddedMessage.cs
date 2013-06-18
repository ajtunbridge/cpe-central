#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Messages
{
    public sealed class PartAddedMessage
    {
        public PartAddedMessage(Part newPart)
        {
            NewPart = newPart;
        }

        public Part NewPart { get; private set; }
    }
}