#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Documents;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Snippets
{
    /// <summary>
    ///     A snippet element that has sub-elements.
    /// </summary>
    [Serializable]
    public class SnippetContainerElement : SnippetElement
    {
        private readonly NullSafeCollection<SnippetElement> elements = new NullSafeCollection<SnippetElement>();

        /// <summary>
        ///     Gets the list of child elements.
        /// </summary>
        public IList<SnippetElement> Elements
        {
            get { return elements; }
        }

        /// <inheritdoc />
        public override void Insert(InsertionContext context)
        {
            foreach (SnippetElement e in Elements) {
                e.Insert(context);
            }
        }

        /// <inheritdoc />
        public override Inline ToTextRun()
        {
            var span = new Span();
            foreach (SnippetElement e in Elements) {
                Inline r = e.ToTextRun();
                if (r != null) {
                    span.Inlines.Add(r);
                }
            }
            return span;
        }
    }
}