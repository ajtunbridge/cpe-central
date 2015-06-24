#region Using directives

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Xml;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.Properties;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using NcCommunicator.Data;
using NcCommunicator.Data.Model;
using nGenLibrary;
using FontFamily = System.Windows.Media.FontFamily;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

#endregion

namespace CPECentral.Controls
{
    public partial class AvalonNcEditor : UserControl
    {
        private static NcUnitOfWork _machinesDb;
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private readonly TextEditor _editor;
        private readonly ElementHost _host;
        private string _currentFileName;
        private string _currentToolChangeValue;
        private bool _isLoadingFile;
        private StringReader _stringToPrint;

        public AvalonNcEditor()
        {
            InitializeComponent();

            _editor = new TextEditor();

            _host = new ElementHost();
            _host.Child = _editor;
            _host.Dock = DockStyle.Fill;

            Controls.Add(_host);

            _host.BringToFront();
            _editor.FontFamily = new FontFamily("Courier New");
            _editor.FontSize = 16;
            _editor.TextChanged += Editor_TextChanged;
            _editor.KeyDown += Editor_KeyDown;
            _editor.HorizontalAlignment = HorizontalAlignment.Stretch;
            _editor.VerticalAlignment = VerticalAlignment.Stretch;
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == System.Windows.Input.ModifierKeys.Control
                && e.KeyboardDevice.IsKeyDown(Key.S) && saveToolStripButton.Enabled) {
                SaveChanges();
            }
        }

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            if (_isLoadingFile) {
                return;
            }

            saveToolStripButton.Enabled = true;
        }

        public void LoadFile(string fileName)
        {
            _isLoadingFile = true;

            _editor.Text = "loading...";
            Enabled = false;

            ThreadPool.QueueUserWorkItem(delegate {
                string text = File.ReadAllText(fileName);

                _host.Invoke((MethodInvoker) delegate {
                    _editor.Text = text;
                    _currentFileName = fileName;
                    _isLoadingFile = false;
                    Enabled = true;
                });
            });
        }

        public void GoToNextToolCall()
        {
            if (string.IsNullOrEmpty(_currentToolChangeValue)) {
                return;
            }

            int currentIndex = 0;

            TextViewPosition caretPos = _editor.TextArea.Caret.Position;

            currentIndex = _editor.Document.GetOffset(caretPos) + 1;

            var regex = new Regex(_currentToolChangeValue);

            Match match = regex.Match(_editor.Text, currentIndex);

            if (match.Index == 0) {
                return;
            }

            TextLocation nextLocation = _editor.Document.GetLocation(match.Index + 1);

            _editor.TextArea.Caret.Position = new TextViewPosition(nextLocation.Line, nextLocation.Column - 1);

            _editor.TextArea.Caret.BringCaretToView();
        }

        private void AvalonNcEditor_Load(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageDocuments, false)) {
                _editor.IsReadOnly = true;
            }

            LoadLanguageList();
            LoadMachineList();
        }

        private void LanguageToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool toolChangeHasBeenSet = false;

            try {
                using (BusyCursor.Show()) {
                    using (XmlReader configReader = OpenConfigurationFile()) {
                        while (configReader.Read()) {
                            if (configReader.NodeType != XmlNodeType.Element && configReader.Name != "language") {
                                continue;
                            }

                            string language = configReader.GetAttribute("name");

                            if (language != languageToolStripComboBox.Text) {
                                continue;
                            }

                            Settings.Default.PreferredNcLanguage = language;
                            Settings.Default.Save();

                            while (configReader.Read()) {
                                if (configReader.NodeType == XmlNodeType.Element && configReader.Name == "toolchange") {
                                    _currentToolChangeValue = configReader.ReadString();
                                    toolChangeHasBeenSet = true;
                                    continue;
                                }

                                if (configReader.NodeType == XmlNodeType.Element && configReader.Name == "syntaxfile") {
                                    string syntaxFileName = configReader.ReadString();

                                    ApplySyntaxHighlighting(syntaxFileName);

                                    if (toolChangeHasBeenSet) {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                _dialogService.ShowError(ex.Message);
            }
        }

        private void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "saveToolStripButton":
                    SaveChanges();
                    break;
                case "gotoNextToolCallToolStripButton":
                    GoToNextToolCall();
                    break;
            }
        }

        private void SaveChanges()
        {
            try {
                using (BusyCursor.Show()) {
                    File.WriteAllText(_currentFileName, _editor.Text);
                }

                saveToolStripButton.Enabled = false;

                string fileName = Path.GetFileName(_currentFileName);

                string status = "Saved " + fileName + " successfully!";

                Session.MessageBus.Publish(new StatusUpdateMessage(status));
            }
            catch (Exception ex) {
                _dialogService.ShowError(ex.Message);
            }
        }

        private XmlReader OpenConfigurationFile()
        {
            string appDir = Settings.Default.SharedAppDir;

            string configFile = string.Format("{0}\\Syntax\\config.xml", appDir);

            if (!File.Exists(configFile)) {
                throw new FileNotFoundException("The machine language configuration file is missing!");
            }

            return XmlReader.Create(configFile);
        }

        private void LoadLanguageList()
        {
            try {
                using (BusyCursor.Show()) {
                    using (XmlReader reader = OpenConfigurationFile()) {
                        while (reader.Read()) {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "language") {
                                string language = reader.GetAttribute("name");

                                languageToolStripComboBox.Items.Add(language);
                            }
                        }
                    }

                    if (languageToolStripComboBox.Items.Count > 0) {
                        string preferredLanguage = Settings.Default.PreferredNcLanguage;

                        if (languageToolStripComboBox.Items.Contains(preferredLanguage)) {
                            languageToolStripComboBox.SelectedItem = preferredLanguage;
                        }
                        else {
                            languageToolStripComboBox.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex) {
                _dialogService.ShowError(ex.Message);
            }
        }

        private void LoadMachineList()
        {
            if (_machinesDb == null) {
                _machinesDb = new NcUnitOfWork();
            }

            IOrderedEnumerable<Machine> machines = _machinesDb.Machines.GetAll().OrderBy(m => m.Name);
            foreach (Machine machine in machines) {
                var transmitItem = new ToolStripMenuItem(machine.Name);
                var receiveItem = new ToolStripMenuItem(machine.Name);

                transmitItem.Tag = machine;
                receiveItem.Tag = machine;

                transmitToolStripDropDownButton.DropDownItems.Add(transmitItem);
                receiveToolStripDropDownButton.DropDownItems.Add(receiveItem);
            }
        }

        private void ApplySyntaxHighlighting(string syntaxFile)
        {
            string storageDir = Settings.Default.SharedAppDir;

            string fileName = string.Format("{0}\\Syntax\\{1}", storageDir, syntaxFile);

            if (!File.Exists(fileName)) {
                throw new FileNotFoundException("The syntax highlighting file for this language is missing!");
            }

            using (FileStream stream = File.OpenRead(fileName)) {
                using (var reader = new XmlTextReader(stream)) {
                    _editor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }
        }

        private void transmitToolStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag is Machine) {
                var machine = e.ClickedItem.Tag as Machine;
                MachineControl control = _machinesDb.MachineControls.GetById(machine.MachineControlId);

                using (var dialog = new TransmitProgramDialog(_editor.Text, machine.ComPort, control)) {
                    dialog.ShowDialog(ParentForm);
                }
            }
        }

        private void receiveToolStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            receiveToolStripDropDownButton.HideDropDown();

            if (e.ClickedItem.Tag is Machine) {
                var machine = e.ClickedItem.Tag as Machine;
                MachineControl control = _machinesDb.MachineControls.GetById(machine.MachineControlId);

                if (!_dialogService.AskQuestion("Are you sure you want to overwrite this program?")) {
                    return;
                }

                using (var dialog = new ReceiveProgramDialog(machine.ComPort, control)) {
                    if (dialog.ShowDialog(ParentForm) != DialogResult.OK)
                    {
                        return;
                    }

                    _editor.Text = dialog.ReceivedProgram;
                    SaveChanges();
                }
            }
        }

        private void printToolStripButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            printToolStripButton.HideDropDown();

            switch (e.ClickedItem.Name) {
                case "programToolStripMenuItem":
                    PrintProgram();
                    break;
                case "toolListToolStripMenuItem":
                    PrintToolList();
                    break;
            }
        }

        private void PrintProgram()
        {
            _stringToPrint = new StringReader(_editor.Text);
            Print("NC Program");
        }

        private void PrintToolList()
        {
            var stringBuilder = new StringBuilder();

            string turningPattern = Settings.Default.TurningToolRegEx;

            var regex = new Regex(turningPattern);

            MatchCollection matches = regex.Matches(_editor.Text);

            // if is turning file
            if (matches.Count > 0) {
                foreach (Match match in matches) {
                    string position = match.Groups["position"].Value;
                    string offset = match.Groups["offset"].Value;
                    string name = match.Groups["name"].Value;

                    stringBuilder.AppendFormat("TOOL {0} OFFSET {1}: {2}", position, offset, name);
                    stringBuilder.AppendLine();
                }

                _stringToPrint = new StringReader(stringBuilder.ToString());
                Print("Tool list");
            }

            // TODO: milling tool regex matching
        }

        private void Print(string documentName)
        {
            using (var doc = new PrintDocument()) {
                doc.DocumentName = documentName;
                doc.PrintPage += doc_PrintPage;

                var printDialog = new PrintDialog();
                printDialog.Document = doc;
                if (printDialog.ShowDialog() == DialogResult.OK) {
                    doc.Print();
                }
            }
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var font = new Font("Consolas", 10f);
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = e.MarginBounds.Height/font.GetHeight(e.Graphics);

            // Print each line of the file. 
            while (count < linesPerPage && ((line = _stringToPrint.ReadLine()) != null)) {
                yPos = topMargin + (count*font.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, font, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page. 
            if (line == null) {
                e.HasMorePages = false;
                _stringToPrint.Dispose();
            }
            else {
                e.HasMorePages = true;
            }
        }
    }
}