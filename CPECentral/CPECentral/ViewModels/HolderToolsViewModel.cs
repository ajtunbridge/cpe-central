#region Using directives

using System.Collections.Generic;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.ViewModels
{
    public class HolderToolsViewModel
    {
        public List<HolderToolsViewModelItem> Items { get; set; }

        #region Nested type: HolderToolsViewModelItem

        public class HolderToolsViewModelItem
        {
            public string Description { get; set; }

            public HolderTool HolderTool { get; set; }
        }

        #endregion
    }
}