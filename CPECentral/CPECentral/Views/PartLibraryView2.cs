#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IPartLibraryView2 : IView
    {
        Part SelectedPart { get; }
        event EventHandler DeletePart;
        event EventHandler<PartEventArgs> PartSelected;
        event EventHandler<StringEventArgs> FindParts;
        event EventHandler RetrieveLibrary;
        void DisplayRefreshModel(PartLibraryViewReloadModel reloadModel);
        void DisplaySearchModel(PartLibraryView2SearchModel searchModel);
        void ReloadLibrary();
    }

    public partial class PartLibraryView2 : ViewBase, IPartLibraryView2
    {
        private readonly PartLibraryView2Presenter _presenter;
        private int _idOfPartToSelect;

        public PartLibraryView2()
        {
            InitializeComponent();

            base.Font = Session.AppFont;

            if (!IsInDesignMode) {
                _presenter = new PartLibraryView2Presenter(this);

                Session.MessageBus.Subscribe<PartEditedMessage>(PartEditedMessage_Published);
                Session.MessageBus.Subscribe<PartAddedMessage>(PartAddedMessage_Published);
            }
        }

        #region IPartLibraryView2 Members

        public Part SelectedPart
        {
            get
            {
                if (partsTreeView.SelectedNode == null) {
                    return null;
                }
                if (partsTreeView.SelectedNode.Tag is Part) {
                    return partsTreeView.SelectedNode.Tag as Part;
                }
                return null;
            }
        }

        public event EventHandler DeletePart;

        public event EventHandler<PartEventArgs> PartSelected;

        public event EventHandler<StringEventArgs> FindParts;

        public event EventHandler RetrieveLibrary;

        public void DisplayRefreshModel(PartLibraryViewReloadModel reloadModel)
        {
            partsTreeView.Nodes.Clear();

            TreeNode nodeToSelect = null;

            foreach (PartLibraryViewReloadModel.CustomerParts result in reloadModel.Results) {
                TreeNode customerNode = partsTreeView.Nodes.Add(result.Customer.Name);
                customerNode.Tag = result.Customer;
                customerNode.ImageIndex = 2;
                customerNode.SelectedImageIndex = 2;

                foreach (Part part in result.Parts) {
                    TreeNode partNode = customerNode.Nodes.Add(part.DrawingNumber);
                    partNode.ToolTipText = part.Name;
                    partNode.Tag = part;

                    if (_idOfPartToSelect > 0 && part.Id == _idOfPartToSelect) {
                        _idOfPartToSelect = 0;
                        nodeToSelect = partNode;
                    }
                    else if (part.Id == reloadModel.LastViewedPartId && nodeToSelect == null) {
                        nodeToSelect = partNode;
                    }
                }
            }

            if (nodeToSelect != null) {
                partsTreeView.SelectedNode = nodeToSelect;
            }
        }

        public void DisplaySearchModel(PartLibraryView2SearchModel searchModel)
        {
            partsTreeView.Nodes.Clear();

            if (searchModel.DrawingNumberMatches.Count > 0) {
                TreeNode rootNode = partsTreeView.Nodes.Add("Matched by drawing number");
                foreach (Part part in searchModel.DrawingNumberMatches) {
                    TreeNode partNode = rootNode.Nodes.Add(part.DrawingNumber);
                    partNode.Tag = part;
                }
            }

            if (searchModel.DrawingNumberFuzzyMatches.Count > 0) {
                TreeNode rootNode = partsTreeView.Nodes.Add("Similar drawing numbers");
                foreach (Part part in searchModel.DrawingNumberFuzzyMatches) {
                    TreeNode partNode = rootNode.Nodes.Add(part.DrawingNumber);
                    partNode.Tag = part;
                }
            }

            if (searchModel.NameMatches.Count > 0) {
                TreeNode rootNode = partsTreeView.Nodes.Add("Matched by part name");
                foreach (Part part in searchModel.NameMatches) {
                    TreeNode partNode = rootNode.Nodes.Add(string.Format("{0} ({1})", part.Name, part.DrawingNumber));
                    partNode.Tag = part;
                }
            }

            if (searchModel.NameFuzzyMatches.Count > 0) {
                TreeNode rootNode = partsTreeView.Nodes.Add("Similar part names");
                foreach (Part part in searchModel.NameFuzzyMatches) {
                    TreeNode partNode = rootNode.Nodes.Add(string.Format("{0} ({1})", part.Name, part.DrawingNumber));
                    partNode.Tag = part;
                }
            }

            if (partsTreeView.Nodes.Count == 0) {
                TreeNode rootNode = partsTreeView.Nodes.Add("Search returned no results!");
            }
            else if (partsTreeView.Nodes.Count == 1) {
                // select the first node in the first node
                partsTreeView.SelectedNode = partsTreeView.Nodes[0].Nodes[0];
            }
            else {
                partsTreeView.ExpandAll();
            }

            partsTreeView.Select();
        }

        public void ReloadLibrary()
        {
            partsTreeView.Nodes.Clear();
            partsTreeView.Nodes.Add("loading library....");

            OnRetrieveLibrary();
        }

        #endregion

        protected virtual void OnDeletePart()
        {
            EventHandler handler = DeletePart;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnRetrieveLibrary()
        {
            EventHandler handler = RetrieveLibrary;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnFindParts(StringEventArgs e)
        {
            EventHandler<StringEventArgs> handler = FindParts;
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            partsTreeView.Nodes.Clear();
            partsTreeView.Nodes.Add("searching for parts....");

            string searchValue = searchValueTextBox.Text.Trim();

            OnFindParts(new StringEventArgs(searchValue));
        }

        private void PartLibraryView2_Load(object sender, EventArgs e)
        {
            ReloadLibrary();
        }

        private void searchValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                searchButton.PerformClick();
            }
        }

        private void partsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Part) {
                OnPartSelected(new PartEventArgs(e.Node.Tag as Part));
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            ReloadLibrary();
        }

        private void PartAddedMessage_Published(PartAddedMessage message)
        {
            _idOfPartToSelect = message.NewPart.Id;

            OnRetrieveLibrary();
        }

        private void PartEditedMessage_Published(PartEditedMessage message)
        {
            if (SelectedPart == message.EditedPart) {
                TreeNode selectedNode = partsTreeView.SelectedNode;

                selectedNode.Text = message.EditedPart.DrawingNumber;
                selectedNode.ToolTipText = message.EditedPart.Name;
                selectedNode.Tag = message.EditedPart;
            }
        }
    }
}