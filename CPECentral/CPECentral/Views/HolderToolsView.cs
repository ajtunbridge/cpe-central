#region Using directives

using System;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IHolderToolsView : IView
    {
        event EventHandler<HolderEventArgs> AddHolderTool;
        event EventHandler<HolderEventArgs> RetrieveHolderTools;
        void DisplayModel(HolderToolsViewModel model);
        void LoadHolderTools(Holder holder);
    }

    public partial class HolderToolsView : ViewBase, IHolderToolsView
    {
        private readonly HolderToolsViewPresenter _presenter;
        private Holder _currentHolder;

        public HolderToolsView()
        {
            InitializeComponent();

            Font = Session.AppFont;

            if (!IsInDesignMode) {
                _presenter = new HolderToolsViewPresenter(this);
            }
        }

        #region IHolderToolsView Members

        public event EventHandler<HolderEventArgs> AddHolderTool;

        public event EventHandler<HolderEventArgs> RetrieveHolderTools;

        public void DisplayModel(HolderToolsViewModel model)
        {
            Enabled = true;

            holderToolsEnhancedListView.Items.Clear();

            if (!model.Items.Any()) {
                holderToolsEnhancedListView.Items.Add("No tools assigned!");
                return;
            }

            foreach (HolderToolsViewModel.HolderToolsViewModelItem modelItem in model.Items) {
                ListViewItem item = holderToolsEnhancedListView.Items.Add(modelItem.Description);
                item.Tag = modelItem.HolderTool;
            }
        }

        public void LoadHolderTools(Holder holder)
        {
            _currentHolder = holder;

            holderToolsEnhancedListView.Items.Clear();

            Enabled = false;

            if (holder == null) {
                holderToolsEnhancedListView.Items.Add("Please select a holder!");
                return;
            }

            holderToolsEnhancedListView.Items.Add("retrieving...");

            OnRetrieveHolderTools(new HolderEventArgs(holder));
        }

        #endregion

        protected virtual void OnAddHolderTool(HolderEventArgs e)
        {
            EventHandler<HolderEventArgs> handler = AddHolderTool;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnRetrieveHolderTools(HolderEventArgs e)
        {
            EventHandler<HolderEventArgs> handler = RetrieveHolderTools;
            if (handler != null) {
                handler(this, e);
            }
        }

        private void mainContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "assignToolToolStripMenuItem":
                    OnAddHolderTool(new HolderEventArgs(_currentHolder));
                    break;
            }
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "assignToolStripButton":
                    OnAddHolderTool(new HolderEventArgs(_currentHolder));
                    break;
            }
        }
    }
}