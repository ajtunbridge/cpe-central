#region Using directives

using System.Collections.Generic;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Commands
{
    public sealed class DeleteMethodCommand : CommandBase
    {
        public void Execute(Method method)
        {
            IEnumerable<Operation> ops = UnitOfWork.Operations.GetByMethod(method);

            var deleteOperationCommand = new DeleteOperationCommand();

            foreach (Operation op in ops) {
                deleteOperationCommand.Execute(op);
            }

            UnitOfWork.Methods.Delete(method);

            UnitOfWork.Commit();
        }
    }
}