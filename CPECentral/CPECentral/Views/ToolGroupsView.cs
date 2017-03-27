#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Delegates;
using CPECentral.Presenters;
using CPECentral.Properties;

#endregion

namespace CPECentral.Views
{
    public interface IToolGroupsView : IView
    {
        ToolGroup SelectedToolGroup { get; }
        bool EditMode { get; set; }

        event EventHandler RefreshGroups;
        event EventHandler AddRootGroup;
        event EventHandler<ToolGroupEventArgs> AddChildGroup;
        event EventHandler<ToolGroupEventArgs> DeleteGroup;
        event EventHandler<ToolGroupEventArgs> ToolGroupSelected;
        event UpdateResultCallbackDelegate<ToolGroup> ToolGroupRenamed;
        event EventHandler<MoveToolsToNewGroupEventArgs> MoveToolToNewGroup;

        void DisplayGroups(IEnumerable<ToolGroup> groups);

        void SelectToolGroup(ToolGroup groupToSelect, bool inEditMode);
    }

    [DefaultEvent("ToolGroupSelected")]
    public partial class ToolGroupsView : ViewBase, IToolGroupsView
    {
        private readonly ToolGroupsPresenter _presenter;
        private bool _editMode;

        public ToolGroupsView()
        {
            InitializeComponent();

            Font = Session.AppFont;

            treeViewImageList.Images.Add("FolderClosed", Resources.FolderClosedIcon_16x16);
            treeViewImageList.Images.Add("FolderOpen", Resources.FolderOpenIcon_16x16);

            if (!IsInDesignMode) {
                _presenter = new ToolGroupsPresenter(this);
            }
        }

        #region IToolGroupsView Members

        public event EventHandler RefreshGroups;
        public event EventHandler<ToolGroupEventArgs> DeleteGroup;

        public event EventHandler<ToolGroupEventArgs> ToolGroupSelected;
        public event EventHandler AddRootGroup;

        public event EventHandler<ToolGroupEventArgs> AddChildGroup;

        public event UpdateResultCallbackDelegate<ToolGroup> ToolGroupRenamed;
        public event EventHandler<MoveToolsToNewGroupEventArgs> MoveToolToNewGroup;

        public ToolGroup SelectedToolGroup
        {
            get
            {
                return groupsEnhancedTreeView.SelectedNode == null
                    ? null
                    : groupsEnhancedTreeView.SelectedNode.Tag as ToolGroup;
            }
        }

        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                groupsEnhancedTreeView.NodeContextMenuStrip = value ? nodeContextMenuStrip : null;
                groupsEnhancedTreeView.ContextMenuStrip = value ? mainContextMenuStrip : null;
                groupsEnhancedTreeView.LabelEdit = value;
                toolStrip.Visible = value;
                _editMode = value;
            }
        }

        public void DisplayGroups(IEnumerable<ToolGroup> groups)
        {
            groupsEnhancedTreeView.Nodes.Clear();

            IEnumerable<ToolGroup> rootGroups = groups.Where(t => !t.ParentGroupId.HasValue);

            TreeNode nodeToSelect = null;

            foreach (ToolGroup rootGroup in rootGroups) {
                TreeNode rootGroupNode = groupsEnhancedTreeView.Nodes.Add(rootGroup.Name);
                rootGroupNode.ImageKey = "FolderClosed";
                rootGroupNode.SelectedImageKey = "FolderOpen";
                rootGroupNode.Tag = rootGroup;
                RecursivelyAddChildGroups(rootGroupNode, groups);
            }

            groupsEnhancedTreeView.Sort();

            if (groupsEnhancedTreeView.Nodes.Count > 0) {
                groupsEnhancedTreeView.SelectedNode = groupsEnhancedTreeView.Nodes[0];
            }
            else {
                OnToolGroupSelected(new ToolGroupEventArgs(null));
            }
        }

        public void SelectToolGroup(ToolGroup groupToSelect, bool inEditMode)
        {
            var nodeStack = new Stack<TreeNode>();
            foreach (TreeNode node in groupsEnhancedTreeView.Nodes) {
                nodeStack.Push(node);
            }

            while (nodeStack.Count > 0) {
                TreeNode currentNode = nodeStack.Pop();
                foreach (TreeNode childNode in currentNode.Nodes) {
                    nodeStack.Push(childNode);
                }
                var currentGroup = currentNode.Tag as ToolGroup;
                if (currentGroup.Equals(groupToSelect)) {
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
            EventHandler<ToolGroupEventArgs> handler = ToolGroupSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual bool OnToolGroupRenamed(ToolGroup entity)
        {
            bool result = false;

            UpdateResultCallbackDelegate<ToolGroup> handler = ToolGroupRenamed;
            if (handler != null) {
                result = handler(entity);
            }

            return result;
        }

        protected virtual void OnMoveToolToNewGroup(MoveToolsToNewGroupEventArgs e)
        {
            EventHandler<MoveToolsToNewGroupEventArgs> handler = MoveToolToNewGroup;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnRefreshGroups()
        {
            EventHandler handler = RefreshGroups;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnAddRootGroup()
        {
            EventHandler handler = AddRootGroup;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnAddChildGroup(ToolGroupEventArgs e)
        {
            EventHandler<ToolGroupEventArgs> handler = AddChildGroup;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnDeleteGroup(ToolGroupEventArgs e)
        {
            EventHandler<ToolGroupEventArgs> handler = DeleteGroup;
            if (handler != null) {
                handler(this, e);
            }
        }

        #endregion

        private void RecursivelyAddChildGroups(TreeNode parentNode, IEnumerable<ToolGroup> groups)
        {
            var parentGroup = parentNode.Tag as ToolGroup;

            foreach (ToolGroup childGroup in groups.Where(g => g.ParentGroupId == parentGroup.Id)) {
                TreeNode childGroupNode = parentNode.Nodes.Add(childGroup.Name);
                childGroupNode.ImageKey = "FolderClosed";
                childGroupNode.SelectedImageKey = "FolderOpen";
                childGroupNode.Tag = childGroup;
                RecursivelyAddChildGroups(childGroupNode, groups);
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

            switch (e.ClickedItem.Name) {
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

            TreeNodeCollection nodesAtSameLevel = e.Node.Parent == null
                ? groupsEnhancedTreeView.Nodes
                : e.Node.Parent.Nodes;

            foreach (TreeNode node in nodesAtSameLevel) {
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

            bool updatedOk = OnToolGroupRenamed(group);

            e.CancelEdit = !updatedOk;
        }

        private void groupsEnhancedTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedGroup = e.Node.Tag as ToolGroup;

            OnToolGroupSelected(new ToolGroupEventArgs(selectedGroup));
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "rootGroupToolStripMenuItem":
                    OnAddRootGroup();
                    break;
                case "childGroupToolStripMenuItem":
                    OnAddChildGroup(new ToolGroupEventArgs(SelectedToolGroup));
                    break;
                case "renameToolStripButton":
                    groupsEnhancedTreeView.SelectedNode.BeginEdit();
                    break;
                case "deleteToolStripButton":
                    OnDeleteGroup(new ToolGroupEventArgs(SelectedToolGroup));
                    break;
            }
        }

        private void groupsEnhancedTreeView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof (ListView.SelectedListViewItemCollection))) {
                Point point = groupsEnhancedTreeView.PointToClient(new Point(e.X, e.Y));

                TreeNode nodeDroppedOn = groupsEnhancedTreeView.GetNodeAt(point);

                if (nodeDroppedOn == null) {
                    return;
                }

                var itemsDropped =
                    (ListView.SelectedListViewItemCollection)
                        e.Data.GetData(typeof (ListView.SelectedListViewItemCollection));

                var group = nodeDroppedOn.Tag as ToolGroup;
                var toolsToMove = new List<Tool>();

                foreach (ListViewItem selectedItem in itemsDropped) {
                    var toolToMove = selectedItem.Tag as Tool;
                    toolsToMove.Add(toolToMove);
                }

                OnMoveToolToNewGroup(new MoveToolsToNewGroupEventArgs(toolsToMove, group));

                groupsEnhancedTreeView.SelectedNode = nodeDroppedOn;
            }
        }

        private void groupsEnhancedTreeView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof (ListView.SelectedListViewItemCollection))) {
                Point pointToClient = groupsEnhancedTreeView.PointToClient(new Point(e.X, e.Y));

                TreeNode node = groupsEnhancedTreeView.GetNodeAt(pointToClient.X, pointToClient.Y);

                if (node == null) {
                    return;
                }

                if (node.PrevVisibleNode != null) {
                    node.PrevVisibleNode.BackColor = Color.White;
                }
                if (node.NextVisibleNode != null) {
                    node.NextVisibleNode.BackColor = Color.White;
                }

                node.BackColor = Color.LightYellow;

                node.Expand();

                e.Effect = e.AllowedEffect;
            }
        }
    }
}