using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Views;
using NcCommunicator.Data;

namespace CPECentral.Presenters
{
    public class SerialMachineTransferViewPresenter
    {
        private readonly ISerialMachineTransferView _view;

        public SerialMachineTransferViewPresenter(ISerialMachineTransferView view)
        {
            _view = view;
        }
    }
}
