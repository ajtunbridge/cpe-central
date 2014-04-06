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
        SearchField SearchField { get; }
        string SearchValue { get; }

        event EventHandler<PartSearchEventArgs> Search;
        event EventHandler ReloadData;
        event EventHandler<CustomerEventArgs> CustomerSelected;
        event EventHandler<PartEventArgs> PartSelected;
        event EventHandler<PartEventArgs> DeletePart;
        event EventHandler<StringEventArgs> WorksOrderNotFound;

        void RefreshLibrary();
        void DisplayLibrary(PartLibraryViewModel viewModel);
        void DisplaySearchResults(PartLibraryViewModel viewModel);
    }

    [DefaultEvent("PartSelected")]
    public partial class PartLibraryView : ViewBase, IPartLibraryView
    {
        private readonly PartLibraryViewPresenter _presenter;
        private Part _partToSelect;

        public PartLibraryView()
        {
            InitializeComponent();

            enhancedTreeViewImageList.Images.Add("CustomerIcon", Resources.CustomerIcon_16x16);
            enhancedTreeViewImageList.Images.Add("PartIcon", Resources.OpenIcon_16x16);

            if (!IsInDesignMode) {
                _presenter = new PartLibraryViewPresenter(this);

                Session.MessageBus.Subscribe<PartEditedMessage>(PartEditedMessage_Published);
                Session.MessageBus.Subscribe<PartAddedMessage>(PartAddedMessage_Published);
            }
        }

        #region IPartLibraryView Members

        public Part SelectedPart { get; private set; }
        public Customer SelectedCustomer { get; private set; }

        public SearchField SearchField
        {
            get
            {
                switch (searchFieldComboBox.Text) {
                    case "Works order number":
                        return SearchField.WorksOrderNumber;
                    case "Drawing number":
                        return SearchField.DrawingNumber;
                    case "Name":
                        return SearchField.Name;
                    default:
                        return SearchField.DrawingNumber;
                }
            }
        }

        public string SearchValue
        {
            get { return searchValueTextBox.Text; }
        }

        public event EventHandler<PartSearchEventArgs> Search;

        public event EventHandler ReloadData;
        public event EventHandler<CustomerEventArgs> CustomerSelected;
        public event EventHandler<PartEventArgs> PartSelected;
        public event EventHandler<PartEventArgs> DeletePart;
        public event EventHandler<StringEventArgs> WorksOrderNotFound;

        public void DisplayLibrary(PartLibraryViewModel viewModel)
        {
            DisplayModel(viewModel, false);

            if (_partToSelect != null) {
                SelectPart(_partToSelect.Id);
                _partToSelect = null;
            }
            else if (viewModel.LastViewedPartId.HasValue) {
                SelectPart(viewModel.LastViewedPartId.Value);
            }
        }

        public void DisplaySearchResults(PartLibraryViewModel viewModel)
        {
            DisplayModel(viewModel, true);

            enhancedTreeView.ExpandAll();
        }

        public void RefreshLibrary()
        {
            enhancedTreeView.Nodes.Clear();
            enhancedTreeView.Nodes.Add("loading....");
            enhancedTreeView.Enabled = false;

            OnReloadData();
        }

        #endregion

        private void PartLibraryView_Load(object sender, EventArgs e)
        {
            searchFieldComboBox.SelectedIndex = 0;

            RefreshLibrary();
        }

        private void DisplayModel(PartLibraryViewModel viewModel, bool isSearchResult)
        {
            enhancedTreeView.Nodes.Clear();

            enhancedTreeView.Enabled = true;

            if (viewModel == null) {
                enhancedTreeView.Nodes.Add("Error loading library!");
                return;
            }

            if (!viewModel.Customers.Any()) {
                if (isSearchResult) {
                    enhancedTreeView.Nodes.Add("The search returned no results!");
                    if (SearchField == SearchField.WorksOrderNumber) {
                        var canEditParts = AppSecurity.Check(AppPermission.ManageParts);
                        if (canEditParts) {
                            if (DialogService.AskQuestion("No matches found!\n\nDo you want to create a new part?")) {
                                OnWorksOrderNotFound(new StringEventArgs(SearchValue));
                            }
                        }
                    }
                }
                else {
                    enhancedTreeView.Nodes.Add("There are no parts in the library!");
                }

                return;
            }

            int partCount = 0;

            TreeNode nodeToSelect = null;

            foreach (Customer customer in viewModel.Customers.OrderBy(c => c.Name)) {
                TreeNode customerNode = enhancedTreeView.Nodes.Add(customer.Name);
                customerNode.ImageKey = "CustomerIcon";
                customerNode.SelectedImageKey = "CustomerIcon";
                customerNode.Tag = customer;

                IOrderedEnumerable<Part> customerParts = viewModel.Parts.Where(p => p.CustomerId == customer.Id)
                    .OrderBy(p => p.DrawingNumber);

                foreach (Part part in customerParts) {
                    partCount++;

                    string nodeText;

                    if (isSearchResult && SearchField == SearchField.Name) {
                        nodeText = part.DrawingNumber + " (" + part.Name + ")";
                    }
                    else {
                        nodeText = part.DrawingNumber;
                    }

                    TreeNode partNode = customerNode.Nodes.Add(nodeText);
                    partNode.ImageKey = "PartIcon";
                    partNode.SelectedImageKey = "PartIcon";
                    partNode.ToolTipText = part.Name;
                    partNode.Tag = part;
                }
            }

            string status = "Found " + partCount + " parts";

            Session.MessageBus.Publish(new StatusUpdateMessage(status));
        }

        protected virtual void OnReloadData()
        {
            EventHandler handler = ReloadData;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnCustomerSelected(CustomerEventArgs e)
        {
            EventHandler<CustomerEventArgs> handler = CustomerSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnPartSelected(PartEventArgs e)
        {
            EventHandler<PartEventArgs> handler = PartSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnDeletePart(PartEventArgs e)
        {
            EventHandler<PartEventArgs> handler = DeletePart;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnSearch(PartSearchEventArgs e)
        {
            EventHandler<PartSearchEventArgs> handler = Search;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnWorksOrderNotFound(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = WorksOrderNotFound;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void PartAddedMessage_Published(PartAddedMessage message)
        {
            _partToSelect = message.NewPart;

            OnReloadData();
        }

        private void PartEditedMessage_Published(PartEditedMessage message)
        {
            if (SelectedPart == message.EditedPart) {
                TreeNode selectedNode = enhancedTreeView.SelectedNode;

                selectedNode.Text = message.EditedPart.DrawingNumber;
                selectedNode.ToolTipText = message.EditedPart.Name;
                selectedNode.Tag = message.EditedPart;
            }
        }

        private void enhancedTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Part) {
                contextMenuStrip.Enabled = true;

                SelectedPart = (Part) e.Node.Tag;

                OnPartSelected(new PartEventArgs(SelectedPart));
            }
            else if (e.Node.Tag is Customer) {
                contextMenuStrip.Enabled = false;

                SelectedCustomer = (Customer) e.Node.Tag;
                OnCustomerSelected(new CustomerEventArgs(SelectedCustomer));
            }
        }

        private void SelectPart(int partId)
        {
            foreach (TreeNode customerNode in enhancedTreeView.Nodes) {
                foreach (TreeNode partNode in customerNode.Nodes) {
                    var nodePart = (Part) partNode.Tag;

                    if (nodePart.Id != partId) {
                        continue;
                    }

                    enhancedTreeView.SelectedNode = partNode;
                    return;
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            enhancedTreeView.Nodes.Clear();
            enhancedTreeView.Nodes.Add("searching...");

            var args = new PartSearchArgs(SearchField, SearchValue);

            OnSearch(new PartSearchEventArgs(args));
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshLibrary();
        }

        private void searchValueTextBox_EnterKeyPressed(object sender, EventArgs e)
        {
            searchButton.PerformClick();
        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip.Hide();

            switch (e.ClickedItem.Name) {
                case "deleteToolStripMenuItem":
                    OnDeletePart(new PartEventArgs(SelectedPart));
                    break;
            }
        }
    }

    public class PartSearchArgs
    {
        public PartSearchArgs(SearchField field, string value)
        {
            Field = field;
            Value = value;
        }

        public SearchField Field { get; set; }
        public string Value { get; set; }
    }

    public enum SearchField
    {
        DrawingNumber,
        Name,
        WorksOrderNumber
    }
}