#region Using directives

using System;
using System.Data;
using System.IO;
using System.Reflection;
using NcCommunicator.Data.Model;
using NcCommunicator.Data.Repositories;

#endregion

namespace NcCommunicator.Data
{
    public class UnitOfWork : IDisposable
    {
        private MachinesDataSet _dataSet;

        private MachineRepository _machines;

        public UnitOfWork()
        {
            ReadInDataFile();
        }

        #region IDisposable Members

        public void Dispose()
        {
            _dataSet.Dispose();
        }

        #endregion

        public MachineRepository Machines
        {
            get { return _machines ?? (_machines = new MachineRepository(_dataSet)); }
        }

        public void Commit()
        {
            var dataFile = GetDataFileName();

            _dataSet.WriteXml(dataFile, XmlWriteMode.WriteSchema);
        }

        public void Rollback()
        {
            ReadInDataFile();
        }

        private void ReadInDataFile()
        {
            var dataFile = GetDataFileName();

            if (!File.Exists(dataFile))
                throw new FileNotFoundException("Unable to locate the machines data file!");

            _dataSet = new MachinesDataSet();
            _dataSet.ReadXml(dataFile, XmlReadMode.ReadSchema);
        }

        private static string GetDataFileName()
        {
            var appDir = Assembly.GetEntryAssembly().Location;

            return string.Format("{0}\\Data\\machines.xml", appDir);
        }
    }
}