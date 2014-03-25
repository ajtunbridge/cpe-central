using CPECentral.Data.EF5;

namespace CPECentral.Delegates
{
    public delegate bool UpdateResultCallbackDelegate<T>(T entity) where T : IEntity;
}