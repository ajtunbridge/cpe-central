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

        public Customer GetCustomer(int customerReference)
        {
            return _entities.Customers.SingleOrDefault(c => c.Customer_Reference == customerReference);
        }

        public string GetFixtureLocation(string drawingNumber)
        {
            var material = _entities.Materials.FirstOrDefault(m => m.Specification == drawingNumber);

            if (material == null) {
                return string.Empty;
            }

            var stock = _entities.MStocks.FirstOrDefault(ms => ms.Material_Reference == material.Material_Reference);

            if (stock == null) {
                return string.Empty;
            }

            return stock.Location;
        }

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