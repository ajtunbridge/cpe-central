using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.ViewModels
{
    public class PartLibraryView3Model
    {
        public string DrawingNumber { get; set; }

        public string CurrentVersion { get; set; }

        public string Name { get; set; }

        public string PathToDrawingFile { get; set; }

        public Part Part { get; set; }
    }
}