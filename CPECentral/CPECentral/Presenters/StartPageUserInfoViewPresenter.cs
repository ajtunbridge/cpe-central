using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;
using CPECentral.ViewModels;
using CPECentral.Views;
using nGenLibrary;

namespace CPECentral.Presenters
{
    public class StartPageUserInfoViewPresenter
    {
        private readonly IStartPageUserInfoView _view;

        public StartPageUserInfoViewPresenter(IStartPageUserInfoView view)
        {
            _view = view;

            _view.RefreshRecentPartsList += _view_RefreshRecentPartsList;
        }

        void _view_RefreshRecentPartsList(object sender, EventArgs e)
        {
            using (BusyCursor.Show()) {
                using (var cpe = new CPEUnitOfWork()) {
                    var recentParts = cpe.RecentParts.GetRecentParts(Session.CurrentEmployee);

                    var model = new List<RecentPartsViewModel>();
                    foreach (var part in recentParts) {
                        var item = new RecentPartsViewModel();
                        item.Part = part;
                        var currentVersion = cpe.PartVersions.GetLatestVersion(part);
                        if (currentVersion.PhotoBytes != null) {
                            using (var ms = new MemoryStream(currentVersion.PhotoBytes))
                            {
                                item.CurrentVersionPhoto = Image.FromStream(ms);
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