#region Using directives

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Two collections in sequence
    /// </summary>
    public class MergedCollection<T, TCollection> : ObservableCollection<T>
        where TCollection : INotifyCollectionChanged, IList<T>
    {
        private readonly TCollection a;
        private readonly TCollection b;

        /// <summary> Create a wrapper containing elements of 'a' and then 'b' </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        public MergedCollection(TCollection a, TCollection b)
        {
            this.a = a;
            this.b = b;

            this.a.CollectionChanged += SourceCollectionAChanged;
            this.b.CollectionChanged += SourceCollectionBChanged;

            Reset();
        }

        private void Reset()
        {
            Clear();
            foreach (T item in a) {
                Add(item);
            }
            foreach (T item in b) {
                Add(item);
            }
        }

        private void SourceCollectionAChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SourceCollectionChanged(0, e);
        }

        private void SourceCollectionBChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SourceCollectionChanged(a.Count, e);
        }

        private void SourceCollectionChanged(int collectionStart, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action) {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++) {
                        InsertItem(collectionStart + e.NewStartingIndex + i, (T) e.NewItems[i]);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++) {
                        RemoveAt(collectionStart + e.OldStartingIndex);
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