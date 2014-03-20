#region Using directives

using System;
using System.Collections.Generic;

#endregion

namespace CPECentral.CustomEventArgs
{
    public class FileDropEventArgs : EventArgs
    {
        public FileDropEventArgs(IEnumerable<string> droppedFiles)
        {
            DroppedFiles = droppedFiles;
        }

        public IEnumerable<string> DroppedFiles { get; private set; }
    }
}