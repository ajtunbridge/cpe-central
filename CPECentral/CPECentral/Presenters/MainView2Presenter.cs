#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CPECentral.Data.EF5;
using CPECentral.Views;

#endregion

namespace CPECentral.Presenters
{
    public class MainView2Presenter
    {
        private readonly IMainView2 _view;

        public MainView2Presenter(IMainView2 view)
        {
            _view = view;

            _view.RetrieveEmployeeAccounts += _view_RetrieveEmployeeAccounts;
        }

        private void _view_RetrieveEmployeeAccounts(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker();

            worker.DoWork += (o, args) => {
                try {
                    using (var cpe = new CPEUnitOfWork()) {
                        IOrderedEnumerable<Employee> employees = cpe.Employees.GetAll()
                            .Where(emp => emp.UserName != "admin")
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

        private void HandleException(Exception ex)
        {
            string msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

            _view.DialogService.ShowError(msg);
        }
    }
}