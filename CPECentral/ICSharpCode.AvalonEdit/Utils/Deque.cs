﻿#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace ICSharpCode.AvalonEdit.Utils
{
    /// <summary>
    ///     Double-ended queue.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [Serializable]
    public sealed class Deque<T> : ICollection<T>
    {
        private T[] arr = Empty<T>.Array;
        private int head;
        private int size;
        private int tail;

        /// <summary>
        ///     Gets/Sets an element inside the deque.
        /// </summary>
        public T this[int index]
        {
            get
            {
                ThrowUtil.CheckInRangeInclusive(index, "index", 0, size - 1);
                return arr[(head + index)%arr.Length];
            }
            set
            {
                ThrowUtil.CheckInRangeInclusive(index, "index", 0, size - 1);
                arr[(head + index)%arr.Length] = value;
            }
        }

        #region ICollection<T> Members

        /// <inheritdoc />
        public int Count
        {
            get { return size; }
        }

        /// <inheritdoc />
        public void Clear()
        {
            arr = Empty<T>.Array;
            size = 0;
            head = 0;
            tail = 0;
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            if (head < tail) {
                for (int i = head; i < tail; i++) {
                    yield return arr[i];
                }
            }
            else {
                for (int i = head; i < arr.Length; i++) {
                    yield return arr[i];
                }
                for (int i = 0; i < tail; i++) {
                    yield return arr[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        void ICollection<T>.Add(T item)
        {
            PushBack(item);
        }

        /// <inheritdoc />
        public bool Contains(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            foreach (T element in this) {
                if (comparer.Equals(item, element)) {
                    return true;
                }
            }
            return false;
        }

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) {
                throw new ArgumentNullException("array");
            }
            if (head < tail) {
                Array.Copy(arr, head, array, arrayIndex, tail - head);
            }
            else {
                int num1 = arr.Length - head;
                Array.Copy(arr, head, array, arrayIndex, num1);
                Array.Copy(arr, 0, array, arrayIndex + num1, tail);
            }
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotSupportedException();
        }

        #endregion

        /// <summary>
        ///     Adds an element to the end of the deque.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "PushBack")]
        public void PushBack(T item)
        {
            if (size == arr.Length) {
                SetCapacity(Math.Max(4, arr.Length*2));
            }
            arr[tail++] = item;
            if (tail == arr.Length) {
                tail = 0;
            }
            size++;
        }

        /// <summary>
        ///     Pops an element from the end of the deque.
        /// </summary>
        public T PopBack()
        {
            if (size == 0) {
                throw new InvalidOperationException();
            }
            if (tail == 0) {
                tail = arr.Length - 1;
            }
            else {
                tail--;
            }
            T val = arr[tail];
            arr[tail] = default(T); // allow GC to collect the element
            size--;
            return val;
        }

        /// <summary>
        ///     Adds an element to the front of the deque.
        /// </summary>
        public void PushFront(T item)
        {
            if (size == arr.Length) {
                SetCapacity(Math.Max(4, arr.Length*2));
            }
            if (head == 0) {
                head = arr.Length - 1;
            }
            else {
                head--;
            }
            arr[head] = item;
            size++;
        }

        /// <summary>
        ///     Pops an element from the end of the deque.
        /// </summary>
        public T PopFront()
        {
            if (size == 0) {
                throw new InvalidOperationException();
            }
            T val = arr[head];
            arr[head] = default(T); // allow GC to collect the element
            head++;
            if (head == arr.Length) {
                head = 0;
            }
            size--;
            return val;
        }

        private void SetCapacity(int capacity)
        {
            var newArr = new T[capacity];
            CopyTo(newArr, 0);
            head = 0;
            tail = (size == capacity) ? 0 : size;
            arr = newArr;
        }
    }
}