#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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
        event EventHandler ChangeEmployeePassword;

        void DisplayRecentParts(IEnumerable<RecentPartsViewModel> recentParts);
    }

    public partial class StartPageUserInfoView : ViewBase, IStartPageUserInfoView
    {
        private readonly Employee _employee;
        private StartPageUserInfoPresenter _presenter;

        public StartPageUserInfoView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new StartPageUserInfoPresenter(this);

                headerLabel.Text = "Hello " + Session.CurrentEmployee.FirstName + "!";
                _employee = Session.CurrentEmployee;

                Session.MessageBus.Subscribe<RecentPartsChangedMessage>(RecentPartsChangedMessage_Published);

                OnRefreshRecentPartsList();
            }
        }

        #region IStartPageUserInfoView Members

        public event EventHandler RefreshRecentPartsList;
        public event EventHandler ChangeEmployeePassword;

        public void DisplayRecentParts(IEnumerable<RecentPartsViewModel> recentParts)
        {
            recentPartsGroupBox.Controls.Clear();

            foreach (RecentPartsViewModel item in recentParts) {
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

        #endregion

        protected virtual void OnRefreshRecentPartsList()
        {
            EventHandler handler = RefreshRecentPartsList;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnChangeEmployeePassword()
        {
            EventHandler handler = ChangeEmployeePassword;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        private void recentPartLabel_MouseHover(object sender, EventArgs e)
        {
            var model = (sender as Label).Tag as RecentPartsViewModel;

            var image = Session.PartPartPhotoCache[model.Part.Id];

            if (image == null) {
                return;
            }

            var popupForm = new ImagePopupForm(image);
            popupForm.Location = new Point(MousePosition.X + 20, MousePosition.Y + 20);
            popupForm.Show();

            //ParentForm.Activate();
        }

        private void recentPartLabel_Click(object sender, EventArgs e)
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

        private void changePasswordLabel_Click(object sender, EventArgs e)
        {
            OnChangeEmployeePassword();
        }

        private void headerLabel_SizeChanged(object sender, EventArgs e)
        {
            changePasswordLabel.Left = headerLabel.Right + 5;
        }
    }
}