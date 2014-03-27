#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class EmployeeRepository : RepositoryBase<Employee>
    {
        public EmployeeRepository(CPEUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Employee GetByUserName(string userName)
        {
            return GetSet().FirstOrDefault(emp => emp.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Employee> GetByEmployeeGroup(EmployeeGroup employeeGroup)
        {
            return GetByEmployeeGroup(employeeGroup.Id);
        }

        public IEnumerable<Employee> GetByEmployeeGroup(int employeeGroupId)
        {
            return GetSet().Where(emp => emp.EmployeeGroupId == employeeGroupId).ToList();
        }
    }
}