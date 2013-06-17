#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
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

            //EnsureThereIsAnAdminAccount();
            //AddMyAccount();

            Application.Run(new AddPartDialog());
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
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                MessageBox.Show(msg);
            }
        }

        private static void AddMyAccount()
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var myGroup = uow.EmployeeGroups.GetByName("Power users");

                    if (myGroup == null)
                    {
                        myGroup = new EmployeeGroup();
                        myGroup.Name = "Power users";
                        myGroup.GrantPermission(ApplicationPermission.ManageDocuments);
                        myGroup.GrantPermission(ApplicationPermission.ManageEmployees);
                        myGroup.GrantPermission(ApplicationPermission.ManageOperations);
                        myGroup.GrantPermission(ApplicationPermission.ManageParts);

                        uow.EmployeeGroups.Add(myGroup);

                        uow.Commit();
                    }

                    var myEmployee = uow.Employees.GetByUserName("adam");

                    if (myEmployee == null)
                    {
                        myEmployee = new Employee();
                        myEmployee.FirstName = "Adam";
                        myEmployee.LastName = "Tunbridge";
                        myEmployee.UserName = "adam";
                        myEmployee.EmployeeGroupId = myGroup.Id;

                        var securedPassword = Session.GetInstanceOf<IPasswordService>().SecurePassword("hA7p6p0Y13");

                        myEmployee.Password = securedPassword.Hash;
                        myEmployee.Salt = securedPassword.Salt;

                        uow.Employees.Add(myEmployee);

                        uow.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                MessageBox.Show(msg);
            }
        }
    }
}