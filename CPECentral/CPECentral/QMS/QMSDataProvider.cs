#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using CPECentral.Properties;
using CPECentral.QMS.Model;

#endregion

namespace CPECentral.QMS
{
    public class QMSDataProvider
    {
        private readonly OleDbConnection _connection;

        public QMSDataProvider()
        {
            string commonAppDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                  "\\CPECentral\\";

            var pathToRemoteQms = Settings.Default.PathToQMSDatabase;

            var fileName = Path.GetFileName(pathToRemoteQms);

            var localFilePath = Path.Combine(commonAppDir, fileName);

            var connString =
                string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=False;",
                    localFilePath);

            _connection = new OleDbConnection(connString);
        }

        public bool HasComplaints(string drawingNumber)
        {
            const string query =
                "SELECT COUNT([Reject Report Number]) FROM [Customer complaints] WHERE [Part Number] LIKE '%' + @prm1 + '%'";

            var cmd = new OleDbCommand(query, _connection);
            cmd.Parameters.AddWithValue("@prm1", drawingNumber);

            try
            {
                _connection.Open();

                var count = (int) cmd.ExecuteScalar();
                return count > 0;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public IEnumerable<Complaint> GetInternalComplaints(DateTime startDate, DateTime endDate)
        {
            const string query =
                "SELECT * FROM [Customer Complaints] WHERE [Complaint Type]='INTERNAL' AND [Date Returned] BETWEEN @prm1 AND @prm2";

            var prms = new[]
            {
                new OleDbParameter("@prm1", startDate),
                new OleDbParameter("@prm2", endDate)
            };

            return GetComplaints(query, prms);
        }

        public IEnumerable<Complaint> GetCustomerComplaints(DateTime startDate, DateTime endDate)
        {
            const string query =
                "SELECT * FROM [Customer Complaints] WHERE [Complaint Type]='EXTERNAL' AND [Date Returned] BETWEEN @prm1 AND @prm2";

            var prms = new[]
            {
                new OleDbParameter("@prm1", startDate),
                new OleDbParameter("@prm2", endDate)
            };

            return GetComplaints(query, prms);
        }

        public IEnumerable<Complaint> GetSupplierComplaints(DateTime startDate, DateTime endDate)
        {
            const string query =
                "SELECT * FROM [Customer Complaints] WHERE [Complaint Type]='SUPPLIER' AND [Date Returned] BETWEEN @prm1 AND @prm2";

            var prms = new[]
            {
                new OleDbParameter("@prm1", startDate),
                new OleDbParameter("@prm2", endDate)
            };

            return GetComplaints(query, prms);
        }

        public IEnumerable<Complaint> GetComplaintsByDrawingNumber(string drawingNumber)
        {
            const string query = "SELECT * FROM [Customer complaints] WHERE [Part Number] LIKE '%' + @prm1 + '%'";

            var prms = new OleDbParameter("@prm1", drawingNumber);

            return GetComplaints(query, prms);
        }

        public IEnumerable<Complaint> GetComplaints(string query, params OleDbParameter[] prms)
        {
            var results = new List<Complaint>();

            var cmd = new OleDbCommand(query, _connection);
            cmd.Parameters.AddRange(prms);

            try
            {
                _connection.Open();

                using (OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    int reasonOrdinal = reader.GetOrdinal("Reason For Return");
                    int customerNameOrdinal = reader.GetOrdinal("Customer Name");
                    int contactNameOrdinal = reader.GetOrdinal("Contact Name");
                    int categoryOrdinal = reader.GetOrdinal("Nonconformance Category");
                    int descriptionOrdinal = reader.GetOrdinal("Reason for non conformance");
                    int employeeOrdinal = reader.GetOrdinal("Employee");
                    int authorizedOrdinal = reader.GetOrdinal("Actions Authorised By");
                    int conclusionOrdinal = reader.GetOrdinal("Final Disposition");
                    int correctiveOrdinal = reader.GetOrdinal("Corrective Actions");
                    int preventativeOrdinal = reader.GetOrdinal("Preventative Actions");
                    int raisedOnOrdinal = reader.GetOrdinal("Date Returned");
                    int resultsOfInspectionOrdinal = reader.GetOrdinal("Results of re inspection");

                    while (reader.Read())
                    {
                        var nc = new Complaint
                        {
                            ReportNumber = (int) reader["Reject Report Number"],
                            ResultsOfInspection =
                                reader.IsDBNull(resultsOfInspectionOrdinal)
                                    ? "N/A"
                                    : reader.GetString(resultsOfInspectionOrdinal),
                            RaisedBy =
                                reader.IsDBNull(customerNameOrdinal) ? "N/A" : reader.GetString(customerNameOrdinal),
                            Reason = reader.IsDBNull(reasonOrdinal) ? "N/A" : reader.GetString(reasonOrdinal),
                            Contact = reader.IsDBNull(contactNameOrdinal) ? "N/A" : reader.GetString(contactNameOrdinal),
                            Category = reader.IsDBNull(categoryOrdinal) ? "N/A" : reader.GetString(categoryOrdinal),
                            Description =
                                reader.IsDBNull(descriptionOrdinal) ? "N/A" : reader.GetString(descriptionOrdinal),
                            Employee = reader.IsDBNull(employeeOrdinal) ? "N/A" : reader.GetString(employeeOrdinal),
                            AuthorizedBy =
                                reader.IsDBNull(authorizedOrdinal) ? "N/A" : reader.GetString(authorizedOrdinal),
                            Conclusion =
                                reader.IsDBNull(conclusionOrdinal) ? "N/A" : reader.GetString(conclusionOrdinal),
                            CorrectiveAction =
                                reader.IsDBNull(correctiveOrdinal) ? "N/A" : reader.GetString(correctiveOrdinal),
                            PreventativeAction =
                                reader.IsDBNull(preventativeOrdinal) ? "N/A" : reader.GetString(preventativeOrdinal),
                            RaisedOn =
                                reader.IsDBNull(raisedOnOrdinal)
                                    ? null
                                    : new DateTime?(reader.GetDateTime(raisedOnOrdinal))
                        };

                        results.Add(nc);
                    }
                }
            }
            finally
            {
                cmd.Dispose();

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }

                _connection.Dispose();
            }

            return results;
        }

        public IEnumerable<Gauge> GetGaugesDueForCalibration()
        {
            var gauges = new List<Gauge>();

            const string gaugeQuery =
                "SELECT [Gauge Number], [SIZE/RANGE], [GAUGE DESCRIPTION], [HOLDER] FROM [GAUGE DATA]";
            const string calibQuery =
                "SELECT TOP 1 [Calibration Date], [Frequency] FROM [Calibration Results] WHERE [GAuge Reference]=@prm1 ORDER BY [Calibration Date] DESC";


            var gaugeCmd = new OleDbCommand(gaugeQuery, _connection);
            var calibCmd = new OleDbCommand(calibQuery, _connection);

            try
            {
                _connection.Open();

                using (var reader = gaugeCmd.ExecuteReader())
                {
                    var gaugeNumberOrdinal = reader.GetOrdinal("Gauge Number");
                    var sizeRangeOrdinal = reader.GetOrdinal("SIZE/RANGE");
                    var descriptionOrdinal = reader.GetOrdinal("GAUGE DESCRIPTION");
                    var holderOrdinal = reader.GetOrdinal("HOLDER");

                    while (reader.Read())
                    {
                        var gauge = new Gauge
                        {
                            GaugeNumber =
                                reader.IsDBNull(gaugeNumberOrdinal) ? "N/A" : reader.GetString(gaugeNumberOrdinal),
                            SizeRange = reader.IsDBNull(sizeRangeOrdinal) ? "N/A" : reader.GetString(sizeRangeOrdinal),
                            Description =
                                reader.IsDBNull(descriptionOrdinal) ? "N/A" : reader.GetString(descriptionOrdinal),
                            HeldBy = reader.IsDBNull(holderOrdinal) ? "N/A" : reader.GetString(holderOrdinal)
                        };

                        calibCmd.Parameters.Clear();
                        calibCmd.Parameters.AddWithValue("@prm1", gauge.GaugeNumber);

                        using (var calibReader = calibCmd.ExecuteReader())
                        {
                            if (calibReader.Read())
                            {
                                if (!calibReader.IsDBNull(0))
                                {
                                    var calibrationDate = calibReader.GetDateTime(0);
                                    var frequency = calibReader.IsDBNull(1) ? 12 : calibReader.GetInt32(1);

                                    var dueDate = calibrationDate.AddMonths(frequency);

                                    if (dueDate.Month == DateTime.Today.Month && dueDate.Year == DateTime.Today.Year ||
                                        dueDate < DateTime.Now)
                                    {
                                        gauge.CalibrationDueOn = dueDate;
                                        gauges.Add(gauge);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return gauges;
        }
    }
}