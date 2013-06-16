#region Using directives

using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Text;
using CPECentral.Data.EF5.Repositories;

#endregion

namespace CPECentral.Data.EF5
{
    public sealed class UnitOfWork : IDisposable
    {
        #region Members

        internal CPECentralEntities Entities = new CPECentralEntities();

        private CustomerRepository _customers;
        private DocumentRepository _documents;
        private EmployeeGroupRepository _employeeGroups;
        private EmployeeRepository _employees;
        private HolderGroupRepository _holderGroups;
        private HolderToolRepository _holderTools;
        private HolderRepository _holders;
        private MachineGroupRepository _machineGroups;
        private MethodRepository _methods;
        private OperationToolRepository _operationTools;
        private OperationRepository _operations;
        private PartVersionRepository _partVersions;
        private PartRepository _parts;
        private ToolGroupRepository _toolGroups;
        private ToolRepository _tools;

        #endregion

        #region Properties

        public CustomerRepository Customers
        {
            get { return _customers ?? (_customers = new CustomerRepository(this)); }
        }

        public DocumentRepository Documents
        {
            get { return _documents ?? (_documents = new DocumentRepository(this)); }
        }

        public EmployeeGroupRepository EmployeeGroups
        {
            get { return _employeeGroups ?? (_employeeGroups = new EmployeeGroupRepository(this)); }
        }

        public EmployeeRepository Employees
        {
            get { return _employees ?? (_employees = new EmployeeRepository(this)); }
        }

        public HolderGroupRepository HolderGroups
        {
            get { return _holderGroups ?? (_holderGroups = new HolderGroupRepository(this)); }
        }

        public HolderRepository Holders
        {
            get { return _holders ?? (_holders = new HolderRepository(this)); }
        }

        public HolderToolRepository HolderTools
        {
            get { return _holderTools ?? (_holderTools = new HolderToolRepository(this)); }
        }

        public MachineGroupRepository MachineGroups
        {
            get { return _machineGroups ?? (_machineGroups = new MachineGroupRepository(this)); }
        }

        public MethodRepository Methods
        {
            get { return _methods ?? (_methods = new MethodRepository(this)); }
        }

        public OperationRepository Operations
        {
            get { return _operations ?? (_operations = new OperationRepository(this)); }
        }

        public OperationToolRepository OperationTools
        {
            get { return _operationTools ?? (_operationTools = new OperationToolRepository(this)); }
        }

        public PartRepository Parts
        {
            get { return _parts ?? (_parts = new PartRepository(this)); }
        }

        public PartVersionRepository PartVersions
        {
            get { return _partVersions ?? (_partVersions = new PartVersionRepository(this)); }
        }

        public ToolGroupRepository ToolGroups
        {
            get { return _toolGroups ?? (_toolGroups = new ToolGroupRepository(this)); }
        }

        public ToolRepository Tools
        {
            get { return _tools ?? (_tools = new ToolRepository(this)); }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Entities.Dispose();
        }

        #endregion

        public void OpenConnection()
        {
            Entities.Database.Connection.Open();
        }

        public void CloseConnection()
        {
            Entities.Database.Connection.Close();
        }

        public void BeginTransaction()
        {
            Entities = new CPECentralEntities();
        }

        public void Commit()
        {
            try
            {
                Entities.SaveChanges();

                foreach (var entry in Entities.ChangeTracker.Entries())
                {
                    entry.State = EntityState.Detached;
                }

                Entities = new CPECentralEntities();
            }
            catch (Exception ex)
            {
                Rollback();

                if (ex is DbEntityValidationException)
                {
                    var validationEx = (DbEntityValidationException) ex;

                    var errors = new StringBuilder();

                    foreach (var validationError in validationEx.EntityValidationErrors)
                    {
                        foreach (var err in validationError.ValidationErrors)
                        {
                            errors.AppendLine(err.ErrorMessage);
                        }
                    }

                    throw new DataProviderException(errors.ToString(), DataProviderError.InvalidData, ex);
                }

                var inner = ex.InnerException;

                while (inner.GetType() != typeof (SqlException))
                {
                    inner = inner.InnerException;
                }

                var sqlEx = (SqlException) inner;

                string message;
                DataProviderError error;

                if (sqlEx.Number == -2)
                {
                    message = "Unable to save: Connection timed out!";
                    error = DataProviderError.ConnectionTimedOut;
                }
                else if (sqlEx.Number == 547)
                {
                    message = "Unable to save: Would violate foreign key constraint!";
                    error = DataProviderError.RelationshipViolation;
                }
                else if (sqlEx.Number == 2627)
                {
                    message = "Unable to save: Duplicate value was provided!";
                    error = DataProviderError.UniqueConstraintViolation;
                }
                else if (sqlEx.Number == 53 || sqlEx.Number == 4060)
                {
                    message = "Unable to save: Unable to connect to data store!";
                    error = DataProviderError.ConnectionFailed;
                }
                else
                {
                    message = "Unable to save: Unknown error. See an administrator!";
                    error = DataProviderError.Unknown;
                }

                throw new DataProviderException(message, error, ex);
            }
        }

        public void Rollback()
        {
            Entities = new CPECentralEntities();
        }
    }
}