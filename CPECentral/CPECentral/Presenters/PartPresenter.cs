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

                    photoImage = ResizePartVersionImageToStandardResolution(img);
                }

                using (BusyCursor.Show()) {
                    using (var cpe = new CPEUnitOfWork()) {
                        using (var ms = new MemoryStream()) {
                            photoImage.Save(ms, ImageFormat.Jpeg);
                            cpe.Photos.Add(_partView.SelectedPartVersion, ms.ToArray());
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
                            _partView.ShowVersionWarning();
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

                    e.Result = model;
                }
            }
            catch (Exception ex) {
                e.Result = ex;
            }
        }

        private Image ResizePartVersionImageToStandardResolution(Image image)
        {
            double ratioX = 640.0d/image.Width;
            double ratioY = 480.0d/image.Height;

            double ratio = ratioX < ratioY ? ratioX : ratioY;

            int newHeight = Convert.ToInt32(image.Height*ratio);
            int newWidth = Convert.ToInt32(image.Width*ratio);

            var destRect = new Rectangle(0, 0, newWidth, newHeight);
            var destImage = new Bitmap(newWidth, newHeight);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
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
    }
}