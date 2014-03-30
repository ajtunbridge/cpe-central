#region Using directives

using System;
using System.Diagnostics.CodeAnalysis;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Document
{
    /// <summary>
    ///     Contains weak event managers for the TextDocument events.
    /// </summary>
    public static class TextDocumentWeakEventManager
    {
        #region Nested type: Changed

        /// <summary>
        ///     Weak event manager for the <see cref="TextDocument.Changed" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class Changed : WeakEventManagerBase<Changed, TextDocument>
        {
            /// <inheritdoc />
            protected override void StartListening(TextDocument source)
            {
                source.Changed += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(TextDocument source)
            {
                source.Changed -= DeliverEvent;
            }
        }

        #endregion

        #region Nested type: Changing

        /// <summary>
        ///     Weak event manager for the <see cref="TextDocument.Changing" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class Changing : WeakEventManagerBase<Changing, TextDocument>
        {
            /// <inheritdoc />
            protected override void StartListening(TextDocument source)
            {
                source.Changing += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(TextDocument source)
            {
                source.Changing -= DeliverEvent;
            }
        }

        #endregion

        #region Nested type: LineCountChanged

        /// <summary>
        ///     Weak event manager for the <see cref="TextDocument.LineCountChanged" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        [Obsolete(
            "The TextDocument.LineCountChanged event will be removed in a future version. Use PropertyChangedEventManager instead."
            )]
        public sealed class LineCountChanged : WeakEventManagerBase<LineCountChanged, TextDocument>
        {
            /// <inheritdoc />
            protected override void StartListening(TextDocument source)
            {
                source.LineCountChanged += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(TextDocument source)
            {
                source.LineCountChanged -= DeliverEvent;
            }
        }

        #endregion

        #region Nested type: TextChanged

        /// <summary>
        ///     Weak event manager for the <see cref="TextDocument.TextChanged" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class TextChanged : WeakEventManagerBase<TextChanged, TextDocument>
        {
            /// <inheritdoc />
            protected override void StartListening(TextDocument source)
            {
                source.TextChanged += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(TextDocument source)
            {
                source.TextChanged -= DeliverEvent;
            }
        }

        #endregion

        #region Nested type: TextLengthChanged

        /// <summary>
        ///     Weak event manager for the <see cref="TextDocument.TextLengthChanged" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        [Obsolete(
            "The TextDocument.TextLengthChanged event will be removed in a future version. Use PropertyChangedEventManager instead."
            )]
        public sealed class TextLengthChanged : WeakEventManagerBase<TextLengthChanged, TextDocument>
        {
            /// <inheritdoc />
            protected override void StartListening(TextDocument source)
            {
                source.TextLengthChanged += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(TextDocument source)
            {
                source.TextLengthChanged -= DeliverEvent;
            }
        }

        #endregion

        #region Nested type: UpdateFinished

        /// <summary>
        ///     Weak event manager for the <see cref="TextDocument.UpdateFinished" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class UpdateFinished : WeakEventManagerBase<UpdateFinished, TextDocument>
        {
            /// <inheritdoc />
            protected override void StartListening(TextDocument source)
            {
                source.UpdateFinished += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(TextDocument source)
            {
                source.UpdateFinished -= DeliverEvent;
            }
        }

        #endregion

        #region Nested type: UpdateStarted

        /// <summary>
        ///     Weak event manager for the <see cref="TextDocument.UpdateStarted" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class UpdateStarted : WeakEventManagerBase<UpdateStarted, TextDocument>
        {
            /// <inheritdoc />
            protected override void StartListening(TextDocument source)
            {
                source.UpdateStarted += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(TextDocument source)
            {
                source.UpdateStarted -= DeliverEvent;
            }
        }

        #endregion
    }
}