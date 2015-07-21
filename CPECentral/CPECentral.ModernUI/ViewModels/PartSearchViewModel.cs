using System.Collections.Generic;
using System.Windows.Documents;

namespace CPECentral.ModernUI.ViewModels
{
    public class PartSearchViewModel
    {
        public PartSearchViewModel()
        {
            SearchResults = new List<SearchResult>();
        }

        public List<SearchResult> SearchResults { get; private set; }

        public class SearchResult
        {
            public int PartId { get; set; }

            public string DrawingNumber { get; set; }

            public string Version { get; set; }

            public string Name { get; set; }

            public byte[] ImageBytes { get; set; }
        }
    }
}