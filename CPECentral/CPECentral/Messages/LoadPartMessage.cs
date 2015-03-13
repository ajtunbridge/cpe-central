#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Messages
{
    public class LoadPartMessage
    {
        private readonly Part _partToLoad;

        public LoadPartMessage(Part partToLoad)
        {
            _partToLoad = partToLoad;
        }

        public Part PartToLoad
        {
            get { return _partToLoad; }
        }
    }
}