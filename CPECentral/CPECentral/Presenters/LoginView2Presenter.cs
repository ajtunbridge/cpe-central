using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using CPECentral.Data.EF5;
using CPECentral.Views;

namespace CPECentral.Presenters
{
    public class LoginView2Presenter
    {
        private readonly ILoginView2 _view;

        public LoginView2Presenter(ILoginView2 view)
        {
            _view = view;

            _view.LoadEmployees += _view_LoadEmployees;
        }

        void _view_LoadEmployees(object sender, EventArgs e)
        {
            var loadEmployeesWorker = new BackgroundWorker();

            loadEmployeesWorker.DoWork += (obj, args) => {
                try {
                    using (var cpe = new CPEUnitOfWork()) {
                        var employees = cpe.Employees.GetAll().OrderBy(emp => emp.ToString());
                        args.Result = employees;
                    }
                }
                catch (Exception ex) {
                    args.Result = ex;
                }
            };

            loadEmployeesWorker.RunWorkerCompleted += (obj, args) => {
                if (args.Result is Exception) {
                    var ex = args.Result as Exception;
                    HandleException(ex);
                    _view.DisplayEmployees(null);
                    return;
                }
                var employees = args.Result as IEnumerable<Employee>;
                _view.DisplayEmployees(employees);
            };

            loadEmployeesWorker.RunWorkerAsync();
        }

        private void HandleException(Exception ex)
        {
            string msg = "Unable to connect to the server.\n\nPlease check you configuration and network and try again\n\n";

            msg +=ex.InnerException == null ? ex.Message : ex.InnerException.Message;

            _view.DialogService.ShowError(msg);
        }
    }
}
