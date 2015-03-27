#region Using directives

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CPECentral.Properties;
using CPECentral.Views;
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
                    var pdfViewer = new PdfViewer();
                    pdfViewer.Dock = DockStyle.Fill;
                    pdfViewer.AllowDrop = true;
                    pdfViewer.DragEnter += FilePreviewPanel_DragEnter;
                    pdfViewer.DragDrop += FilePreviewPanel_DragDrop;
                    pdfViewer.LoadFile(fileName);
                    Controls.Add(pdfViewer);
                return;
            }

            string[] imageExtensions = Settings.Default.ImageFileExtensions.Split(new[] {"|"},
                StringSplitOptions.RemoveEmptyEntries);

            if (imageExtensions.Any(validExt => validExt.Equals(extension, StringComparison.OrdinalIgnoreCase))) {
                var imageViewer = new ImageViewer();
                imageViewer.Dock = DockStyle.Fill;
                imageViewer.AllowDrop = true;
                imageViewer.DragEnter += FilePreviewPanel_DragEnter;
                imageViewer.DragDrop += FilePreviewPanel_DragDrop;
                Controls.Add(imageViewer);
                imageViewer.LoadFile(fileName);
            }
        }

        public void Clear()
        {
            Controls.Clear();
        }

        private void FilePreviewPanel_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void FilePreviewPanel_DragEnter(object sender, DragEventArgs e)
        {
        }
    }
}