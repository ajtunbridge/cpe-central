using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class EmployeeWorkCentreRepository : RepositoryBase<EmployeeWorkCentre>
    {
        public EmployeeWorkCentreRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<int> GetEmployeeWorkCentreReferences(int employeeId)
        {
            return GetSet().Where(w => w.EmployeeId == employeeId).Select(w => w.WCentreId).ToList();
        } 
    }
}
