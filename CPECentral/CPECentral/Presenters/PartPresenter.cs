#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.QMS;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class PartPresenter
    {
        private readonly IPartView _partView;

        public PartPresenter(IPartView partView)
        {
            _partView = partView;

            _partView.ReloadData += _partView_ReloadData;
            _partView.SelectedVersionChanged += _partView_SelectedVersionChanged;
            _partView.SetPartVersionPhoto += _partView_SetPartVersionPhoto;
            _partView.RemovePartVersionPhoto += _partView_RemovePartVersionPhoto;
            _partView.CheckForNonConformances += _partView_CheckForNonConformances;
        }

        private void _partView_CheckForNonConformances(object sender, EventArgs e)
        {
            var checkForNonConformanceWorker = new BackgroundWorker();

            checkForNonConformanceWorker.DoWork += (obj, args) => {
                try {
                    var qms = new QMSDataProvider();
                    args.Result = qms.HasComplaints(_partView.Part.DrawingNumber);
                }
                catch (Exception ex) {
                    args.Result = ex;
                }
            };

            checkForNonConformanceWorker.RunWorkerCompleted += (obj, args) => {
                bool hasNonConformances = false;

                if (args.Result is Exception) {
                    var ex = args.Result as Exception;
                    HandleException(ex);
                }
                else {
                    hasNonConformances = (bool) args.Result;
                }

                _partView.FinishedNonConformanceCheck(hasNonConformances);
            };

            checkForNonConformanceWorker.RunWorkerAsync();
        }

        private void _partView_RemovePartVersionPhoto(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageParts, true)) {
                return;
            }

            try {
                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        cpe.Photos.Delete(_partView.SelectedPartVersion);
                        cpe.Commit();
                    }
                }

                Session.PartPartPhotoCache.CreateOrUpdate(_partView.Part.Id, null);

                Session.MessageBus.Publish(new PartVersionPhotoChangedMessage(_partView.SelectedPartVersion));
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void _partView_SetPartVersionPhoto(object sender, EventArgs e)
        {
            if (!AppSecurity.Check(AppPermission.ManageParts, true)) {
                return;
            }

            try {
                Image photoImage = null;

                using (var openFileDialog = new OpenFileDialog()) {
                    openFileDialog.Filter = "Image files|*.jpg;*.jpeg;*.png";
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    openFileDialog.Multiselect = false;
                    if (openFileDialog.ShowDialog() != DialogResult.OK) {
                        return;
                    }
                    Image img = Image.FromFile(openFileDialog.FileName);

                    using (var photoEditorDialog = new PhotoEditorDialog(img))
                    {
                        if (photoEditorDialog.ShowDialog(_partView.ParentForm) != DialogResult.OK) 
                        {
                            return;
                        }

                        img = photoEditorDialog.EditedImage;
                    }

                    photoImage = Session.ResizePhoto(img);
                }

                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        using (var ms = new MemoryStream()) {
                            photoImage.Save(ms, ImageFormat.Jpeg);
                            cpe.Photos.Set(_partView.SelectedPartVersion, ms.ToArray());
                            cpe.Commit();
                        }
                    }
                }

                Session.PartPartPhotoCache.CreateOrUpdate(_partView.Part.Id, photoImage);

                Session.MessageBus.Publish(new PartVersionPhotoChangedMessage(_partView.SelectedPartVersion));
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void _partView_SelectedVersionChanged(object sender, PartVersionEventArgs e)
        {
            try {
                using (var cpe = new CPEUnitOfWork()) {
                    using (BusyCursor.Show()) {
                        IEnumerable<PartVersion> allVersions = cpe.PartVersions.GetByPart(e.PartVersion.PartId);
                        PartVersion latestVersion = allVersions.OrderByDescending(pv => pv.VersionNumber).First();
                        if (e.PartVersion != latestVersion) {
                            _partView.ShowOldVersionWarningPanel();
                        }
                    }
                }
            }
            catch (Exception ex) {
                HandleException(ex);
            }
        }

        private void _partView_ReloadData(object sender, EventArgs e)
        {
            var reloadWorker = new BackgroundWorker();
            reloadWorker.DoWork += reloadWorker_DoWork;
            reloadWorker.RunWorkerCompleted += reloadWorker_RunWorkerCompleted;
            reloadWorker.RunWorkerAsync(_partView.Part);
        }

        private void reloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception) {
                HandleException(e.Result as Exception);
                return;
            }

            var model = e.Result as PartViewModel;

            _partView.DisplayModel(model);

            if (model.IsVersionDifferentToWorksOrder)
                _partView.ShowNewVersionWarningPanel();
        }

        private void reloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                var part = (Part) e.Argument;

                using (var cpe = new CPEUnitOfWork()) {
                    Employee createdBy = cpe.Employees.GetById(part.CreatedBy);
                    Employee modifiedBy = cpe.Employees.GetById(part.ModifiedBy);

                    cpe.RecentParts.AddToRecentParts(Session.CurrentEmployee, part);

                    cpe.Commit();

                    var model = new PartViewModel();
                    model.CreatedBy = createdBy.ToString();
                    model.ModifiedBy = modifiedBy.ToString();

                    using (var tricorn = new Tricorn.TricornDataProvider())
                    {
                        var worder = tricorn.GetWorksOrdersByDrawingNumber(part.DrawingNumber)
                            .OrderByDescending(wo => wo.Delivery)
                            .First();

                        var standardizedVersionNumber = CleanVersionNumber(worder.Drawing_Issue);
                        var latestVersion = cpe.PartVersions.GetLatestVersion(part.Id);
                        if (latestVersion.VersionNumber != standardizedVersionNumber)
                        {
                            model.IsVersionDifferentToWorksOrder = true;
                        }
                    }

                    e.Result = model;
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

            _partView.DialogService.ShowError(message);
        }

        private string CleanVersionNumber(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
            {
                return string.Empty;
            }

            string trimmed = version.Trim();

            bool isNumeric = trimmed.All(char.IsNumber);

            if (isNumeric)
            {
                int issueNumber = int.Parse(trimmed);
                return issueNumber.ToString("D2");
            }

            return trimmed.ToUpper();
        }
    }
}