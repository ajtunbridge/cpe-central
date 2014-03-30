#region Using directives

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;

#endregion

namespace ICSharpCode.AvalonEdit.Search
{
    internal class SearchResultBackgroundRenderer : IBackgroundRenderer
    {
        private readonly TextSegmentCollection<SearchResult> currentResults = new TextSegmentCollection<SearchResult>();

        private Brush markerBrush;
        private Pen markerPen;

        public SearchResultBackgroundRenderer()
        {
            markerBrush = Brushes.LightGreen;
            markerPen = new Pen(markerBrush, 1);
        }

        public TextSegmentCollection<SearchResult> CurrentResults
        {
            get { return currentResults; }
        }

        public Brush MarkerBrush
        {
            get { return markerBrush; }
            set
            {
                markerBrush = value;
                markerPen = new Pen(markerBrush, 1);
            }
        }

        #region IBackgroundRenderer Members

        public KnownLayer Layer
        {
            get
            {
                // draw behind selection
                return KnownLayer.Selection;
            }
        }

        public void Draw(TextView textView, DrawingContext drawingContext)
        {
            if (textView == null) {
                throw new ArgumentNullException("textView");
            }
            if (drawingContext == null) {
                throw new ArgumentNullException("drawingContext");
            }

            if (currentResults == null || !textView.VisualLinesValid) {
                return;
            }

            ReadOnlyCollection<VisualLine> visualLines = textView.VisualLines;
            if (visualLines.Count == 0) {
                return;
            }

            int viewStart = visualLines.First().FirstDocumentLine.Offset;
            int viewEnd = visualLines.Last().LastDocumentLine.EndOffset;

            foreach (SearchResult result in currentResults.FindOverlappingSegments(viewStart, viewEnd - viewStart)) {
                var geoBuilder = new BackgroundGeometryBuilder();
                geoBuilder.AlignToMiddleOfPixels = true;
                geoBuilder.CornerRadius = 3;
                geoBuilder.AddSegment(textView, result);
                Geometry geometry = geoBuilder.CreateGeometry();
                if (geometry != null) {
                    drawingContext.DrawGeometry(markerBrush, markerPen, geometry);
                }
            }
        }

        #endregion
    }
}