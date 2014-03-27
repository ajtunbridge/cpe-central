using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Presenters;
using CPECentral.ViewModels;

namespace CPECentral.Views
{
    public interface IOperationToolsView : IView
    {
        event EventHandler<OperationEventArgs> LoadOperationTools;
        void DisplayModel(OperationToolsViewModel model);
        void RetrieveOperationTools(Operation operation);
    }

    public partial class OperationToolsView : ViewBase, IOperationToolsView
    {
        private readonly OperationToolsViewPresenter _presenter;

        public event EventHandler<OperationEventArgs> LoadOperationTools;

        protected virtual void OnLoadOperationTools(OperationEventArgs e)
        {
            EventHandler<OperationEventArgs> handler = LoadOperationTools;
            if (handler != null) {
                handler(this, e);
            }
        }

        public OperationToolsView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new OperationToolsViewPresenter(this);
            }
        }

        private void OperationToolsView_Load(object sender, EventArgs e)
        {
            
        }

        public void DisplayModel(OperationToolsViewModel model)
        {
            operationToolsEnhancedListView.Items.Clear();

            foreach (var modelItem in model.Items) {
                ListViewItem item = operationToolsEnhancedListView.Items.Add(modelItem.OperationTool.Position.ToString("00"));
                item.SubItems.Add(modelItem.OperationTool.Offset.ToString("00"));
                item.SubItems.Add(modelItem.ToolName);
                item.SubItems.Add(modelItem.HolderName);

                bool isInStock = modelItem.QuantityInStock.HasValue && modelItem.QuantityInStock > 0;

                item.ForeColor = isInStock ? Color.Green : Color.Red;

                item.ToolTipText = isInStock
                    ? "Quantity in stock: " + modelItem.QuantityInStock.Value.ToString("00")
                    : "None in stock!";
            }
        }

        public void RetrieveOperationTools(Operation operation)
        {
            if (operation == null) {
                operationToolsEnhancedListView.Items.Clear();
                return;
            }

            operationToolsEnhancedListView.Items.Clear();
            operationToolsEnhancedListView.Items.Add("retrieving...");

            OnLoadOperationTools(new OperationEventArgs(operation));
        }

        private void operationToolsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
