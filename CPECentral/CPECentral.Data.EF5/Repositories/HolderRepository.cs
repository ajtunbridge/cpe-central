#region Using directives

using System.Collections.Generic;
using System.Data.Objects.SqlClient;
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

        public IEnumerable<Holder> GetByTool(Tool tool)
        {
            return GetByTool(tool.Id);
        }

        public IEnumerable<Holder> GetByTool(int toolId)
        {
            var holderTools = UnitOfWork.HolderTools.GetByTool(toolId);

            return holderTools.Select(ht => GetById(ht.HolderId)).ToList();
        }

        public IEnumerable<Holder> GetWhereNameMatches(string value)
        {
            return GetSet().Where(h => SqlFunctions.PatIndex(value, h.Name) > 0).OrderBy(h => h.Name);
        } 
    }
}