#region Using directives

using System;
using System.Media;
using System.Windows.Forms;
using CPECentral.Properties;
using NcCommunicator;
using NcCommunicator.Data.Model;

#endregion

namespace CPECentral.Dialogs
{
    public partial class ReceiveProgramDialog : Form
    {
        private readonly SerialLink _serialLink;
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();

        public ReceiveProgramDialog(string comPort, MachineControl control)
        {
            InitializeComponent();
            _serialLink = new SerialLink(comPort, control);
            _serialLink.ReceiveProgress += _serialLink_ReceiveProgress;
            _serialLink.DataTransferStarted += _serialLink_DataTransferStarted;
            _serialLink.DataTransferComplete += _serialLink_DataTransferComplete;
        }

        private void _serialLink_DataTransferStarted(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate {
                messageLabel.Text = "Receiving program...";
                using (var stream = Resources.Beep) {
                    using (var player = new SoundPlayer(stream)) {
                        player.Play();
                    }
                }
            });
        }

        public string ReceivedProgram
        {
            get { return programTextBox.Text; }
        }

        private void _serialLink_DataTransferComplete(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker) Close);
        }

        private void _serialLink_ReceiveProgress(object sender, ReceiveProgressEventArgs e)
        {
            // clean up whitespace
            var cleanValue = e.Value.Replace("\n\r\r", Environment.NewLine);

            Invoke((MethodInvoker) delegate {
                programTextBox.Text += cleanValue;
                programTextBox.SelectionStart = programTextBox.Text.Length - 1;
                programTextBox.ScrollToCaret();
            });
        }

        private void ReceiveProgramDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serialLink.Disconnect();
        }

        private void ReceiveProgramDialog_Load(object sender, EventArgs e)
        {
            try {
                _serialLink.Connect();
            }
            catch (SerialConnectionFailedException serialEx) {
                _dialogService.ShowError(serialEx.Message);
            }
        }
    }
}