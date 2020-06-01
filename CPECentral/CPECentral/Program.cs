#region Using directives

using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using nGenLibrary.Security;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#endregion Using directives

namespace CPECentral
{
    internal static class Program
    {
        private const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            bool createdNew = true;

            using (var mutex = new Mutex(true, "CPECentral", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Session.Initialize();

                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    Application.ThreadException += Application_ThreadException;

                    var form = new MainForm();

                    Application.Run(form);


                    // clean out PDF page extraction temp files
                    var extractedPdfTempPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                          "\\CpeCentral\\pdf_page_extraction_temp\\";

                    foreach (var file in Directory.GetFiles(extractedPdfTempPath))
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            ShowWindow(process.MainWindowHandle, SW_RESTORE);
                            SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string msg = e.Exception.InnerException?.Message ?? e.Exception.Message;

            MessageBox.Show(msg);
        }

        private static void EnsureThereIsAnAdminAccount()
        {
            try
            {
                using (var cpe = new CPEUnitOfWork())
                {
                    EmployeeGroup adminGroup = cpe.EmployeeGroups.GetByName("BUILTIN_ADMIN_GROUP");

                    if (adminGroup == null)
                    {
                        adminGroup = new EmployeeGroup();
                        adminGroup.Name = "BUILTIN_ADMIN_GROUP";
                        adminGroup.GrantPermission(AppPermission.Administrator);
                        cpe.EmployeeGroups.Add(adminGroup);
                        cpe.Commit();
                    }

                    Employee adminEmployee = cpe.Employees.GetByUserName("admin");

                    if (adminEmployee == null)
                    {
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
            catch (Exception ex)
            {
                string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                MessageBox.Show(msg);
            }
        }

        private static void AddMyAccount()
        {
            try
            {
                using (var cpe = new CPEUnitOfWork())
                {
                    EmployeeGroup myGroup = cpe.EmployeeGroups.GetByName("Power users");

                    if (myGroup == null)
                    {
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

                    if (myEmployee == null)
                    {
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
            catch (Exception ex)
            {
                string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                MessageBox.Show(msg);
            }
        }
    }
}