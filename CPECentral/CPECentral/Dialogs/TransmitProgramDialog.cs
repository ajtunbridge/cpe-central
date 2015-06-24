#region Using directives

using System;
using System.IO;
using System.Media;
using System.Windows.Forms;
using CPECentral.Properties;
using NcCommunicator;
using NcCommunicator.Data.Model;

#endregion

namespace CPECentral.Dialogs
{
    public partial class TransmitProgramDialog : Form
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private readonly SerialLink _serialLink;
        private readonly string _textToSend;
        private bool _transmissionStarted;

        public TransmitProgramDialog(string textToSend, string comPort, MachineControl control)
        {
            InitializeComponent();

            _textToSend = textToSend;

            _serialLink = new SerialLink(comPort, control);
            _serialLink.TransmitProgress += _serialLink_TransmitProgress;
            _serialLink.DataTransferStarted += _serialLink_DataTransferStarted;
            _serialLink.DataTransferComplete += SerialLinkDataTransferComplete;
        }

        private void _serialLink_DataTransferStarted(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate {
                messageLabel.Text = "Transmitting program...";
                using (UnmanagedMemoryStream stream = Resources.Beep) {
                    using (var player = new SoundPlayer(stream)) {
                        player.Play();
                    }
                }
            });
        }

        private void NcTransmissionDialog_Load(object sender, EventArgs e)
        {
            try {
                _serialLink.Connect();
                _serialLink.Transmit(_textToSend);
            }
            catch (SerialConnectionFailedException serialEx) {
                _dialogService.ShowError(serialEx.Message);
            }
        }

        private void SerialLinkDataTransferComplete(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker) Close);
        }

        private void _serialLink_TransmitProgress(object sender, TransmitProgressEventArgs e)
        {
            Invoke((MethodInvoker) delegate { progressBar.Value = e.Progress; });
        }

        private void TransmitProgramDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serialLink.Disconnect();
        }
    }
}