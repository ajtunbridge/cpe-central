#region Using directives

using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
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

        public Material GetMaterialByReference(int materialReference)
        {
            return _entities.Materials.SingleOrDefault(m => m.Material_Reference == materialReference);
        }

        public double? GetMaterialStockLevel(int materialReference)
        {
            return
                _entities.MStocks.Where(m => m.Material_Reference == materialReference)
                    .Sum(stock => stock.Quantity_In_Stock);
        }

        public IEnumerable<MStock> GetMStocks(int materialReference)
        {
            return
                _entities.MStocks.Where(m => m.Material_Reference == materialReference)
                    .Where(ms => ms.Quantity_In_Stock > 0);
        }

        public IEnumerable<Material> GetMaterials(string filterValue)
        {
            return _entities.Materials.Where(entity => SqlFunctions.PatIndex(filterValue, entity.Name) > 0);
        }
    }
}