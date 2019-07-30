using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CPECentral.Data.EF5;

namespace CPECentral.Dialogs
{
    public partial class ReceiveMillingProgramDialog : Form
    {
        private readonly Operation _operation;
        private MillingMachine _selectedMachine;
        private SerialPort _serialPort;
        private StringBuilder _receivedData;
        private const string _programNameRegExPattern = @"(?<=BEGIN PGM )[A-Z0-9-_]*";
        private const string _programEndRegexPattern = @"END PGM.*MM";

        public ReceiveMillingProgramDialog(Operation operation)
        {
            InitializeComponent();

            _operation = operation;
        }

        private void ReceiveMillingProgramDialog_Load(object sender, EventArgs e)
        {
            using (var fs = new FileStream("milling_machines.txt", FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                     {
                        var currentLine = reader.ReadLine();

                        var split = currentLine.Split(new string[] { "|" }, StringSplitOptions.None);

                        var mc = new MillingMachine
                        {
                            Name = split[0],
                            SwitchBox = split[1],
                            SwitchValue = split[2],
                            ComPort = split[3]
                        };

                        machinesListBox.Items.Add(mc);
                    }
                }
            }

            if (machinesListBox.Items.Count > 0)
            {
                machinesListBox.SelectedIndex = 0;
            }
        }

        private class MillingMachine
        {
            public string Name { get; set; }

            public string SwitchBox { get; set; }

            public string SwitchValue { get; set; }

            public string ComPort { get; set; }
        }

        private void machinesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedMachine = machinesListBox.SelectedItem as MillingMachine;

            switchBoxLabel.Text = $"Change {_selectedMachine.SwitchBox} to {_selectedMachine.SwitchValue}";
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            if (beginButton.Text == "Begin")
            {
                _receivedData = new StringBuilder();

                _serialPort = new SerialPort
                {
                    PortName = _selectedMachine.ComPort,
                    DataBits = 7,
                    Parity = Parity.Even,
                    StopBits = StopBits.Two,
                    DtrEnable = true,
                    RtsEnable = true,
                    BaudRate = 9600,
                    Handshake = Handshake.RequestToSendXOnXOff
                };

                _serialPort.DataReceived += _serialPort_DataReceived;
                _serialPort.Open();
                cancelButton.Enabled = true;
                beginButton.Enabled = false;

                receivedTextBox.Text = "Awaiting signal to receive.....";
            }
            else
            {
                var text = _receivedData.ToString().Trim();

                var regex = new Regex(_programNameRegExPattern);

                var match = regex.Match(text);

                var tmpDir = Path.GetTempPath();

                var fileName = $"{tmpDir}\\{match.Value.Trim()}.h";

                using (var writer = File.CreateText(fileName))
                {
                    writer.Write(text);
                }

                Session.DocumentService.QueueUpload(fileName, _operation, true);

                Close();
            }
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            receivedTextBox.InvokeEx(() => receivedTextBox.Text = "Receiving....");

            var received = _serialPort.ReadExisting();
            
            foreach (var c in received)
            {
                if (c == 13 || c == 10 || (c >= 32 && c <= 126))
                {
                    _receivedData.Append(c);
                    receivedTextBox.InvokeEx(() =>
                    {
                        receivedTextBox.Text += c;
                        receivedTextBox.SelectionStart = receivedTextBox.Text.Length - 1;
                        receivedTextBox.ScrollToCaret();
                    });
                }
            }

            // if end of transmission
            var endRegex = new Regex(_programEndRegexPattern);

            if (endRegex.IsMatch(_receivedData.ToString()))
            {
                receivedTextBox.InvokeEx(() =>
                {
                    cancelButton.Enabled = false;
                    beginButton.Text = "Save";
                    beginButton.Enabled = true;
                    receivedTextBox.Text = _receivedData.ToString().Trim();
                });
            }
        }

        private void ReceiveMillingProgramDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_serialPort != null)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }
    }
}
