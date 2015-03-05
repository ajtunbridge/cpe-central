#region Using directives

using System.Collections.Generic;
using System.Linq;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Commands
{
    public sealed class DeleteOperationCommand : CommandBase
    {
        public void Execute(Operation operation)
        {
            IEnumerable<Document> docsToDelete = UnitOfWork.Documents.GetByOperation(operation);
            IEnumerable<OperationTool> opToolsToDelete = UnitOfWork.OperationTools.GetByOperation(operation);

            if (docsToDelete != null && docsToDelete.Any()) {
                Session.DocumentService.DeleteDocuments(docsToDelete);
            }

            if (opToolsToDelete != null && opToolsToDelete.Any()) {
                foreach (OperationTool tool in opToolsToDelete) {
                    UnitOfWork.OperationTools.Delete(tool);
                }
            }

            UnitOfWork.Operations.Delete(operation);

            UnitOfWork.Commit();
        }
    }
}