#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Messages
{
    public sealed class PartEditedMessage
    {
        public PartEditedMessage(Part editedPart)
        {
            EditedPart = editedPart;
        }

        public Part EditedPart { get; private set; }
    }
}