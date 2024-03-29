﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary>
    ///     Specailized attribute collection with attribute name caching
    /// </summary>
    public class AXmlAttributeCollection : FilteredCollection<AXmlAttribute, AXmlObjectCollection<AXmlObject>>
    {
        /// <summary> Empty unbound collection </summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "InsertItem prevents modifying the Empty collection")] public static readonly
            AXmlAttributeCollection Empty = new AXmlAttributeCollection();

        private static readonly List<AXmlAttribute> NoAttributes = new List<AXmlAttribute>();

        private readonly Dictionary<string, List<AXmlAttribute>> hashtable =
            new Dictionary<string, List<AXmlAttribute>>();

        /// <summary> Create unbound collection </summary>
        protected AXmlAttributeCollection()
        {
        }

        /// <summary> Wrap the given collection.  Non-attributes are filtered </summary>
        public AXmlAttributeCollection(AXmlObjectCollection<AXmlObject> source) : base(source)
        {
        }

        /// <summary> Wrap the given collection.  Non-attributes are filtered.  Items not matching the condition are filtered. </summary>
        public AXmlAttributeCollection(AXmlObjectCollection<AXmlObject> source, Predicate<object> condition)
            : base(source, condition)
        {
        }

        private void AddToHashtable(AXmlAttribute attr)
        {
            string localName = attr.LocalName;
            if (!hashtable.ContainsKey(localName)) {
                hashtable[localName] = new List<AXmlAttribute>(1);
            }
            hashtable[localName].Add(attr);
        }

        private void RemoveFromHashtable(AXmlAttribute attr)
        {
            string localName = attr.LocalName;
            hashtable[localName].Remove(attr);
        }

        /// <summary>
        ///     Get all attributes with given local name.
        ///     Hash table is used for lookup so this is cheap.
        /// </summary>
        public IEnumerable<AXmlAttribute> GetByLocalName(string localName)
        {
            if (hashtable.ContainsKey(localName)) {
                return hashtable[localName];
            }
            return NoAttributes;
        }

        /// <inheritdoc />
        protected override void ClearItems()
        {
            foreach (AXmlAttribute item in this) {
                RemoveFromHashtable(item);
                item.Changing -= item_Changing;
                item.Changed -= item_Changed;
            }
            base.ClearItems();
        }

        /// <inheritdoc />
        protected override void InsertItem(int index, AXmlAttribute item)
        {
            // prevent insertions into the static 'Empty' instance
            if (this == Empty) {
                throw new NotSupportedException("Cannot insert into AXmlAttributeCollection.Empty");
            }

            AddToHashtable(item);
            item.Changing += item_Changing;
            item.Changed += item_Changed;
            base.InsertItem(index, item);
        }

        /// <inheritdoc />
        protected override void RemoveItem(int index)
        {
            RemoveFromHashtable(this[index]);
            this[index].Changing -= item_Changing;
            this[index].Changed -= item_Changed;
            base.RemoveItem(index);
        }

        /// <inheritdoc />
        protected override void SetItem(int index, AXmlAttribute item)
        {
            RemoveFromHashtable(this[index]);
            this[index].Changing -= item_Changing;
            this[index].Changed -= item_Changed;

            AddToHashtable(item);
            item.Changing += item_Changing;
            item.Changed += item_Changed;
            base.SetItem(index, item);
        }

        // Every item in the collection should be registered to these handlers
        // so that we can handle renames

        private void item_Changing(object sender, AXmlObjectEventArgs e)
        {
            RemoveFromHashtable((AXmlAttribute) e.Object);
        }

        private void item_Changed(object sender, AXmlObjectEventArgs e)
        {
            AddToHashtable((AXmlAttribute) e.Object);
        }
    }
}