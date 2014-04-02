#region Using directives

using System;
using System.Threading;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using nGenLibrary.Security;

#endregion

namespace CPECentral
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Session.Initialize();

#if DEBUG
            EnsureThereIsAnAdminAccount();
            AddMyAccount();
#endif

            //ToolGenerator.GenerateMetricHSSDrills();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string msg = e.Exception.InnerException == null ? e.Exception.Message : e.Exception.InnerException.Message;

            MessageBox.Show(msg);
        }

        private static void EnsureThereIsAnAdminAccount()
        {
            try {
                using (var cpe = new CPEUnitOfWork()) {
                    EmployeeGroup adminGroup = cpe.EmployeeGroups.GetByName("BUILTIN_ADMIN_GROUP");

                    if (adminGroup == null) {
                        adminGroup = new EmployeeGroup();
                        adminGroup.Name = "BUILTIN_ADMIN_GROUP";
                        adminGroup.GrantPermission(AppPermission.Administrator);
                        cpe.EmployeeGroups.Add(adminGroup);
                        cpe.Commit();
                    }

                    Employee adminEmployee = cpe.Employees.GetByUserName("admin");

                    if (adminEmployee == null) {
                        adminEmployee = new Employee();
                        adminEmployee.FirstName = "System";
                        adminEmployee.LastName = "Administrator";
                        adminEmployee.UserName = "admin";
                        adminEmployee.EmployeeGroupId = adminGroup.Id;

                        Password securedPassword = Session.GetInstanceOf<IPasswordService>().SecurePassword("5jc3ngltd");

                        adminEmployee.Password = securedPassword.Hash;
                        adminEmployee.Salt = securedPassword.Salt;

                        cpe.Employees.Add(adminEmployee);

                        cpe.Commit();
                    }
                }
            }
            catch (Exception ex) {
                string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                MessageBox.Show(msg);
            }
        }

        private static void AddMyAccount()
        {
            try {
                using (var cpe = new CPEUnitOfWork()) {
                    EmployeeGroup myGroup = cpe.EmployeeGroups.GetByName("Power users");

                    if (myGroup == null) {
                        myGroup = new EmployeeGroup();
                        myGroup.Name = "Power users";
                        myGroup.GrantPermission(AppPermission.ManageDocuments);
                        myGroup.GrantPermission(AppPermission.ManageEmployees);
                        myGroup.GrantPermission(AppPermission.ManageOperations);
                        myGroup.GrantPermission(AppPermission.ManageParts);
                        myGroup.GrantPermission(AppPermission.EditSettings);

                        cpe.EmployeeGroups.Add(myGroup);

                        cpe.Commit();
                    }

                    Employee myEmployee = cpe.Employees.GetByUserName("adam");

                    if (myEmployee == null) {
                        myEmployee = new Employee();
                        myEmployee.FirstName = "Adam";
                        myEmployee.LastName = "Tunbridge";
                        myEmployee.UserName = "adam";
                        myEmployee.EmployeeGroupId = myGroup.Id;

                        Password securedPassword = Session.GetInstanceOf<IPasswordService>().SecurePassword("password");

                        myEmployee.Password = securedPassword.Hash;
                        myEmployee.Salt = securedPassword.Salt;

                        cpe.Employees.Add(myEmployee);

                        cpe.Commit();
                    }
                }
            }
            catch (Exception ex) {
                string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                MessageBox.Show(msg);
            }
        }
    }
}