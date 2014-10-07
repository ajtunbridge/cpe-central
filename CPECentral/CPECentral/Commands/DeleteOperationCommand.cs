#region Using directives

using System.Linq;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Commands
{
    public sealed class DeleteOperationCommand : CommandBase
    {
        public void Execute(Operation operation)
        {
            var docsToDelete = UnitOfWork.Documents.GetByOperation(operation);
            var opToolsToDelete = UnitOfWork.OperationTools.GetByOperation(operation);

            if (docsToDelete != null && docsToDelete.Any()) {
                Session.DocumentService.DeleteDocuments(docsToDelete);
            }

            if (opToolsToDelete != null && opToolsToDelete.Any()) {
                foreach (var tool in opToolsToDelete) {
                    UnitOfWork.OperationTools.Delete(tool);
                }
            }

            UnitOfWork.Operations.Delete(operation);

            UnitOfWork.Commit();
        }
    }
}