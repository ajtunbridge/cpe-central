using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Properties;
using CPECentral.QMS;

namespace CPECentral.Dialogs
{
    public partial class NonConformanceViewerDialog : Form
    {
        private readonly string _drawingNumber;

        public NonConformanceViewerDialog(string drawingNumber)
        {
            InitializeComponent();
            _drawingNumber = drawingNumber;

            Text = "Non-conformances for " + drawingNumber;

            Size = Settings.Default.NonConformanceFormSize;
        }

        private void NonConformanceViewerDialog_Load(object sender, EventArgs e)
        {
            nonConformanceSelectorView.DrawingNumber = _drawingNumber;
        }

        private void nonConformanceSelectorView_NonConformanceSelected(object sender, CustomEventArgs.NonConformanceEventArgs e)
        {
            nonConformanceView1.ShowNonConformance(e.NonConformance);
        }

        private void NonConformanceViewerDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.NonConformanceFormSize = Size;
            Settings.Default.Save();
        }

        private void nonConformanceSelectorView_Load(object sender, EventArgs e)
        {

        }
    }
}