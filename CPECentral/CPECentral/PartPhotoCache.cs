#region Using directives

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral
{
    public class PartPhotoCache
    {
        private static readonly List<CacheItem> ImageCache = new List<CacheItem>();

        public Image this[int partId]
        {
            get
            {
                CacheItem cacheItem = ImageCache.SingleOrDefault(item => item.PartId == partId);
                return cacheItem == null ? null : cacheItem.Image;
            }
        }

        public Image this[Part part]
        {
            get { return this[part.Id]; }
        }

        public void CreateOrUpdate(int partId, Image image)
        {
            CacheItem cacheItem = ImageCache.SingleOrDefault(item => item.PartId == partId);

            if (cacheItem == null) {
                cacheItem = new CacheItem {PartId = partId, Image = image};
                ImageCache.Add(cacheItem);
            }
            else {
                cacheItem.Image = image;
            }
        }

        #region Nested type: CacheItem

        public class CacheItem
        {
            public int PartId { get; set; }

            public Image Image { get; set; }
        }

        #endregion
    }
}