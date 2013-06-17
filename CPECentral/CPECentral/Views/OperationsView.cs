#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            if (!IsInDesignMode)
                _presenter = new OperationsViewPresenter(this);
        }

        #region IOperationsView Members

        public PartVersion CurrentPartVersion { get; private set; }

        public Method SelectedMethod { get; private set; }
        public Operation SelectedOperation { get; private set; }

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

            foreach (var method in methods)
            {
                var item = methodsEnhancedListView.Items.Add(method.Description);
                item.Tag = method;
            }

            methodsEnhancedListView.SelectFirstItem();

            Invalidate();
        }

        public void DisplayOperations(IEnumerable<Operation> operations)
        {
            operationsEnhancedListView.Items.Clear();
            operationsEnhancedListView.Enabled = true;

            foreach (var operation in operations)
            {
                var item = operationsEnhancedListView.Items.Add(operation.Sequence.ToString("D2"));
                item.SubItems.Add(operation.Description);
                item.Tag = operation;
            }

            operationsEnhancedListView.SelectFirstItem();

            Invalidate();
        }

        #endregion

        protected virtual void OnRefreshViewData()
        {
            var handler = ReloadMethods;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnMethodSelected(MethodEventArgs e)
        {
            var handler = MethodSelected;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnOperationSelected(OperationEventArgs e)
        {
            var handler = OperationSelected;
            if (handler != null) handler(this, e);
        }

        private void MethodsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            operationsEnhancedListView.Items.Clear();

            operationsToolStrip.Enabled = false;
            operationsEnhancedListView.Enabled = false;

            if (methodsEnhancedListView.SelectionCount == 0)
            {
                SelectedMethod = null;
                return;
            }

            operationsEnhancedListView.Items.Add("-").SubItems.Add("retrieving...");

            SelectedMethod = (Method) methodsEnhancedListView.SelectedItems[0].Tag;

            OnMethodSelected(new MethodEventArgs(SelectedMethod));
        }

        private void OperationsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (operationsEnhancedListView.SelectionCount == 0)
                SelectedOperation = null;
            else
                SelectedOperation = (Operation) operationsEnhancedListView.SelectedItems[0].Tag;

            OnOperationSelected(new OperationEventArgs(SelectedOperation));
        }
    }
}