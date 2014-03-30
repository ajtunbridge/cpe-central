#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Cyotek.Windows.Forms
{
    //[TypeConverter(typeof(ZoomLevelCollectionConverter))]
    public class ZoomLevelCollection : IList<int>
    {
        #region Constructors

        public ZoomLevelCollection()
        {
            List = new SortedList<int, int>();
        }

        public ZoomLevelCollection(IEnumerable<int> collection)
            : this()
        {
            if (collection == null) {
                throw new ArgumentNullException("collection");
            }

            AddRange(collection);
        }

        #endregion

        #region Class Properties

        public static ZoomLevelCollection Default
        {
            get
            {
                return
                    new ZoomLevelCollection(new[]
                    {7, 10, 15, 20, 25, 30, 50, 70, 100, 150, 200, 300, 400, 500, 600, 700, 800, 1200, 1600});
            }
        }

        #endregion

        #region Properties

        protected SortedList<int, int> List { get; set; }

        public int Count
        {
            get { return List.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int this[int index]
        {
            get { return List.Values[index]; }
            set
            {
                List.RemoveAt(index);
                Add(value);
            }
        }

        #endregion

        #region Members

        public void Add(int item)
        {
            List.Add(item, item);
        }

        public void Clear()
        {
            List.Clear();
        }

        public bool Contains(int item)
        {
            return List.ContainsKey(item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            if (Count != 0) {
                Array.Copy(List.Values.ToArray(), 0, array, arrayIndex, Count);
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return List.Values.GetEnumerator();
        }

        public int IndexOf(int item)
        {
            return List.IndexOfKey(item);
        }

        public void Insert(int index, int item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int item)
        {
            return List.Remove(item);
        }

        public void RemoveAt(int index)
        {
            List.RemoveAt(index);
        }

        public void AddRange(IEnumerable<int> collection)
        {
            if (collection == null) {
                throw new ArgumentNullException("collection");
            }

            foreach (int value in collection) {
                Add(value);
            }
        }

        public int FindNearest(int zoomLevel)
        {
            return this.OrderBy(v => Math.Abs(v - zoomLevel)).First();
        }

        public int NextZoom(int zoomLevel)
        {
            int index;

            index = IndexOf(FindNearest(zoomLevel));
            if (index < Count - 1) {
                index++;
            }

            return this[index];
        }

        public int PreviousZoom(int zoomLevel)
        {
            int index;

            index = IndexOf(FindNearest(zoomLevel));
            if (index > 0) {
                index--;
            }

            return this[index];
        }

        public int[] ToArray()
        {
            int[] results;

            results = new int[Count];
            CopyTo(results, 0);

            return results;
        }

        #endregion

        #region IList<int> Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}