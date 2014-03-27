#region Using directives

using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class PartRepository : RepositoryBase<Part>
    {
        public PartRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Part> GetWhereDrawingNumberContains(string value)
        {
            return GetSet().Where(p => p.DrawingNumber.Contains(value)).ToList();
        }

        public IEnumerable<Part> GetWhereDrawingNumberMatches(string wildcardQuery)
        {
            return GetSet().Where(p => SqlFunctions.PatIndex(wildcardQuery, p.DrawingNumber) > 0).ToList();
        }

        public IEnumerable<Part> GetWhereNameContains(string value)
        {
            return GetSet().Where(p => p.Name.Contains(value)).ToList();
        }

        public IEnumerable<Part> GetWhereNameMatches(string wildcardQuery)
        {
            return GetSet().Where(p => SqlFunctions.PatIndex(wildcardQuery, p.Name) > 0).ToList();
        }

        public IEnumerable<Part> GetByCustomer(Customer customer)
        {
            return GetByCustomer(customer.Id);
        }

        public IEnumerable<Part> GetByCustomer(int customerId)
        {
            return GetSet().Where(p => p.CustomerId == customerId).ToList();
        }
    }
}