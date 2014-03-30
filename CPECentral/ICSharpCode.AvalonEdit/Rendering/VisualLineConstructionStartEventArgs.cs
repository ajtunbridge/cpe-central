#region Using directives

using System;
using ICSharpCode.AvalonEdit.Document;

#endregion

namespace ICSharpCode.AvalonEdit.Rendering
{
    /// <summary>
    ///     EventArgs for the <see cref="TextView.VisualLineConstructionStarting" /> event.
    /// </summary>
    public class VisualLineConstructionStartEventArgs : EventArgs
    {
        /// <summary>
        ///     Creates a new VisualLineConstructionStartEventArgs instance.
        /// </summary>
        public VisualLineConstructionStartEventArgs(DocumentLine firstLineInView)
        {
            if (firstLineInView == null) {
                throw new ArgumentNullException("firstLineInView");
            }
            FirstLineInView = firstLineInView;
        }

        /// <summary>
        ///     Gets/Sets the first line that is visible in the TextView.
        /// </summary>
        public DocumentLine FirstLineInView { get; private set; }
    }
}