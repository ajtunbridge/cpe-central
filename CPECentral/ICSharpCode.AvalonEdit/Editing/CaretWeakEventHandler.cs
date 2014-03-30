#region Using directives

using System.Diagnostics.CodeAnalysis;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Editing
{
    /// <summary>
    ///     Contains classes for handling weak events on the Caret class.
    /// </summary>
    public static class CaretWeakEventManager
    {
        #region Nested type: PositionChanged

        /// <summary>
        ///     Handles the Caret.PositionChanged event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class PositionChanged : WeakEventManagerBase<PositionChanged, Caret>
        {
            /// <inheritdoc />
            protected override void StartListening(Caret source)
            {
                source.PositionChanged += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(Caret source)
            {
                source.PositionChanged -= DeliverEvent;
            }
        }

        #endregion
    }
}