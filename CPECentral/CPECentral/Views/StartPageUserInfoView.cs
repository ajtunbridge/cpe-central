#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IStartPageUserInfoView : IView
    {
        event EventHandler RefreshRecentPartsList;

        void DisplayRecentParts(IEnumerable<RecentPartsViewModel> recentParts);
    }

    public partial class StartPageUserInfoView : ViewBase, IStartPageUserInfoView
    {
        public event EventHandler RefreshRecentPartsList;

        private StartPageUserInfoViewPresenter _presenter;
        private Employee _employee;

        protected virtual void OnRefreshRecentPartsList()
        {
            EventHandler handler = RefreshRecentPartsList;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        public StartPageUserInfoView()
        {
            InitializeComponent();

            if (!IsInDesignMode)
            {
                _presenter = new StartPageUserInfoViewPresenter(this);

                headerLabel.Text = "Hello " + Session.CurrentEmployee.FirstName + "!";
                _employee = Session.CurrentEmployee;

                Session.MessageBus.Subscribe<RecentPartsChangedMessage>(RecentPartsChangedMessage_Published);

                OnRefreshRecentPartsList();
            }
        }

        public void DisplayRecentParts(IEnumerable<RecentPartsViewModel> recentParts)
        {
            recentPartsGroupBox.Controls.Clear();

            foreach (var item in recentParts) {
                var label = new Label();
                label.Text = string.Format("{0} ({1})", item.Part.DrawingNumber, item.Part.Name);
                label.ForeColor = Color.Blue;
                label.Font = new Font(Font, FontStyle.Underline);
                label.AutoSize = false;
                label.Height = 30;
                label.Dock = DockStyle.Top;
                label.Cursor = Cursors.Hand;
                label.Tag = item;
                label.MouseHover += recentPartLabel_MouseHover;
                label.Click += recentPartLabel_Click;
                recentPartsGroupBox.Controls.Add(label);
                label.BringToFront();
            }
        }

        void recentPartLabel_MouseHover(object sender, EventArgs e)
        {
            // only display popup image if control key is pressed
            if (ModifierKeys != Keys.Control)
            {
                return;
            }

            var model = (sender as Label).Tag as RecentPartsViewModel;

            if (model.CurrentVersionPhoto == null)
            {
                return;
            }

            var popupForm = new ImagePopupForm(model.CurrentVersionPhoto);
            popupForm.Location = new Point(MousePosition.X - 1, MousePosition.Y - 1);
            popupForm.Show();
        }

        void recentPartLabel_Click(object sender, EventArgs e)
        {
            var item = (sender as Label).Tag as RecentPartsViewModel;

            Session.MessageBus.Publish(new LoadPartMessage(item.Part));
        }

        private void StartPageUserInfoView_Load(object sender, EventArgs e)
        {
        }

        public void RecentPartsChangedMessage_Published(RecentPartsChangedMessage message)
        {
            if (Session.CurrentEmployee == _employee) {
                OnRefreshRecentPartsList();
            }
        }
    }
}