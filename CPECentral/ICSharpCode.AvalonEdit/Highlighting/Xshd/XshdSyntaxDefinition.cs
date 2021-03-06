﻿#region Using directives

using System;
using System.Collections.Generic;
using ICSharpCode.AvalonEdit.Utils;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting.Xshd
{
    /// <summary>
    ///     A &lt;SyntaxDefinition&gt; element.
    /// </summary>
    [Serializable]
    public class XshdSyntaxDefinition
    {
        /// <summary>
        ///     Creates a new XshdSyntaxDefinition object.
        /// </summary>
        public XshdSyntaxDefinition()
        {
            Elements = new NullSafeCollection<XshdElement>();
            Extensions = new NullSafeCollection<string>();
        }

        /// <summary>
        ///     Gets/sets the definition name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets the associated extensions.
        /// </summary>
        public IList<string> Extensions { get; private set; }

        /// <summary>
        ///     Gets the collection of elements.
        /// </summary>
        public IList<XshdElement> Elements { get; private set; }

        /// <summary>
        ///     Applies the visitor to all elements.
        /// </summary>
        public void AcceptElements(IXshdVisitor visitor)
        {
            foreach (XshdElement element in Elements) {
                element.AcceptVisitor(visitor);
            }
        }
    }
}