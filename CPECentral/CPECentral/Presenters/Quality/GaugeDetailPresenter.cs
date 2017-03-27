using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.ViewModels.Quality;
using CPECentral.Views.Quality;
using nGenLibrary;

namespace CPECentral.Presenters.Quality
{
    public sealed class GaugeDetailPresenter
    {
        private readonly GaugeDetailView _view;

        public GaugeDetailPresenter(GaugeDetailView view)
        {
            _view = view;
            _view.GaugeChanged += _view_GaugeChanged;
            _view.SetPhoto += _view_SetPhoto;
            _view.SaveChanges += _view_SaveChanges;
        }

        private void _view_SetPhoto(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.bmp;*.png";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var image = Image.FromFile(dialog.FileName);

            var photoEditor = new PhotoEditorDialog(image);

            if (photoEditor.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var cpe = new CPEUnitOfWork())
            {
                using (var ms = new MemoryStream())
                {
                    photoEditor.EditedImage.Save(ms, ImageFormat.Jpeg);
                    cpe.Photos.Set(_view.CurrentGauge, ms.ToArray());
                    cpe.Commit();
                    _view.Model.Photo = photoEditor.EditedImage;
                }
            }
        }

        private void _view_SaveChanges(object sender, EventArgs e)
        {
            using (BusyCursor.Show())
            {
                using (var cpe = new CPEUnitOfWork())
                {
                    var gauge = _view.CurrentGauge;

                    gauge.Reference = _view.Model.Reference;
                    gauge.GaugeType = _view.Model.GaugeType;
                    gauge.GaugeTypeId = _view.Model.GaugeType.Id;
                    gauge.Name = _view.Model.Name;
                    gauge.IsReferenceOnly = _view.Model.IsReferenceOnly;
                    gauge.HeldBy = _view.Model.HeldBy.Id;
                    gauge.SizeRangeMin = _view.Model.SizeRangeMin;
                    gauge.SizeRangeMax = _view.Model.SizeRangeMax;

                    cpe.Gauges.Update(gauge);
                    
                    cpe.Commit();

                    Session.MessageBus.Publish(new GaugeEditedMessage(gauge));

                    _view.SaveComplete(true);
                }
            }
        }

        private void _view_GaugeChanged(object sender, CustomEventArgs.GaugeEventArgs e)
        {
            using (BusyCursor.Show())
            {
                using (var cpe = new CPEUnitOfWork())
                {
                    var model = new GaugeDetailViewModel();

                    model.Employees = cpe.Employees.GetAll().OrderBy(emp => emp.FirstName).ThenBy(emp => emp.LastName).ToList();
                    model.GaugeTypes = cpe.GaugeTypes.GetAll().OrderBy(g => g.Name).ToList();

                    model.Name = e.Gauge.Name;
                    model.Reference = e.Gauge.Reference;
                    model.GaugeType = cpe.GaugeTypes.GetById(e.Gauge.GaugeTypeId);
                    model.HeldBy = cpe.Employees.GetById(e.Gauge.HeldBy);
                    model.IsReferenceOnly = e.Gauge.IsReferenceOnly;
                    model.SizeRangeMin = e.Gauge.SizeRangeMin;
                    model.SizeRangeMax = e.Gauge.SizeRangeMax;

                    var photo = cpe.Photos.GetByGauge(e.Gauge);

                    if (photo != null)
                    {
                        using (var ms = new MemoryStream(photo))
                        {
                            model.Photo = Image.FromStream(ms);
                        }
                    }

                    // TODO: get calibration date

                    _view.DisplayModel(model);
                }
            }
        }
    }
}
