#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
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

        public string GetPathToDocument(Document document, CPEUnitOfWork cpe)
        {
            IEntity entity = GetDocumentEntity(document);

            string storageDir = GetEntityStorageDirectory(entity);

            return $"{storageDir}\\{document.FileName}";
        }

        private IEntity GetDocumentEntity(Document document)
        {
            IEntity entity = null;

            if (document.OperationId.HasValue)
            {
                entity = UnitOfWork.Operations.GetById(document.OperationId.Value);
            }
            else if (document.PartId.HasValue)
            {
                entity = UnitOfWork.Parts.GetById(document.PartId.Value);
            }
            else if (document.PartVersionId.HasValue)
            {
                entity = UnitOfWork.PartVersions.GetById(document.PartVersionId.Value);
            }

            return entity;
        }

        private string GetEntityStorageDirectory(IEntity entity)
        {
            if (entity is Part)
            {
                string appDir = UnitOfWork.ClientSettings.GetWindowsDataDirectory();

                return $"{appDir}\\Documents\\PID{entity.Id}";
            }

            if (entity is PartVersion)
            {
                var version = entity as PartVersion;

                Part part = UnitOfWork.Parts.GetById(version.PartId);

                string partDir = GetEntityStorageDirectory(part);

                return $"{partDir}\\VER{entity.Id}";
            }

            if (entity is Operation)
            {
                var op = entity as Operation;

                Method method = UnitOfWork.Methods.GetById(op.MethodId);

                string versionDir = GetEntityStorageDirectory(method.PartVersion);

                return $"{versionDir}\\OP{entity.Id}";
            }

            throw new ArgumentException("You cannot store documents for this type!");
        }
    }
}