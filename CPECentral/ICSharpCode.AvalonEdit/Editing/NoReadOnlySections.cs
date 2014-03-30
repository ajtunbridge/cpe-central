#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Editing
{
    /// <summary>
    ///     <see cref="IReadOnlySectionProvider" /> that has no read-only sections; all text is editable.
    /// </summary>
    internal sealed class NoReadOnlySections : IReadOnlySectionProvider
    {
        public static readonly NoReadOnlySections Instance = new NoReadOnlySections();

        #region IReadOnlySectionProvider Members

        public bool CanInsert(int offset)
        {
            return true;
        }

        public IEnumerable<ISegment> GetDeletableSegments(ISegment segment)
        {
            if (segment == null) {
                throw new ArgumentNullException("segment");
            }
            // the segment is always deletable
            return ExtensionMethods.Sequence(segment);
        }

        #endregion
    }

    /// <summary>
    ///     <see cref="IReadOnlySectionProvider" /> that completely disables editing.
    /// </summary>
    internal sealed class ReadOnlyDocument : IReadOnlySectionProvider
    {
        public static readonly ReadOnlyDocument Instance = new ReadOnlyDocument();

        #region IReadOnlySectionProvider Members

        public bool CanInsert(int offset)
        {
            return false;
        }

        public IEnumerable<ISegment> GetDeletableSegments(ISegment segment)
        {
            return Enumerable.Empty<ISegment>();
        }

        #endregion
    }
}