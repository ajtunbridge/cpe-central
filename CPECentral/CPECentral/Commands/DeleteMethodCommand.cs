using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.Commands
{
    public sealed class DeleteMethodCommand : CommandBase
    {
        public void Execute(Method method)
        {
            var ops = UnitOfWork.Operations.GetByMethod(method);

            var deleteOperationCommand = new DeleteOperationCommand();

            foreach (var op in ops) {
                deleteOperationCommand.Execute(op);
            }

            UnitOfWork.Methods.Delete(method);

            UnitOfWork.Commit();
        }
    }
}
