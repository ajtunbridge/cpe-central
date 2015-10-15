#region Using directives

using System;
using System.Collections.Generic;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IPartWorksOrdersView : IView
    {
        event EventHandler<PartEventArgs> LoadWorksOrders;
        void DisplayModel(IEnumerable<PartWorksOrdersViewModel> model);
        void InitializeView(Part part);
    }

    public sealed partial class PartWorksOrdersView : ViewBase, IPartWorksOrdersView
    {
        private readonly PartWorksOrdersPresenter _presenter;

        public PartWorksOrdersView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new PartWorksOrdersPresenter(this);
            }
        }

        #region IPartWorksOrdersView Members

        public event EventHandler<PartEventArgs> LoadWorksOrders;

        public void DisplayModel(IEnumerable<PartWorksOrdersViewModel> model)
        {
            worksOrdersObjectListView.EmptyListMsg = "No works orders found for this part!";

            worksOrdersObjectListView.SetObjects(model);
        }

        public void InitializeView(Part part)
        {
            worksOrdersObjectListView.SetObjects(null);
            worksOrdersObjectListView.EmptyListMsg = "retrieving works orders...";

            OnLoadWorksOrders(new PartEventArgs(part));
        }

        #endregion

        private void OnLoadWorksOrders(PartEventArgs e)
        {
            EventHandler<PartEventArgs> handler = LoadWorksOrders;
            if (handler != null) {
                handler(this, e);
            }
        }
    }
}