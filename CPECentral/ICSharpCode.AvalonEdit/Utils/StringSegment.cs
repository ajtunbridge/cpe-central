﻿#region Using directives

using System;

#endregion

namespace ICSharpCode.AvalonEdit.Utils
{
    /// <summary>
    ///     Represents a string with a segment.
    ///     Similar to System.ArraySegment&lt;T&gt;, but for strings instead of arrays.
    /// </summary>
    public struct StringSegment : IEquatable<StringSegment>
    {
        private readonly int count;
        private readonly int offset;
        private readonly string text;

        /// <summary>
        ///     Creates a new StringSegment.
        /// </summary>
        public StringSegment(string text, int offset, int count)
        {
            if (text == null) {
                throw new ArgumentNullException("text");
            }
            if (offset < 0 || offset > text.Length) {
                throw new ArgumentOutOfRangeException("offset");
            }
            if (offset + count > text.Length) {
                throw new ArgumentOutOfRangeException("count");
            }
            this.text = text;
            this.offset = offset;
            this.count = count;
        }

        /// <summary>
        ///     Creates a new StringSegment.
        /// </summary>
        public StringSegment(string text)
        {
            if (text == null) {
                throw new ArgumentNullException("text");
            }
            this.text = text;
            offset = 0;
            count = text.Length;
        }

        /// <summary>
        ///     Gets the string used for this segment.
        /// </summary>
        public string Text
        {
            get { return text; }
        }

        /// <summary>
        ///     Gets the start offset of the segment with the text.
        /// </summary>
        public int Offset
        {
            get { return offset; }
        }

        /// <summary>
        ///     Gets the length of the segment.
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        #region Equals and GetHashCode implementation

        /// <inheritdoc />
        public bool Equals(StringSegment other)
        {
            // add comparisions for all members here
            return ReferenceEquals(text, other.text) && offset == other.offset && count == other.count;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is StringSegment) {
                return Equals((StringSegment) obj); // use Equals method below
            }
            return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return text.GetHashCode() ^ offset ^ count;
        }

        /// <summary>
        ///     Equality operator.
        /// </summary>
        public static bool operator ==(StringSegment left, StringSegment right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Inequality operator.
        /// </summary>
        public static bool operator !=(StringSegment left, StringSegment right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}