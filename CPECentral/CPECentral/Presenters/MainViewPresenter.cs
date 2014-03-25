#region Using directives

using System;
using System.Windows.Forms;
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
        private readonly IMainView _mainView;

        public MainViewPresenter(IMainView mainView)
        {
            _mainView = mainView;

            _mainView.AddPart += mainView_AddPart;
            _mainView.LoadHexagonCalculator += mainView_LoadHexagonCalculator;
            _mainView.LoadSettingsDialog += mainView_LoadSettingsDialog;
            _mainView.LoadToolManagementDialog += _mainView_LoadToolManagementDialog;
        }

        void _mainView_LoadToolManagementDialog(object sender, EventArgs e)
        {
            using (var toolManagementDialog = new ToolManagementDialog()) {
                toolManagementDialog.ShowDialog(_mainView.ParentForm);
            }
        }

        private void mainView_LoadSettingsDialog(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.EditSettings, true)) {
                return;
            }

            using (var settingsDialog = new SettingsDialog()) {
                settingsDialog.ShowDialog(_mainView.ParentForm);
            }
        }

        private void mainView_LoadHexagonCalculator(object sender, EventArgs e)
        {
            using (var dialog = new HexDiaCalculatorDialog()) {
                dialog.ShowDialog(_mainView.ParentForm);
            }
        }

        private void mainView_AddPart(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageParts, true)) {
                return;
            }

            using (var addPartDialog = new AddPartDialog()) {
                var parent = ((UserControl) _mainView).ParentForm;

                if (addPartDialog.ShowDialog(parent) != DialogResult.OK) {
                    return;
                }

                try {
                    using (BusyCursor.Show()) {
                        using (var uow = new UnitOfWork()) {
                            uow.BeginTransaction();

                            var part = new Part();

                            if (addPartDialog.IsNewCustomer) {
                                var customer = new Customer();
                                customer.Name = addPartDialog.NewCustomerName;
                                customer.CreatedBy = Session.CurrentEmployee.Id;
                                customer.ModifiedBy = Session.CurrentEmployee.Id;

                                uow.Customers.Add(customer);

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

                            uow.Parts.Add(part);

                            var version = new PartVersion();
                            version.Part = part;
                            version.VersionNumber = addPartDialog.VersionNumber;
                            version.CreatedBy = Session.CurrentEmployee.Id;
                            version.ModifiedBy = Session.CurrentEmployee.Id;

                            uow.PartVersions.Add(version);

                            uow.Commit();

                            Session.MessageBus.Publish(new PartAddedMessage(part));

                            foreach (var file in addPartDialog.FilesToImport) {
                                Session.DocumentService.QueueUpload(file, version);
                            }
                        }
                    }
                }
                catch (DataProviderException dataEx) {
                    var msg = dataEx.Error == DataProviderError.UniqueConstraintViolation
                        ? "A part with these details already exists in the system!"
                        : dataEx.Message;
                    _mainView.DialogService.ShowError(msg);
                }
                catch (Exception ex) {
                    var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                    _mainView.DialogService.ShowError(msg);
                }
            }
        }
    }
}