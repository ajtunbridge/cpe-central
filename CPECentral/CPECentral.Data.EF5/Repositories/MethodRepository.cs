#region Using directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class MethodRepository : RepositoryBase<Method>
    {
        public MethodRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Method> GetByPartVersion(PartVersion partVersion)
        {
            return GetByPartVersion(partVersion.Id);
        }

        public IEnumerable<Method> GetByPartVersion(int partVersionId)
        {
            return GetSet().Where(m => m.PartVersionId == partVersionId).ToList();
        }

        public Method GetPreferredMethod(PartVersion partVersion)
        {
            return GetPreferredMethod(partVersion.Id);
        }

        public Method GetPreferredMethod(int partVersionId)
        {
            return GetSet().First(m => m.PartVersionId == partVersionId && m.IsPreferred);
        }

        public void SetPreferredMethod(Method method)
        {
            var allMethods = GetByPartVersion(method.PartVersionId);

            foreach (var m in allMethods)
            {
                if (m.Id == method.Id)
                {
                    m.IsPreferred = true;
                    continue;
                }

                m.IsPreferred = false;
            }
        }
    }
}