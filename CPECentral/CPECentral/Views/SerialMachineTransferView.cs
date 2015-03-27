#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Presenters;
using NcCommunicator.Data.Model;

#endregion

namespace CPECentral.Views
{
    public interface ISerialMachineTransferView
    {

    }

    public partial class SerialMachineTransferView : ViewBase, ISerialMachineTransferView
    {
        private readonly SerialMachineTransferViewPresenter _presenter;

        public SerialMachineTransferView(Machine machine)
        {
            InitializeComponent();

            base.Dock = DockStyle.Fill;

            if (!IsInDesignMode) {
                _presenter = new SerialMachineTransferViewPresenter(this);
            }
        }

        private void SerialMachineTransferView_Load(object sender, EventArgs e)
        {
        }
    }
}