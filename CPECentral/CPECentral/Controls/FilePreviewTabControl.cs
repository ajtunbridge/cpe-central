#region Using directives

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Properties;
using nGenLibrary;

#endregion

namespace CPECentral.Controls
{
    /// <summary>
    ///     Description of FilePreviewTabControl.
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
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void tabControl_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[]) e.Data.GetData(DataFormats.FileDrop);

            string fileName = files[0];

            ShowFile(fileName);
        }

        public void ShowFile(string fileName)
        {
            foreach (TabPage page in tabControl.TabPages) {
                if (page.Text == Path.GetFileName(fileName)) {
                    tabControl.SelectedTab = page;
                    return;
                }
            }

            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1) {
                return;
            }

            string extension = fileName.Substring(indexOfLastDot).ToLower();

            if (!tabPagesImageList.Images.ContainsKey(extension)) {
                Bitmap smallIcon = Win32.GetIconForFileExtension(extension, false, false).ToBitmap();
                tabPagesImageList.Images.Add(extension, smallIcon);
            }

            int imageIndex = tabPagesImageList.Images.IndexOfKey(extension);

            var newPage = new TabPage(Path.GetFileName(fileName));
            newPage.ImageIndex = imageIndex;

            if (extension == ".pdf") {
                using (BusyCursor.Show()) {
                    string tempFile = Path.GetTempFileName() + extension;

                    File.Copy(fileName, tempFile, true);

                    var pdfViewer = new PdfViewer();
                    pdfViewer.Dock = DockStyle.Fill;
                    newPage.Controls.Add(pdfViewer);
                    pdfViewer.LoadFile(tempFile);
                }

                tabControl.TabPages.Add(newPage);
                tabControl.SelectedTab = newPage;

                return;
            }

            if (ModelViewer.ValidCadExtensions.Any(ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase))) {
                var modelView = new ModelViewer();
                modelView.Dock = DockStyle.Fill;
                newPage.Controls.Add(modelView);

                tabControl.TabPages.Add(newPage);
                tabControl.SelectedTab = newPage;

                modelView.LoadFile(fileName);

                return;
            }

            string[] validTextExtensions = Settings.Default.TextFileExtensions.Split(new[] {"|"},
                StringSplitOptions.None);

            if (validTextExtensions.Any(validExt => validExt.Equals(extension, StringComparison.OrdinalIgnoreCase))) {
                var ncEditor = new AvalonNcEditor();
                ncEditor.Dock = DockStyle.Fill;
                newPage.Controls.Add(ncEditor);
                ncEditor.BringToFront();
                ncEditor.LoadFile(fileName);

                tabControl.TabPages.Add(newPage);
                tabControl.SelectedTab = newPage;

                return;
            }

            string[] imageExtensions = Settings.Default.ImageFileExtensions.Split(new[] {"|"},
                StringSplitOptions.RemoveEmptyEntries);

            if (imageExtensions.Any(validExt => validExt.Equals(extension, StringComparison.OrdinalIgnoreCase))) {
                var imageViewer = new ImageViewer();
                imageViewer.Dock = DockStyle.Fill;
                newPage.Controls.Add(imageViewer);
                imageViewer.LoadFile(fileName);

                tabControl.TabPages.Add(newPage);
                tabControl.SelectedTab = newPage;
            }
        }

        public void Clear()
        {
            tabControl.TabPages.Clear();
        }

        private void FilePreviewTabControl_Load(object sender, EventArgs e)
        {
            if (tabPagesImageList == null) {
                tabPagesImageList = new ImageList();
                tabPagesImageList.ImageSize = new Size(16, 16);
                tabPagesImageList.ColorDepth = ColorDepth.Depth32Bit;
                tabPagesImageList.Images.Add("GenericFileIcon", Resources.GenericFileIcon);
            }
        }

        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl.TabPageCollection tabs = tabControl.TabPages;

            if (e.Button == MouseButtons.Middle) {
                tabs.Remove(tabs.Cast<TabPage>()
                    .Where((t, i) => tabControl.GetTabRect(i).Contains(e.Location))
                    .First());
            }
        }
    }
}