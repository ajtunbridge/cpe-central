#region Using directives

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Commands;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public sealed class PartInformationViewPresenter
    {
        private readonly IPartInformationView _partInformationView;

        public PartInformationViewPresenter(IPartInformationView partInformationView)
        {
            _partInformationView = partInformationView;

            _partInformationView.ReloadData += PartInformationView_ReloadData;
            _partInformationView.SaveChanges += _partInformationView_SaveChanges;
            _partInformationView.CreateNewVersion += _partInformationView_CreateNewVersion;
        }

        private void _partInformationView_CreateNewVersion(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageParts)) {
                return;
            }

            try {
                using (var cpe = new CPEUnitOfWork()) {
                    PartVersion latestVersion;

                    using (BusyCursor.Show()) {
                        latestVersion = cpe.PartVersions.GetLatestVersion(_partInformationView.Part);
                    }

                    bool isNumeric = latestVersion.VersionNumber.All(char.IsNumber);

                    string estimatedVersionNumber = string.Empty;

                    if (isNumeric) {
                        int number = Convert.ToInt32(latestVersion.VersionNumber);
                        int incrementedNumber = number + 1;
                        estimatedVersionNumber = incrementedNumber.ToString("D2");
                    }
                    else {
                        // if it's a single letter, work out what the next letter is
                        if (latestVersion.VersionNumber.Length == 1) {
                            char c = Convert.ToChar(latestVersion.VersionNumber[0]);
                            estimatedVersionNumber += (char) (c + 1);
                        }
                    }

                    var newVersionDialog = new NewVersionDialog(estimatedVersionNumber);

                    if (newVersionDialog.ShowDialog(_partInformationView.ParentForm) != DialogResult.OK) {
                        return;
                    }

                    var newVersionCommand = new NewVersionCommand();

                    using (BusyCursor.Show()) {
                        newVersionCommand.Execute(_partInformationView.Part, newVersionDialog.VersionNumber,
                            newVersionDialog.CopyMethodsAndOperations, newVersionDialog.CopyToolLists,
                            newVersionDialog.CopyOperationDocuments);
                    }
                }

                _partInformationView.LoadPart(_partInformationView.Part);
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void _partInformationView_SaveChanges(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageParts, true)) {
                return;
            }

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        Part part = _partInformationView.Part;

                        part.ModifiedBy = Session.CurrentEmployee.Id;

                        cpe.Parts.Update(part);

                        cpe.Commit();
                    }
                }

                _partInformationView.SaveCompleted(true);
            }
            catch (Exception ex) {
                HandleException(ex);

                _partInformationView.SaveCompleted(false);
            }
        }

        private void PartInformationView_ReloadData(object sender, EventArgs e)
        {
            var getDataWorker = new BackgroundWorker();
            getDataWorker.DoWork += getDataWorker_DoWork;
            getDataWorker.RunWorkerCompleted += getDataWorker_RunWorkerCompleted;

            getDataWorker.RunWorkerAsync(_partInformationView.Part);
        }

        private void getDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                _partInformationView.DisplayModel(null);
                return;
            }

            var model = (PartInformationViewModel) e.Result;

            _partInformationView.DisplayModel(model);
        }

        private void getDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                using (BusyCursor.Show()) {
                    var part = (Part) e.Argument;

                    using (var cpe = new CPEUnitOfWork()) {
                        Customer customer = cpe.Customers.GetById(part.CustomerId);
                        IOrderedEnumerable<PartVersion> versions =
                            cpe.PartVersions.GetByPart(part).OrderByDescending(v => v.VersionNumber);

                        var model = new PartInformationViewModel();
                        model.AllVersions = versions;
                        model.Customer = customer.Name;
                        model.DrawingNumber = part.DrawingNumber;
                        model.Name = part.Name;
                        model.ToolingLocation = part.ToolingLocation;
                        model.ReadOnly = !AppSecurity.Check(AppPermission.ManageParts, false);

                        e.Result = model;
                    }
                }
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private void HandleException(Exception ex)
        {
            string message;

            if (ex is DataProviderException) {
                message = ex.Message;
            }
            else {
                message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            _partInformationView.DialogService.ShowError(message);
        }
    }
}