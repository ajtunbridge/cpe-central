#region Using directives

using System;

#endregion

namespace ICSharpCode.AvalonEdit.Xml
{
    /// <summary> Holds event args for event caused by <see cref="AXmlObject" /> </summary>
    public class AXmlObjectEventArgs : EventArgs
    {
        /// <summary> The object that caused the event </summary>
        public AXmlObject Object { get; set; }
    }
}