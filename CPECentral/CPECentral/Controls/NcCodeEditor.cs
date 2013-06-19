#region Using directives

using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

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