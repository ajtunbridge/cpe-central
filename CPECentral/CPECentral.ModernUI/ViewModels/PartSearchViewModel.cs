#region Using directives

using System;
using System.Collections.Generic;

#endregion

namespace CPECentral.ModernUI.ViewModels
{
    public class PartSearchViewModel
    {
        public PartSearchViewModel()
        {
            SearchResults = new List<SearchResult>();
        }

        public List<SearchResult> SearchResults { get; private set; }

        public class SearchResult : IEquatable<SearchResult>
        {
            public int PartId { get; set; }
            public string DrawingNumber { get; set; }
            public string Version { get; set; }
            public string Name { get; set; }
            public byte[] ImageBytes { get; set; }

            public bool Equals(SearchResult other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return PartId == other.PartId;
            }

            public override int GetHashCode()
            {
                return PartId;
            }

            public static bool operator ==(SearchResult left, SearchResult right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(SearchResult left, SearchResult right)
            {
                return !Equals(left, right);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((SearchResult) obj);
            }
        }
    }
}