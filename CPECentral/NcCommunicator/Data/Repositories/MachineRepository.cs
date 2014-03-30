#region Using directives

using System.Collections.Generic;
using System.Linq;
using NcCommunicator.Data.Model;

#endregion

namespace NcCommunicator.Data.Repositories
{
    public class MachineRepository : RepositoryBase
    {
        public MachineRepository(MachinesDataSet dataSet) : base(dataSet)
        {
        }

        public Machine GetById(int id)
        {
            Machine match = null;

            foreach (MachinesDataSet.MachinesRow row in DataSet.Machines.Rows) {
                if (row.Id != id) {
                    continue;
                }

                match = new Machine {
                    Id = row.Id,
                    Name = row.Name,
                    ComPort = row.ComPort,
                    MachineControlId = row.MachineControlId
                };

                break;
            }

            return match;
        }

        public IEnumerable<Machine> GetAll()
        {
            var machines = new List<Machine>();

            foreach (MachinesDataSet.MachinesRow row in DataSet.Machines.Rows) {
                var mc = new Machine {
                    Id = row.Id,
                    Name = row.Name,
                    ComPort = row.ComPort,
                    MachineControlId = row.MachineControlId
                };

                machines.Add(mc);
            }

            return machines;
        }

        public void Insert(Machine machine)
        {
            MachinesDataSet.MachinesRow rowToInsert = DataSet.Machines.NewMachinesRow();
            rowToInsert.Name = machine.Name;
            rowToInsert.ComPort = machine.ComPort;
            rowToInsert.MachineControlId = machine.MachineControlId;

            DataSet.Machines.AddMachinesRow(rowToInsert);
        }

        public void Delete(int id)
        {
            MachinesDataSet.MachinesRow rowToDelete = DataSet.Machines.SingleOrDefault(m => m.Id == id);

            if (rowToDelete == null) {
                throw new KeyNotFoundException("Unable to find machine with an ID value of " + id);
            }

            DataSet.Machines.RemoveMachinesRow(rowToDelete);
        }

        public void Update(Machine machine)
        {
            MachinesDataSet.MachinesRow rowToUpdate = DataSet.Machines.SingleOrDefault(m => m.Id == machine.Id);

            if (rowToUpdate == null) {
                throw new KeyNotFoundException("Unable to find machine with an ID value of " + machine.Id);
            }

            rowToUpdate.Name = machine.Name;
            rowToUpdate.ComPort = machine.ComPort;
            rowToUpdate.MachineControlId = machine.MachineControlId;
        }
    }
}