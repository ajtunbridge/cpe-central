#region Using directives

using System;
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

            EnsureThereIsAnAdminAccount();

            Application.Run(new MainForm());
        }

        private static void EnsureThereIsAnAdminAccount()
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var adminGroup = uow.EmployeeGroups.GetByName("BUILTIN_ADMIN_GROUP");

                    if (adminGroup == null)
                    {
                        adminGroup = new EmployeeGroup();
                        adminGroup.Name = "BUILTIN_ADMIN_GROUP";
                        adminGroup.GrantPermission(Data.EF5.ApplicationPermission.Administrator);
                        uow.EmployeeGroups.Add(adminGroup);
                        uow.Commit();
                    }

                    var adminEmployee = uow.Employees.GetByUserName("admin");

                    if (adminEmployee == null)
                    {
                        adminEmployee = new Employee();
                        adminEmployee.FirstName = "System";
                        adminEmployee.LastName = "Administrator";
                        adminEmployee.UserName = "admin";
                        adminEmployee.EmployeeGroupId = adminGroup.Id;

                        var securedPassword = Session.GetInstanceOf<IPasswordService>().SecurePassword("5jc3ngltd");

                        adminEmployee.Password = securedPassword.Hash;
                        adminEmployee.Salt = securedPassword.Salt;

                        uow.Employees.Add(adminEmployee);

                        uow.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}