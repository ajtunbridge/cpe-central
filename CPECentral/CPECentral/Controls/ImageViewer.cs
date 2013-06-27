using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Properties;
using nGenLibrary;

namespace CPECentral.Controls
{
    public partial class ImageViewer : UserControl
    {
        private readonly string _fileName;

        public ImageViewer(string fileName)
        {
            InitializeComponent();
            _fileName = fileName;
            imageBox.BackgroundTile = Resources.DocumentPreviewBgTile;
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            using (var fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read))
            {
                imageBox.Image = Image.FromStream(fs);
            }

            imageBox.ZoomToFit();

            imageBox.ZoomIn();
            imageBox.ZoomIn();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "zoomInToolStripButton":
                    imageBox.ZoomIn();
                    break;
                case "zoomOutToolStripButton":
                    imageBox.ZoomOut();
                    break;
                case "rotateToolStripButton":
                    using (BusyCursor.Show())
                    {
                        imageBox.Rotate();
                        saveToolStripButton.Enabled = true;
                    }
                    break;
                case "saveToolStripButton":
                    using (BusyCursor.Show())
                    {
                        imageBox.Image.Save(_fileName);
                        saveToolStripButton.Enabled = false;
                    }
                    break;
                case "previewToolStripButton":
                    var previewForm = new PreviewPopoutForm(new ImageViewer(_fileName));
                    previewForm.ShowDialog(ParentForm);
                    break;
            }
        }
    }
}
