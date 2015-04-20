#region Using directives

using System;
using System.Linq;
using CPECentral.Data.EF5;
using NcCommunicator.Data;
using NcCommunicator.Data.Model;

#endregion

namespace CPECentral.Views
{
    public partial class NcProgrammingView : ViewBase
    {
        public NcProgrammingView(Operation operation, string pathToNcFile)
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                LoadMachines();
                avalonNcEditor.LoadFile(pathToNcFile);
                operationToolsView.RetrieveOperationTools(operation);
            }
        }

        private void LoadMachines()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            var machines = new MachinesDataProvider(dir);

            foreach (var machine in machines.GetAllMachines().OrderBy(m => m.Name)) {
                machinesComboBox.Items.Add(machine);
            }

            if (machinesComboBox.Items.Count > 0) {
                machinesComboBox.SelectedIndex = 0;
            }
        }

        private void machinesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mc = machinesComboBox.SelectedItem as Machine;

            if (mc is SerialMachine) {
                var c = new SerialMachineTransferView(mc);
                splitContainer2.Panel2.Controls.Add(c);
                c.BringToFront();
            }
        }
    }
}