#region Using directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public class TricornToolRepository : RepositoryBase<TricornTool>
    {
        public TricornToolRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<TricornTool> GetByTool(Tool tool)
        {
            return GetSet().Where(t => t.ToolId == tool.Id).ToList();
        }
    }
}