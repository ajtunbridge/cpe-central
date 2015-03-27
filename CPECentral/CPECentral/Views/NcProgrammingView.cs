using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NcCommunicator.Data.Model;

namespace CPECentral.Views
{
    public partial class NcProgrammingView : ViewBase
    {
        public NcProgrammingView()
        {
            InitializeComponent();
        }

        private void machinesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mc = machinesComboBox.SelectedItem as Machine;

            if (mc is SerialMachine) {
                var c = new SerialMachineTransferView(mc);
                splitContainer2.Panel2.Controls.Add(c);
            }
        }
    }
}
