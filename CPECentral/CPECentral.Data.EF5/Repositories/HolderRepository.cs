#region Using directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class HolderRepository : RepositoryBase<Holder>
    {
        public HolderRepository(CPEUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Holder> GetByHolderGroup(HolderGroup holderGroup)
        {
            return GetByHolderGroup(holderGroup.Id);
        }

        public IEnumerable<Holder> GetByHolderGroup(int holderGroupId)
        {
            return GetSet().Where(h => h.HolderGroupId == holderGroupId).ToList();
        }
    }
}