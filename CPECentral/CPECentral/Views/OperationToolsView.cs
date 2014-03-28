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
        event EventHandler<OperationEventArgs> AddOperationTool;
        event EventHandler<OperationToolEventArgs> EditOperationTool;
        event EventHandler<OperationToolEventArgs> DeleteOperationTool;

        void RefreshOperationTools();
        void DisplayModel(OperationToolsViewModel model);
        void RetrieveOperationTools(Operation operation);
    }

    public partial class OperationToolsView : ViewBase, IOperationToolsView
    {
        private readonly OperationToolsViewPresenter _presenter;
        private Operation _currentOperation;
        private OperationTool _selectedOperationTool;
        public event EventHandler<OperationEventArgs> LoadOperationTools;
        public event EventHandler<OperationEventArgs> AddOperationTool;
        public event EventHandler<OperationToolEventArgs> EditOperationTool;
        public event EventHandler<OperationToolEventArgs> DeleteOperationTool;

        protected virtual void OnDeleteOperationTool(OperationToolEventArgs e)
        {
            EventHandler<OperationToolEventArgs> handler = DeleteOperationTool;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnEditOperationTool(OperationToolEventArgs e)
        {
            EventHandler<OperationToolEventArgs> handler = EditOperationTool;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnAddOperationTool(OperationEventArgs e)
        {
            var handler = AddOperationTool;
            if (handler != null) {
                handler(this, e);
            }
        }

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

        public void RefreshOperationTools()
        {
            RetrieveOperationTools(_currentOperation);
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

                item.Tag = modelItem.OperationTool;
            }
        }

        public void RetrieveOperationTools(Operation operation)
        {
            _currentOperation = operation;

            if (operation == null) {
                operationToolsEnhancedListView.Items.Clear();
                return;
            }

            operationToolsEnhancedListView.Items.Clear();
            operationToolsEnhancedListView.Items.Add("retrieving...");

            OnLoadOperationTools(new OperationEventArgs(operation));
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addToolStripButton":
                    OnAddOperationTool(new OperationEventArgs(_currentOperation));
                    break;
                case "editToolStripButton":
                    OnEditOperationTool(new OperationToolEventArgs(_selectedOperationTool));
                    break;
                case "deleteToolStripButton":
                    OnDeleteOperationTool(new OperationToolEventArgs(_selectedOperationTool));
                    break;
            }
        }

        private void operationToolsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectionCount = operationToolsEnhancedListView.SelectionCount;

            editToolStripButton.Enabled = (selectionCount == 1);
            deleteToolStripButton.Enabled = (selectionCount == 1);

            if (selectionCount == 0) {
                _selectedOperationTool = null;
                return;
            }

            _selectedOperationTool = operationToolsEnhancedListView.SelectedItems[0].Tag as OperationTool;
        }

        private void operationToolsEnhancedListView_ItemActivate(object sender, EventArgs e)
        {
            OnEditOperationTool(new OperationToolEventArgs(_selectedOperationTool));
        }
    }
}
