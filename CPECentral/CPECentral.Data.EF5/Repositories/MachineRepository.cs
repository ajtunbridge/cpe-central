using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class MachineRepository : RepositoryBase<Machine>
    {
        public MachineRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Machine> GetByMachineGroup(MachineGroup machineGroup)
        {
            return GetByMachineGroup(machineGroup.Id);
        }

        public IEnumerable<Machine> GetByMachineGroup(int machineGroupId)
        {
            return UnitOfWork.Entities.Machines.Where(m => m.MachineGroupId == machineGroupId).ToList();
        }
    }
}
