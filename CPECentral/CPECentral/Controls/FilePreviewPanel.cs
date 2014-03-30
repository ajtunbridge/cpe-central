#region Using directives

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Properties;
using nGenLibrary;

#endregion

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

            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1) {
                return;
            }

            string extension = fileName.Substring(indexOfLastDot).ToLower();

            if (extension == ".pdf") {
                using (BusyCursor.Show()) {
                    string tempFile = Path.GetTempFileName() + extension;

                    File.Copy(fileName, tempFile, true);

                    var pdfViewer = new PdfViewer();
                    pdfViewer.Dock = DockStyle.Fill;
                    Controls.Add(pdfViewer);
                    pdfViewer.LoadFile(tempFile);
                }
                return;
            }

            string[] validTextExtensions = Settings.Default.TextFileExtensions.Split(new[] {"|"},
                StringSplitOptions.None);

            if (validTextExtensions.Any(validExt => validExt.Equals(extension, StringComparison.OrdinalIgnoreCase))) {
                var ncEditor = new AvalonNcEditor();
                ncEditor.Dock = DockStyle.Fill;
                Controls.Add(ncEditor);
                ncEditor.BringToFront();
                ncEditor.LoadFile(fileName);
            }

            string[] imageExtensions = Settings.Default.ImageFileExtensions.Split(new[] {"|"},
                StringSplitOptions.RemoveEmptyEntries);

            if (imageExtensions.Any(validExt => validExt.Equals(extension, StringComparison.OrdinalIgnoreCase))) {
                var imageViewer = new ImageViewer();
                imageViewer.Dock = DockStyle.Fill;
                Controls.Add(imageViewer);
                imageViewer.LoadFile(fileName);
            }
        }

        public void Clear()
        {
            Controls.Clear();
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Enabled = true;
        }
    }
}