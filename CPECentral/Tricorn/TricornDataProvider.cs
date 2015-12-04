#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects.SqlClient;
using System.Data.SqlClient;
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
            return _entities.WOrders.Where(wo => SqlFunctions.PatIndex(drawingNumber, wo.Drawing_Number) > 0);
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

        public IEnumerable<WOrder> GetNextJobsForWorkCentre(int wcentreId)
        {
            var wowcentres =
                _entities.WOWCentres.Where(wow => wow.WCentre_Reference == wcentreId && !wow.Operation_Finished);

            var worders = new List<WOrder>();

            const string query = @"SELECT TOP 1 ORNO, STARTDATE FROM OR_FRAG_VIEWER WHERE OPNO=@opnumber ORDER BY STARTDATE ASC";

            var conn = _entities.Database.Connection;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            var cmd = new SqlCommand(query, (SqlConnection)conn);
            cmd.Prepare();

            foreach (var wowc in wowcentres)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@opnumber", wowc.WOWCentre_Reference);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var worderReference = Convert.ToInt32(reader.GetValue(0));

                        if (worderReference == 0)
                        {
                            continue;
                        }

                        var startDate = Convert.ToDateTime(reader.GetValue(1));

                        var worder = _entities.WOrders.Single(wo => wo.WOrder_Reference == worderReference);

                        if (worders.Any(wo => wo.WOrder_Reference == worder.WOrder_Reference))
                        {
                            continue;
                        }

                        worder.ScheduledStart = startDate;

                        worders.Add(worder);
                    }
                }
            }

            return worders.OrderBy(wo => wo.ScheduledStart);
        }

        public IEnumerable<WCentre> GetWorkCentres()
        {
            return _entities.WCentres.OrderBy(wc => wc.Name).ToList();
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