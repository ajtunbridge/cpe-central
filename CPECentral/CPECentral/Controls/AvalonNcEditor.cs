#region Using directives

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using CPECentral.Properties;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using nGenLibrary;
using HorizontalAlignment = System.Windows.HorizontalAlignment;

#endregion

namespace CPECentral.Controls
{
    public partial class AvalonNcEditor : UserControl
    {
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();
        private readonly TextEditor _editor;
        private readonly ElementHost _host;
        private string _currentFileName;
        private string _currentToolChangeValue;
        private bool _isLoadingFile;

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
            _editor.KeyDown += _editor_KeyDown;
            _editor.HorizontalAlignment = HorizontalAlignment.Stretch;
            _editor.VerticalAlignment = VerticalAlignment.Stretch;
        }

        void _editor_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == System.Windows.Input.ModifierKeys.Control
                && e.KeyboardDevice.IsKeyDown(Key.S) && saveToolStripButton.Enabled)
            {
                SaveChanges();
            }
        }

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            if (_isLoadingFile)
                return;

            saveToolStripButton.Enabled = true;
        }

        public void LoadFile(string fileName)
        {
            _isLoadingFile = true;

            _editor.Text = "loading...";
            Enabled = false;

            var ext = Path.GetExtension(fileName);

            ThreadPool.QueueUserWorkItem(delegate
                {
                    var text = File.ReadAllText(fileName);

                    _host.InvokeEx(() =>
                        {
                            _editor.Text = text;
                            _currentFileName = fileName;
                            _isLoadingFile = false;
                            Enabled = true;
                        });
                });
        }

        public void GoToNextToolCall()
        {
            if (string.IsNullOrEmpty(_currentToolChangeValue))
                return;

            var currentIndex = 0;

            var caretPos = _editor.TextArea.Caret.Position;

            currentIndex = _editor.Document.GetOffset(caretPos) + 1;

            var regex = new Regex(_currentToolChangeValue);

            var match = regex.Match(_editor.Text, currentIndex);

            if (match.Index == 0)
                return;

            var nextLocation = _editor.Document.GetLocation(match.Index + 1);

            _editor.TextArea.Caret.Position = new TextViewPosition(nextLocation.Line, nextLocation.Column - 1);

            _editor.TextArea.Caret.BringCaretToView();
        }

        private void AvalonNcEditor_Load(object sender, EventArgs e)
        {
            LoadLanguageList();
        }

        private void LanguageToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var toolChangeHasBeenSet = false;

            try
            {
                using (BusyCursor.Show())
                {
                    using (var configReader = OpenConfigurationFile())
                    {
                        while (configReader.Read())
                        {
                            if (configReader.NodeType != XmlNodeType.Element && configReader.Name != "language")
                                continue;

                            var language = configReader.GetAttribute("name");

                            if (language != languageToolStripComboBox.Text)
                                continue;

                            Settings.Default.PreferredNcLanguage = language;
                            Settings.Default.Save();

                            while (configReader.Read())
                            {
                                if (configReader.NodeType == XmlNodeType.Element && configReader.Name == "toolchange")
                                {
                                    _currentToolChangeValue = configReader.ReadString();
                                    toolChangeHasBeenSet = true;
                                    continue;
                                }

                                if (configReader.NodeType == XmlNodeType.Element && configReader.Name == "syntaxfile")
                                {
                                    var syntaxFileName = configReader.ReadString();

                                    ApplySyntaxHighlighting(syntaxFileName);

                                    if (toolChangeHasBeenSet)
                                        return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _dialogService.ShowError(ex.Message);
            }
        }

        private void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
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
            try
            {
                using (BusyCursor.Show())
                {
                    File.WriteAllText(_currentFileName, _editor.Text);
                }

                saveToolStripButton.Enabled = false;
            }
            catch (Exception ex)
            {
                _dialogService.ShowError(ex.Message);
            }
        }

        private XmlReader OpenConfigurationFile()
        {
            var appDir = Settings.Default.SharedAppDir;

            var configFile = string.Format("{0}\\Syntax\\config.xml", appDir);

            if (!File.Exists(configFile))
                throw new FileNotFoundException("The machine language configuration file is missing!");

            return XmlReader.Create(configFile);
        }

        private void LoadLanguageList()
        {
            try
            {
                using (BusyCursor.Show())
                {
                    using (var reader = OpenConfigurationFile())
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "language")
                            {
                                var language = reader.GetAttribute("name");

                                languageToolStripComboBox.Items.Add(language);
                            }
                        }
                    }

                    if (languageToolStripComboBox.Items.Count > 0)
                    {
                        var preferredLanguage = Settings.Default.PreferredNcLanguage;

                        if (languageToolStripComboBox.Items.Contains(preferredLanguage))
                            languageToolStripComboBox.SelectedItem = preferredLanguage;
                        else
                            languageToolStripComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _dialogService.ShowError(ex.Message);
            }
        }

        private void ApplySyntaxHighlighting(string syntaxFile)
        {
            var storageDir = Settings.Default.SharedAppDir;

            var fileName = string.Format("{0}\\Syntax\\{1}", storageDir, syntaxFile);

            if (!File.Exists(fileName))
                throw new FileNotFoundException("The syntax highlighting file for this language is missing!");

            using (var stream = File.OpenRead(fileName))
            {
                using (var reader = new XmlTextReader(stream))
                {
                    _editor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                }
            }
        }
    }
}