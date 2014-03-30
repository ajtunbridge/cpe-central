﻿#region Using directives

using ICSharpCode.AvalonEdit.Document;

#endregion

namespace ICSharpCode.AvalonEdit.Snippets
{
    /// <summary>
    ///     Creates a named anchor that can be accessed by other SnippetElements.
    /// </summary>
    public sealed class SnippetAnchorElement : SnippetElement
    {
        /// <summary>
        ///     Creates a SnippetAnchorElement with the supplied name.
        /// </summary>
        public SnippetAnchorElement(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Gets or sets the name of the anchor.
        /// </summary>
        public string Name { get; private set; }

        /// <inheritdoc />
        public override void Insert(InsertionContext context)
        {
            TextAnchor start = context.Document.CreateAnchor(context.InsertionPosition);
            start.MovementType = AnchorMovementType.BeforeInsertion;
            start.SurviveDeletion = true;
            var segment = new AnchorSegment(start, start);
            context.RegisterActiveElement(this, new AnchorElement(segment, Name, context));
        }
    }

    /// <summary>
    ///     AnchorElement created by SnippetAnchorElement.
    /// </summary>
    public sealed class AnchorElement : IActiveElement
    {
        private readonly InsertionContext context;
        private AnchorSegment segment;

        /// <summary>
        ///     Creates a new AnchorElement.
        /// </summary>
        public AnchorElement(AnchorSegment segment, string name, InsertionContext context)
        {
            this.segment = segment;
            this.context = context;
            Name = name;
        }

        /// <summary>
        ///     Gets or sets the text at the anchor.
        /// </summary>
        public string Text
        {
            get { return context.Document.GetText(segment); }
            set
            {
                int offset = segment.Offset;
                int length = segment.Length;
                context.Document.Replace(offset, length, value);
                if (length == 0) {
                    // replacing an empty anchor segment with text won't enlarge it, so we have to recreate it
                    segment = new AnchorSegment(context.Document, offset, value.Length);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the name of the anchor.
        /// </summary>
        public string Name { get; private set; }

        #region IActiveElement Members

        /// <inheritdoc />
        public bool IsEditable
        {
            get { return false; }
        }

        /// <inheritdoc />
        public ISegment Segment
        {
            get { return segment; }
        }

        /// <inheritdoc />
        public void OnInsertionCompleted()
        {
        }

        /// <inheritdoc />
        public void Deactivate(SnippetEventArgs e)
        {
        }

        #endregion
    }
}