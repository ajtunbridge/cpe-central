#region Using directives

using System;
using System.Collections.Generic;

#endregion

namespace ICSharpCode.AvalonEdit.Utils
{
    /// <summary>
    ///     Maintains a list of delayed events to raise.
    /// </summary>
    internal sealed class DelayedEvents
    {
        private readonly Queue<EventCall> eventCalls = new Queue<EventCall>();

        public void DelayedRaise(EventHandler handler, object sender, EventArgs e)
        {
            if (handler != null) {
                eventCalls.Enqueue(new EventCall(handler, sender, e));
            }
        }

        public void RaiseEvents()
        {
            while (eventCalls.Count > 0) {
                eventCalls.Dequeue().Call();
            }
        }

        #region Nested type: EventCall

        private struct EventCall
        {
            private readonly EventArgs e;
            private readonly EventHandler handler;
            private readonly object sender;

            public EventCall(EventHandler handler, object sender, EventArgs e)
            {
                this.handler = handler;
                this.sender = sender;
                this.e = e;
            }

            public void Call()
            {
                handler(sender, e);
            }
        }

        #endregion
    }
}