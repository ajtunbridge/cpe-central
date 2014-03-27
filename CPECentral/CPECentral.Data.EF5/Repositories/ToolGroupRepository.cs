using System.Collections.Generic;
using System.Linq;

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class ToolGroupRepository : RepositoryBase<ToolGroup>
    {
        public ToolGroupRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<ToolGroup> GetRootGroups()
        {
            return GetSet().Where(g => !g.ParentGroupId.HasValue).ToList();
        }

        public IEnumerable<ToolGroup> GetChildGroups(ToolGroup selectedToolGroup)
        {
            return GetSet().Where(g => g.ParentGroupId == selectedToolGroup.Id);
        }
    }
}