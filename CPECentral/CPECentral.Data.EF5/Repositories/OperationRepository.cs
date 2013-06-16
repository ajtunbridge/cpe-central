#region Using directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class OperationRepository : RepositoryBase<Operation>
    {
        public OperationRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Operation> GetByMethod(Method method)
        {
            return GetByMethod(method.Id);
        }

        public IEnumerable<Operation> GetByMethod(int methodId)
        {
            return GetSet().Where(op => op.MethodId == methodId).ToList();
        }
    }
}