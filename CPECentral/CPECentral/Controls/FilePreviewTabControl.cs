/*
 * User: atunbridge
 * Date: 12/11/2013
 * Time: 10:50
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Properties;
using nGenLibrary;

namespace CPECentral.Controls
{
	/// <summary>
	/// Description of FilePreviewTabControl.
	/// </summary>
	public partial class FilePreviewTabControl : UserControl
	{
		public FilePreviewTabControl()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

        private void tabControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void tabControl_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            var fileName = files[0];

            var indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
                return;

            var extension = fileName.Substring(indexOfLastDot).ToLower();
            
                    var newPage = new TabPage(Path.GetFileName(fileName));
            tabControl.TabPages.Add(newPage);
            if (extension == ".pdf")
            {
                using (BusyCursor.Show())
                {
                    var tempFile = Path.GetTempFileName() + extension;

                    File.Copy(fileName, tempFile, true);

                    var pdfViewer = new PdfViewer();
                    pdfViewer.Dock = DockStyle.Fill;
                    newPage.Controls.Add(pdfViewer);
                    pdfViewer.LoadFile(tempFile);
                }
                return;
            }

            var validTextExtensions = Settings.Default.TextFileExtensions.Split(new[] { "|" }, StringSplitOptions.None);

            if (validTextExtensions.Any(validExt => validExt.Equals(extension, StringComparison.OrdinalIgnoreCase)))
            {
                var ncEditor = new AvalonNcEditor();
                ncEditor.Dock = DockStyle.Fill;
                newPage.Controls.Add(ncEditor);
                ncEditor.BringToFront();
                ncEditor.LoadFile(fileName);
            }

            var imageExtensions = Settings.Default.ImageFileExtensions.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            if (imageExtensions.Any(validExt => validExt.Equals(extension, StringComparison.OrdinalIgnoreCase)))
            {
                var imageViewer = new ImageViewer();
                imageViewer.Dock = DockStyle.Fill;
                newPage.Controls.Add(imageViewer);
                imageViewer.LoadFile(fileName);
            }
        }
	}
}
