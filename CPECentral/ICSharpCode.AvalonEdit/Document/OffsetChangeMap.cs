﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Document
{
    /// <summary>
    ///     Contains predefined offset change mapping types.
    /// </summary>
    public enum OffsetChangeMappingType
    {
        /// <summary>
        ///     Normal replace.
        ///     Anchors in front of the replaced region will stay in front, anchors after the replaced region will stay after.
        ///     Anchors in the middle of the removed region will be deleted. If they survive deletion,
        ///     they move depending on their AnchorMovementType.
        /// </summary>
        /// <remarks>
        ///     This is the default implementation of DocumentChangeEventArgs when OffsetChangeMap is null,
        ///     so using this option usually works without creating an OffsetChangeMap instance.
        ///     This is equivalent to an OffsetChangeMap with a single entry describing the replace operation.
        /// </remarks>
        Normal,

        /// <summary>
        ///     First the old text is removed, then the new text is inserted.
        ///     Anchors immediately in front (or after) the replaced region may move to the other side of the insertion,
        ///     depending on the AnchorMovementType.
        /// </summary>
        /// <remarks>
        ///     This is implemented as an OffsetChangeMap with two entries: the removal, and the insertion.
        /// </remarks>
        RemoveAndInsert,

        /// <summary>
        ///     The text is replaced character-by-character.
        ///     Anchors keep their position inside the replaced text.
        ///     Anchors after the replaced region will move accordingly if the replacement text has a different length than the
        ///     replaced text.
        ///     If the new text is shorter than the old text, anchors inside the old text that would end up behind the replacement
        ///     text
        ///     will be moved so that they point to the end of the replacement text.
        /// </summary>
        /// <remarks>
        ///     On the OffsetChangeMap level, growing text is implemented by replacing the last character in the replaced text
        ///     with itself and the additional text segment. A simple insertion of the additional text would have the undesired
        ///     effect of moving anchors immediately after the replaced text into the replacement text if they used
        ///     AnchorMovementStyle.BeforeInsertion.
        ///     Shrinking text is implemented by removing the text segment that's too long; but in a special mode that
        ///     causes anchors to always survive irrespective of their <see cref="TextAnchor.SurviveDeletion" /> setting.
        ///     If the text keeps its old size, this is implemented as OffsetChangeMap.Empty.
        /// </remarks>
        CharacterReplace,

        /// <summary>
        ///     Like 'Normal', but anchors with <see cref="TextAnchor.MovementType" /> = Default will stay in front of the
        ///     insertion instead of being moved behind it.
        /// </summary>
        KeepAnchorBeforeInsertion
    }

    /// <summary>
    ///     Describes a series of offset changes.
    /// </summary>
    [Serializable]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "It's a mapping old offsets -> new offsets")]
    public sealed class OffsetChangeMap : Collection<OffsetChangeMapEntry>
    {
        /// <summary>
        ///     Immutable OffsetChangeMap that is empty.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "The Empty instance is immutable")] public static readonly OffsetChangeMap Empty =
                new OffsetChangeMap(Empty<OffsetChangeMapEntry>.Array, true);

        private bool isFrozen;

        /// <summary>
        ///     Creates a new OffsetChangeMap instance.
        /// </summary>
        public OffsetChangeMap()
        {
        }

        internal OffsetChangeMap(int capacity)
            : base(new List<OffsetChangeMapEntry>(capacity))
        {
        }

        private OffsetChangeMap(IList<OffsetChangeMapEntry> entries, bool isFrozen)
            : base(entries)
        {
            this.isFrozen = isFrozen;
        }

        /// <summary>
        ///     Gets if this instance is frozen. Frozen instances are immutable and thus thread-safe.
        /// </summary>
        public bool IsFrozen
        {
            get { return isFrozen; }
        }

        /// <summary>
        ///     Creates a new OffsetChangeMap with a single element.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <returns>Returns a frozen OffsetChangeMap with a single entry.</returns>
        public static OffsetChangeMap FromSingleElement(OffsetChangeMapEntry entry)
        {
            return new OffsetChangeMap(new[] {entry}, true);
        }

        /// <summary>
        ///     Gets the new offset where the specified offset moves after this document change.
        /// </summary>
        public int GetNewOffset(int offset, AnchorMovementType movementType)
        {
            IList<OffsetChangeMapEntry> items = Items;
            int count = items.Count;
            for (int i = 0; i < count; i++) {
                offset = items[i].GetNewOffset(offset, movementType);
            }
            return offset;
        }

        /// <summary>
        ///     Gets whether this OffsetChangeMap is a valid explanation for the specified document change.
        /// </summary>
        public bool IsValidForDocumentChange(int offset, int removalLength, int insertionLength)
        {
            int endOffset = offset + removalLength;
            foreach (OffsetChangeMapEntry entry in this) {
                // check that ChangeMapEntry is in valid range for this document change
                if (entry.Offset < offset || entry.Offset + entry.RemovalLength > endOffset) {
                    return false;
                }
                endOffset += entry.InsertionLength - entry.RemovalLength;
            }
            // check that the total delta matches
            return endOffset == offset + insertionLength;
        }

        /// <summary>
        ///     Calculates the inverted OffsetChangeMap (used for the undo operation).
        /// </summary>
        public OffsetChangeMap Invert()
        {
            if (this == Empty) {
                return this;
            }
            var newMap = new OffsetChangeMap(Count);
            for (int i = Count - 1; i >= 0; i--) {
                OffsetChangeMapEntry entry = this[i];
                // swap InsertionLength and RemovalLength
                newMap.Add(new OffsetChangeMapEntry(entry.Offset, entry.InsertionLength, entry.RemovalLength));
            }
            return newMap;
        }

        /// <inheritdoc />
        protected override void ClearItems()
        {
            CheckFrozen();
            base.ClearItems();
        }

        /// <inheritdoc />
        protected override void InsertItem(int index, OffsetChangeMapEntry item)
        {
            CheckFrozen();
            base.InsertItem(index, item);
        }

        /// <inheritdoc />
        protected override void RemoveItem(int index)
        {
            CheckFrozen();
            base.RemoveItem(index);
        }

        /// <inheritdoc />
        protected override void SetItem(int index, OffsetChangeMapEntry item)
        {
            CheckFrozen();
            base.SetItem(index, item);
        }

        private void CheckFrozen()
        {
            if (isFrozen) {
                throw new InvalidOperationException("This instance is frozen and cannot be modified.");
            }
        }

        /// <summary>
        ///     Freezes this instance.
        /// </summary>
        public void Freeze()
        {
            isFrozen = true;
        }
    }

    /// <summary>
    ///     An entry in the OffsetChangeMap.
    ///     This represents the offset of a document change (either insertion or removal, not both at once).
    /// </summary>
    [Serializable]
    public struct OffsetChangeMapEntry : IEquatable<OffsetChangeMapEntry>
    {
        // MSB: DefaultAnchorMovementIsBeforeInsertion
        private readonly uint insertionLengthWithMovementFlag;
        private readonly int offset;

        // MSB: RemovalNeverCausesAnchorDeletion; other 31 bits: RemovalLength
        private readonly uint removalLengthWithDeletionFlag;

        /// <summary>
        ///     Creates a new OffsetChangeMapEntry instance.
        /// </summary>
        public OffsetChangeMapEntry(int offset, int removalLength, int insertionLength)
        {
            ThrowUtil.CheckNotNegative(offset, "offset");
            ThrowUtil.CheckNotNegative(removalLength, "removalLength");
            ThrowUtil.CheckNotNegative(insertionLength, "insertionLength");

            this.offset = offset;
            removalLengthWithDeletionFlag = (uint) removalLength;
            insertionLengthWithMovementFlag = (uint) insertionLength;
        }

        /// <summary>
        ///     Creates a new OffsetChangeMapEntry instance.
        /// </summary>
        public OffsetChangeMapEntry(int offset, int removalLength, int insertionLength,
            bool removalNeverCausesAnchorDeletion, bool defaultAnchorMovementIsBeforeInsertion)
            : this(offset, removalLength, insertionLength)
        {
            if (removalNeverCausesAnchorDeletion) {
                removalLengthWithDeletionFlag |= 0x80000000;
            }
            if (defaultAnchorMovementIsBeforeInsertion) {
                insertionLengthWithMovementFlag |= 0x80000000;
            }
        }

        /// <summary>
        ///     The offset at which the change occurs.
        /// </summary>
        public int Offset
        {
            get { return offset; }
        }

        /// <summary>
        ///     The number of characters inserted.
        ///     Returns 0 if this entry represents a removal.
        /// </summary>
        public int InsertionLength
        {
            get { return (int) (insertionLengthWithMovementFlag & 0x7fffffff); }
        }

        /// <summary>
        ///     The number of characters removed.
        ///     Returns 0 if this entry represents an insertion.
        /// </summary>
        public int RemovalLength
        {
            get { return (int) (removalLengthWithDeletionFlag & 0x7fffffff); }
        }

        /// <summary>
        ///     Gets whether the removal should not cause any anchor deletions.
        /// </summary>
        public bool RemovalNeverCausesAnchorDeletion
        {
            get { return (removalLengthWithDeletionFlag & 0x80000000) != 0; }
        }

        /// <summary>
        ///     Gets whether default anchor movement causes the anchor to stay in front of the caret.
        /// </summary>
        public bool DefaultAnchorMovementIsBeforeInsertion
        {
            get { return (insertionLengthWithMovementFlag & 0x80000000) != 0; }
        }

        #region IEquatable<OffsetChangeMapEntry> Members

        /// <inheritdoc />
        public bool Equals(OffsetChangeMapEntry other)
        {
            return offset == other.offset && insertionLengthWithMovementFlag == other.insertionLengthWithMovementFlag &&
                   removalLengthWithDeletionFlag == other.removalLengthWithDeletionFlag;
        }

        #endregion

        /// <summary>
        ///     Gets the new offset where the specified offset moves after this document change.
        /// </summary>
        public int GetNewOffset(int oldOffset, AnchorMovementType movementType)
        {
            int insertionLength = InsertionLength;
            int removalLength = RemovalLength;
            if (!(removalLength == 0 && oldOffset == offset)) {
                // we're getting trouble (both if statements in here would apply)
                // if there's no removal and we insert at the offset
                // -> we'd need to disambiguate by movementType, which is handled after the if

                // offset is before start of change: no movement
                if (oldOffset <= offset) {
                    return oldOffset;
                }
                // offset is after end of change: movement by normal delta
                if (oldOffset >= offset + removalLength) {
                    return oldOffset + insertionLength - removalLength;
                }
            }
            // we reach this point if
            // a) the oldOffset is inside the deleted segment
            // b) there was no removal and we insert at the caret position
            if (movementType == AnchorMovementType.AfterInsertion) {
                return offset + insertionLength;
            }
            if (movementType == AnchorMovementType.BeforeInsertion) {
                return offset;
            }
            return DefaultAnchorMovementIsBeforeInsertion ? offset : offset + insertionLength;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked {
                return offset + 3559*(int) insertionLengthWithMovementFlag + 3571*(int) removalLengthWithDeletionFlag;
            }
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is OffsetChangeMapEntry && Equals((OffsetChangeMapEntry) obj);
        }

        /// <summary>
        ///     Tests the two entries for equality.
        /// </summary>
        public static bool operator ==(OffsetChangeMapEntry left, OffsetChangeMapEntry right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Tests the two entries for inequality.
        /// </summary>
        public static bool operator !=(OffsetChangeMapEntry left, OffsetChangeMapEntry right)
        {
            return !left.Equals(right);
        }
    }
}