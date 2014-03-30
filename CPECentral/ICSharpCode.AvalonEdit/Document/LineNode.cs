namespace ICSharpCode.AvalonEdit.Document
{
    #region Using directives

    using LineNode = DocumentLine;

    #endregion

    // A tree node in the document line tree.
    // For the purpose of the invariants, "children", "descendents", "siblings" etc. include the DocumentLine object,
    // it is treated as a third child node between left and right.

    // Originally, this was a separate class, with a reference to the documentLine. The documentLine had a reference
    // back to the node. To save memory, the same object is used for both the documentLine and the line node.
    // This saves 16 bytes per line (8 byte object overhead + two pointers).
//	sealed class LineNode
//	{
//		internal readonly DocumentLine documentLine;
    partial class DocumentLine
    {
        internal bool color;
        internal DocumentLine left;

        /// <summary>
        ///     The number of lines in this node and its child nodes.
        ///     Invariant:
        ///     nodeTotalCount = 1 + left.nodeTotalCount + right.nodeTotalCount
        /// </summary>
        internal int nodeTotalCount;

        /// <summary>
        ///     The total text length of this node and its child nodes.
        ///     Invariant:
        ///     nodeTotalLength = left.nodeTotalLength + documentLine.TotalLength + right.nodeTotalLength
        /// </summary>
        internal int nodeTotalLength;

        internal DocumentLine parent;
        internal DocumentLine right;

        internal LineNode LeftMost
        {
            get
            {
                LineNode node = this;
                while (node.left != null) {
                    node = node.left;
                }
                return node;
            }
        }

        internal LineNode RightMost
        {
            get
            {
                LineNode node = this;
                while (node.right != null) {
                    node = node.right;
                }
                return node;
            }
        }

        /// <summary>
        ///     Resets the line to enable its reuse after a document rebuild.
        /// </summary>
        internal void ResetLine()
        {
            totalLength = delimiterLength = 0;
            isDeleted = color = false;
            left = right = parent = null;
        }

        internal LineNode InitLineNode()
        {
            nodeTotalCount = 1;
            nodeTotalLength = TotalLength;
            return this;
        }
    }
}