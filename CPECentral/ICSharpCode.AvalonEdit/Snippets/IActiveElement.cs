#region Using directives

using ICSharpCode.AvalonEdit.Document;

#endregion

namespace ICSharpCode.AvalonEdit.Snippets
{
    /// <summary>
    ///     Represents an active element that allows the snippet to stay interactive after insertion.
    /// </summary>
    public interface IActiveElement
    {
        /// <summary>
        ///     Gets whether this element is editable (the user will be able to select it with Tab).
        /// </summary>
        bool IsEditable { get; }

        /// <summary>
        ///     Gets the segment associated with this element. May be null.
        /// </summary>
        ISegment Segment { get; }

        /// <summary>
        ///     Called when the all snippet elements have been inserted.
        /// </summary>
        void OnInsertionCompleted();

        /// <summary>
        ///     Called when the interactive mode is deactivated.
        /// </summary>
        void Deactivate(SnippetEventArgs e);
    }
}