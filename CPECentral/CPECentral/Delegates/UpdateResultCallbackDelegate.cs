#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Delegates
{
    public delegate bool UpdateResultCallbackDelegate<T>(T entity) where T : IEntity;
}