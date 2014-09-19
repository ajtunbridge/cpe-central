#region Using directives

using System.Collections.Generic;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.ViewModels
{
    public class PartLibraryView2SearchModel
    {
        public List<Part> DrawingNumberMatches { get; set; }

        public List<Part> DrawingNumberFuzzyMatches { get; set; }

        public List<Part> NameMatches { get; set; }

        public List<Part> NameFuzzyMatches { get; set; }
    }
}