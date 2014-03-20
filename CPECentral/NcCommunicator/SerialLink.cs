#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using NcCommunicator.Data.Model;

#endregion

namespace NcCommunicator
{
    public class SerialLink : IDisposable
    {
        private const byte DefaultBlockSize = 16;
        private readonly string _comPortName;
        private readonly MachineControl _control;
        private readonly char[] _validChars = new char[62];

        private bool _awaitingTransmission;
        private byte[] _dataToTransmit;
        private SerialPort _port;

        public SerialLink(string comPortName, MachineControl control)
        {
            // set valid characters
            var index = 0;

            for (var charValue = 32; charValue < 94; charValue++) {
                _validChars[index] = (char) charValue;
                index++;
            }

            _comPortName = comPortName;
            _control = control;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_port != null) {
                _port.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        #endregion

        public event EventHandler<ReceiveProgressEventArgs> ReceiveProgress;
        public event EventHandler<TransmitProgressEventArgs> TransmitProgress;
        public event EventHandler DataTransferStarted;
        public event EventHandler DataTransferComplete;

        protected virtual void OnDataTransferStarted()
        {
            EventHandler handler = DataTransferStarted;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnDataTransferComplete()
        {
            var handler = DataTransferComplete;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnReceiveProgress(ReceiveProgressEventArgs e)
        {
            var handler = ReceiveProgress;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnTransmitProgress(TransmitProgressEventArgs e)
        {
            var handler = TransmitProgress;
            if (handler != null) {
                handler(this, e);
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // allow buffer to fill
            Thread.Sleep(200);

            while (_port.BytesToRead > 0) {
                string line = null;
                
                try {
                    line = _port.ReadLine();
                }
                catch (IOException ioEx) {

                }
                catch (TimeoutException timeoutEx) {
                    line = _port.ReadExisting();
                }

                bool receivedXOnChar = line.IndexOfAny(new[] {
                    _control.XOnChar, _control.XOnChar2
                }) >= 0;

                if (receivedXOnChar)
                {
                    OnDataTransferStarted();
                    if (_awaitingTransmission) {
                        TransmitData();
                        continue;
                    }
                }

                bool receivedXoffChar = line.IndexOfAny(new[] {
                    _control.XOffChar, _control.XOffChar2
                }) >= 0;

                // if finished uploading data
                if (receivedXoffChar && _awaitingTransmission) {
                    _awaitingTransmission = false;
                    _dataToTransmit = null;
                    OnDataTransferComplete();
                    break;
                }
                
                // otherwise we're still reading

                // remove any invalid characters and whitespace
                var cleanLine = RemoveInvalidCharacters(line.Trim()) + Environment.NewLine;
                OnReceiveProgress(new ReceiveProgressEventArgs(cleanLine));

                if (receivedXoffChar) {
                    OnDataTransferComplete();
                    break;
                }
            }
        }

        public void Connect()
        {
            // clear any existing port connection
            Disconnect();

            try {
                _port = new SerialPort {
                    PortName = _comPortName,
                    BaudRate = _control.BaudRate,
                    DataBits = _control.DataBits,
                    DtrEnable = _control.DtrEnable,
                    Handshake = _control.Handshake,
                    Parity = _control.Parity,
                    RtsEnable = _control.RtsEnable,
                    StopBits = _control.StopBits,
                    NewLine = _control.NewLine,
                    ReadTimeout = 1000
                };

                _port.Open();

                _port.DataReceived += port_DataReceived;
            }
            catch (Exception ex) {
                throw new SerialConnectionFailedException(_port.PortName, ex);
            }
        }

        /// <summary>
        ///     Closes the internal <see cref="SerialPort" /> and releases any resources it was using
        /// </summary>
        public void Disconnect()
        {
            if (_port == null) {
                return;
            }

            _port.DiscardInBuffer();
            _port.DiscardOutBuffer();
            _port.Close();
            _port.Dispose();
        }

        public void Transmit(string text)
        {
            var data = Encoding.ASCII.GetBytes(text);
            Transmit(data);
        }

        public void Transmit(byte[] data)
        {
            _dataToTransmit = data;
            _awaitingTransmission = true;
        }

        private void TransmitData()
        {
            var currentIndex = 0;

            while (currentIndex < _dataToTransmit.Length) {
                var remainder = _dataToTransmit.Length - currentIndex;
                var blockSize = Math.Min(DefaultBlockSize, remainder);
                var bufferSpace = _port.WriteBufferSize - _port.BytesToWrite;
                while (bufferSpace < blockSize) {
                    bufferSpace = _port.WriteBufferSize - _port.BytesToWrite;
                }
                _port.Write(_dataToTransmit, currentIndex, blockSize);
                var written = new byte[blockSize];
                Buffer.BlockCopy(_dataToTransmit, currentIndex, written, 0, blockSize);
                var progress = Convert.ToInt32(((double) currentIndex/_dataToTransmit.Length)*100);
                OnTransmitProgress(new TransmitProgressEventArgs(written, progress));
                currentIndex += blockSize;
            }
        }
        private string RemoveInvalidCharacters(string value)
        {
            var builder = new StringBuilder();

            foreach (var c in value)
            {
                if (!_validChars.Any(validChar => validChar == c))
                    continue;

                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}