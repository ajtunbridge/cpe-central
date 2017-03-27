using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.Data.EF5.Repositories
{
    public class CalibrationResultRepository : RepositoryBase<CalibrationResult>
    {
        public CalibrationResultRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<CalibrationResult> GetByGauge(Gauge gauge)
        {
            return GetByGauge(gauge.Id);
        }

        public IEnumerable<CalibrationResult> GetByGauge(int gaugeId)
        {
            return GetSet().Where(cr => cr.GaugeId == gaugeId).OrderByDescending(cr => cr.CalibratedOn);
        } 
    }
}
