#region Using directives

using System;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class CustomerRepository : RepositoryBase<Customer>
    {
        public CustomerRepository(CPEUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Customer GetByName(string name)
        {
            return GetSet().FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}