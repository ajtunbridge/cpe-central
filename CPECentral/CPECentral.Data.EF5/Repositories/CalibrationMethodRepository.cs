using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class CalibrationMethodRepository : RepositoryBase<CalibrationMethod>
    {
        public CalibrationMethodRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
