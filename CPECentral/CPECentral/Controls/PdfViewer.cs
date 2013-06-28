using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPECentral.Controls
{
    public partial class PdfViewer : UserControl
    {
        private readonly IDialogService _dialogService;
        private string _fileName;
        private WebBrowser _browser;

        public PdfViewer()
        {
            InitializeComponent();

            if (!DesignMode)
                _dialogService = Session.GetInstanceOf<IDialogService>();
        }

        private void PdfViewer_Load(object sender, EventArgs e)
        {
        }

        public void LoadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                _dialogService.ShowError("Could not locate " + fileName);
                return;
            }

            _fileName = fileName;

            if (_browser != null)
            {
                Controls.Remove(_browser);
                _browser.Dispose();
                _browser = null;
            }

            _browser = new WebBrowser();
            _browser.Dock = DockStyle.Fill;
            _browser.DocumentCompleted += browser_DocumentCompleted;
            _browser.Navigate(_fileName);
        }

        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Controls.Add(_browser);
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
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

                if (openPreviewForm.PreviewControl is PdfViewer)
                {
                    var viewer = openPreviewForm.PreviewControl as PdfViewer;
                    viewer.LoadFile(_fileName);
                    return;
                }
                else
                {
                    var viewer = new PdfViewer();
                    viewer.Dock = DockStyle.Fill;
                    openPreviewForm.PreviewControl = viewer;
                    viewer.LoadFile(_fileName);
                    return;
                }
            }

            var pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;
            pdfViewer.LoadFile(_fileName);

            var previewForm = new PreviewPopoutForm(pdfViewer);
            previewForm.Show(ParentForm);
        }
    }
}
