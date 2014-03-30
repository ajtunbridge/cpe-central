﻿#region Using directives

using System;

#endregion

namespace ICSharpCode.AvalonEdit.Snippets
{
    /// <summary>
    ///     Provides information about the event that occured during use of snippets.
    /// </summary>
    public class SnippetEventArgs : EventArgs
    {
        /// <summary>
        ///     Creates a new SnippetEventArgs object, with a DeactivateReason.
        /// </summary>
        public SnippetEventArgs(DeactivateReason reason)
        {
            Reason = reason;
        }

        /// <summary>
        ///     Gets the reason for deactivation.
        /// </summary>
        public DeactivateReason Reason { get; private set; }
    }

    /// <summary>
    ///     Describes the reason for deactivation of a <see cref="SnippetElement" />.
    /// </summary>
    public enum DeactivateReason
    {
        /// <summary>
        ///     Unknown reason.
        /// </summary>
        Unknown,

        /// <summary>
        ///     Snippet was deleted.
        /// </summary>
        Deleted,

        /// <summary>
        ///     There are no active elements in the snippet.
        /// </summary>
        NoActiveElements,

        /// <summary>
        ///     The SnippetInputHandler was detached.
        /// </summary>
        InputHandlerDetached,

        /// <summary>
        ///     Return was pressed by the user.
        /// </summary>
        ReturnPressed,

        /// <summary>
        ///     Escape was pressed by the user.
        /// </summary>
        EscapePressed
    }
}