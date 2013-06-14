#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Tricorn
{
    public class TricornDataProvider : IDisposable
    {
        private readonly TricornEntities _entities = new TricornEntities();

        #region IDisposable Members

        public void Dispose()
        {
            _entities.Dispose();
        }

        #endregion

        public IEnumerable<WOrder> GetWorksOrders(string userReference)
        {
            return _entities.WOrders.Where(wo => wo.User_Reference == userReference);
        }

        public IEnumerable<Material> GetMaterials()
        {
            return _entities.Materials.ToList();
        }
    }
}