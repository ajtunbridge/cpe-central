﻿#region Using directives

using System.Collections.Generic;
using ICSharpCode.AvalonEdit.Document;

#endregion

namespace ICSharpCode.AvalonEdit.Folding
{
    /// <summary>
    ///     Base class for folding strategies.
    /// </summary>
    public abstract class AbstractFoldingStrategy
    {
        /// <summary>
        ///     Create <see cref="NewFolding" />s for the specified document and updates the folding manager with them.
        /// </summary>
        public void UpdateFoldings(FoldingManager manager, TextDocument document)
        {
            int firstErrorOffset;
            IEnumerable<NewFolding> foldings = CreateNewFoldings(document, out firstErrorOffset);
            manager.UpdateFoldings(foldings, firstErrorOffset);
        }

        /// <summary>
        ///     Create <see cref="NewFolding" />s for the specified document.
        /// </summary>
        public abstract IEnumerable<NewFolding> CreateNewFoldings(TextDocument document, out int firstErrorOffset);
    }
}