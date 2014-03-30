﻿#region Using directives

using System;

#endregion

namespace ICSharpCode.AvalonEdit.Highlighting.Xshd
{
    /// <summary>
    ///     A property in an Xshd file.
    /// </summary>
    [Serializable]
    public class XshdProperty : XshdElement
    {
        /// <summary>
        ///     Gets/sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets/sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <inheritdoc />
        public override object AcceptVisitor(IXshdVisitor visitor)
        {
            return null;
//			return visitor.VisitProperty(this);
        }
    }
}