﻿#region Using directives

using System;
using System.Text.RegularExpressions;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting
{
    /// <summary>
    ///     A highlighting rule.
    /// </summary>
    [Serializable]
    public class HighlightingRule
    {
        /// <summary>
        ///     Gets/Sets the regular expression for the rule.
        /// </summary>
        public Regex Regex { get; set; }

        /// <summary>
        ///     Gets/Sets the highlighting color.
        /// </summary>
        public HighlightingColor Color { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + GetType().Name + " " + Regex + "]";
        }
    }
}