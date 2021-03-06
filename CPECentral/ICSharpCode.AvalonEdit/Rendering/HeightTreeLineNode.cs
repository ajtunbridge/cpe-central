﻿#region Using directives

using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace ICSharpCode.AvalonEdit.Rendering
{
    internal struct HeightTreeLineNode
    {
        internal List<CollapsedLineSection> collapsedSections;
        internal double height;

        internal HeightTreeLineNode(double height)
        {
            collapsedSections = null;
            this.height = height;
        }

        internal bool IsDirectlyCollapsed
        {
            get { return collapsedSections != null; }
        }

        /// <summary>
        ///     Returns 0 if the line is directly collapsed, otherwise, returns <see cref="height" />.
        /// </summary>
        internal double TotalHeight
        {
            get { return IsDirectlyCollapsed ? 0 : height; }
        }

        internal void AddDirectlyCollapsed(CollapsedLineSection section)
        {
            if (collapsedSections == null) {
                collapsedSections = new List<CollapsedLineSection>();
            }
            collapsedSections.Add(section);
        }

        internal void RemoveDirectlyCollapsed(CollapsedLineSection section)
        {
            Debug.Assert(collapsedSections.Contains(section));
            collapsedSections.Remove(section);
            if (collapsedSections.Count == 0) {
                collapsedSections = null;
            }
        }
    }
}