#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;

            _view.AddNewPart += _view_AddNewPart;
            _view.LoadToolManagementDialog += _view_LoadToolManagementDialog;
            _view.RetrieveEmployeeAccounts += _view_RetrieveEmployeeAccounts;
            _view.LoadSettingsDialog += _view_LoadSettingsDialog;
            _view.LoadSuperDumpDialog += _view_LoadSuperDumpDialog;
        }

        private void _view_LoadSuperDumpDialog(object sender, EventArgs e)
        {
            using (var dialog = new SuperDumpDialog())
            {
                dialog.ShowDialog(_view.ParentForm);
            }
        }

        void _view_LoadSettingsDialog(object sender, EventArgs e)
        {
            using (var dialog = new SettingsDialog())
            {
                dialog.ShowDialog(_view.ParentForm);
            }
        }

        void _view_LoadToolManagementDialog(object sender, EventArgs e)
        {
            using (var dialog = new ToolManagementDialog()) {
                dialog.ShowDialog(_view.ParentForm);
            }
        }

        private void _view_AddNewPart(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageParts, true)) {
                return;
            }

            using (var addPartDialog = new AddPartDialog()) {
                addPartDialog.ShowDialog(_view.ParentForm);
            }
        }

        private void _view_RetrieveEmployeeAccounts(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();

            worker.DoWork += (o, args) => {
                try {
                    using (var cpe = new CPEUnitOfWork()) {
                        IOrderedEnumerable<Employee> employees = cpe.Employees.GetAll()
                            .Where(emp => emp.UserName != "admin")
                            .Where(emp => emp.IsEnabled)
                            .Where(emp => emp.Id != Session.CurrentEmployee.Id)
                            .OrderBy(emp => emp.FirstName);
                        args.Result = employees;
                    }
                }
                catch (Exception ex) {
                    args.Result = ex;
                }
            };

            worker.RunWorkerCompleted += (o, args) => {
                if (args.Result is Exception) {
                    HandleException(args.Result as Exception);
                    return;
                }
                var employees = args.Result as IEnumerable<Employee>;
                _view.PopulateSwitchUserDropDownButton(employees);
            };

            worker.RunWorkerAsync();
        }

        private void AddNewPart(AddPartDialog addPartDialog)
        {
            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        cpe.BeginTransaction();

                        var part = new Part();

                        if (addPartDialog.IsNewCustomer) {
                            var customer = new Customer();
                            customer.Name = addPartDialog.NewCustomerName;
                            customer.CreatedBy = Session.CurrentEmployee.Id;
                            customer.ModifiedBy = Session.CurrentEmployee.Id;

                            cpe.Customers.Add(customer);

                            part.Customer = customer;
                        }
                        else {
                            part.CustomerId = addPartDialog.SelectedCustomer.Id;
                        }

                        part.DrawingNumber = addPartDialog.DrawingNumber;
                        part.Name = addPartDialog.PartName;
                        part.ToolingLocation = addPartDialog.ToolingLocation;
                        part.CreatedBy = Session.CurrentEmployee.Id;
                        part.ModifiedBy = Session.CurrentEmployee.Id;

                        cpe.Parts.Add(part);

                        var version = new PartVersion();
                        version.Part = part;
                        version.VersionNumber = addPartDialog.VersionNumber;
                        version.CreatedBy = Session.CurrentEmployee.Id;
                        version.ModifiedBy = Session.CurrentEmployee.Id;

                        cpe.PartVersions.Add(version);

                        cpe.Commit();

                        Session.MessageBus.Publish(new PartAddedMessage(part));

                        foreach (string file in addPartDialog.FilesToImport) {
                            Session.DocumentService.QueueUpload(file, version);
                        }

                        Session.MessageBus.Publish(new LoadPartMessage(part));
                    }
                }
            }
            catch (DataProviderException dataEx) {
                string msg = dataEx.Error == DataProviderError.UniqueConstraintViolation
                    ? "A part with these details already exists in the system!"
                    : dataEx.Message;
                _view.DialogService.ShowError(msg);
            }
            catch (Exception ex) {
                string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                _view.DialogService.ShowError(msg);
            }
        }

        private void HandleException(Exception ex)
        {
            string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

            _view.DialogService.ShowError(msg);
        }
    }
}