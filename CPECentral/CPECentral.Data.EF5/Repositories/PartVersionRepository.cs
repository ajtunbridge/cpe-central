#region Using directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class PartVersionRepository : RepositoryBase<PartVersion>
    {
        public PartVersionRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<PartVersion> GetByPart(Part part)
        {
            return GetByPart(part.Id);
        }

        public IEnumerable<PartVersion> GetByPart(int partId)
        {
            return GetSet().Where(ver => ver.PartId == partId).ToList();
        }

        public PartVersion GetLatestVersion(Part part)
        {
            return GetLatestVersion(part.Id);
        }

        public PartVersion GetLatestVersion(int partId)
        {
            return GetSet().Where(ver => ver.PartId == partId)
                           .OrderByDescending(ver => ver.VersionNumber)
                           .First();
        }
    }
}