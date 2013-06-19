using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Properties;
using ICSharpCode.TextEditor;
using nGenLibrary;

namespace CPECentral.Controls
{
    public partial class FilePreviewPanel : UserControl
    {
        public FilePreviewPanel()
        {
            InitializeComponent();
        }

        public void ClearPreview()
        {
            Controls.Clear();
        }

        public void ShowFile(string fileName)
        {
            Controls.Clear();

            var indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
                return;

            var extension = fileName.Substring(indexOfLastDot);

            if (extension == ".pdf")
            {
                using (BusyCursor.Show())
                {
                    var tempFile = Path.GetTempFileName() + extension;

                    File.Copy(fileName, tempFile, true);

                    Enabled = false; // prevent focus being stolen

                    var webBrowser = new WebBrowser();
                    webBrowser.Dock = DockStyle.Fill;
                    webBrowser.DocumentCompleted += browser_DocumentCompleted;
                    Controls.Add(webBrowser);
                    webBrowser.Navigate(tempFile);
                }
                return;
            }

            if (extension == ".txt" || extension == ".nc")
            {
                var ncEditor = new NcCodeEditor();
                ncEditor.Dock = DockStyle.Fill;
                Controls.Add(ncEditor);
                ncEditor.LoadFile(fileName);
            }

            var imageExtensions = Settings.Default.ImageFileExtensions.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            if (imageExtensions.Any(ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
        }

        public void Clear()
        {
            Controls.Clear();
        }

        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Enabled = true;
        }
    }
}
