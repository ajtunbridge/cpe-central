using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Properties;
using nGenLibrary;
using NcCommunicator;
using NcCommunicator.Data;
using NcCommunicator.Data.Model;

namespace CPECentral.Dialogs
{
    public partial class SuperDumpDialog : Form
    {
        private const string DrawingNumberRegEx = @"(?<=DWG\.)[\w]*";
        private const string VersionNumberRegEx = @"(?<=VER\.)[\w]*";
        private const string OpNumberRegEx = @"(?<=OP\.)[\d]*";
        private const string ProgramNumberRegEx = @"(?<=\:)[\d]{4}";
        private readonly StringBuilder _programDump = new StringBuilder();
        private SerialLink _serialLink;
        private List<string> _failedMatches = new List<string>();

        private ImageList _smallIconImageList;
        private ImageList _largeIconImageList;

        private List<UnmanagedMemoryStream> _superDumpSounds = new List<UnmanagedMemoryStream>()
        {
            Resources.SuperDump_01,
            Resources.SuperDump_02,
            Resources.SuperDump_03,
            Resources.SuperDump_04,
            Resources.SuperDump_05,
            Resources.SuperDump_06
        };

        public SuperDumpDialog()
        {
            InitializeComponent();

                
            if (_smallIconImageList == null)
            {
                _smallIconImageList = new ImageList();
                _smallIconImageList.ImageSize = new Size(16, 16);
                _smallIconImageList.ColorDepth = ColorDepth.Depth32Bit;
                _smallIconImageList.Images.Add("TextFile", Resources.GenericFileIcon);
            }

            if (_largeIconImageList == null)
            {
                _largeIconImageList = new ImageList();
                _largeIconImageList.ImageSize = new Size(32, 32);
                _largeIconImageList.ColorDepth = ColorDepth.Depth32Bit;
                _largeIconImageList.Images.Add("TextFile", Resources.GenericFileIcon);
            }

            listView1.SmallImageList = _smallIconImageList;
            listView1.LargeImageList = _largeIconImageList;
        }

        private void ProcessReceivedProgram(string programData)
        {
            if (!programData.EndsWith("%"))
            {
                programData += "%";
            }
            
            programData = programData.Insert(0, "%\r\n:");

            var newProvenDate = $"(PROVEN ON {DateTime.Today.ToShortDateString()})";

            programData = programData.Replace("(* NOT PROVEN *)", newProvenDate);
                                
            var drawingMatch = new Regex(DrawingNumberRegEx).Match(programData);
            var versionMatch = new Regex(VersionNumberRegEx).Match(programData);
            var opMatch = new Regex(OpNumberRegEx).Match(programData);
            var progMatch = new Regex(ProgramNumberRegEx).Match(programData);

            var allMatched = new[] {drawingMatch, versionMatch, opMatch, progMatch}.All(m => m.Success);

            if (!allMatched)
            {
                _failedMatches.Add(progMatch.Success ? $"{progMatch.Value}.nc" : "Uknown program number!");
            }

            if (allMatched)
            {
                using (var cpe = new CPEUnitOfWork())
                {
                    var part = cpe.Parts.GetWhereDrawingNumberMatches(drawingMatch.Value).SingleOrDefault();

                    if (part == null)
                    {
                        _failedMatches.Add(progMatch.Success ? $"{progMatch.Value}.nc (DWG)" : "Uknown program number!");
                    }

                    var version =
                        cpe.PartVersions.GetByPart(part).SingleOrDefault(pv => pv.VersionNumber == versionMatch.Value);

                    if (version == null)
                    {
                        _failedMatches.Add(progMatch.Success ? $"{progMatch.Value}.nc (VER)" : "Uknown program number!");
                    }

                    var methods = cpe.Methods.GetByPartVersion(version);

                    var opNumber = Convert.ToInt32(opMatch.Value);

                    var ops =
                        methods.Select(
                            method => cpe.Operations.GetByMethod(method).SingleOrDefault(o => o.Sequence == opNumber))
                            .ToList();

                    foreach (var op in ops.Where(o => o != null))
                    {
                        var ncDoc =
                            cpe.Documents.GetByOperation(op).SingleOrDefault(d => d.FileName == $"{progMatch.Value}.nc");

                        if (ncDoc == null)
                        {
                            continue;
                        }

                        var fileName = Session.DocumentService.GetPathToDocument(ncDoc);

                        listView1.InvokeEx(() =>
                        {
                            var item = listView1.Items.Add(Path.GetFileName(fileName));
                            item.Tag = $"{fileName}|{programData}";
                            item.ImageIndex = 0;
                        });

                        break;
                    }
                }
            }
        }
        
        private void getStartedButton_Click(object sender, EventArgs e)
        {
            using (UnmanagedMemoryStream stream = Resources.AhhYeah)
            {
                using (var player = new SoundPlayer(stream))
                {
                    player.Play();
                }
            }

            getStartedButton.Text = "Waiting for the dump to come...";
            getStartedButton.Enabled = false;
            
            var machine = (Machine) machinesComboBox.SelectedItem;

            var control = new NcUnitOfWork().MachineControls.GetById(machine.MachineControlId);

            _serialLink = new SerialLink(machine.ComPort, control);

            _serialLink.ReceiveProgress += _serialLink_ReceiveProgress;
            _serialLink.DataTransferStarted += _serialLink_DataTransferStarted;
            _serialLink.DataTransferComplete += _serialLink_DataTransferComplete;
            _serialLink.ErrorReceived += _serialLink_ErrorReceived;

            _serialLink.Connect();
        }

        private void _serialLink_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
        }

        private void _serialLink_DataTransferStarted(object sender, EventArgs e)
        {
            progressBar1.InvokeEx(() =>
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                getStartedButton.Text = "Receiving that beautiful dump....";
            });
        }

        private void _serialLink_DataTransferComplete(object sender, EventArgs e)
        {
            progressBar1.InvokeEx(() =>
            {
                using (UnmanagedMemoryStream stream = Resources.ThatFeltGood)
                {
                    using (var player = new SoundPlayer(stream))
                    {
                        player.Play();
                    }
                }

                getStartedButton.Text = "Dump received. Now performing some magic....";

                var worker = new BackgroundWorker();
                worker.DoWork += Worker_DoWork;
                worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
                worker.RunWorkerAsync();
            });
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_failedMatches.Any())
            {
                var msgBuilder = new StringBuilder("The following programs could not be automatically processed.");
                msgBuilder.AppendLine();
                foreach (var failure in _failedMatches)
                {
                    msgBuilder.AppendLine(failure);
                }
                msgBuilder.AppendLine();
                msgBuilder.Append("These programs will have to be saved manually.");

                Session.GetInstanceOf<IDialogService>().ShowError(msgBuilder.ToString());
            }

            getStartedButton.Text = "Move on to step 4";
            progressBar1.Style = ProgressBarStyle.Blocks;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var splitPrograms = _programDump.ToString().Split(new[] { ":" }, StringSplitOptions.None);

            foreach (var prog in splitPrograms.Skip(1))
            {
                ProcessReceivedProgram(prog);
            }
        }

        private void _serialLink_ReceiveProgress(object sender, ReceiveProgressEventArgs e)
        {
            // clean up whitespace
            string cleanValue = e.Value.Replace("\n\r\r", Environment.NewLine);

            _programDump.Append(cleanValue);

            var match = new Regex(ProgramNumberRegEx).Match(cleanValue);

            if (match.Success)
            {
                using (UnmanagedMemoryStream stream = Resources.PooPlop)
                {
                    using (var player = new SoundPlayer(stream))
                    {
                        player.Play();
                    }
                }

                Thread.Sleep(500);
            }
        }

        private void SuperDumpDialog_Load(object sender, EventArgs e)
        {
            using (var nc = new NcUnitOfWork())
            {
                foreach (var mc in nc.Machines.GetAll())
                {
                    machinesComboBox.Items.Add(mc);
                }
            }

            if (machinesComboBox.Items.Count > 0)
            {
                machinesComboBox.SelectedIndex = 0;
            }

            var index = new Random().Next(0, 5);

            using (UnmanagedMemoryStream stream = _superDumpSounds[index])
            {
                using (var player = new SoundPlayer(stream))
                {
                    player.Play();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (UnmanagedMemoryStream stream = Resources.ToiletFlushing)
            {
                using (var player = new SoundPlayer(stream))
                {
                    player.Play();
                }
            }

            using (BusyCursor.Show())
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    var split = ((string) item.Tag).Split(new[] {"|"}, StringSplitOptions.None);

                    File.WriteAllText(split[0], split[1]);
                }
            }

            Close();
        }
    }
}