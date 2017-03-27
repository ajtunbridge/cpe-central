using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class GaugeRepository : RepositoryBase<Gauge>
    {
        public GaugeRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Gauge> GetByGaugeType(GaugeType gaugeType)
        {
            return GetByGaugeType(gaugeType.Id);
        }

        public IEnumerable<Gauge> GetByGaugeType(int gaugeTypeId)
        {
            return GetSet().Include("GaugeType").Where(g => g.GaugeTypeId == gaugeTypeId);
        } 
    }
}
