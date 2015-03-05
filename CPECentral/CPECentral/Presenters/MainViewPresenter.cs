#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class MainViewPresenter
    {
        private readonly IMainView _view;

        public MainViewPresenter(IMainView view)
        {
            _view = view;

            _view.AddPart += View_AddPart;
            _view.AddPartByWorksOrder += View_AddPartByWorksOrder;
            _view.LoadHexagonCalculator += View_LoadHexagonCalculator;
            _view.LoadSettingsDialog += View_LoadSettingsDialog;
            _view.LoadToolManagementDialog += View_LoadToolManagementDialog;
        }

        private void View_LoadToolManagementDialog(object sender, EventArgs e)
        {
            using (var toolManagementDialog = new ToolManagementDialog()) {
                toolManagementDialog.ShowDialog(_view.ParentForm);
            }
        }

        private void View_LoadSettingsDialog(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.EditSettings, true)) {
                return;
            }

            using (var settingsDialog = new SettingsDialog()) {
                settingsDialog.ShowDialog(_view.ParentForm);
            }
        }

        private void View_LoadHexagonCalculator(object sender, EventArgs e)
        {
            using (var dialog = new HexDiaCalculatorDialog()) {
                dialog.ShowDialog(_view.ParentForm);
            }
        }

        private void View_AddPart(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageParts, true)) {
                return;
            }

            using (var addPartDialog = new AddPartDialog()) {
                Form parent = _view.ParentForm;

                if (addPartDialog.ShowDialog(parent) != DialogResult.OK) {
                    return;
                }

                AddNewPart(addPartDialog);
            }
        }

        private void View_AddPartByWorksOrder(object sender, StringEventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageParts, true)) {
                return;
            }

            using (var addPartDialog = new AddPartDialog(e.Value)) {
                Form parent = _view.ParentForm;

                if (addPartDialog.ShowDialog(parent) != DialogResult.OK) {
                    return;
                }

                AddNewPart(addPartDialog);
            }
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
    }
}