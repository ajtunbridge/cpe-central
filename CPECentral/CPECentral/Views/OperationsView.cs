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
        Method CurrentMethod { get; }
        Operation SelectedOperation { get; }
        event EventHandler ReloadData;
        event EventHandler<OperationSelectedEventArgs> OperationSelected;
        void LoadOperations(Method method);
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

        public Method CurrentMethod { get; private set; }
        public Operation SelectedOperation { get; private set; }

        public event EventHandler ReloadData;
        public event EventHandler<OperationSelectedEventArgs> OperationSelected;

        public void LoadOperations(Method method)
        {
            CurrentMethod = method;

            enhancedListView.Items.Clear();
            enhancedListView.Items.Add("-").SubItems.Add("retrieving...");

            OnReloadData();
        }

        public void DisplayOperations(IEnumerable<Operation> operations)
        {
            enhancedListView.Items.Clear();

            foreach (var operation in operations)
            {
                var item = enhancedListView.Items.Add(operation.Sequence.ToString("D2"));
                item.SubItems.Add(operation.Description);
                item.Tag = operation;
            }

            enhancedListView.SelectFirstItem();
        }

        #endregion

        protected virtual void OnReloadData()
        {
            var handler = ReloadData;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnOperationSelected(OperationSelectedEventArgs e)
        {
            var handler = OperationSelected;
            if (handler != null) handler(this, e);
        }

        private void enhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void OperationsView_Load(object sender, EventArgs e)
        {
        }

        private void enhancedListView_ClientSizeChanged(object sender, EventArgs e)
        {
        }

        private void enhancedListView_Resize(object sender, EventArgs e)
        {
        }
    }
}