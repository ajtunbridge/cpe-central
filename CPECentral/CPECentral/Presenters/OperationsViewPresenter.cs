#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Views;

#endregion

namespace CPECentral.Presenters
{
    public sealed class OperationsViewPresenter
    {
        private readonly IOperationsView _operationsView;

        public OperationsViewPresenter(IOperationsView operationsView)
        {
            _operationsView = operationsView;

            _operationsView.ReloadMethods += OperationsView_ReloadMethods;
            _operationsView.MethodSelected += OperationsView_MethodSelected;
        }

        private void OperationsView_ReloadMethods(object sender, EventArgs e)
        {
            var getMethodsWorker = new BackgroundWorker();

            getMethodsWorker.DoWork += GetMethodsWorker_DoWork;
            getMethodsWorker.RunWorkerCompleted += GetMethodsWorker_RunWorkerCompleted;

            getMethodsWorker.RunWorkerAsync(_operationsView.CurrentPartVersion);
        }

        private void OperationsView_MethodSelected(object sender, MethodEventArgs e)
        {
            var getOperationsWorker = new BackgroundWorker();

            getOperationsWorker.DoWork += GetOperationsWorker_DoWork;
            getOperationsWorker.RunWorkerCompleted += GetOperationsWorker_RunWorkerCompleted;

            getOperationsWorker.RunWorkerAsync(_operationsView.SelectedMethod);
        }

        private void GetOperationsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var method = (Method) e.Argument;

                using (var uow = new UnitOfWork())
                {
                    var ops = uow.Operations.GetByMethod(method).OrderBy(op => op.Sequence);

                    e.Result = ops;
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void GetOperationsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                HandleException(e.Result as Exception);
                _operationsView.DisplayOperations(null);
                return;
            }

            var ops = (IEnumerable<Operation>)e.Result;

            _operationsView.DisplayOperations(ops);
        }

        private void GetMethodsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var partVersion = (PartVersion) e.Argument;

                using (var uow = new UnitOfWork())
                {
                    var methods = uow.Methods.GetByPartVersion(partVersion)
                                     .OrderByDescending(method => method.IsPreferred);

                    e.Result = methods;
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void GetMethodsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                HandleException(e.Result as Exception);
                _operationsView.DisplayMethods(null);
                return;
            }

            var methods = (IEnumerable<Method>) e.Result;

            _operationsView.DisplayMethods(methods);
        }

        private void HandleException(Exception ex)
        {
            string message;

            if (ex is DataProviderException)
            {
                message = ex.Message;
            }
            else
            {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _operationsView.DialogService.ShowError(message);
        }
    }
}