#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

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
        void NewToolAdded();
    }

    public partial class OperationToolsView : ViewBase, IOperationToolsView
    {
        private readonly OperationToolsPresenter _presenter;
        private Operation _currentOperation;
        private OperationTool _selectedOperationTool;

        public OperationToolsView()
        {
            InitializeComponent();

            base.Font = Session.AppFont;

            if (!IsInDesignMode) {
                _presenter = new OperationToolsPresenter(this);
                Session.MessageBus.Subscribe<ToolRenamedMessage>(ToolRenamedMessageHandler);
            }
        }

        #region IOperationToolsView Members

        public event EventHandler<OperationEventArgs> LoadOperationTools;
        public event EventHandler<OperationEventArgs> AddOperationTool;
        public event EventHandler<OperationToolEventArgs> EditOperationTool;
        public event EventHandler<OperationToolEventArgs> DeleteOperationTool;

        public void RefreshOperationTools()
        {
            RetrieveOperationTools(_currentOperation);
        }

        public void DisplayModel(OperationToolsViewModel model)
        {
            operationToolsEnhancedListView.Items.Clear();

            foreach (OperationToolsViewModelItem modelItem in model.Items) {
                ListViewItem item =
                    operationToolsEnhancedListView.Items.Add(modelItem.OperationTool.Position.ToString("00"));
                item.SubItems.Add(modelItem.OperationTool.Offset.ToString("00"));
                item.SubItems.Add(modelItem.ToolName);
                item.SubItems.Add(modelItem.HolderName);

                string stockLevelString = (modelItem.QuantityInStock.HasValue)
                    ? string.Format("{0:00}", modelItem.QuantityInStock)
                    : "N/A";

                item.SubItems.Add(stockLevelString);

                if (modelItem.QuantityInStock == null) {
                    item.ForeColor = ForeColor;
                    item.ToolTipText = "Not linked to Tricorn!";
                }
                else {
                    bool isInStock = modelItem.QuantityInStock > 0;

                    item.ForeColor = isInStock ? Color.Green : Color.Red;

                    item.ToolTipText = isInStock
                        ? string.Format("Quantity in stock: {0:00}", modelItem.QuantityInStock)
                        : "None in stock!";
                }

                item.Tag = modelItem.OperationTool;
            }

            Enabled = true;
        }

        public void RetrieveOperationTools(Operation operation)
        {
            _currentOperation = operation;

            operationToolsEnhancedListView.Items.Clear();

            if (operation == null) {
                Enabled = false;
                return;
            }

            operationToolsEnhancedListView.Items.Add("retrieving...");

            OnLoadOperationTools(new OperationEventArgs(operation));
        }

        public void NewToolAdded()
        {
            RetrieveOperationTools(_currentOperation);

            if (DialogService.AskQuestion("Do you want to add another tool?"))
            {
                OnAddOperationTool(new OperationEventArgs(_currentOperation));
            }
        }

        #endregion

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
            EventHandler<OperationEventArgs> handler = AddOperationTool;
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

        private void ToolRenamedMessageHandler(ToolRenamedMessage toolRenamedMessage)
        {
            foreach (ListViewItem item in operationToolsEnhancedListView.Items) {
                var opTool = item.Tag as OperationTool;
                if (opTool.ToolId == toolRenamedMessage.RenamedTool.Id) {
                    item.SubItems[2].Text = toolRenamedMessage.RenamedTool.Description;
                }
            }
        }

        private void OperationToolsView_Load(object sender, EventArgs e)
        {
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
                case "viewStockLevelsToolStripButton":
                    IEnumerable<int> toolIds = from ListViewItem item in operationToolsEnhancedListView.Items
                        select (item.Tag as OperationTool).ToolId;
                    using (var dialog = new StockLevelsDialog(toolIds)) {
                        dialog.ShowDialog(ParentForm);
                    }
                    break;
            }
        }

        private void operationToolsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectionCount = operationToolsEnhancedListView.SelectionCount;

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

        private void itemContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "editToolStripMenuItem":
                    OnEditOperationTool(new OperationToolEventArgs(_selectedOperationTool));
                    break;
                case "deleteToolStripMenuItem":
                    OnDeleteOperationTool(new OperationToolEventArgs(_selectedOperationTool));
                    break;
            }
        }

        private void mainContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addToolToolStripMenuItem":
                    OnAddOperationTool(new OperationEventArgs(_currentOperation));
                    break;
            }
        }

        private void operationToolsEnhancedListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && _selectedOperationTool != null)
            {
                OnDeleteOperationTool(new OperationToolEventArgs(_selectedOperationTool));
            }
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                OnAddOperationTool(new OperationEventArgs(_currentOperation));
            }
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {

        }
    }
}