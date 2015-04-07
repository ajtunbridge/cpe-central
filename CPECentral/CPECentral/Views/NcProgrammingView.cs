#region Using directives

using System;
using System.Linq;
using NcCommunicator.Data;
using NcCommunicator.Data.Model;

#endregion

namespace CPECentral.Views
{
    public partial class NcProgrammingView : ViewBase
    {
        public NcProgrammingView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

                var machines = new MachinesDataProvider(dir);
                machinesComboBox.Items.AddRange(machines.GetAllMachines().OrderBy(m => m.Name).ToArray());
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