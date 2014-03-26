#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IToolGroupsView : IView
    {
        ToolGroup SelectedToolGroup { get; }
        event EventHandler RefreshGroups;
        event EventHandler AddRootGroup;
        event EventHandler<ToolGroupEventArgs> AddChildGroup;
        event EventHandler<ToolGroupEventArgs> ToolGroupSelected;
        event EventHandler<ToolGroupEventArgs> ToolGroupRenamed;

        void DisplayModel(ToolGroupsViewModel model);

        void SelectToolGroup(ToolGroup groupToSelect);
    }

    public partial class ToolGroupsView : ViewBase, IToolGroupsView
    {
        private readonly ToolGroupsViewPresenter _presenter;

        public ToolGroupsView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new ToolGroupsViewPresenter(this);
            }
        }

        #region IToolGroupsView Members

        public event EventHandler RefreshGroups;
        public event EventHandler<ToolGroupEventArgs> ToolGroupSelected;
        public event EventHandler AddRootGroup;

        public event EventHandler<ToolGroupEventArgs> AddChildGroup;

        public event EventHandler<ToolGroupEventArgs> ToolGroupRenamed;

        public ToolGroup SelectedToolGroup
        {
            get
            {
                return enhancedTreeView.SelectedNode == null
                    ? null
                    : enhancedTreeView.SelectedNode.Tag as ToolGroup;
            }
        }

        public void DisplayModel(ToolGroupsViewModel model)
        {
            enhancedTreeView.Nodes.Clear();

            var rootGroups = model.ToolGroups.Where(t => !t.ParentGroupId.HasValue);

            foreach (var rootGroup in rootGroups) {
                var rootGroupNode = enhancedTreeView.Nodes.Add(rootGroup.Name);
                rootGroupNode.Tag = rootGroup;
                RecursivelyAddChildGroups(rootGroupNode, model);
            }

            if (enhancedTreeView.Nodes.Count > 0) {
                enhancedTreeView.SelectedNode = enhancedTreeView.Nodes[0];
            }
        }

        public void SelectToolGroup(ToolGroup groupToSelect)
        {
            var nodeStack = new Stack<TreeNode>();
            foreach (TreeNode node in enhancedTreeView.Nodes) {
                nodeStack.Push(node);
            }

            while (nodeStack.Count > 0) {
                var currentNode = nodeStack.Pop();
                foreach (TreeNode childNode in currentNode.Nodes) {
                    nodeStack.Push(childNode);
                }
                var currentGroup = currentNode.Tag as ToolGroup;
                if (currentGroup.Equals(groupToSelect)) {
                    enhancedTreeView.SelectedNode = currentNode;
                    break;
                }
            }
        }

        #endregion

        #region Event invocators

        protected virtual void OnToolGroupRenamed(ToolGroupEventArgs e)
        {
            var handler = ToolGroupRenamed;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnToolGroupSelected(ToolGroupEventArgs e)
        {
            var handler = ToolGroupSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnRefreshGroups()
        {
            var handler = RefreshGroups;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnAddRootGroup()
        {
            var handler = AddRootGroup;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnAddChildGroup(ToolGroupEventArgs e)
        {
            var handler = AddChildGroup;
            if (handler != null) {
                handler(this, e);
            }
        }

        #endregion

        private void RecursivelyAddChildGroups(TreeNode parentNode, ToolGroupsViewModel model)
        {
            var parentGroup = parentNode.Tag as ToolGroup;

            foreach (var childGroup in model.ToolGroups.Where(g => g.ParentGroupId == parentGroup.Id)) {
                var childGroupNode = parentNode.Nodes.Add(childGroup.Name);
                childGroupNode.Tag = childGroup;
                RecursivelyAddChildGroups(childGroupNode, model);
            }
        }

        private void ToolGroupsView_Load(object sender, EventArgs e)
        {
            if (!IsInDesignMode) {
                OnRefreshGroups();
            }
        }

        private void mainContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void nodeContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "addChildGroupToolStripMenuItem":
                    OnAddChildGroup(new ToolGroupEventArgs(SelectedToolGroup));
                    break;
            }
        }
    }
}