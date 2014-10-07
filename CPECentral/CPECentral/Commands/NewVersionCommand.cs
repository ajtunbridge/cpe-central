using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral.Commands
{
    public sealed class NewVersionCommand : CommandBase
    {
        public void Execute(Part part, string newVersionNumber, bool copyMethodsAndOperations, bool copyToolLists, bool copyOperationDocuments)
        {
            var currentVersion = UnitOfWork.PartVersions.GetLatestVersion(part.Id);

            var newVersion = new PartVersion {
                PartId = part.Id,
                VersionNumber = newVersionNumber,
                CreatedBy = Session.CurrentEmployee.Id,
                ModifiedBy = Session.CurrentEmployee.Id
            };

            UnitOfWork.PartVersions.Add(newVersion);

            if (copyMethodsAndOperations) {
                foreach (var method in currentVersion.Methods) {
                    var newMethod = new Method {
                        PartVersion = newVersion,
                        IsPreferred = method.IsPreferred,
                        Description = "COPIED FROM OLD VERSION: " + method.Description,
                        CreatedBy = Session.CurrentEmployee.Id,
                        ModifiedBy = Session.CurrentEmployee.Id
                    };

                    UnitOfWork.Methods.Add(newMethod);

                    foreach (var operation in method.Operations) {
                        var newOperation = new Operation {
                            CreatedBy = Session.CurrentEmployee.Id,
                            CycleTime = operation.CycleTime,
                            Description = "COPIED FROM OLD VERSION: " + operation.Description,
                            MachineGroupId = operation.MachineGroupId,
                            Method = newMethod,
                            ModifiedBy = Session.CurrentEmployee.Id,
                            Notes = operation.Notes,
                            Sequence = operation.Sequence,
                            SetupTime = operation.SetupTime
                        };

                        UnitOfWork.Operations.Add(newOperation);

                        if (copyToolLists) {
                            foreach (var opTool in operation.OperationTools) {
                                var newOpTool = new OperationTool {
                                    HolderId = opTool.HolderId,
                                    Notes = opTool.Notes,
                                    Offset = opTool.Offset,
                                    Operation = newOperation,
                                    Position = opTool.Position,
                                    ToolId = opTool.ToolId,
                                    UseOnePer = opTool.UseOnePer
                                };

                                UnitOfWork.OperationTools.Add(newOpTool);
                            }
                        }
                    }
                }
            }

            UnitOfWork.Commit();
        }
    }
}
