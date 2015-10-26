#region Using directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class HolderToolRepository : RepositoryBase<HolderTool>
    {
        public HolderToolRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<HolderTool> GetByHolder(Holder holder)
        {
            return GetByHolder(holder.Id);
        }

        public IEnumerable<HolderTool> GetByHolder(int holderId)
        {
            return GetSet().Where(ht => ht.HolderId == holderId).ToList();
        }

        public IEnumerable<HolderTool> GetByTool(Tool tool)
        {
            return GetByTool(tool.Id);
        }

        public IEnumerable<HolderTool> GetByTool(int toolId)
        {
            return GetSet().Where(ht => ht.ToolId == toolId);
        }
    }
}