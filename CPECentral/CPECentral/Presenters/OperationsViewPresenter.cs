#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
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

            _operationsView.ReloadData += OperationsViewReloadData;
        }

        private void OperationsViewReloadData(object sender, EventArgs e)
        {
            var getOperationsWorker = new BackgroundWorker();
            getOperationsWorker.DoWork += GetOperationsWorker_DoWork;
            getOperationsWorker.RunWorkerCompleted += GetOperationsWorker_RunWorkerCompleted;
            getOperationsWorker.RunWorkerAsync(_operationsView.CurrentMethod);
        }

        private void GetOperationsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                HandleException(e.Result as Exception);
                _operationsView.DisplayOperations(null);
                return;
            }

            var operations = (IEnumerable<Operation>) e.Result;

            _operationsView.DisplayOperations(operations);
        }

        private void GetOperationsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var currentMethod = (Method) e.Argument;

                var uow = new UnitOfWork();

                var operations = uow.Operations.GetByMethod(currentMethod)
                                    .OrderBy(op => op.Sequence);

                e.Result = operations;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
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