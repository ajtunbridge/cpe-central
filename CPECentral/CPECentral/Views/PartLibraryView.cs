#region Using directives

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.Properties;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IPartLibraryView : IView
    {
        Part SelectedPart { get; }
        Customer SelectedCustomer { get; }

        event EventHandler ReloadData;
        event EventHandler<CustomerSelectedEventArgs> CustomerSelected;
        event EventHandler<PartSelectedEventArgs> PartSelected;

        void DisplayLibrary(PartLibraryViewModel viewModel);
        void DisplaySearchResults(PartLibraryViewModel viewModel);
    }

    [DefaultEvent("PartSelected")]
    public partial class PartLibraryView : ViewBase, IPartLibraryView
    {
        private readonly PartLibraryViewPresenter _presenter;

        public PartLibraryView()
        {
            InitializeComponent();

            enhancedTreeViewImageList.Images.Add("CustomerIcon", Resources.CustomerIcon_16x16);
            enhancedTreeViewImageList.Images.Add("PartIcon", Resources.OpenIcon_16x16);

            if (!IsInDesignMode)
            {
                _presenter = new PartLibraryViewPresenter(this);

                Session.MessageBus.Subscribe<PartEditedMessage>(PartEditedMessage_Published);
            }
        }

        #region IPartLibraryView Members

        public Part SelectedPart { get; private set; }
        public Customer SelectedCustomer { get; private set; }

        public event EventHandler ReloadData;
        public event EventHandler<CustomerSelectedEventArgs> CustomerSelected;
        public event EventHandler<PartSelectedEventArgs> PartSelected;

        public void DisplayLibrary(PartLibraryViewModel viewModel)
        {
            DisplayModel(viewModel);
        }

        public void DisplaySearchResults(PartLibraryViewModel viewModel)
        {
            DisplayModel(viewModel);

            enhancedTreeView.ExpandAll();
        }

        #endregion

        private void PartLibraryView_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void DisplayModel(PartLibraryViewModel viewModel)
        {
            enhancedTreeView.Nodes.Clear();

            enhancedTreeView.Enabled = true;

            if (viewModel == null)
            {
                enhancedTreeView.Nodes.Add("Error loading library!");
                return;
            }

            if (!viewModel.Customers.Any())
            {
                enhancedTreeView.Nodes.Add("There are no parts in the library!");
                return;
            }

            foreach (var customer in viewModel.Customers)
            {
                var customerNode = enhancedTreeView.Nodes.Add(customer.Name);
                customerNode.ImageKey = "CustomerIcon";
                customerNode.SelectedImageKey = "CustomerIcon";
                customerNode.Tag = customer;

                var customerParts = viewModel.Parts.Where(p => p.CustomerId == customer.Id)
                                             .OrderBy(p => p.DrawingNumber);

                foreach (var part in customerParts)
                {
                    var partNode = customerNode.Nodes.Add(part.DrawingNumber);
                    partNode.ImageKey = "PartIcon";
                    partNode.SelectedImageKey = "PartIcon";
                    partNode.ToolTipText = part.Name;
                    partNode.Tag = part;
                }
            }
        }

        private void RefreshData()
        {
            enhancedTreeView.Nodes.Clear();
            enhancedTreeView.Nodes.Add("loading....");
            enhancedTreeView.Enabled = false;

            OnReloadData();
        }

        protected virtual void OnReloadData()
        {
            var handler = ReloadData;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnCustomerSelected(CustomerSelectedEventArgs e)
        {
            var handler = CustomerSelected;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnPartSelected(PartSelectedEventArgs e)
        {
            var handler = PartSelected;
            if (handler != null) handler(this, e);
        }

        private void PartEditedMessage_Published(PartEditedMessage message)
        {
            if (SelectedPart == message.EditedPart)
            {
                var selectedNode = enhancedTreeView.SelectedNode;

                selectedNode.Text = message.EditedPart.DrawingNumber;
                selectedNode.ToolTipText = message.EditedPart.Name;
                selectedNode.Tag = message.EditedPart;
            }
        }

        private void enhancedTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Part)
            {
                SelectedPart = (Part) e.Node.Tag;
                OnPartSelected(new PartSelectedEventArgs(SelectedPart));
            }
            else // is Customer
            {
                SelectedCustomer = (Customer) e.Node.Tag;
                OnCustomerSelected(new CustomerSelectedEventArgs(SelectedCustomer));
            }
        }
    }
}