#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CPECentral.Messages;
using CPECentral.Presenters;
using NcCommunicator.Data.Model;

#endregion

namespace CPECentral.Views
{
    public interface ISerialMachineTransferView
    {
        SerialMachine Machine { get; }
        event EventHandler ViewLoaded;
        event EventHandler OpenConnection;
        event EventHandler CloseConnection;
        void IfConnectionIsAlreadyOpen();
        void AfterConnectionIsOpened();
        void AfterConnectionIsClosed();
    }

    public sealed partial class SerialMachineTransferView : ViewBase, ISerialMachineTransferView
    {
        private static Dictionary<SerialMachine, string> _logs = new Dictionary<SerialMachine, string>();

        private static string _logText;
        private readonly SerialMachine _machine;
        private readonly SerialMachineTransferViewPresenter _presenter;

        public SerialMachineTransferView()
        {
            InitializeComponent();
        }

        public SerialMachineTransferView(Machine machine)
        {
            InitializeComponent();

            base.Dock = DockStyle.Fill;

            _machine = machine as SerialMachine;

            if (!IsInDesignMode) {
                _presenter = new SerialMachineTransferViewPresenter(this);

                logRichTextBox.Text = _logText;

                Session.MessageBus.Subscribe<SerialMachineLogUpdatedMessage>(msg => {
                    if (msg.Machine != _machine) {
                        return;
                    }
                    logRichTextBox.Text = _logs[msg.Machine];
                });
            }
        }

        #region ISerialMachineTransferView Members

        public SerialMachine Machine
        {
            get { return _machine; }
        }

        public event EventHandler ViewLoaded;
        public event EventHandler OpenConnection;
        public event EventHandler CloseConnection;

        public void IfConnectionIsAlreadyOpen()
        {
            openCloseButton.Text = "Close connection";
            button2.Enabled = true;
            button3.Enabled = true;
        }

        public void AfterConnectionIsOpened()
        {
            openCloseButton.Text = "Close connection";
            button2.Enabled = true;
            button3.Enabled = true;

            AppendToLog(string.Format("{0}: {1} connection established.",
                DateTime.Now.ToShortTimeString(),
                _machine.ComPort));
        }

        public void AfterConnectionIsClosed()
        {
            openCloseButton.Text = "Open connection";
            button2.Enabled = false;
            button3.Enabled = false;

            AppendToLog(string.Format("{0}: {1} connection closed.",
                DateTime.Now.ToShortTimeString(),
                _machine.ComPort));
        }

        #endregion

        private void SerialMachineTransferView_Load(object sender, EventArgs e)
        {
            OnViewLoaded();
        }

        private void OnViewLoaded()
        {
            var handler = ViewLoaded;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnOpenConnection()
        {
            var handler = OpenConnection;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnCloseConnection()
        {
            var handler = CloseConnection;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void openCloseButton_Click(object sender, EventArgs e)
        {
            if (openCloseButton.Text == "Open connection") {
                OnOpenConnection();
            }
            else {
                OnCloseConnection();
            }
        }

        private void AppendToLog(string text)
        {
            if (!_logs.ContainsKey(_machine)) {
                _logs.Add(_machine, string.Empty);
            }

            _logs[_machine] += text + Environment.NewLine;

            Session.MessageBus.Publish(new SerialMachineLogUpdatedMessage(_machine));
        }
    }
}