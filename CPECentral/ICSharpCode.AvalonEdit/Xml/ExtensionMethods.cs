#region Using directives

using System;
using System.Collections.Generic;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    internal static class ExtensionMethods
    {
        // Copied from ICSharpCode.SharpDevelop.Dom.ExtensionMethods
        /// <summary>
        ///     Converts a recursive data structure into a flat list.
        /// </summary>
        /// <param name="input">The root elements of the recursive data structure.</param>
        /// <param name="recursion">The function that gets the children of an element.</param>
        /// <returns>Iterator that enumerates the tree structure in preorder.</returns>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> input, Func<T, IEnumerable<T>> recursion)
        {
            var stack = new Stack<IEnumerator<T>>();
            try {
                stack.Push(input.GetEnumerator());
                while (stack.Count > 0) {
                    while (stack.Peek().MoveNext()) {
                        T element = stack.Peek().Current;
                        yield return element;
                        IEnumerable<T> children = recursion(element);
                        if (children != null) {
                            stack.Push(children.GetEnumerator());
                        }
                    }
                    stack.Pop().Dispose();
                }
            }
            finally {
                while (stack.Count > 0) {
                    stack.Pop().Dispose();
                }
            }
        }
    }
}