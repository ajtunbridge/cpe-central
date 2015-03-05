#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace CPECentral.Controls
{
    public partial class HexagonPanel : Control
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

            var centre = new Point(e.ClipRectangle.Width/2, e.ClipRectangle.Height/2);
            var narrowestSize = Math.Min(Width, Height);

            var vertices = CalculateVertices(6, (narrowestSize / 2) - 3, 0, centre);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            using (var p = new Pen(Brushes.DimGray, 2f))
            {
                e.Graphics.DrawPolygon(p, vertices);
            }

            float overPoints = vertices[0].X - vertices[3].X;
            float yOffset = (overPoints - (vertices[4].Y - vertices[2].Y)) / 2;

            using (var p = new Pen(Brushes.DarkRed, 2f))
            {
                p.DashStyle = DashStyle.Dash;
                
                e.Graphics.DrawEllipse(p, vertices[3].X, vertices[2].Y - yOffset, overPoints, overPoints);
            }
        }

        private PointF[] CalculateVertices(int sides, int radius, int startingAngle, Point center)
        {
            if (sides < 3)
                throw new ArgumentException("Polygon must have 3 sides or more.");

            List<PointF> points = new List<PointF>();
            float step = 360.0f / sides;

            float angle = startingAngle; //starting angle
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a full circle
            {
                points.Add(DegreesToXY(angle, radius, center)); //code snippet from above
                angle += step;
            }

            return points.ToArray();
        }
        
        /// <summary>
        /// Calculates a point that is at an angle from the origin (0 is to the right)
        /// </summary>
        private PointF DegreesToXY(float degrees, float radius, Point origin)
        {
            PointF xy = new PointF();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (float)Math.Cos(radians) * radius + origin.X;
            xy.Y = (float)Math.Sin(-radians) * radius + origin.Y;

            return xy;
        }
    }
}