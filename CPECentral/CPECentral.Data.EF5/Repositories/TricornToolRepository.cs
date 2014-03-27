using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
