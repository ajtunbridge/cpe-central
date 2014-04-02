using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryNameGenerator.Modules
{
    public class IModuleEventArgs : EventArgs
    {
        public IModuleEventArgs(IModule module)
        {
            Module = module;
        }

        public IModule Module { get; private set; }
    }
}