using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.ViewModels
{
    public class ToolLibraryViewModel
    {
        public IEnumerable<ToolGroup> ToolGroups;
        public IEnumerable<Tool> Tools;
    }
}
