#region Using directives

using System;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class MachineGroupRepository : RepositoryBase<MachineGroup>
    {
        public MachineGroupRepository(CPEUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public MachineGroup GetByName(string name)
        {
            return GetSet().FirstOrDefault(group => @group.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}