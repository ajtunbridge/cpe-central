#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class PartRepository : RepositoryBase<Part>
    {
        public PartRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Part> GetWhereDrawingNumberStartsWith(string value)
        {
            return GetSet().Where(p => p.DrawingNumber.StartsWith(value, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Part> GetWhereDrawingNumberContains(string value)
        {
            return GetSet().Where(p => p.DrawingNumber.Contains(value)).ToList();
        }

        public IEnumerable<Part> GetWhereNameStartsWith(string value)
        {
            return GetSet().Where(p => p.Name.StartsWith(value, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Part> GetWhereNameContains(string value)
        {
            return GetSet().Where(p => p.Name.Contains(value)).ToList();
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