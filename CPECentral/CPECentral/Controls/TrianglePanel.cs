#region Using directives

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace CPECentral.Controls
{
    public partial class TrianglePanel : Control
    {
        private string _adjText = "adj";
        private double _adjacent;
        private double _angleA;
        private string _angleAText = "A";
        private double _angleB;
        private string _angleBText = "B";
        private string _hypText = "hyp";
        private double _hypotenuse;
        private Color _lineColor = Color.Black;
        private int _lineWidth = 2;
        private string _oppText = "opp";
        private double _opposite;

        public TrianglePanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            InitializeComponent();
        }

        public int LineWidth
        {
            get { return _lineWidth; }
            set
            {
                _lineWidth = value;
                Refresh();
            }
        }

        public Color LineColor
        {
            get { return _lineColor; }
            set
            {
                _lineColor = value;
                Refresh();
            }
        }

        public double Opposite
        {
            get { return _opposite; }
            set { 
                _opposite = value;
                Refresh();
            }
        }

        public double Adjacent
        {
            get { return _adjacent; }
            set
            {
                _adjacent = value;
                Refresh();
            }
        }

        public double Hypotenuse
        {
            get { return _hypotenuse; }
            set
            {
                _hypotenuse = value;
                Refresh();
            }
        }

        public double AngleA
        {
            get { return _angleA; }
            set
            {
                _angleA = value;
                Refresh();
            }
        }

        public double AngleB
        {
            get { return _angleB; }
            set
            {
                _angleB = value;
                Refresh();
            }
        }

        public bool SuspendDrawing { get; set; }

        public void SolveTriangle()
        {
            if (_hypotenuse > 0 & _opposite > 0) {
                CalculateFromHypAndOpp();
            }
            else if (_hypotenuse > 0 & _adjacent > 0) {
                CalculateFromHypAndAdj();
            }
            else if (_opposite > 0 & _adjacent > 0) {
                CalculateFromOppAndAdj();
            }
            else if (_hypotenuse > 0 & _angleA > 0) {
                CalculateFromHypAndAngleA();
            }
            else if (_hypotenuse > 0 & _angleB > 0) {
                CalculateFromHypAndAngleB();
            }
            else if (_opposite > 0 & _angleA > 0) {
                CalculateFromOppAndAngleA();
            }
            else if (_opposite > 0 & _angleB > 0) {
                CalculateFromOppAndAngleB();
            }
            else if (_adjacent > 0 & _angleA > 0) {
                CalculateFromAdjAndAngleA();
            }
            else if (_adjacent > 0 & _angleB > 0) {
                CalculateFromAdjAndAngleB();
            }

            Refresh();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;

            g.SmoothingMode = SmoothingMode.HighQuality;

            _oppText = _opposite == 0 ? "opp" : _opposite.ToString("0.000");
            _adjText = _adjacent == 0 ? "adj" : _adjacent.ToString("0.000");
            _hypText = _hypotenuse == 0 ? "hyp" : _hypotenuse.ToString("0.000");
            _angleAText = _angleA == 0 ? "A" : _angleA.ToString("0.00°");
            _angleBText = _angleB == 0 ? "B" : _angleB.ToString("0.00°");

            SizeF oppTextSize = g.MeasureString(_oppText, Font);
            SizeF hypTextSize = g.MeasureString(_hypText, Font);
            SizeF adjTextSize = g.MeasureString(_adjText, Font);
            SizeF angleATextSize = g.MeasureString(_angleAText, Font);
            SizeF angleBTextSize = g.MeasureString(_angleBText, Font);

            int left = Padding.Left + ((int) oppTextSize.Width/2) + 5;
            int top = Padding.Top + ((int)angleBTextSize.Height/2);
            int bottom = Height - top - Padding.Bottom - ((int) adjTextSize.Height/2);
            int right = Width - Padding.Left - Padding.Right - ((int) angleATextSize.Width/2);

            using (var pen = new Pen(new SolidBrush(_lineColor), _lineWidth)) {
                pen.EndCap = LineCap.Triangle;
                pen.StartCap = LineCap.Triangle;
                g.DrawLine(pen, left, top, left, bottom);
                g.DrawLine(pen, left, bottom, right, bottom);
                g.DrawLine(pen, left, top, right, bottom);
            }

            var oppRect = new Rectangle(
                Padding.Left,
                ((bottom - top)/2) ,
                (int) oppTextSize.Width + 10,
                (int) oppTextSize.Height);

            var adjRect = new Rectangle(
                ((right - left)/2) - (int) adjTextSize.Width/2,
                bottom - (_lineWidth/2) - ((int) adjTextSize.Height/2),
                (int) adjTextSize.Width + 10,
                (int) adjTextSize.Height + 2);

            var adjHypXDiff = (int)((adjTextSize.Width - hypTextSize.Width)/2);

            var hypRect = new Rectangle(
                adjRect.X + adjHypXDiff,
                oppRect.Top,
                (int) hypTextSize.Width + 10,
                (int) hypTextSize.Height);

            var angleARect = new Rectangle(
                right - ((int) angleATextSize.Width)/2 - 10,
                bottom - (_lineWidth/2) - ((int) angleATextSize.Height/2),
                (int) angleATextSize.Width + 10,
                (int) angleATextSize.Height);

            var angleBRect = new Rectangle(
                left - ((int)angleBTextSize.Width)/2,
                top -((int)angleBTextSize.Height/2) + 2,
                (int)angleBTextSize.Width+ 10,
                (int)angleBTextSize.Height + 2);

            var stringFormat = new StringFormat {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            g.FillRectangle(Brushes.White, oppRect);
            g.DrawRectangle(Pens.Black, oppRect);

            g.FillRectangle(Brushes.White, adjRect);
            g.DrawRectangle(Pens.Black, adjRect);

            g.FillRectangle(Brushes.White, hypRect);
            g.DrawRectangle(Pens.Black, hypRect);

            g.FillRectangle(Brushes.White, angleARect);
            g.DrawRectangle(Pens.Black, angleARect);

            g.FillRectangle(Brushes.White, angleBRect);
            g.DrawRectangle(Pens.Black, angleBRect);

            g.DrawString(_oppText, Font, new SolidBrush(ForeColor), oppRect, stringFormat);

            g.DrawString(_adjText, Font, new SolidBrush(ForeColor), adjRect, stringFormat);

            g.DrawString(_hypText, Font, new SolidBrush(ForeColor), hypRect, stringFormat);

            g.DrawString(_angleAText, Font, new SolidBrush(ForeColor), angleARect, stringFormat);

            g.DrawString(_angleBText, Font, new SolidBrush(ForeColor), angleBRect, stringFormat);
        }

        #region Right-angle calculation methods

        private void CalculateFromHypAndOpp()
        {
            _adjacent = Math.Sqrt(Square(_hypotenuse) - Square(_opposite));

            double sineOfAngleA = _opposite/_hypotenuse;
            double radiansAngleA = Math.Asin(sineOfAngleA);
            _angleA = RadiansToDegrees(radiansAngleA);

            _angleB = 90 - _angleA;
        }

        private void CalculateFromHypAndAdj()
        {
            _opposite = Math.Sqrt(Square(_hypotenuse) - Square(_adjacent));

            double sineOfAngleB = _adjacent/_hypotenuse;
            double radiansAngleB = Math.Asin(sineOfAngleB);
            _angleB = RadiansToDegrees(radiansAngleB);

            _angleA = 90 - _angleB;
        }

        private void CalculateFromOppAndAdj()
        {
            _hypotenuse = Math.Sqrt(Square(_opposite) + Square(_adjacent));

            double tanOfAngleA = _opposite/_adjacent;
            double radiansAngleA = Math.Atan(tanOfAngleA);
            _angleA = RadiansToDegrees(radiansAngleA);

            _angleB = 90 - _angleA;
        }

        private void CalculateFromHypAndAngleA()
        {
            double radiansAngleA = DegreesToRadians(_angleA);

            _opposite = _hypotenuse*Math.Sin(radiansAngleA);

            _adjacent = _hypotenuse*Math.Cos(radiansAngleA);

            _angleB = 90 - _angleA;
        }

        private void CalculateFromHypAndAngleB()
        {
            double radiansAngleB = DegreesToRadians(_angleB);

            _opposite = _hypotenuse*Math.Cos(radiansAngleB);

            _adjacent = _hypotenuse*Math.Sin(radiansAngleB);

            _angleA = 90 - _angleB;
        }

        private void CalculateFromOppAndAngleA()
        {
            double radiansAngleA = DegreesToRadians(_angleA);

            _hypotenuse = _opposite/Math.Sin(radiansAngleA);

            _adjacent = _opposite*Cotan(radiansAngleA);

            _angleB = 90 - _angleA;
        }

        private void CalculateFromOppAndAngleB()
        {
            double radiansAngleB = DegreesToRadians(_angleB);

            _hypotenuse = _opposite/Math.Cos(radiansAngleB);

            _adjacent = _opposite*Math.Tan(radiansAngleB);

            _angleA = 90 - _angleB;
        }

        private void CalculateFromAdjAndAngleA()
        {
            double radiansAngleA = DegreesToRadians(_angleA);

            _hypotenuse = _adjacent/Math.Cos(radiansAngleA);

            _opposite = _adjacent*Math.Tan(radiansAngleA);

            _angleB = 90 - _angleA;
        }

        private void CalculateFromAdjAndAngleB()
        {
            double radiansAngleB = DegreesToRadians(_angleB);

            _hypotenuse = _adjacent/Math.Sin(radiansAngleB);

            _opposite = _adjacent*Cotan(radiansAngleB);

            _angleA = 90 - _angleB;
        }

        private double RadiansToDegrees(double radians)
        {
            return radians*(180/Math.PI);
        }

        private double DegreesToRadians(double degrees)
        {
            return Math.PI*degrees/180.0;
        }

        private double Square(double value)
        {
            return Math.Pow(value, 2);
        }

        private double Cotan(double value)
        {
            return 1/Math.Tan(value);
        }

        #endregion
    }
}