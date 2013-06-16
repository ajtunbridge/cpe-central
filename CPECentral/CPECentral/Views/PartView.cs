#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IPartView : IView
    {
        Part Part { get; }
        event EventHandler ReloadData;
        void DisplayModel(PartViewModel model);
    }

    public partial class PartView : ViewBase, IPartView
    {
        private readonly Part _part;
        private readonly PartViewPresenter _presenter;

        public PartView(Part part)
        {
            InitializeComponent();

            base.Dock = DockStyle.Fill;

            _part = part;

            if (!IsInDesignMode)
            {
                _presenter = new PartViewPresenter(this);
                Session.MessageBus.Subscribe<PartEditedMessage>(PartEditedMessage_Published);
            }
        }

        #region IPartView Members

        public event EventHandler ReloadData;

        public Part Part
        {
            get { return _part; }
        }

        public void DisplayModel(PartViewModel model)
        {
            createdByLabel.Text = "Created by: " + model.CreatedBy;
            modifiedByLabel.Text = "Modified by: " + model.ModifiedBy;

            RepositionHeaderLabels();
        }

        #endregion

        protected virtual void OnReloadData()
        {
            var handler = ReloadData;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void PartEditedMessage_Published(PartEditedMessage message)
        {
            if (!Equals(_part, message.EditedPart))
                return;

            RefreshData();
        }

        private void PartView_Load(object sender, EventArgs e)
        {
            partInformationView1.LoadPart(_part);

            RefreshData();
        }

        private void RefreshData()
        {
            createdByLabel.Text = "Created by: N/A";
            modifiedByLabel.Text = "Modified by: N/A";

            RepositionHeaderLabels();

            OnReloadData();
        }

        private void RepositionHeaderLabels()
        {
            createdByLabel.Left = Right - createdByLabel.Width - 3;
            modifiedByLabel.Left = Right - modifiedByLabel.Width - 3;
        }
    }
}