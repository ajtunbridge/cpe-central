#region Using directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class OperationToolRepository : RepositoryBase<OperationTool>
    {
        public OperationToolRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<OperationTool> GetByOperation(Operation operation)
        {
            return GetByOperation(operation.Id);
        }

        public IEnumerable<OperationTool> GetByOperation(int operationId)
        {
            return GetSet().Where(ot => ot.OperationId == operationId).ToList();
        }
    }
}