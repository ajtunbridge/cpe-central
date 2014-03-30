#region Using directives

using System;
using System.Data;
using System.IO;
using NcCommunicator.Data.Model;
using NcCommunicator.Data.Repositories;

#endregion

namespace NcCommunicator.Data
{
    public class UnitOfWork : IDisposable
    {
        private MachinesDataSet _dataSet;

        private MachineControlRepository _machineControls;
        private MachineRepository _machines;

        public UnitOfWork()
        {
            ReadInDataFile();
        }

        public MachineRepository Machines
        {
            get { return _machines ?? (_machines = new MachineRepository(_dataSet)); }
        }

        public MachineControlRepository MachineControls
        {
            get { return _machineControls ?? (_machineControls = new MachineControlRepository(_dataSet)); }
        }

        #region IDisposable Members

        public void Dispose()
        {
            _dataSet.Dispose();
        }

        #endregion

        public void Commit()
        {
            string dataFile = GetDataFileName();

            _dataSet.WriteXml(dataFile, XmlWriteMode.WriteSchema);
        }

        public void Rollback()
        {
            ReadInDataFile();
        }

        private void ReadInDataFile()
        {
            string dataFile = GetDataFileName();

            if (!File.Exists(dataFile)) {
                _dataSet = new MachinesDataSet();
                _dataSet.WriteXml(dataFile, XmlWriteMode.WriteSchema);
            }

            _dataSet = new MachinesDataSet();
            _dataSet.ReadXml(dataFile, XmlReadMode.ReadSchema);
        }

        private static string GetDataFileName()
        {
            string commonAppDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                  "\\CPECentral\\";

            if (!Directory.Exists(commonAppDir)) {
                Directory.CreateDirectory(commonAppDir);
            }

            return string.Format("{0}\\machines.xml", commonAppDir);
        }
    }
}