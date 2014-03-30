#region Using directives

using System;
using System.Windows;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Rendering;

#endregion

namespace ICSharpCode.AvalonEdit.Editing
{
    internal sealed class SelectionLayer : Layer, IWeakEventListener
    {
        private readonly TextArea textArea;

        public SelectionLayer(TextArea textArea) : base(textArea.TextView, KnownLayer.Selection)
        {
            IsHitTestVisible = false;

            this.textArea = textArea;
            TextViewWeakEventManager.VisualLinesChanged.AddListener(textView, this);
            TextViewWeakEventManager.ScrollOffsetChanged.AddListener(textView, this);
        }

        #region IWeakEventListener Members

        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof (TextViewWeakEventManager.VisualLinesChanged)
                || managerType == typeof (TextViewWeakEventManager.ScrollOffsetChanged)) {
                InvalidateVisual();
                return true;
            }
            return false;
        }

        #endregion

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var geoBuilder = new BackgroundGeometryBuilder();
            geoBuilder.AlignToMiddleOfPixels = true;
            geoBuilder.ExtendToFullWidthAtLineEnd = textArea.Selection.EnableVirtualSpace;
            geoBuilder.CornerRadius = textArea.SelectionCornerRadius;
            foreach (SelectionSegment segment in textArea.Selection.Segments) {
                geoBuilder.AddSegment(textView, segment);
            }
            Geometry geometry = geoBuilder.CreateGeometry();
            if (geometry != null) {
                drawingContext.DrawGeometry(textArea.SelectionBrush, textArea.SelectionBorder, geometry);
            }
        }
    }
}