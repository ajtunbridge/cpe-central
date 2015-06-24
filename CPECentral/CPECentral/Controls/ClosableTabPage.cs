using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPECentral.Controls
{
    public partial class ClosableTabPage : TabPage
    {
        public ClosableTabPage()
        {
            InitializeComponent();
        }

        public ClosableTabPage(string text) : this()
        {
            base.Text = text;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //base.OnPaint(pe);

            pe.Graphics.DrawString("x", new Font(Font, FontStyle.Bold), Brushes.DimGray, Width - 15, Top);
        }

    }
}