#region Using directives

using System.Diagnostics.CodeAnalysis;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit
{
    /// <summary>
    ///     Contains weak event managers for <see cref="ITextEditorComponent" />.
    /// </summary>
    public static class TextEditorWeakEventManager
    {
        #region Nested type: DocumentChanged

        /// <summary>
        ///     Weak event manager for the <see cref="ITextEditorComponent.DocumentChanged" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class DocumentChanged : WeakEventManagerBase<DocumentChanged, ITextEditorComponent>
        {
            /// <inheritdoc />
            protected override void StartListening(ITextEditorComponent source)
            {
                source.DocumentChanged += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(ITextEditorComponent source)
            {
                source.DocumentChanged -= DeliverEvent;
            }
        }

        #endregion

        #region Nested type: OptionChanged

        /// <summary>
        ///     Weak event manager for the <see cref="ITextEditorComponent.OptionChanged" /> event.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class OptionChanged : WeakEventManagerBase<OptionChanged, ITextEditorComponent>
        {
            /// <inheritdoc />
            protected override void StartListening(ITextEditorComponent source)
            {
                source.OptionChanged += DeliverEvent;
            }

            /// <inheritdoc />
            protected override void StopListening(ITextEditorComponent source)
            {
                source.OptionChanged -= DeliverEvent;
            }
        }

        #endregion
    }
}