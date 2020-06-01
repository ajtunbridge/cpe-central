using System.Collections.Generic;
using System.Linq;

namespace CPECentral.Data.EF5.Repositories
{
    public class PartAlertsRepository : RepositoryBase<PartAlert>
    {
        public PartAlertsRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<PartAlert> GetAlerts(Part part)
        {
            return GetSet().Where(pa => pa.PartId == part.Id)
                .OrderByDescending(pa => pa.CreatedAt);
        }

        public bool HasAlerts(Part part)
        {
            return GetSet().Where(pa => pa.PartId == part.Id).Count() > 0;
        }
    }
}