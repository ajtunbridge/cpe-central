#region Using directives

using System.Collections.Generic;
using System.Linq;
using NcCommunicator.Data.Model;

#endregion

namespace NcCommunicator.Data.Repositories
{
    public class MachineControlRepository : RepositoryBase
    {
        public MachineControlRepository(MachinesDataSet dataSet) : base(dataSet)
        {
        }

        public MachineControl GetById(int id)
        {
            MachineControl match = null;

            foreach (MachinesDataSet.MachineControlsRow row in DataSet.MachineControls.Rows) {
                if (row.Id != id) {
                    continue;
                }

                match = CreateMachineControlFromDataRow(row);

                break;
            }

            return match;
        }

        public IEnumerable<MachineControl> GetAll()
        {
            var machineControls = new List<MachineControl>();

            foreach (MachinesDataSet.MachineControlsRow row in DataSet.MachineControls.Rows) {
                machineControls.Add(CreateMachineControlFromDataRow(row));
            }

            return machineControls;
        }

        public void Insert(MachineControl machineControl)
        {
            MachinesDataSet.MachineControlsRow rowToInsert = DataSet.MachineControls.NewMachineControlsRow();

            rowToInsert.BaudRate = machineControl.BaudRate;
            rowToInsert.DataBits = machineControl.DataBits;
            rowToInsert.DtrEnable = machineControl.DtrEnable;
            rowToInsert.Handshake = machineControl.Handshake;
            rowToInsert.Name = machineControl.Name;
            rowToInsert.NewLine = machineControl.NewLine;
            rowToInsert.Parity = machineControl.Parity;
            rowToInsert.ProgramEndChar = machineControl.ProgramEndChar;
            rowToInsert.ProgramStartChar = machineControl.ProgramStartChar;
            rowToInsert.RtsEnable = machineControl.RtsEnable;
            rowToInsert.StopBits = machineControl.StopBits;
            rowToInsert.XOffChar = machineControl.XOffChar;
            rowToInsert.XOnChar = machineControl.XOnChar;
            rowToInsert.XOffChar2 = machineControl.XOffChar2;
            rowToInsert.XOnChar2 = machineControl.XOnChar2;

            DataSet.MachineControls.AddMachineControlsRow(rowToInsert);
        }

        public void Update(MachineControl machineControl)
        {
            MachinesDataSet.MachineControlsRow rowToUpdate =
                DataSet.MachineControls.SingleOrDefault(r => r.Id == machineControl.Id);

            if (rowToUpdate == null) {
                throw new KeyNotFoundException("Unable to find machine control with an ID value of " + machineControl.Id);
            }

            rowToUpdate.BaudRate = machineControl.BaudRate;
            rowToUpdate.DataBits = machineControl.DataBits;
            rowToUpdate.DtrEnable = machineControl.DtrEnable;
            rowToUpdate.Handshake = machineControl.Handshake;
            rowToUpdate.Name = machineControl.Name;
            rowToUpdate.NewLine = machineControl.NewLine;
            rowToUpdate.Parity = machineControl.Parity;
            rowToUpdate.ProgramEndChar = machineControl.ProgramEndChar;
            rowToUpdate.ProgramStartChar = machineControl.ProgramStartChar;
            rowToUpdate.RtsEnable = machineControl.RtsEnable;
            rowToUpdate.StopBits = machineControl.StopBits;
            rowToUpdate.XOffChar = machineControl.XOffChar;
            rowToUpdate.XOnChar = machineControl.XOnChar;
            rowToUpdate.XOffChar2 = machineControl.XOffChar2;
            rowToUpdate.XOnChar2 = machineControl.XOnChar2;
        }

        private MachineControl CreateMachineControlFromDataRow(MachinesDataSet.MachineControlsRow row)
        {
            return new MachineControl {
                Id = row.Id,
                Name = row.Name,
                StopBits = row.StopBits,
                Parity = row.Parity,
                Handshake = row.Handshake,
                DataBits = row.DataBits,
                BaudRate = row.BaudRate,
                DtrEnable = row.DtrEnable,
                RtsEnable = row.RtsEnable,
                XOnChar = row.XOnChar,
                XOffChar = row.XOffChar,
                XOnChar2 = row.XOnChar2,
                XOffChar2 = row.XOffChar2,
                ProgramStartChar = row.ProgramStartChar,
                ProgramEndChar = row.ProgramEndChar,
                NewLine = row.NewLine
            };
        }
    }
}