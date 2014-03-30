#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public sealed class OperationsViewPresenter
    {
        private readonly IOperationsView _operationsView;

        public OperationsViewPresenter(IOperationsView operationsView)
        {
            _operationsView = operationsView;

            _operationsView.AddMethod += OperationsView_AddMethod;
            _operationsView.EditMethod += OperationsView_EditMethod;

            _operationsView.AddOperation += _operationsView_AddOperation;
            _operationsView.EditOperation += _operationsView_EditOperation;

            _operationsView.ReloadMethods += OperationsView_ReloadMethods;
            _operationsView.MethodSelected += OperationsView_MethodSelected;
        }

        private void _operationsView_EditOperation(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageOperations, true)) {
                return;
            }

            try {
                Form parentForm = ((UserControl) _operationsView).ParentForm;

                using (var operationDialog = new EditOperationDialog(_operationsView.SelectedOperation)) {
                    if (operationDialog.ShowDialog(parentForm) != DialogResult.OK) {
                        return;
                    }

                    using (BusyCursor.Show()) {
                        using (var cpe = new CPEUnitOfWork()) {
                            Operation opToEdit = cpe.Operations.GetById(_operationsView.SelectedOperation.Id);

                            opToEdit.CycleTime = operationDialog.CycleTime;
                            opToEdit.Description = operationDialog.Description;
                            opToEdit.MachineGroupId = operationDialog.SelectedMachineGroup.Id;
                            opToEdit.ModifiedBy = Session.CurrentEmployee.Id;
                            opToEdit.Sequence = operationDialog.Sequence;
                            opToEdit.SetupTime = operationDialog.SetupTime;

                            cpe.Operations.Update(opToEdit);

                            cpe.Commit();

                            ReloadOperations();
                        }
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void _operationsView_AddOperation(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageOperations, true)) {
                return;
            }

            try {
                Operation newOperation;

                using (var operationDialog = new EditOperationDialog()) {
                    Form parentForm = ((UserControl) _operationsView).ParentForm;

                    if (operationDialog.ShowDialog(parentForm) != DialogResult.OK) {
                        return;
                    }

                    newOperation = new Operation();
                    newOperation.MethodId = _operationsView.SelectedMethod.Id;
                    newOperation.Description = operationDialog.Description;
                    newOperation.Sequence = operationDialog.Sequence;
                    newOperation.SetupTime = operationDialog.SetupTime;
                    newOperation.CycleTime = operationDialog.CycleTime;
                    newOperation.MachineGroupId = operationDialog.SelectedMachineGroup.Id;
                    newOperation.CreatedBy = Session.CurrentEmployee.Id;
                    newOperation.ModifiedBy = Session.CurrentEmployee.Id;
                }

                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        cpe.Operations.Add(newOperation);
                        cpe.Commit();
                    }
                }

                ReloadOperations();
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void OperationsView_AddMethod(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageOperations, true)) {
                return;
            }

            try {
                Method newMethod;

                using (var methodDialog = new EditMethodDialog()) {
                    Form parentForm = ((UserControl) _operationsView).ParentForm;

                    if (methodDialog.ShowDialog(parentForm) != DialogResult.OK) {
                        return;
                    }

                    newMethod = new Method();
                    newMethod.Description = methodDialog.Description;
                    newMethod.IsPreferred = methodDialog.IsPreferred;
                    newMethod.PartVersionId = _operationsView.CurrentPartVersion.Id;
                    newMethod.CreatedBy = Session.CurrentEmployee.Id;
                    newMethod.ModifiedBy = Session.CurrentEmployee.Id;
                }

                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        cpe.Methods.Add(newMethod);
                        cpe.Commit();

                        if (newMethod.IsPreferred) {
                            EnsureOnlyOnePreferredMethod(newMethod, cpe);
                        }
                    }
                }

                ReloadMethods();
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void OperationsView_EditMethod(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageOperations, true)) {
                return;
            }

            try {
                using (var methodDialog = new EditMethodDialog(_operationsView.SelectedMethod)) {
                    Form parentForm = ((UserControl) _operationsView).ParentForm;

                    if (methodDialog.ShowDialog(parentForm) != DialogResult.OK) {
                        return;
                    }

                    using (BusyCursor.Show()) {
                        using (var cpe = new CPEUnitOfWork()) {
                            Method methodToEdit = cpe.Methods.GetById(_operationsView.SelectedMethod.Id);
                            methodToEdit.Description = methodDialog.Description;
                            methodToEdit.IsPreferred = methodDialog.IsPreferred;

                            cpe.Methods.Update(methodToEdit);
                            cpe.Commit();

                            if (methodToEdit.IsPreferred) {
                                EnsureOnlyOnePreferredMethod(methodToEdit, cpe);
                            }
                        }
                    }
                }

                ReloadMethods();
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void OperationsView_ReloadMethods(object sender, EventArgs e)
        {
            ReloadMethods();
        }

        private void OperationsView_MethodSelected(object sender, MethodEventArgs e)
        {
            ReloadOperations();
        }

        private void GetOperationsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                var method = (Method) e.Argument;

                using (var cpe = new CPEUnitOfWork()) {
                    IOrderedEnumerable<Operation> ops = cpe.Operations.GetByMethod(method).OrderBy(op => op.Sequence);

                    e.Result = ops;
                }
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private void GetOperationsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                _operationsView.DisplayOperations(null);
                return;
            }

            var ops = (IEnumerable<Operation>) e.Result;

            _operationsView.DisplayOperations(ops);
        }

        private void GetMethodsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                var partVersion = (PartVersion) e.Argument;

                using (var cpe = new CPEUnitOfWork()) {
                    IOrderedEnumerable<Method> methods = cpe.Methods.GetByPartVersion(partVersion)
                        .OrderByDescending(method => method.IsPreferred);

                    e.Result = methods;
                }
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private void GetMethodsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                _operationsView.DisplayMethods(null);
                return;
            }

            var methods = (IEnumerable<Method>) e.Result;

            _operationsView.DisplayMethods(methods);
        }

        private void EnsureOnlyOnePreferredMethod(Method prefferedMethod, CPEUnitOfWork cpe)
        {
            IEnumerable<Method> otherMethods = cpe.Methods.GetByPartVersion(_operationsView.CurrentPartVersion)
                .Where(m => m.Id != prefferedMethod.Id);

            foreach (Method method in otherMethods) {
                method.IsPreferred = false;
                cpe.Methods.Update(method);
            }

            cpe.Commit();
        }

        private void ReloadMethods()
        {
            var getMethodsWorker = new BackgroundWorker();

            getMethodsWorker.DoWork += GetMethodsWorker_DoWork;
            getMethodsWorker.RunWorkerCompleted += GetMethodsWorker_RunWorkerCompleted;

            getMethodsWorker.RunWorkerAsync(_operationsView.CurrentPartVersion);
        }

        private void ReloadOperations()
        {
            var getOperationsWorker = new BackgroundWorker();

            getOperationsWorker.DoWork += GetOperationsWorker_DoWork;
            getOperationsWorker.RunWorkerCompleted += GetOperationsWorker_RunWorkerCompleted;

            getOperationsWorker.RunWorkerAsync(_operationsView.SelectedMethod);
        }

        private void HandleException(Exception ex)
        {
            string message;

            if (ex is DataProviderException) {
                var dataEx = ex as DataProviderException;

                message = dataEx.Error == DataProviderError.UniqueConstraintViolation
                    ? "An operation already exists at this sequence!"
                    : ex.Message;
            }
            else {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _operationsView.DialogService.ShowError(message);
        }
    }
}