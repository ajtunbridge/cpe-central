#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace CPECentral.Controls
{
    public partial class HexagonDiameterPanel : UserControl
    {
        private string _diameter;

        public HexagonDiameterPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            InitializeComponent();
        }

        public string Diameter
        {
            get { return _diameter; }
            set
            {
                _diameter = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var pen = new Pen(Color.Gray, 3f);

            e.Graphics.DrawLine(pen, 0, 3, Width - 25, 3);
            e.Graphics.DrawLine(pen, 0, Height - 3, Width - 25, Height - 3);

            var arrowPen = new Pen(Color.Gray, 3f);
            arrowPen.StartCap = LineCap.ArrowAnchor;

            e.Graphics.DrawLine(arrowPen, Width - 50, 5, Width - 50, (Height/2) - 15);

            e.Graphics.DrawLine(arrowPen, Width - 50, Height - 5, Width - 50, (Height/2) + 15);

            SizeF size = e.Graphics.MeasureString(_diameter, Font);

            int x = Convert.ToInt32(Width - size.Width - 5);
            int y = Convert.ToInt32(((double) Height/2) - (size.Height/2));

            var rectangle = new RectangleF(x, y, size.Width, size.Height);

            e.Graphics.DrawString(_diameter, Font, Brushes.Black, rectangle);

            base.OnPaint(e);
        }
    }
}