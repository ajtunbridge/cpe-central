using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.Data.EF5.Repositories
{
    public class RecentPartRepository : RepositoryBase<RecentPart>
    {
        private const int MaximumRecentPartCount = 7;

        public RecentPartRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Part> GetRecentParts(Employee employee)
        {
            return GetRecentParts(employee.Id);
        }

        public IEnumerable<Part> GetRecentParts(int employeeId)
        {
            return GetSet().Where(rp => rp.EmployeeId == employeeId)
                .OrderByDescending(rp => rp.ViewedOn)
                .Select(rp => rp.Part);
        }

        public void AddToRecentParts(Employee employee, Part part)
        {
            AddToRecentParts(employee.Id, part.Id);
        }

        public void AddToRecentParts(int employeeId, Part part)
        {
            AddToRecentParts(employeeId, part.Id);
        }

        public void AddToRecentParts(Employee employee, int partId)
        {
            AddToRecentParts(employee.Id, partId);
        }

        public void AddToRecentParts(int employeeId, int partId)
        {
            var recentParts = GetSet().Where(rp => rp.EmployeeId == employeeId).OrderBy(rp => rp.ViewedOn);

            var existingRecord = recentParts.SingleOrDefault(rp => rp.EmployeeId == employeeId && rp.PartId == partId);

            if (existingRecord != null) {
                existingRecord.ViewedOn = DateTime.Now;
                Update(existingRecord);
            }
            else {
                if (recentParts.Count() == MaximumRecentPartCount) {
                    var oldestRecord = recentParts.First();
                    Delete(oldestRecord);
                }

                var newRecord = new RecentPart {
                    EmployeeId = employeeId,
                    PartId = partId,
                    ViewedOn = DateTime.Now
                };

                Add(newRecord);
            }
        }
    }
}
