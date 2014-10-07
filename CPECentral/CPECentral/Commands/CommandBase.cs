using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.Commands
{
    public abstract class CommandBase
    {
        protected readonly CPEUnitOfWork UnitOfWork = new CPEUnitOfWork();
    }
}
