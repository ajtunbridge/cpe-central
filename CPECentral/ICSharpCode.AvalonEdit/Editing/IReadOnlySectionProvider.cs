﻿#region Using directives

using System.Collections.Generic;
using ICSharpCode.AvalonEdit.Document;

#endregion

namespace ICSharpCode.AvalonEdit.Editing
{
    /// <summary>
    ///     Determines whether the document can be modified.
    /// </summary>
    public interface IReadOnlySectionProvider
    {
        /// <summary>
        ///     Gets whether insertion is possible at the specified offset.
        /// </summary>
        bool CanInsert(int offset);

        /// <summary>
        ///     Gets the deletable segments inside the given segment.
        /// </summary>
        /// <remarks>
        ///     All segments in the result must be within the given segment, and they must be returned in order
        ///     (e.g. if two segments are returned, EndOffset of first segment must be less than StartOffset of second segment).
        ///     For replacements, the last segment being returned will be replaced with the new text. If an empty list is returned,
        ///     no replacement will be done.
        /// </remarks>
        IEnumerable<ISegment> GetDeletableSegments(ISegment segment);
    }
}