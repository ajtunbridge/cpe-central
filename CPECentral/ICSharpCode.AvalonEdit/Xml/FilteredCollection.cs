#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Collection that presents only some items from the wrapped collection.
    ///     It implicitely filters object that are not of type T (or derived).
    /// </summary>
    public class FilteredCollection<T, TCollection> : ObservableCollection<T>
        where TCollection : INotifyCollectionChanged, IList
    {
        private readonly Predicate<object> condition;
        private readonly TCollection source;
        private readonly List<int> srcPtrs = new List<int>(); // Index to the original collection

        /// <summary> Create unbound collection </summary>
        protected FilteredCollection()
        {
        }

        /// <summary> Wrap the given collection.  Items of type other then T are filtered </summary>
        public FilteredCollection(TCollection source) : this(source, x => true)
        {
        }

        /// <summary>
        ///     Wrap the given collection.  Items of type other then T are filtered.  Items not matching the condition are
        ///     filtered.
        /// </summary>
        public FilteredCollection(TCollection source, Predicate<object> condition)
        {
            this.source = source;
            this.condition = condition;

            this.source.CollectionChanged += SourceCollectionChanged;

            Reset();
        }

        private void Reset()
        {
            Clear();
            srcPtrs.Clear();
            for (int i = 0; i < source.Count; i++) {
                if (source[i] is T && condition(source[i])) {
                    Add((T) source[i]);
                    srcPtrs.Add(i);
                }
            }
        }

        private void SourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action) {
                case NotifyCollectionChangedAction.Add:
                    // Update pointers
                    for (int i = 0; i < srcPtrs.Count; i++) {
                        if (srcPtrs[i] >= e.NewStartingIndex) {
                            srcPtrs[i] += e.NewItems.Count;
                        }
                    }
                    // Find where to add items
                    int addIndex = srcPtrs.FindIndex(srcPtr => srcPtr >= e.NewStartingIndex);
                    if (addIndex == -1) {
                        addIndex = Count;
                    }
                    // Add items to collection
                    for (int i = 0; i < e.NewItems.Count; i++) {
                        if (e.NewItems[i] is T && condition(e.NewItems[i])) {
                            InsertItem(addIndex, (T) e.NewItems[i]);
                            srcPtrs.Insert(addIndex, e.NewStartingIndex + i);
                            addIndex++;
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    // Remove the item from our collection
                    for (int i = 0; i < e.OldItems.Count; i++) {
                        // Anyone points to the removed item?
                        int removeIndex = srcPtrs.IndexOf(e.OldStartingIndex + i);
                        // Remove
                        if (removeIndex != -1) {
                            RemoveAt(removeIndex);
                            srcPtrs.RemoveAt(removeIndex);
                        }
                    }
                    // Update pointers
                    for (int i = 0; i < srcPtrs.Count; i++) {
                        if (srcPtrs[i] >= e.OldStartingIndex) {
                            srcPtrs[i] -= e.OldItems.Count;
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Reset();
                    break;
                default:
                    throw new NotSupportedException(e.Action.ToString());
            }
        }
    }
}