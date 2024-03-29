﻿#region Using directives

using System;
using System.Text;

#endregion

namespace ICSharpCode.AvalonEdit.Snippets
{
    /// <summary>
    ///     Inserts the previously selected text at the selection marker.
    /// </summary>
    [Serializable]
    public class SnippetSelectionElement : SnippetElement
    {
        /// <summary>
        ///     Gets/Sets the new indentation of the selected text.
        /// </summary>
        public int Indentation { get; set; }

        /// <inheritdoc />
        public override void Insert(InsertionContext context)
        {
            var tabString = new StringBuilder();

            for (int i = 0; i < Indentation; i++) {
                tabString.Append(context.Tab);
            }

            string indent = tabString.ToString();

            string text = context.SelectedText.TrimStart(' ', '\t');

            text = text.Replace(context.LineTerminator,
                context.LineTerminator + indent);

            context.Document.Insert(context.InsertionPosition, text);
            context.InsertionPosition += text.Length;

            if (string.IsNullOrEmpty(context.SelectedText)) {
                SnippetCaretElement.SetCaret(context);
            }
        }
    }
}