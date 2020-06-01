using CPECentral.Data.EF5;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CPECentral.Dialogs
{
    public partial class PdfPageExtractionDialog : Form
    {
        private string _inputDocumentPath;
        private PartVersion _partVersion;

        private List<string> _pageFilePaths = new List<string>();
        private int _currentIndex;

        public PdfPageExtractionDialog(string inputDocumentPath, PartVersion partVersion)
        {
            InitializeComponent();

            _inputDocumentPath = inputDocumentPath;
            _partVersion = partVersion;

            var tempDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                  "\\CpeCentral\\pdf_page_extraction_temp\\";

            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);
        }

        private void PdfPageExtractionDialog_Load(object sender, EventArgs e)
        {
            var inputDocument = PdfReader.Open(_inputDocumentPath, PdfDocumentOpenMode.Import);

            int pageNumber = 1;

            var tempDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                  "\\CpeCentral\\pdf_page_extraction_temp\\";

            if (inputDocument.PageCount == 1)
            {
                MessageBox.Show("This file only has one page! There is nothing else to extract!");
                DialogResult = DialogResult.Cancel;
                Close();
            }

            foreach (var page in inputDocument.Pages)
            {
                var outputDocument = new PdfDocument();

                outputDocument.AddPage(page);

                var outputFileName = $"{tempDir}{Path.GetFileNameWithoutExtension(_inputDocumentPath)}_Page{pageNumber:00}.pdf";

                outputDocument.Save(outputFileName);

                _pageFilePaths.Add(outputFileName);

                pageNumber++;
            }

            pdfViewer1.LoadFile(_pageFilePaths[0]);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Session.DocumentService.QueueUpload(_pageFilePaths[_currentIndex], _partVersion);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            previousPageButton.Enabled = true;

            _currentIndex++;

            pdfViewer1.LoadFile(_pageFilePaths[_currentIndex]);

            nextPageButton.Enabled = _currentIndex < _pageFilePaths.Count - 1;
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            nextPageButton.Enabled = true;

            _currentIndex--;

            pdfViewer1.LoadFile(_pageFilePaths[_currentIndex]);

            previousPageButton.Enabled = _currentIndex > 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}