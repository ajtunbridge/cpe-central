#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace CPECentral.Dialogs
{
    public partial class HexagonPanel : UserControl
    {
        public HexagonPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawHexagon(e.Graphics);
        }

        private void DrawHexagon(Graphics g)
        {
            int sideLength = (Width/3);
            int x = (Width - sideLength)/2;
            int y = (Height - sideLength*2);

            float shortSide = Convert.ToSingle(Math.Sin(30*Math.PI/180)*sideLength);
            float longSide = Convert.ToSingle(Math.Cos(30*Math.PI/180)*sideLength);

            var points = new PointF[6];
            points[0] = new PointF(x, y);
            points[1] = new PointF(x + sideLength, y);
            points[2] = new PointF(x + sideLength + shortSide, y + longSide);
            points[3] = new PointF(x + sideLength, y + longSide + longSide);
            points[4] = new PointF(x, y + longSide + longSide);
            points[5] = new PointF(x - shortSide, y + longSide);

            g.SmoothingMode = SmoothingMode.HighQuality;

            using (var p = new Pen(Brushes.DimGray, 2f)) {
                g.DrawPolygon(p, points);
            }

            float overPoints = points[2].X - points[5].X;
            float yOffset = (overPoints - (points[4].Y - points[0].Y))/2;

            using (var p = new Pen(Brushes.DarkRed, 2f)) {
                p.DashStyle = DashStyle.Dash;
                g.DrawEllipse(p, points[5].X, points[0].Y - yOffset, overPoints, overPoints);
            }
        }
    }
}