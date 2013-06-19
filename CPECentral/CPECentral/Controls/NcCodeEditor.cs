#region Using directives

using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
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
        }

        public void LoadFile(string fileName)
        {
            textEditorControl.Text = "loading...";
            Enabled = false;

            var ext = Path.GetExtension(fileName);

            if (ext.Equals(".nc"))
            {
                string dir = @"SyntaxHighlighting\"; // Insert the path to your xshd-files.
                FileSyntaxModeProvider fsmProvider; // Provider
                if (Directory.Exists(dir))
                {
                    fsmProvider = new FileSyntaxModeProvider(dir); // Create new provider with the highlighting directory.
                    HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmProvider); // Attach to the text editor.
                    textEditorControl.SetHighlighting("Fanuc"); // Activate the highlighting, use the name from the SyntaxDefinition node.
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
    }
}