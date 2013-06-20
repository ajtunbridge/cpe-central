#region Using directives

using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ICSharpCode.TextEditor.Document;

#endregion

namespace CPECentral.Controls
{
    public partial class NcCodeEditor : UserControl
    {
        public NcCodeEditor()
        {
            InitializeComponent();

            textEditorControl.TextEditorProperties.Font = new Font("Consolas", 12);

            toolStripComboBox1.SelectedIndex = 0;
        }

        public void LoadFile(string fileName)
        {
            textEditorControl.Text = "loading...";
            Enabled = false;

            var ext = Path.GetExtension(fileName);

            if (ext.Equals(".nc"))
            {
                string dir = @"CncLanguages\"; // Insert the path to your xshd-files.
                FileSyntaxModeProvider fsmProvider; // Provider
                if (Directory.Exists(dir))
                {
                    fsmProvider = new FileSyntaxModeProvider(dir); // Create new provider with the highlighting directory.
                    HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmProvider); // Attach to the text editor.
                    textEditorControl.SetHighlighting("FanucSyntax"); // Activate the highlighting, use the name from the SyntaxDefinition node.
                }
            }

            ThreadPool.QueueUserWorkItem(delegate
                {
                    var text = File.ReadAllText(fileName);

                    textEditorControl.InvokeEx(() =>
                        {
                            textEditorControl.Text = text;
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

            var caretPos = textEditorControl.ActiveTextAreaControl.Caret.Position;

            currentIndex = textEditorControl.Document.PositionToOffset(caretPos);

            var regex = new Regex(toolChangeValue);

            var match = regex.Match(textEditorControl.Text, currentIndex);

            if (match.Index == 0)
                return;

            var nextLocation = textEditorControl.Document.OffsetToPosition(match.Index + 1);

            textEditorControl.ActiveTextAreaControl.Caret.Position = nextLocation;

            textEditorControl.ActiveTextAreaControl.ScrollToCaret();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "nextToolCallToolStripButton":
                    GoToNextToolChange();
                    break;
            }
        }
    }
}