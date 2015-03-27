#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using NcCommunicator.Data.Model;
using nGenLibrary.Imaging;

#endregion

namespace NcCommunicator.Data
{
    public sealed class MachinesDataProvider : IDisposable
    {
        private SQLiteConnection _connection;

        public MachinesDataProvider(string databaseDirectory)
        {
            InitializeConnection(databaseDirectory);
        }

        #region IDisposable Members

        public void Dispose()
        {
            _connection.Dispose();
        }

        #endregion

        public ICollection<Machine> GetAllMachines()
        {
            const string getAllMachinesQuery = "SELECT * FROM machines_serial; SELECT * FROM machines_smb";

            var allMachines = new List<Machine>();

            try {
                var cmd = new SQLiteCommand(getAllMachinesQuery, _connection);

                _connection.Open();

                int currentResultSet = 1;

                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                    // loop through both result sets
                    do {
                        while (reader.Read()) {
                            Machine machine;

                            if (currentResultSet == 1) {
                                // currently reading the machines_serial table result set
                                machine = ReaderToSerialMachine(reader);
                            }
                            else {
                                // currently reading the machines_smb table result set
                                machine = ReaderToSmbMachine(reader);
                            }

                            allMachines.Add(machine);
                        }

                        // increment here to show we're on the next result set
                        currentResultSet++;
                    } while (reader.NextResult());
                }
            }
            finally {
                if (_connection.State == ConnectionState.Open) {
                    _connection.Close();
                }
            }

            return allMachines;
        }

        public ICollection<Machine> GetFavouriteMachines(int employeeId)
        {
            var favouriteMachines = new List<Machine>();

            string getFavouriteMachinesQuery =
                "SELECT serial_machine_id, smb_machine_id FROM favourite_machines WHERE employee_id" + employeeId;

            try {
                _connection.Open();

                var serialMachineIds = new List<int>();
                var smbMachineIds = new List<int>();

                using (var cmd = new SQLiteCommand(getFavouriteMachinesQuery, _connection)) {
                    using (SQLiteDataReader favouriteMachinesReader = cmd.ExecuteReader()) {
                        while (favouriteMachinesReader.Read()) {
                            if (favouriteMachinesReader.IsDBNull(0)) {
                                // is SmbMachine
                                int id = favouriteMachinesReader.GetInt32(1);
                                smbMachineIds.Add(id);
                            }
                            else {
                                // is SerialMachine
                                int id = favouriteMachinesReader.GetInt32(0);
                                serialMachineIds.Add(id);
                            }
                        }
                    }
                }

                foreach (int id in serialMachineIds) {
                    string query = "SELECT * FROM machines_serial WHERE id=" + id;
                    using (var cmd = new SQLiteCommand(query, _connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                            favouriteMachines.Add(ReaderToSerialMachine(reader));
                        }
                    }
                }
                foreach (int id in smbMachineIds) {
                    string query = "SELECT * FROM machines_smb WHERE id=" + id;
                    using (var cmd = new SQLiteCommand(query, _connection)) {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                            favouriteMachines.Add(ReaderToSmbMachine(reader));
                        }
                    }
                }
            }
            finally {
                if (_connection.State == ConnectionState.Open) {
                    _connection.Close();
                }
            }

            return favouriteMachines;
        }

        public void Insert(Machine machine)
        {
            if (machine is SerialMachine) {
                InsertSerialMachine(machine);
            }
            else {
                InsertSmbMachine(machine);
            }
        }

        public void Delete(Machine machine)
        {
            if (machine is SerialMachine) {
                DeleteSerialMachine(machine);
            }
            else {
                DeleteSmbMachine(machine);
            }
        }

        public void Update(Machine machine)
        {
            if (machine is SerialMachine) {
                UpdateSerialMachine(machine);
            }
            else {
                UpdateSmbMachine(machine);
            }
        }

        private void InitializeConnection(string directory)
        {
            string dataDir = string.Format("{0}\\CPECentral\\Data\\", directory);

            if (!Directory.Exists(dataDir)) {
                Directory.CreateDirectory(dataDir);
            }

            string databaseFilePath = string.Format("{0}\\machines.sqlite", dataDir);

            if (!File.Exists(databaseFilePath)) {
                const string resourceName = "NcCommunicator.Data.Model.machines.sqlite";

                Assembly assembly = Assembly.GetExecutingAssembly();

                using (Stream templateDatabaseStream = assembly.GetManifestResourceStream(resourceName)) {
                    using (
                        var databaseFileStream = new FileStream(databaseFilePath, FileMode.CreateNew, FileAccess.Write)) {
                        templateDatabaseStream.CopyTo(databaseFileStream);
                    }
                }
            }

            string connString = string.Format("Data Source={0};Version=3;", databaseFilePath);

            _connection = new SQLiteConnection(connString);
        }

        #region Utility methods

        private T StringToEnum<T>(string value)
        {
            return (T) Enum.Parse(typeof (T), value);
        }

        private string EnumToString<T>(T value)
        {
            return Enum.GetName(typeof (T), value);
        }

        private void InsertSerialMachine(Machine machineToInsert)
        {
            if (!(machineToInsert is SerialMachine)) {
                throw new ArgumentException("The machine provided is not of the type SerialMachine!", "machineToInsert");
            }

            var mc = machineToInsert as SerialMachine;

            string cmdText = string.Format(
                @"INSERT INTO machines_serial (name,com_port, stop_bits, parity, handshake, data_bits, baud_rate,
                    dtr_enable, rts_enable, xon_char, xoff_char, alt_xon_char, alt_xoff_char, program_start,
                    program_end, new_line, photo) VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},
                    {8},{9},{10},{11},{12},'{13}','{14}','{15}',@photo)",
                mc.Name,
                mc.ComPort,
                EnumToString(mc.StopBits),
                EnumToString(mc.Parity),
                EnumToString(mc.Handshake),
                mc.DataBits,
                mc.BaudRate,
                mc.DtrEnable ? 1 : 0,
                mc.RtsEnable ? 1 : 0,
                mc.XOnChar,
                mc.XOffChar,
                mc.AltXOnChar,
                mc.AltXOffChar,
                mc.ProgramStart,
                mc.ProgramEnd,
                mc.NewLine);

            var prm = new SQLiteParameter("@photo", DbType.Binary);

            prm.Value = mc.Photo == null ? null : ImageUtility.ConvertImageToBytes(mc.Photo);

            ExecuteCommand(cmdText, prm);
        }

        private void InsertSmbMachine(Machine machineToInsert)
        {
            if (!(machineToInsert is SmbMachine)) {
                throw new ArgumentException("The machine provided is not of the type SmbMachine!", "machineToInsert");
            }

            var mc = machineToInsert as SmbMachine;

            string cmdText = string.Format("INSERT INTO machines_smb VALUES('{0}', '{1}', @photo)", mc.Name,
                mc.RootDirectoryPath);

            var prm = new SQLiteParameter("@photo", DbType.Binary);

            prm.Value = mc.Photo == null ? null : ImageUtility.ConvertImageToBytes(mc.Photo);

            ExecuteCommand(cmdText, prm);
        }

        private void UpdateSerialMachine(Machine machineToUpdate)
        {
            if (!(machineToUpdate is SerialMachine)) {
                throw new ArgumentException("The machine provided is not of the type SerialMachine!", "machineToUpdate");
            }

            var mc = machineToUpdate as SerialMachine;

            string cmdText = string.Format(
                @"UPDATE machines_serial SET name='{0}', com_port='{1}', stop_bits='{2}', parity='{3}', handshake='{4}', data_bits={5},
                    baud_rate={6}, dtr_enable={7}, rts_enable={8}, xon_char={9}, xoff_char={10}, alt_xon_char={11},
                    alt_xoff_char={12}, program_start='{13}', program_end='{14}', new_line='{15}', photo=@photo)
                  WHERE id={16}",
                mc.Name,
                mc.ComPort,
                EnumToString(mc.StopBits),
                EnumToString(mc.Parity),
                EnumToString(mc.Handshake),
                mc.DataBits,
                mc.BaudRate,
                mc.DtrEnable ? 1 : 0,
                mc.RtsEnable ? 1 : 0,
                mc.XOnChar,
                mc.XOffChar,
                mc.AltXOnChar,
                mc.AltXOffChar,
                mc.ProgramStart,
                mc.ProgramEnd,
                mc.NewLine,
                mc.Id);

            var prm = new SQLiteParameter("@photo", DbType.Binary);

            prm.Value = mc.Photo == null ? null : ImageUtility.ConvertImageToBytes(mc.Photo);

            ExecuteCommand(cmdText, prm);
        }

        private void UpdateSmbMachine(Machine machineToUpdate)
        {
            if (!(machineToUpdate is SmbMachine)) {
                throw new ArgumentException("The machine provided is not of the type SmbMachine!", "machineToUpdate");
            }

            var mc = machineToUpdate as SmbMachine;

            string cmdText =
                string.Format("UPDATE machines_smb SET name='{0}',root_directory_path='{1}', photo=@photo WHERE id={2}",
                    mc.Name, mc.RootDirectoryPath, mc.Id);

            var prm = new SQLiteParameter("@photo", DbType.Binary);

            prm.Value = mc.Photo == null ? null : ImageUtility.ConvertImageToBytes(mc.Photo);

            ExecuteCommand(cmdText, prm);
        }

        private void DeleteSerialMachine(Machine machineToDelete)
        {
            if (!(machineToDelete is SerialMachine)) {
                throw new ArgumentException("The machine provided is not of the type SerialMachine!", "machineToDelete");
            }

            string cmdText = string.Format("DELETE FROM machines_serial WHERE id=" + machineToDelete.Id);

            ExecuteCommand(cmdText);
        }

        private void DeleteSmbMachine(Machine machineToDelete)
        {
            if (!(machineToDelete is SmbMachine)) {
                throw new ArgumentException("The machine provided is not of the type SmbMachine!", "machineToDelete");
            }

            string cmdText = string.Format("DELETE FROM machines_smb WHERE id=" + machineToDelete.Id);

            ExecuteCommand(cmdText);
        }

        private void ExecuteCommand(string cmdText, params SQLiteParameter[] prms)
        {
            try {
                using (var cmd = new SQLiteCommand(cmdText, _connection)) {
                    foreach (SQLiteParameter prm in prms) {
                        cmd.Parameters.Add(prm);
                    }
                    if (_connection.State == ConnectionState.Closed) {
                        _connection.Open();
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            finally {
                if (_connection.State == ConnectionState.Open) {
                    _connection.Close();
                }
            }
        }

        private SerialMachine ReaderToSerialMachine(SQLiteDataReader reader)
        {
            var machine = new SerialMachine {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                ComPort = reader.GetString(reader.GetOrdinal("com_port")),
                StopBits = StringToEnum<StopBits>(reader.GetString(reader.GetOrdinal("stop_bits"))),
                Parity = StringToEnum<Parity>(reader.GetString(reader.GetOrdinal("parity"))),
                Handshake = StringToEnum<Handshake>(reader.GetString(reader.GetOrdinal("handshake"))),
                DataBits = reader.GetByte(reader.GetOrdinal("data_bits")),
                BaudRate = reader.GetInt32(reader.GetOrdinal("baud_rate")),
                DtrEnable = reader.GetBoolean(reader.GetOrdinal("dtr_enable")),
                RtsEnable = reader.GetBoolean(reader.GetOrdinal("rts_enable")),
                XOnChar = reader.GetByte(reader.GetOrdinal("xon_char")),
                XOffChar = reader.GetByte(reader.GetOrdinal("xoff_char")),
                AltXOnChar = reader.GetByte(reader.GetOrdinal("alt_xon_char")),
                AltXOffChar = reader.GetByte(reader.GetOrdinal("alt_xoff_char")),
                ProgramStart = reader.GetString(reader.GetOrdinal("program_start")),
                ProgramEnd = reader.GetString(reader.GetOrdinal("program_end")),
                NewLine = reader.GetString(reader.GetOrdinal("new_line")),
                Photo = GetPhotoFromReader(reader)
            };

            return machine;
        }

        private SmbMachine ReaderToSmbMachine(SQLiteDataReader reader)
        {
            var machine = new SmbMachine {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                RootDirectoryPath = reader.GetString(reader.GetOrdinal("root_directory_path")),
                Photo = GetPhotoFromReader(reader)
            };

            int photoOrdinal = reader.GetOrdinal("photo");

            byte[] photoBytes = reader.IsDBNull(photoOrdinal) ? null : (byte[]) reader[photoOrdinal];

            machine.Photo = photoBytes == null ? null : ImageUtility.ConvertBytesToImage(photoBytes);

            return machine;
        }

        private Image GetPhotoFromReader(SQLiteDataReader reader)
        {
            int photoOrdinal = reader.GetOrdinal("photo");

            byte[] photoBytes = reader.IsDBNull(photoOrdinal) ? null : (byte[]) reader[photoOrdinal];

            Image image = photoBytes == null ? null : ImageUtility.ConvertBytesToImage(photoBytes);

            return image;
        }

        #endregion
    }
}