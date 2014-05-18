#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Presenters;

#endregion

namespace CPECentral.Views
{
    public interface IOperationsView : IView
    {
        PartVersion CurrentPartVersion { get; }
        Method SelectedMethod { get; }
        Operation SelectedOperation { get; }

        event EventHandler AddMethod;
        event EventHandler EditMethod;

        event EventHandler AddOperation;
        event EventHandler EditOperation;

        event EventHandler ReloadMethods;
        event EventHandler<MethodEventArgs> MethodSelected;
        event EventHandler<OperationEventArgs> OperationSelected;

        void LoadMethods(PartVersion partVersion);

        void DisplayMethods(IEnumerable<Method> methods);
        void DisplayOperations(IEnumerable<Operation> operations);
    }

    [DefaultEvent("OperationSelected")]
    public partial class OperationsView : ViewBase, IOperationsView
    {
        private readonly OperationsViewPresenter _presenter;

        public OperationsView()
        {
            InitializeComponent();

            Font = Session.AppFont;

            if (!IsInDesignMode) {
                _presenter = new OperationsViewPresenter(this);
            }
        }

        #region IOperationsView Members

        public PartVersion CurrentPartVersion { get; private set; }

        public Method SelectedMethod { get; private set; }
        public Operation SelectedOperation { get; private set; }

        public event EventHandler AddMethod;
        public event EventHandler EditMethod;
        public event EventHandler AddOperation;
        public event EventHandler EditOperation;

        public event EventHandler ReloadMethods;
        public event EventHandler<MethodEventArgs> MethodSelected;
        public event EventHandler<OperationEventArgs> OperationSelected;

        public void LoadMethods(PartVersion partVersion)
        {
            CurrentPartVersion = partVersion;

            operationsEnhancedListView.Items.Clear();
            methodsEnhancedListView.Items.Clear();

            methodsEnhancedListView.Items.Add("retrieving...");

            operationsEnhancedListView.Enabled = false;
            methodsEnhancedListView.Enabled = false;

            operationsToolStrip.Enabled = false;
            methodsToolStrip.Enabled = false;

            OnRefreshViewData();
        }

        public void DisplayMethods(IEnumerable<Method> methods)
        {
            methodsEnhancedListView.Items.Clear();
            methodsEnhancedListView.Enabled = true;

            methodsToolStrip.Enabled = true;

            foreach (Method method in methods) {
                ListViewItem item = methodsEnhancedListView.Items.Add(method.Description);
                item.SubItems.Add(method.IsPreferred ? "Yes" : "No");
                item.Tag = method;
            }

            methodsEnhancedListView.SelectFirstItem();

            Invalidate();
        }

        public void DisplayOperations(IEnumerable<Operation> operations)
        {
            operationsEnhancedListView.Items.Clear();
            operationsEnhancedListView.Enabled = true;

            foreach (Operation operation in operations) {
                ListViewItem item = operationsEnhancedListView.Items.Add(operation.Sequence.ToString("D2"));
                item.SubItems.Add(operation.Description);
                item.Tag = operation;
            }

            operationsEnhancedListView.SelectFirstItem();
        }

        #endregion

        protected virtual void OnAddMethod()
        {
            EventHandler handler = AddMethod;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnEditMethod()
        {
            EventHandler handler = EditMethod;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnAddOperation()
        {
            EventHandler handler = AddOperation;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnEditOperation()
        {
            EventHandler handler = EditOperation;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnRefreshViewData()
        {
            EventHandler handler = ReloadMethods;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnMethodSelected(MethodEventArgs e)
        {
            EventHandler<MethodEventArgs> handler = MethodSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnOperationSelected(OperationEventArgs e)
        {
            EventHandler<OperationEventArgs> handler = OperationSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        private void MethodsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            operationsEnhancedListView.Items.Clear();

            operationsToolStrip.Enabled = false;
            operationsEnhancedListView.Enabled = false;

            editMethodToolStripButton.Enabled = methodsEnhancedListView.SelectionCount == 1;
            deleteMethodToolStripButton.Enabled = methodsEnhancedListView.SelectionCount == 1;

            if (methodsEnhancedListView.SelectionCount == 0) {
                SelectedMethod = null;
                return;
            }

            operationsEnhancedListView.Items.Add("-").SubItems.Add("retrieving...");

            SelectedMethod = (Method) methodsEnhancedListView.SelectedItems[0].Tag;

            operationsToolStrip.Enabled = true;
            operationsEnhancedListView.Enabled = true;

            OnMethodSelected(new MethodEventArgs(SelectedMethod));
        }

        private void OperationsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            editOperationToolStripButton.Enabled = operationsEnhancedListView.SelectionCount == 1;
            deleteOperationToolStripButton.Enabled = operationsEnhancedListView.SelectionCount == 1;

            if (operationsEnhancedListView.SelectionCount == 0) {
                SelectedOperation = null;
            }
            else {
                SelectedOperation = (Operation) operationsEnhancedListView.SelectedItems[0].Tag;
            }

            OnOperationSelected(new OperationEventArgs(SelectedOperation));
        }

        private void methodsToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addMethodToolStripButton":
                    OnAddMethod();
                    break;
                case "editMethodToolStripButton":
                    OnEditMethod();
                    break;
            }
        }

        private void methodsEnhancedListView_ItemActivate(object sender, EventArgs e)
        {
            OnEditMethod();
        }

        private void operationsEnhancedListView_ItemActivate(object sender, EventArgs e)
        {
            OnEditOperation();
        }

        private void operationsToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addOperationToolStripButton":
                    OnAddOperation();
                    break;
                case "editOperationToolStripButton":
                    OnEditOperation();
                    break;
            }
        }
    }
}