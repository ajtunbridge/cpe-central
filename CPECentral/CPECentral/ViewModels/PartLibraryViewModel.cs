#region Using directives

using System.Drawing;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.ViewModels
{
    public class PartLibraryViewModel
    {
        public string Group { get; set; }

        public string DrawingNumber { get; set; }

        public string CurrentVersion { get; set; }

        public string Name { get; set; }

        public string PathToDrawingFile { get; set; }

        public Image CurrentVersionPhoto { get; set; }

        public Part Part { get; set; }
    }
}