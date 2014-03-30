#region Using directives

using System;
using System.Windows;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Rendering
{
    /// <summary>
    ///     Renders a ruler at a certain column.
    /// </summary>
    internal sealed class ColumnRulerRenderer : IBackgroundRenderer
    {
        public static readonly Color DefaultForeground = Colors.LightGray;
        private readonly TextView textView;
        private int column;
        private Pen pen;

        public ColumnRulerRenderer(TextView textView)
        {
            if (textView == null) {
                throw new ArgumentNullException("textView");
            }

            pen = new Pen(new SolidColorBrush(DefaultForeground), 1);
            pen.Freeze();
            this.textView = textView;
            this.textView.BackgroundRenderers.Add(this);
        }

        #region IBackgroundRenderer Members

        public KnownLayer Layer
        {
            get { return KnownLayer.Background; }
        }

        public void Draw(TextView textView, DrawingContext drawingContext)
        {
            if (column < 1) {
                return;
            }
            double offset = textView.WideSpaceWidth*column;
            Size pixelSize = PixelSnapHelpers.GetPixelSize(textView);
            double markerXPos = PixelSnapHelpers.PixelAlign(offset, pixelSize.Width);
            markerXPos -= textView.ScrollOffset.X;
            var start = new Point(markerXPos, 0);
            var end = new Point(markerXPos, Math.Max(textView.DocumentHeight, textView.ActualHeight));

            drawingContext.DrawLine(pen, start, end);
        }

        #endregion

        public void SetRuler(int column, Pen pen)
        {
            if (this.column != column) {
                this.column = column;
                textView.InvalidateLayer(Layer);
            }
            if (this.pen != pen) {
                this.pen = pen;
                textView.InvalidateLayer(Layer);
            }
        }
    }
}