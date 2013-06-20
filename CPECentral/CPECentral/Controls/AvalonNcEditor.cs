#region Using directives

using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Xml;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.TextEditor.Document;
using HighlightingManager = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager;

#endregion

namespace CPECentral.Controls
{
    public partial class AvalonNcEditor : UserControl
    {
        private ElementHost _host;
        private TextEditor _editor;

        public AvalonNcEditor()
        {
            InitializeComponent();

            _editor = new TextEditor();

            if (File.Exists(@"CncLanguages\FanucHighlighting.xshd"))
            {
                using (var stream = File.OpenRead(@"CncLanguages\FanucHighlighting.xshd"))
                {
                    using (var reader = new XmlTextReader(stream))
                    {
                        _editor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
                    }
                }
            }

            _host = new ElementHost();
            _host.Child = _editor;
            _host.Dock = DockStyle.Fill;

            Controls.Add(_host);

            _host.BringToFront();
            _editor.FontFamily = new FontFamily("Consolas");
            _editor.FontSize = 14d;

            _editor.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            _editor.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
        }

        public void LoadFile(string fileName)
        {
            _editor.Text = "loading...";
            Enabled = false;

            var ext = Path.GetExtension(fileName);

            ThreadPool.QueueUserWorkItem(delegate
            {
                var text = File.ReadAllText(fileName);

                _host.InvokeEx(() =>
                {
                    _editor.Text = text;
                    Enabled = true;
                });
            });
        }


        public void GoToNextToolChange()
        {
            var xml = XmlReader.Create(@"CncLanguages\Config.xml");

            string toolChangeValue = null;

            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element
                    && xml.Name == "language")
                {
                    var language = xml.GetAttribute("name");

                    if (language.ToLower() != toolStripComboBox1.Text.ToLower())
                        continue;

                    while (xml.Read())
                    {
                        if (xml.NodeType == XmlNodeType.Element
                            && xml.Name == "toolchange")
                        {
                            toolChangeValue = xml.ReadString();
                            break;
                        }
                    }

                    break;
                }
            }

            if (string.IsNullOrEmpty(toolChangeValue))
                return;

            int currentIndex = 0;

            var caretPos = _editor.TextArea.Caret.Position;

            currentIndex = _editor.Document.GetOffset(caretPos);

            var regex = new Regex(toolChangeValue);

            var match = regex.Match(_editor.Text, currentIndex);

            if (match.Index == 0)
                return;

            var nextLocation = _editor.Document.GetLineByOffset(match.Index + 1);

            _editor.TextArea.Caret.Position = new TextViewPosition(nextLocation);

            _editor.TextArea.Caret.Show();
        }

    }
}