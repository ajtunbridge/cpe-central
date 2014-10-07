using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Properties;
using NcCommunicator.Data;
using NcCommunicator.Data.Model;

namespace CPECentral.Controls
{
    public partial class SettingsMachinesUserControl : UserControl
    {
        private NcUnitOfWork _machinesDb = new NcUnitOfWork();
        private readonly IDialogService _dialogService;

        public SettingsMachinesUserControl()
        {
            InitializeComponent();

            machinesImageList.Images.Add(Resources.MachineIcon);

            _dialogService = Session.GetInstanceOf<IDialogService>();
        }

        private void SettingsMachinesUserControl_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;

            ReloadMachines();

            PopulateComboBox();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addMachineToolStripButton":
                    AddMachine();
                    break;
                case "addControlToolStripButton":
                    AddControl();
                    break;
                case "deleteMachineToolStripButton":
                    break;
            }
        }

        private void AddMachine()
        {
            var machineControls = _machinesDb.MachineControls.GetAll();

            if (!machineControls.Any()) {
                _dialogService.Notify("There must be at least 1 machine control defined before adding any machines.");
                return;
            }

            var defaultControl = machineControls.First();
            var machines = _machinesDb.Machines.GetAll();

            string newMachineName = "New Machine 01";
            int counter = 1;
            while (machines.Any(m => m.Name == newMachineName)) {
                counter++;
                newMachineName = "New Machine " + counter.ToString("D3");
            }

            var newMachine = new Machine {
                ComPort = "COM1",
                MachineControlId = defaultControl.Id,
                Name = newMachineName
            };

            _machinesDb.Machines.Insert(newMachine);

            _machinesDb.Commit();

            ReloadMachines();
        }

        private void AddControl()
        {
            var controls = _machinesDb.MachineControls.GetAll();

            var newControlName = "New Control 01";
            int counter = 1;
            while (controls.Any(c => c.Name == newControlName)) {
                counter++;
                newControlName = "New Control " + counter.ToString("D2");
            }

            var newControl = new MachineControl {
                BaudRate = 9600,
                DataBits = 7,
                DtrEnable = true,
                Handshake = Handshake.None,
                Name = newControlName,
                Parity = Parity.Even,
                RtsEnable = true,
                StopBits = StopBits.Two,
                XOnChar = (char)17,
                XOffChar = (char)19,
                XOnChar2 = (char)18,
                XOffChar2 = (char)20,
                ProgramStartChar = Convert.ToChar("%"),
                ProgramEndChar = Convert.ToChar("%"),
                NewLine = "\r\n\n"
            };

            _machinesDb.MachineControls.Insert(newControl);

            _machinesDb.Commit();

            ReloadControls();
        }

        private void ReloadMachines()
        {
            enhancedListView1.Items.Clear();

            foreach (var mc in _machinesDb.Machines.GetAll())
            {
                ListViewItem item = enhancedListView1.Items.Add(mc.Name);
                item.ImageIndex = 0;
                item.Tag = mc;
            }

            enhancedListView1.SelectFirstItem();
        }

        private void ReloadControls()
        {
            enhancedListView2.Items.Clear();

            foreach (var control in _machinesDb.MachineControls.GetAll()) {
                ListViewItem item = enhancedListView2.Items.Add(control.Name);
                item.Tag = control;
            }

            enhancedListView2.SelectFirstItem();
        }

        private void PopulateComboBox()
        {
            var stopBits = Enum.GetNames(typeof (StopBits));
            stopBitsComboBox.Items.AddRange(stopBits);

            var parity = Enum.GetNames(typeof (Parity));
            parityComboBox.Items.AddRange(parity);

            var handshake = Enum.GetNames(typeof (Handshake));
            handshakeComboBox.Items.AddRange(handshake);

            var dataBits = new object[] {5, 6, 7, 8, 9};
            dataBitsComboBox.Items.AddRange(dataBits);

            var baudRates = new object[] {1200, 2400, 4800, 9600, 19200, 38400, 57600};
            baudRateComboBox.Items.AddRange(baudRates);
        }
    }
}