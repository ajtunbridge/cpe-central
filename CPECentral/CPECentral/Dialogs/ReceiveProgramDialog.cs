#region Using directives

using System;
using System.IO.Ports;
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
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private readonly SerialLink _serialLink;

        public ReceiveProgramDialog(string comPort, MachineControl control)
        {
            InitializeComponent();
            _serialLink = new SerialLink(comPort, control);
            _serialLink.ReceiveProgress += _serialLink_ReceiveProgress;
            _serialLink.DataTransferStarted += _serialLink_DataTransferStarted;
            _serialLink.DataTransferComplete += _serialLink_DataTransferComplete;
            _serialLink.ErrorReceived += _serialLink_ErrorReceived;
        }

        public bool TransferSuccessful { get; private set; }

        public string ReceivedProgram
        {
            get { return programTextBox.Text; }
        }

        private void _serialLink_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            BeginInvoke((MethodInvoker) delegate {
                _dialogService.ShowError("An error occurred receiving the program file!");

                DialogResult = DialogResult.Cancel;
            });
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

        private void _serialLink_DataTransferComplete(object sender, EventArgs e)
        {
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

        private void okayCancelFooter1_OkayClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void okayCancelFooter1_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}