#region Using directives

using System.Collections.Generic;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public class DocumentRepository : RepositoryBase<Document>
    {
        public DocumentRepository(CPEUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Document> GetByOperation(Operation operation)
        {
            return GetByOperation(operation.Id);
        }

        public IEnumerable<Document> GetByOperation(int operationId)
        {
            return GetSet().Where(d => d.OperationId == operationId).ToList();
        }

        public IEnumerable<Document> GetByPart(Part part)
        {
            return GetByPart(part.Id);
        }

        public IEnumerable<Document> GetByPart(int partId)
        {
            return GetSet().Where(d => d.PartId == partId).ToList();
        }

        public IEnumerable<Document> GetByPartVersion(PartVersion partVersion)
        {
            return GetByPartVersion(partVersion.Id);
        }

        public IEnumerable<Document> GetByPartVersion(int partVersionId)
        {
            return GetSet().Where(d => d.PartVersionId == partVersionId).ToList();
        }
    }
}