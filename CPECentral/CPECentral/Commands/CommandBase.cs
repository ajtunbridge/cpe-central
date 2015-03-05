#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Commands
{
    public abstract class CommandBase
    {
        protected readonly CPEUnitOfWork UnitOfWork = new CPEUnitOfWork();
    }
}