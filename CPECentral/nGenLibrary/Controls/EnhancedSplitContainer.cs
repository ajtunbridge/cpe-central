#region Using directives

using System.Drawing;
using System.Windows.Forms;

#endregion

namespace nGenLibrary.Controls
{
    public enum Direction
    {
        Right = 0,
        Left,
        Up,
        Down
    }

    public class EnhancedSplitContainer : SplitContainer
    {
        public EnhancedSplitContainer()
        {
            //InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            KeyPress += ACSplitter_KeyPress;
            KeyUp += ACSplitter_KeyUp;
        }

        #region private properties

        private Color hotColor = CalculateColor(SystemColors.Highlight, SystemColors.Window, 70);

        #endregion

        private void ACSplitter_KeyPress(object sender, KeyPressEventArgs e)
        {
            Invalidate();
            e.Handled = false;
        }

        private void ACSplitter_KeyUp(object sender, KeyEventArgs e)
        {
            Invalidate();
            e.Handled = false;
        }


        // solid color obtained as a result of alpha-blending
        private static Color CalculateColor(Color front, Color back, int alpha)
        {
            Color frontColor = Color.FromArgb(255, front);
            Color backColor = Color.FromArgb(255, back);

            float frontRed = frontColor.R;
            float frontGreen = frontColor.G;
            float frontBlue = frontColor.B;
            float backRed = backColor.R;
            float backGreen = backColor.G;
            float backBlue = backColor.B;

            float fRed = frontRed*alpha/255 + backRed*((float) (255 - alpha)/255);
            var newRed = (byte) fRed;
            float fGreen = frontGreen*alpha/255 + backGreen*((float) (255 - alpha)/255);
            var newGreen = (byte) fGreen;
            float fBlue = frontBlue*alpha/255 + backBlue*((float) (255 - alpha)/255);
            var newBlue = (byte) fBlue;

            return Color.FromArgb(255, newRed, newGreen, newBlue);
        }

        // This creates a point array to draw a arrow-like polygon
        private Point[] ArrowPointArray(int x, int y, Direction direction)
        {
            var point = new Point[3];

            // decide which direction the arrow will point
            if (direction == Direction.Right) {
                // right arrow
                point[0] = new Point(x, y);
                point[1] = new Point(x + 3, y + 3);
                point[2] = new Point(x, y + 6);
            }
            if (direction == Direction.Left) {
                // left arrow
                point[0] = new Point(x + 3, y);
                point[1] = new Point(x, y + 3);
                point[2] = new Point(x + 3, y + 6);
            }
            if (direction == Direction.Up) {
                // up arrow
                point[0] = new Point(x + 3, y);
                point[1] = new Point(x + 6, y + 4);
                point[2] = new Point(x, y + 4);
            }
            if (direction == Direction.Down) {
                // down arrow
                point[0] = new Point(x, y);
                point[1] = new Point(x + 2, y + 3);
                point[2] = new Point(x + 5, y);
            }
            return point;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;

            Rectangle r = ClientRectangle;
            g.FillRectangle(new SolidBrush(BackColor), r);


            if (Orientation == Orientation.Horizontal) {
                SplitterWidth = 9;
                int recWidth = SplitterRectangle.Width/3;
                var split_rect = new Rectangle(SplitterRectangle.X + recWidth, SplitterRectangle.Y,
                    SplitterRectangle.Width - recWidth, SplitterRectangle.Height);

                int x = split_rect.X;
                int y = split_rect.Y + 3;

                g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x, y + 2);
                g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x + recWidth, y);
                g.DrawLine(new Pen(SystemColors.ControlDark), x, y + 2, x + recWidth, y + 2);
                g.DrawLine(new Pen(SystemColors.ControlDark), x + recWidth, y, x + recWidth, y + 2);
            }
            else {
                SplitterWidth = 9;
                int recHeight = SplitterRectangle.Height/3;
                var split_rect = new Rectangle(SplitterRectangle.X, SplitterRectangle.Y + recHeight,
                    SplitterRectangle.Width, SplitterRectangle.Height - 2*recHeight);

                int x = split_rect.X + 3;
                int y = split_rect.Y;

                g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x + 2, y);
                g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x, y + recHeight);
                g.DrawLine(new Pen(SystemColors.ControlDark), x + 2, y, x + 2, y + recHeight);
                g.DrawLine(new Pen(SystemColors.ControlDark), x, y + recHeight, x + 2, y + recHeight);
            }
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }
    }
}