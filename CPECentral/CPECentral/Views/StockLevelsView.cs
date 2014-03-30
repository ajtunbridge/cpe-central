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
    public interface IStockLevelsView
    {
        event EventHandler<ToolEventArgs> LoadStockLevels;
        void DisplayStockLevels(StockLevelsViewModel model);
        void RetrieveToolStockLevels(Tool tool);
    }

    public partial class StockLevelsView : ViewBase, IStockLevelsView
    {
        private readonly StockLevelsViewPresenter _presenter;

        public StockLevelsView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new StockLevelsViewPresenter(this);
            }
        }

        #region IStockLevelsView Members

        public event EventHandler<ToolEventArgs> LoadStockLevels;

        public void DisplayStockLevels(StockLevelsViewModel model)
        {
            stockLevelsEnhancedListView.Items.Clear();

            if (model == null || model.Batches == null || !model.Batches.Any()) {
                stockLevelsEnhancedListView.Items.Add("No batches!");
                return;
            }

            foreach (TricornBatch batch in model.Batches) {
                ListViewItem item = stockLevelsEnhancedListView.Items.Add(batch.BatchNumber);
                item.SubItems.Add(batch.Quantity.ToString("00"));
                item.SubItems.Add(batch.Location);
            }
        }

        public void RetrieveToolStockLevels(Tool tool)
        {
            stockLevelsEnhancedListView.Items.Clear();

            if (tool == null) {
                return;
            }

            stockLevelsEnhancedListView.Items.Add("retrieving...");

            OnLoadStockLevels(new ToolEventArgs(tool));
        }

        #endregion

        protected virtual void OnLoadStockLevels(ToolEventArgs e)
        {
            EventHandler<ToolEventArgs> handler = LoadStockLevels;
            if (handler != null) {
                handler(this, e);
            }
        }
    }
}