﻿#region Using directives

using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;

#endregion

namespace CPECentral.Data.EF5.Repositories
{
    public sealed class ToolRepository : RepositoryBase<Tool>
    {
        public ToolRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Tool> GetByToolGroup(ToolGroup toolGroup, bool includeChildGroups)
        {
            return GetByToolGroup(toolGroup.Id, includeChildGroups);
        }

        public IEnumerable<Tool> GetByToolGroup(int toolGroupId, bool includeChildGroups)
        {
            var tools = new List<Tool>();

            List<Tool> groupTools = GetSet().Where(t => t.ToolGroupId == toolGroupId).ToList();

            tools.AddRange(groupTools);

            if (includeChildGroups) {
                IQueryable<ToolGroup> childGroups =
                    UnitOfWork.Entities.ToolGroups.AsNoTracking().Where(g => g.ParentGroupId == toolGroupId);

                foreach (ToolGroup childGroup in childGroups) {
                    IEnumerable<Tool> childTools = GetByToolGroup(childGroup, true);

                    tools.AddRange(childTools);
                }
            }

            return tools;
        }

        public IEnumerable<Tool> GetByHolder(Holder holder)
        {
            return GetByHolder(holder.Id);
        }

        public IEnumerable<Tool> GetByHolder(int holderId)
        {
            Holder holder = UnitOfWork.Entities.Holders.Single(h => h.Id == holderId);

            return holder.HolderTools.Select(ht => ht.Tool).ToList();
        }

        public IEnumerable<Tool> GetWhereDescriptionMatches(string value)
        {
            if (!value.Contains("%")) {
                value = "%" + value + "%";
            }

            return GetSet().Where(t => SqlFunctions.PatIndex(value, t.Description) > 0).OrderBy(t => t.Description);
        } 

        public IEnumerable<Tool> GetByOperation(Operation operation)
        {
            return GetByOperation(operation.Id);
        }

        public IEnumerable<Tool> GetByOperation(int operationId)
        {
            Operation operation = UnitOfWork.Entities.Operations.Single(op => op.Id == operationId);

            return operation.OperationTools.Select(opTool => opTool.Tool).ToList();
        }

        /// <summary>
        ///     Gets the number of tools dependent on this group existing
        /// </summary>
        /// <param name="rootGroup">The root group</param>
        /// <returns></returns>
        public int GetDependentToolCount(ToolGroup rootGroup)
        {
            return GetSet().Count(t => t.ToolGroupId == rootGroup.Id);
        }
    }
}