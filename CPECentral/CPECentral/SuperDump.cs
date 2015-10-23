using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CPECentral.Properties;
using NcCommunicator;
using NcCommunicator.Data.Model;

namespace CPECentral
{
    public class SuperDump
    {
        private readonly SerialLink _serialLink;
        private readonly StringBuilder _programDump = new StringBuilder();

        public SuperDump(string comPort, MachineControl control)
        {
            _serialLink = new SerialLink(comPort, control);
            _serialLink.ReceiveProgress += _serialLink_ReceiveProgress;
            _serialLink.DataTransferStarted += _serialLink_DataTransferStarted;
            _serialLink.DataTransferComplete += _serialLink_DataTransferComplete;
            _serialLink.ErrorReceived += _serialLink_ErrorReceived;
        }

        private void _serialLink_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
        }

        private void _serialLink_DataTransferStarted(object sender, EventArgs e)
        {
        }

        private void _serialLink_DataTransferComplete(object sender, EventArgs e)
        {
            var splitPrograms = _programDump.ToString().Split(new[] {":"}, StringSplitOptions.None);


        }

        private void _serialLink_ReceiveProgress(object sender, ReceiveProgressEventArgs e)
        {
            // clean up whitespace
            string cleanValue = e.Value.Replace("\n\r\r", Environment.NewLine);

            _programDump.Append(cleanValue);
        }
    }
}