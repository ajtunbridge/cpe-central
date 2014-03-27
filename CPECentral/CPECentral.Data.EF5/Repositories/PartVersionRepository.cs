#region Using directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class PartVersionRepository : RepositoryBase<PartVersion>
    {
        public PartVersionRepository(CPEUnitOfWork unitOfWork)
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

        public override void Add(PartVersion entity)
        {
            entity.VersionNumber = CleanVersionNumber(entity.VersionNumber);

            base.Add(entity);
        }

        private string CleanVersionNumber(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
                return string.Empty;

            var trimmed = version.Trim();

            var isNumeric = trimmed.All(char.IsNumber);

            if (isNumeric)
            {
                var issueNumber = int.Parse(trimmed);
                return issueNumber.ToString("D2");
            }

            return trimmed.ToUpper();
        }
    }
}