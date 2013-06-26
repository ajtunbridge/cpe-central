using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.Views;
using nGenLibrary;

namespace CPECentral.Presenters
{
    public class MainViewPresenter
    {
        private readonly IMainView _mainView;

        public MainViewPresenter(IMainView mainView)
        {
            _mainView = mainView;
            _mainView.AddPart += _mainView_AddPart;
        }

        void _mainView_AddPart(object sender, EventArgs e)
        {
            using (var addPartDialog = new AddPartDialog())
            {
                var parent = ((UserControl) _mainView).ParentForm;

                if (addPartDialog.ShowDialog(parent) != DialogResult.OK)
                    return;

                try
                {
                    using (BusyCursor.Show())
                    {
                        using (var uow = new UnitOfWork())
                        {
                            uow.BeginTransaction();

                            var part = new Part();

                            if (addPartDialog.IsNewCustomer)
                            {
                                var customer = new Customer();
                                customer.Name = addPartDialog.NewCustomerName;
                                customer.CreatedBy = Session.CurrentEmployee.Id;
                                customer.ModifiedBy = Session.CurrentEmployee.Id;

                                uow.Customers.Add(customer);

                                part.Customer = customer;
                            }
                            else
                            {
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

                            foreach (var file in addPartDialog.FilesToImport)
                            {
                                Session.DocumentService.QueueUpload(file, version);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string message;

                    if (ex is DataProviderException)
                        message = ex.Message;
                    else
                        message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                    _mainView.DialogService.ShowError(message);
                }
            }
        }
    }
}
