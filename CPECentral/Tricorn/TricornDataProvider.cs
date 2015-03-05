#region Using directives

using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            Material material = _entities.Materials.FirstOrDefault(m => m.Specification == drawingNumber);

            if (material == null) {
                return string.Empty;
            }

            MStock stock = _entities.MStocks.FirstOrDefault(ms => ms.Material_Reference == material.Material_Reference);

            if (stock == null) {
                return string.Empty;
            }

            return stock.Location;
        }

        public IEnumerable<WOrder> GetWorksOrdersByUserReference(string userReference)
        {
            return _entities.WOrders.Include("Customer").Where(wo => SqlFunctions.PatIndex(userReference + "%", wo.User_Reference) > 0);
        }

        public IEnumerable<WOrder> GetWorksOrdersByDrawingNumber(string drawingNumber)
        {
            return _entities.WOrders.Where(wo => SqlFunctions.PatIndex(drawingNumber, wo.Drawing_Number) > 0)
                .Include(
                    w =>
                        w.WOWCentres.Select(
                            wc => _entities.WOOperActs.Where(woo => woo.WOWCentre_Reference == wc.WCentre_Reference)));
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

        public decimal? GetTurnoverThisMonth()
        {
            var startDate = DateTime.Today.AddDays(DateTime.Today.Day * -1).AddDays(1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return GetTurnoverForPeriod(startDate, endDate);
        }

        public decimal? GetTurnoverLastMonth()
        {
            var startDate = DateTime.Today.AddDays(DateTime.Today.Day * -1).AddDays(1).AddMonths(-1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return GetTurnoverForPeriod(startDate, endDate);
        }

        public decimal? GetTurnoverForPeriod(DateTime startDate, DateTime endDate)
        {
            return
                _entities.Invoices.Where(i => i.Invoice_Date >= startDate && i.Invoice_Date <= endDate).Sum(i => i.Cost);
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