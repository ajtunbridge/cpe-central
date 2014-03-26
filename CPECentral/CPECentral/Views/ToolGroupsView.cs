#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Delegates;
using CPECentral.Presenters;
using CPECentral.ViewModels;

#endregion

namespace CPECentral.Views
{
    public interface IToolGroupsView : IView
    {
        ToolGroup SelectedToolGroup { get; }
        bool EnableEditing { get; set; }

        event EventHandler RefreshGroups;
        event EventHandler AddRootGroup;
        event EventHandler<ToolGroupEventArgs> AddChildGroup;
        event EventHandler<ToolGroupEventArgs> DeleteGroup;
        event EventHandler<ToolGroupEventArgs> ToolGroupSelected;
        event UpdateResultCallbackDelegate<ToolGroup> ToolGroupRenamed;

        void DisplayModel(ToolGroupsViewModel model);

        void SelectToolGroup(ToolGroup groupToSelect, bool inEditMode);
    }

    public partial class ToolGroupsView : ViewBase, IToolGroupsView
    {
        private readonly ToolGroupsViewPresenter _presenter;
        private bool _enableEditing = false;

        public ToolGroupsView()
        {
            InitializeComponent();

            if (!IsInDesignMode) {
                _presenter = new ToolGroupsViewPresenter(this);
            }
        }

        #region IToolGroupsView Members

        public event EventHandler RefreshGroups;
        public event EventHandler<ToolGroupEventArgs> DeleteGroup;
        public event EventHandler<ToolGroupEventArgs> ToolGroupSelected;
        public event EventHandler AddRootGroup;

        public event EventHandler<ToolGroupEventArgs> AddChildGroup;

        public event UpdateResultCallbackDelegate<ToolGroup> ToolGroupRenamed;

        public ToolGroup SelectedToolGroup
        {
            get
            {
                return groupsEnhancedTreeView.SelectedNode == null
                    ? null
                    : groupsEnhancedTreeView.SelectedNode.Tag as ToolGroup;
            }
        }

        public bool EnableEditing
        {
            get { return _enableEditing; }
            set
            {
                groupsEnhancedTreeView.NodeContextMenuStrip = value ? nodeContextMenuStrip : null;
                groupsEnhancedTreeView.ContextMenuStrip = value ? mainContextMenuStrip : null;
                groupsEnhancedTreeView.LabelEdit = value;
                _enableEditing = value;
            }
        }

        public void DisplayModel(ToolGroupsViewModel model)
        {
            groupsEnhancedTreeView.Nodes.Clear();

            var rootGroups = model.ToolGroups.Where(t => !t.ParentGroupId.HasValue);

            foreach (var rootGroup in rootGroups) {
                var rootGroupNode = groupsEnhancedTreeView.Nodes.Add(rootGroup.Name);
                rootGroupNode.Tag = rootGroup;
                RecursivelyAddChildGroups(rootGroupNode, model);
            }

            if (groupsEnhancedTreeView.Nodes.Count > 0) {
                groupsEnhancedTreeView.SelectedNode = groupsEnhancedTreeView.Nodes[0];
            }
        }

        public void SelectToolGroup(ToolGroup groupToSelect, bool inEditMode)
        {
            var nodeStack = new Stack<TreeNode>();
            foreach (TreeNode node in groupsEnhancedTreeView.Nodes)
            {
                nodeStack.Push(node);
            }

            while (nodeStack.Count > 0)
            {
                var currentNode = nodeStack.Pop();
                foreach (TreeNode childNode in currentNode.Nodes)
                {
                    nodeStack.Push(childNode);
                }
                var currentGroup = currentNode.Tag as ToolGroup;
                if (currentGroup.Equals(groupToSelect))
                {
                    groupsEnhancedTreeView.SelectedNode = currentNode;
                    if (inEditMode) {
                        groupsEnhancedTreeView.SelectedNode.BeginEdit();
                    }
                    break;
                }
            }
        }

        #endregion

        #region Event invocators

        protected virtual void OnToolGroupSelected(ToolGroupEventArgs e)
        {
            var handler = ToolGroupSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual bool OnToolGroupRenamed(ToolGroup entity)
        {
            bool result = false;

            UpdateResultCallbackDelegate<ToolGroup> handler = ToolGroupRenamed;
            if (handler != null)
            {
                result = handler(entity);
            }

            return result;
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

        protected virtual void OnDeleteGroup(ToolGroupEventArgs e)
        {
            EventHandler<ToolGroupEventArgs> handler = DeleteGroup;
            if (handler != null)
            {
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
            mainContextMenuStrip.Hide();

            switch (e.ClickedItem.Name) {
                case "addRootGroupToolStripMenuItem":
                    OnAddRootGroup();
                    break;
            }
        }

        private void nodeContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            nodeContextMenuStrip.Hide();

            switch (e.ClickedItem.Name)
            {
                case "addChildGroupToolStripMenuItem":
                    OnAddChildGroup(new ToolGroupEventArgs(SelectedToolGroup));
                    break;
                case "editToolStripMenuItem":
                    groupsEnhancedTreeView.SelectedNode.BeginEdit();
                    break;
                case "deleteToolStripMenuItem":
                    OnDeleteGroup(new ToolGroupEventArgs(SelectedToolGroup));
                    break;
            }
        }

        private void enhancedTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Label)) {
                e.CancelEdit = true;
                return;
            }

            var nodesAtSameLevel = e.Node.Parent == null ? groupsEnhancedTreeView.Nodes : e.Node.Parent.Nodes;

            foreach (TreeNode node in nodesAtSameLevel)
            {
                if (node == e.Node) {
                    continue;
                }
                if (node.Text == e.Label.ToUpper()) {
                    DialogService.Notify("A group with this name already exists at this level!");
                    e.CancelEdit = true;
                    return;
                }
            }

            var group = groupsEnhancedTreeView.SelectedNode.Tag as ToolGroup;
            group.Name = e.Label.ToUpper();
            
            var updatedOk = OnToolGroupRenamed(group);

            e.CancelEdit = !updatedOk;
        }

        private void groupsEnhancedTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedGroup = e.Node.Tag as ToolGroup;

            OnToolGroupSelected(new ToolGroupEventArgs(selectedGroup));
        }
    }
}