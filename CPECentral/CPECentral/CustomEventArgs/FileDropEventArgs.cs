using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.CustomEventArgs
{
    public class FileDropEventArgs : EventArgs
    {
        public IEnumerable<string> DroppedFiles { get; private set; }

        public FileDropEventArgs(IEnumerable<string> droppedFiles)
        {
            DroppedFiles = droppedFiles;
        }
    }
}
