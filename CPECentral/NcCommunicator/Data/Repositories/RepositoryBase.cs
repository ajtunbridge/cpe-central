#region Using directives

using System.Data;
using System.IO;
using NcCommunicator.Data.Model;

#endregion

namespace NcCommunicator.Data.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly MachinesDataSet DataSet;

        protected RepositoryBase(MachinesDataSet dataSet)
        {
            DataSet = dataSet;
        }
    }
}