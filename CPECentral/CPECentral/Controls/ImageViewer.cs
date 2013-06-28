﻿using System;
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
        private string _fileName;

        public ImageViewer()
        {
            InitializeComponent();

            imageBox.BackgroundTile = Resources.DocumentPreviewBgTile;
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadFile(string fileName)
        {
            _fileName = fileName;

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
                    ShowPreviewWindow();
                    break;
            }
        }

        private void ShowPreviewWindow()
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (!(openForm is PreviewPopoutForm))
                    continue;

                var openPreviewForm = openForm as PreviewPopoutForm;

                if (openPreviewForm.PreviewControl is ImageViewer)
                {
                    var viewer = openPreviewForm.PreviewControl as ImageViewer;
                    viewer.LoadFile(_fileName);
                    return;
                }
                else
                {
                    var viewer = new ImageViewer();
                    viewer.Dock = DockStyle.Fill;
                    openPreviewForm.PreviewControl = viewer;
                    viewer.LoadFile(_fileName);
                    return;
                }
            }

            var imgViewer = new ImageViewer();
            imgViewer.Dock = DockStyle.Fill;
            imgViewer.LoadFile(_fileName);

            var previewForm = new PreviewPopoutForm(imgViewer);
            previewForm.Show(ParentForm);
        }
    }
}
