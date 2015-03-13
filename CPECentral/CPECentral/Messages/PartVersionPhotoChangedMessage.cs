#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Messages
{
    public class PartVersionPhotoChangedMessage
    {
        public PartVersionPhotoChangedMessage(PartVersion partVersion)
        {
            PartVersion = partVersion;
        }

        public PartVersion PartVersion { get; private set; }
    }
}