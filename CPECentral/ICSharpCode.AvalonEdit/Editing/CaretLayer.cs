#region Using directives

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Editing
{
    internal sealed class CaretLayer : Layer
    {
        private readonly DispatcherTimer caretBlinkTimer = new DispatcherTimer();
        internal Brush CaretBrush;
        private bool blink;
        private Rect caretRectangle;
        private bool isVisible;

        public CaretLayer(TextView textView) : base(textView, KnownLayer.Caret)
        {
            IsHitTestVisible = false;
            caretBlinkTimer.Tick += caretBlinkTimer_Tick;
        }

        private void caretBlinkTimer_Tick(object sender, EventArgs e)
        {
            blink = !blink;
            InvalidateVisual();
        }

        public void Show(Rect caretRectangle)
        {
            this.caretRectangle = caretRectangle;
            isVisible = true;
            StartBlinkAnimation();
            InvalidateVisual();
        }

        public void Hide()
        {
            if (isVisible) {
                isVisible = false;
                StopBlinkAnimation();
                InvalidateVisual();
            }
        }

        private void StartBlinkAnimation()
        {
            TimeSpan blinkTime = Win32.CaretBlinkTime;
            blink = true; // the caret should visible initially
            // This is important if blinking is disabled (system reports a negative blinkTime)
            if (blinkTime.TotalMilliseconds > 0) {
                caretBlinkTimer.Interval = blinkTime;
                caretBlinkTimer.Start();
            }
        }

        private void StopBlinkAnimation()
        {
            caretBlinkTimer.Stop();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (isVisible && blink) {
                Brush caretBrush = CaretBrush;
                if (caretBrush == null) {
                    caretBrush = (Brush) textView.GetValue(TextBlock.ForegroundProperty);
                }
                var r = new Rect(caretRectangle.X - textView.HorizontalOffset,
                    caretRectangle.Y - textView.VerticalOffset,
                    caretRectangle.Width,
                    caretRectangle.Height);
                drawingContext.DrawRectangle(caretBrush, null,
                    PixelSnapHelpers.Round(r, PixelSnapHelpers.GetPixelSize(this)));
            }
        }
    }
}