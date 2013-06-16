#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using nGenLibrary.IO;

#endregion

namespace CPECentral
{
    /// <summary>
    ///     Use for storing notes pertaining to different entities
    /// </summary>
    [Serializable]
    public class Note
    {
        private readonly DateTime _createdOn;

        public Note()
        {
            _createdOn = DateTime.Now;
        }

        /// <summary>
        ///     The actual note text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     The ID of the employee who created this note
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        ///     The date and time this note was created on
        /// </summary>
        public DateTime CreatedOn
        {
            get { return _createdOn; }
        }
    }

    /// <summary>
    ///     Use for sorting <see cref="Note" /> objects in date descending order
    /// </summary>
    [Serializable]
    public class NoteComparer : IComparer<Note>
    {
        #region IComparer<Note> Members

        public int Compare(Note x, Note y)
        {
            return y.CreatedOn.CompareTo(x.CreatedOn);
        }

        #endregion
    }

    /// <summary>
    ///     A collection of <see cref="Note" /> objects which are
    ///     automatically sorted by date in descending order
    /// </summary>
    [Serializable]
    public class NoteSet : IEnumerable<Note>
    {
        private readonly SortedSet<Note> _notes;

        public NoteSet()
        {
            _notes = new SortedSet<Note>(new NoteComparer());
        }

        /// <summary>
        ///     Returns the total number of notes in the collection
        /// </summary>
        public int Count
        {
            get { return _notes.Count; }
        }

        #region IEnumerable<Note> Members

        public IEnumerator<Note> GetEnumerator()
        {
            return _notes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        /// <summary>
        ///     Adds the supplied <see cref="Note" /> instance to the collection
        /// </summary>
        /// <param name="note">
        ///     The <see cref="Note" /> to add
        /// </param>
        public void Add(Note note)
        {
            _notes.Add(note);
        }

        /// <summary>
        ///     Removes the specified <see cref="Note" /> instance from the collection
        /// </summary>
        /// <param name="note">
        ///     The <see cref="Note" /> to remove
        /// </param>
        public void Remove(Note note)
        {
            _notes.Remove(note);
        }

        /// <summary>
        ///     Serializes this <see cref="NoteSet" /> to a byte array
        /// </summary>
        /// <returns></returns>
        public byte[] Serialize()
        {
            return Serialization<NoteSet>.Serialize(this);
        }

        /// <summary>
        ///     Deserializes the supplied byte array into a <see cref="NoteSet" />
        /// </summary>
        /// <param name="serializedNotes">
        ///     The byte array of a serialized <see cref="NoteSet" />
        /// </param>
        /// <returns></returns>
        public static NoteSet Deserialize(byte[] serializedNotes)
        {
            return Serialization<NoteSet>.Deserialize(serializedNotes);
        }
    }
}