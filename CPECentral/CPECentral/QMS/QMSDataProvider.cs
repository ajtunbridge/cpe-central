#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using CPECentral.QMS.Model;

#endregion

namespace CPECentral.QMS
{
    public class QMSDataProvider
    {
        private readonly OleDbConnection _connection;

        public QMSDataProvider()
        {
            _connection =
                new OleDbConnection(
                    @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\SJCSRV1\Data\Quality\QMS DATABASE2008.mdb;Persist Security Info=False;");
        }

        public bool HasNonConformances(string drawingNumber)
        {
            const string query =
                "SELECT COUNT([Reject Report Number]) FROM [Customer complaints] WHERE [Part Number] LIKE '%' + @prm1 + '%'";

            var cmd = new OleDbCommand(query, _connection);
            cmd.Parameters.AddWithValue("@prm1", drawingNumber);

            try {
                _connection.Open();

                var count = (int) cmd.ExecuteScalar();
                return count > 0;
            }
            finally {
                if (_connection.State == ConnectionState.Open) {
                    _connection.Close();
                }
            }
        }

        public IEnumerable<NonConformance> GetNonConformances(string drawingNumber)
        {
            var results = new List<NonConformance>();

            const string query = "SELECT * FROM [Customer complaints] WHERE [Part Number] LIKE '%' + @prm1 + '%'";

            var cmd = new OleDbCommand(query, _connection);
            cmd.Parameters.AddWithValue("@prm1", drawingNumber);

            try {
                _connection.Open();

                using (OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
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

                    while (reader.Read()) {
                        var nc = new NonConformance {
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
            finally {
                if (_connection.State == ConnectionState.Open) {
                    _connection.Close();
                }
            }

            return results;
        }
    }
}