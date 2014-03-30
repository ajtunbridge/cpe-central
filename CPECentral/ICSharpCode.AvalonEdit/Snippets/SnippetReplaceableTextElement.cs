#region Using directives

using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;

#endregion

namespace ICSharpCode.AvalonEdit.Snippets
{
    /// <summary>
    ///     Text element that is supposed to be replaced by the user.
    ///     Will register an <see cref="IReplaceableActiveElement" />.
    /// </summary>
    [Serializable]
    public class SnippetReplaceableTextElement : SnippetTextElement
    {
        /// <inheritdoc />
        public override void Insert(InsertionContext context)
        {
            int start = context.InsertionPosition;
            base.Insert(context);
            int end = context.InsertionPosition;
            context.RegisterActiveElement(this, new ReplaceableActiveElement(context, start, end));
        }

        /// <inheritdoc />
        public override Inline ToTextRun()
        {
            return new Italic(base.ToTextRun());
        }
    }

    /// <summary>
    ///     Interface for active element registered by <see cref="SnippetReplaceableTextElement" />.
    /// </summary>
    public interface IReplaceableActiveElement : IActiveElement
    {
        /// <summary>
        ///     Gets the current text inside the element.
        /// </summary>
        string Text { get; }

        /// <summary>
        ///     Occurs when the text inside the element changes.
        /// </summary>
        event EventHandler TextChanged;
    }

    internal sealed class ReplaceableActiveElement : IReplaceableActiveElement, IWeakEventListener
    {
        private readonly InsertionContext context;
        private readonly int endOffset;
        private readonly int startOffset;
        private Renderer background;
        private TextAnchor end;
        private Renderer foreground;
        private bool isCaretInside;
        private TextAnchor start;

        public ReplaceableActiveElement(InsertionContext context, int startOffset, int endOffset)
        {
            this.context = context;
            this.startOffset = startOffset;
            this.endOffset = endOffset;
        }

        #region IReplaceableActiveElement Members

        public void OnInsertionCompleted()
        {
            // anchors must be created in OnInsertionCompleted because they should move only
            // due to user insertions, not due to insertions of other snippet parts
            start = context.Document.CreateAnchor(startOffset);
            start.MovementType = AnchorMovementType.BeforeInsertion;
            end = context.Document.CreateAnchor(endOffset);
            end.MovementType = AnchorMovementType.AfterInsertion;
            start.Deleted += AnchorDeleted;
            end.Deleted += AnchorDeleted;

            // Be careful with references from the document to the editing/snippet layer - use weak events
            // to prevent memory leaks when the text area control gets dropped from the UI while the snippet is active.
            // The InsertionContext will keep us alive as long as the snippet is in interactive mode.
            TextDocumentWeakEventManager.TextChanged.AddListener(context.Document, this);

            background = new Renderer {Layer = KnownLayer.Background, element = this};
            foreground = new Renderer {Layer = KnownLayer.Text, element = this};
            context.TextArea.TextView.BackgroundRenderers.Add(background);
            context.TextArea.TextView.BackgroundRenderers.Add(foreground);
            context.TextArea.Caret.PositionChanged += Caret_PositionChanged;
            Caret_PositionChanged(null, null);

            Text = GetText();
        }

        public void Deactivate(SnippetEventArgs e)
        {
            TextDocumentWeakEventManager.TextChanged.RemoveListener(context.Document, this);
            context.TextArea.TextView.BackgroundRenderers.Remove(background);
            context.TextArea.TextView.BackgroundRenderers.Remove(foreground);
            context.TextArea.Caret.PositionChanged -= Caret_PositionChanged;
        }

        public string Text { get; private set; }

        public event EventHandler TextChanged;

        public bool IsEditable
        {
            get { return true; }
        }

        public ISegment Segment
        {
            get
            {
                if (start.IsDeleted || end.IsDeleted) {
                    return null;
                }
                return new SimpleSegment(start.Offset, Math.Max(0, end.Offset - start.Offset));
            }
        }

        #endregion

        #region IWeakEventListener Members

        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof (TextDocumentWeakEventManager.TextChanged)) {
                string newText = GetText();
                if (Text != newText) {
                    Text = newText;
                    if (TextChanged != null) {
                        TextChanged(this, e);
                    }
                }
                return true;
            }
            return false;
        }

        #endregion

        private void AnchorDeleted(object sender, EventArgs e)
        {
            context.Deactivate(new SnippetEventArgs(DeactivateReason.Deleted));
        }

        private void Caret_PositionChanged(object sender, EventArgs e)
        {
            ISegment s = Segment;
            if (s != null) {
                bool newIsCaretInside = s.Contains(context.TextArea.Caret.Offset);
                if (newIsCaretInside != isCaretInside) {
                    isCaretInside = newIsCaretInside;
                    context.TextArea.TextView.InvalidateLayer(foreground.Layer);
                }
            }
        }

        private string GetText()
        {
            if (start.IsDeleted || end.IsDeleted) {
                return string.Empty;
            }
            return context.Document.GetText(start.Offset, Math.Max(0, end.Offset - start.Offset));
        }

        #region Nested type: Renderer

        private sealed class Renderer : IBackgroundRenderer
        {
            private static readonly Brush backgroundBrush = CreateBackgroundBrush();
            private static readonly Pen activeBorderPen = CreateBorderPen();

            internal ReplaceableActiveElement element;

            #region IBackgroundRenderer Members

            public KnownLayer Layer { get; set; }

            public void Draw(TextView textView, DrawingContext drawingContext)
            {
                ISegment s = element.Segment;
                if (s != null) {
                    var geoBuilder = new BackgroundGeometryBuilder();
                    geoBuilder.AlignToMiddleOfPixels = true;
                    if (Layer == KnownLayer.Background) {
                        geoBuilder.AddSegment(textView, s);
                        drawingContext.DrawGeometry(backgroundBrush, null, geoBuilder.CreateGeometry());
                    }
                    else {
                        // draw foreground only if active
                        if (element.isCaretInside) {
                            geoBuilder.AddSegment(textView, s);
                            foreach (
                                BoundActiveElement boundElement in
                                    element.context.ActiveElements.OfType<BoundActiveElement>()) {
                                if (boundElement.targetElement == element) {
                                    geoBuilder.AddSegment(textView, boundElement.Segment);
                                    geoBuilder.CloseFigure();
                                }
                            }
                            drawingContext.DrawGeometry(null, activeBorderPen, geoBuilder.CreateGeometry());
                        }
                    }
                }
            }

            #endregion

            private static Brush CreateBackgroundBrush()
            {
                var b = new SolidColorBrush(Colors.LimeGreen);
                b.Opacity = 0.4;
                b.Freeze();
                return b;
            }

            private static Pen CreateBorderPen()
            {
                var p = new Pen(Brushes.Black, 1);
                p.DashStyle = DashStyles.Dot;
                p.Freeze();
                return p;
            }
        }

        #endregion
    }
}