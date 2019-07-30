using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class GaugeTypeRepository : RepositoryBase<GaugeType>
    {
        public GaugeTypeRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
