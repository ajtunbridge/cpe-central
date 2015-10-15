#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

#endregion

namespace CPECentral.Presenters
{
    public class StartPageUserInfoPresenter
    {
        private readonly IStartPageUserInfoView _view;

        public StartPageUserInfoPresenter(IStartPageUserInfoView view)
        {
            _view = view;

            _view.RefreshRecentPartsList += _view_RefreshRecentPartsList;
            _view.ChangeEmployeePassword += _view_ChangeEmployeePassword;
        }

        private void _view_ChangeEmployeePassword(object sender, EventArgs e)
        {
            using (var passwordDialog = new SetPasswordDialog()) {
                passwordDialog.ShowDialog(_view.ParentForm);
            }
        }

        private void _view_RefreshRecentPartsList(object sender, EventArgs e)
        {
            using (BusyCursor.Show()) {
                using (var cpe = new CPEUnitOfWork()) {
                    IEnumerable<Part> recentParts = cpe.RecentParts.GetRecentParts(Session.CurrentEmployee);

                    var model = new List<RecentPartsViewModel>();
                    foreach (Part part in recentParts) {
                        var item = new RecentPartsViewModel();
                        item.Part = part;
                        PartVersion currentVersion = cpe.PartVersions.GetLatestVersion(part);

                        byte[] photoBytes = cpe.Photos.GetByPartVersion(currentVersion);

                        if (photoBytes != null) {
                            using (var ms = new MemoryStream(photoBytes)) {
                                Session.PartPartPhotoCache.CreateOrUpdate(part.Id, Image.FromStream(ms));
                            }
                        }
                        model.Add(item);
                    }
                    _view.DisplayRecentParts(model);
                }
            }
        }
    }
}