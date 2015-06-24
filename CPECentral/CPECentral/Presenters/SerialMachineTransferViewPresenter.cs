#region Using directives

using System;
using System.IO.Ports;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class SerialMachineTransferViewPresenter
    {
        private readonly SerialPort _port;
        private readonly ISerialMachineTransferView _view;

        public SerialMachineTransferViewPresenter(ISerialMachineTransferView view)
        {
            _view = view;

            _view.ViewLoaded += _view_ViewLoaded;
            _view.OpenConnection += _view_OpenConnection;
            _view.CloseConnection += _view_CloseConnection;
            _port = new SerialPort(view.Machine.ComPort);
        }

        private void _view_CloseConnection(object sender, EventArgs e)
        {
            try {
                using (BusyCursor.Show()) {
                    _port.Close();
                }
            }
            catch {
            }

            _view.AfterConnectionIsClosed();
        }

        private void _view_OpenConnection(object sender, EventArgs e)
        {
            try {
                using (BusyCursor.Show()) {
                    _port.Open();
                }
            }
            catch {
            }

            _view.AfterConnectionIsOpened();
        }

        private void _view_ViewLoaded(object sender, EventArgs e)
        {
            bool isAlreadyOpen = false;

            try {
                using (BusyCursor.Show()) {
                    _port.Open();
                    _port.Close();
                }
            }
            catch {
                isAlreadyOpen = true;
            }

            if (!isAlreadyOpen) {
                _view.IfConnectionIsAlreadyOpen();
            }
        }
    }
}