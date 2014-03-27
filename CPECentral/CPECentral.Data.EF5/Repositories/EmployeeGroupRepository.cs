#region Using directives

using System;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class EmployeeGroupRepository : RepositoryBase<EmployeeGroup>
    {
        public EmployeeGroupRepository(CPEUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public EmployeeGroup GetByName(string name)
        {
            return GetSet().FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}