﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.ViewModels
{
    public class StartPageFindToolBoxViewModel
    {
        public List<StartPageFindToolBoxViewModelItem> Results { get; set; }
    }

    public class StartPageFindToolBoxViewModelItem
    {
        public string DrawingNumber { get; set; }

        public string Location { get; set; }

        public override string ToString()
        {
            return DrawingNumber;
        }
    }
}
