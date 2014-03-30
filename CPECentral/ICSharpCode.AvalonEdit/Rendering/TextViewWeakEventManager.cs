#region Using directives

using System.Diagnostics.CodeAnalysis;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Rendering
{
    /// <summary>
    ///     Contains weak event managers for the TextView events.
    /// </summary>
    public static class TextViewWeakEventManager
    {
        #region Nested type: DocumentChanged

        /// <summary>
        ///     Weak event manager for the <see cref="TextView.DocumentChanged" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class DocumentChanged : WeakEventManagerBase<DocumentChanged, TextView>
        {
            /// <inheritdoc />
            protected override void StartListening(TextView source)
            {
                source.DocumentChanged += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(TextView source)
            {
                source.DocumentChanged -= DeliverEvent;
            }
        }

        #endregion

        #region Nested type: ScrollOffsetChanged

        /// <summary>
        ///     Weak event manager for the <see cref="TextView.ScrollOffsetChanged" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class ScrollOffsetChanged : WeakEventManagerBase<ScrollOffsetChanged, TextView>
        {
            /// <inheritdoc />
            protected override void StartListening(TextView source)
            {
                source.ScrollOffsetChanged += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(TextView source)
            {
                source.ScrollOffsetChanged -= DeliverEvent;
            }
        }

        #endregion

        #region Nested type: VisualLinesChanged

        /// <summary>
        ///     Weak event manager for the <see cref="TextView.VisualLinesChanged" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class VisualLinesChanged : WeakEventManagerBase<VisualLinesChanged, TextView>
        {
            /// <inheritdoc />
            protected override void StartListening(TextView source)
            {
                source.VisualLinesChanged += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(TextView source)
            {
                source.VisualLinesChanged -= DeliverEvent;
            }
        }

        #endregion
    }
}