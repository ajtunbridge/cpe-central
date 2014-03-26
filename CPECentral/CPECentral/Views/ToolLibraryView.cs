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
using CPECentral.ViewModels;
using nGenLibrary;

#endregion

namespace CPECentral.Views
{
    public interface IToolLibraryView : IView
    {
        ToolGroup SelectedToolGroup { get; }
        Tool SelectedTool { get; }
        bool EnableEditing { get; set; }

        event EventHandler LibraryRefreshStarted;
        event EventHandler LibraryRefreshFinished;
        event EventHandler<ToolEventArgs> ToolSelected;
        event EventHandler<ToolEventArgs> ToolActivated;
        event EventHandler<ToolEventArgs> ChangedToolsGroup;
        event UpdateResultCallbackDelegate<ToolGroup> ToolGroupRenamed;
        event UpdateResultCallbackDelegate<Tool> ToolRenamed;

        void DisplayToolGroupsAndTools(ToolLibraryViewModel model);

        void DisplayStockLevels(StockLevelsViewModel model);

        /// <summary>
        /// Refreshes the library
        /// </summary>
        void RefreshLibrary();
        /// <summary>
        /// Refreshes the library and automatically selects the provided tool when finished
        /// </summary>
        /// <param name="toolToSelect">The tool to select after refreshing</param>
        void RefreshLibrary(Tool toolToSelect);
        /// <summary>
        /// Refreshes the library and automatically selects the provided tool group when finished
        /// </summary>
        /// <param name="toolGroupToSelect">The tool group to select after refreshing</param>
        void RefreshLibrary(ToolGroup toolGroupToSelect);

        void SelectTool(Tool toolToSelect);
        void SelectToolGroup(ToolGroup toolGroupToSelect);

        void SelectToolGroup(int toolGroupId);

        void RenameSelectedGroup();
    }

    [DefaultEvent("ToolActivated")]
    public partial class ToolLibraryView : ViewBase, IToolLibraryView
    {
        private const string ReloadingLibraryMessage = "reloading...";
        private readonly ToolLibraryViewPresenter _presenter;
        private bool _enableEditing;
        private Tool _lastSelectedTool;
        private ToolGroup _lastSelectedToolGroup;
        private ToolLibraryViewModel _model;

        public ToolLibraryView()
        {
            InitializeComponent();
            if (!IsInDesignMode) {
                _presenter = new ToolLibraryViewPresenter(this);
            }
        }

        public ContextMenuStrip SelectedToolContextMenuStrip
        {
            get { return toolsEnhancedListView.ItemContextMenuStrip; }
            set { toolsEnhancedListView.ItemContextMenuStrip = value; }
        }

        public ContextMenuStrip ToolListContextMenuStrip
        {
            get { return toolsEnhancedListView.ContextMenuStrip; }
            set { toolsEnhancedListView.ContextMenuStrip = value; }
        }

        public ContextMenuStrip SelectedGroupContextMenuStrip
        {
            get { return toolGroupsEnhancedTreeView.NodeContextMenuStrip; }
            set { toolGroupsEnhancedTreeView.NodeContextMenuStrip = value; }
        }

        public ContextMenuStrip GroupTreeContextMenuStrip
        {
            get { return toolGroupsEnhancedTreeView.ContextMenuStrip; }
            set { toolGroupsEnhancedTreeView.ContextMenuStrip = value; }
        }

        #region IToolLibraryView Members

        public event EventHandler LibraryRefreshStarted;
        public event EventHandler LibraryRefreshFinished;
        public event EventHandler<ToolEventArgs> ToolSelected;
        public event EventHandler<ToolEventArgs> ToolActivated;
        public event EventHandler<ToolEventArgs> ChangedToolsGroup;
        public event UpdateResultCallbackDelegate<ToolGroup> ToolGroupRenamed;
        public event UpdateResultCallbackDelegate<Tool> ToolRenamed;

        public ToolGroup SelectedToolGroup
        {
            get
            {
                if (toolGroupsEnhancedTreeView.SelectedNode == null) {
                    return null;
                }
                return toolGroupsEnhancedTreeView.SelectedNode.Tag as ToolGroup;
            }
        }

        public Tool SelectedTool
        {
            get
            {
                if (toolsEnhancedListView.SelectionCount == 0) {
                    return null;
                }
                return toolsEnhancedListView.SelectedItems[0].Tag as Tool;
            }
        }

        public bool EnableEditing
        {
            get { return _enableEditing; }
            set
            {
                _enableEditing = value;
                toolGroupsEnhancedTreeView.LabelEdit = value;
                toolsEnhancedListView.LabelEdit = value;
            }
        }

        public void DisplayToolGroupsAndTools(ToolLibraryViewModel model)
        {
            _model = model;

            toolGroupsEnhancedTreeView.Nodes.Clear();

            var rootGroups = _model.ToolGroups.Where(t => !t.ParentGroupId.HasValue);

            foreach (var rootGroup in rootGroups) {
                var rootGroupNode = toolGroupsEnhancedTreeView.Nodes.Add(rootGroup.Name);
                rootGroupNode.Tag = rootGroup;
                RecursivelyAddChildGroups(rootGroupNode);
            }

            if (toolGroupsEnhancedTreeView.Nodes.Count > 0) {
                toolGroupsEnhancedTreeView.SelectedNode = toolGroupsEnhancedTreeView.Nodes[0];
            }

            Enabled = true;

            if (_lastSelectedTool != null) {
                SelectTool(_lastSelectedTool);
            }

            OnLibraryRefreshFinished();
        }

        public void DisplayStockLevels(StockLevelsViewModel model)
        {
            stockLevelsEnhancedListView.Items.Clear();

            if (model == null || model.StockLevels == null || !model.StockLevels.Any()) {
                stockLevelsEnhancedListView.Items.Add("None");
                return;
            }

            foreach (var batch in model.StockLevels) {
                ListViewItem item = stockLevelsEnhancedListView.Items.Add(batch.BatchNumber);
                item.SubItems.Add(batch.Quantity.ToString("00"));
                item.SubItems.Add(batch.Location);
            }
        }

        public void RefreshLibrary()
        {
            Enabled = false;

            toolGroupsEnhancedTreeView.Nodes.Clear();
            toolsEnhancedListView.Items.Clear();

            toolGroupsEnhancedTreeView.Nodes.Add(ReloadingLibraryMessage);

            OnReloadLibrary();
        }

        public void RefreshLibrary(Tool toolToSelect)
        {
            _lastSelectedTool = toolToSelect;
            RefreshLibrary();
        }

        public void RefreshLibrary(ToolGroup toolGroupToSelect)
        {
            RefreshLibrary();

        }

        public void SelectTool(Tool toolToSelect)
        {   
            // selecting the node also populates the tools ListView
            SelectToolGroup(toolToSelect.ToolGroupId);

            // find the tool in the ListView and select it
            foreach (ListViewItem item in toolsEnhancedListView.Items) {
                var tool = item.Tag as Tool;
                if (tool.Id != toolToSelect.Id) {
                    continue;
                }
                item.Selected = true;
                break;
            }

            // set input focus to the ListView
            toolsEnhancedListView.Select();
        }

        public void SelectToolGroup(ToolGroup toolGroupToSelect)
        {
            SelectToolGroup(toolGroupToSelect.Id);
        }

        public void SelectToolGroup(int toolGroupId)
        {
            // recursively search TreeNodes to find the group
            var nodeStack = new Stack<TreeNode>();
            foreach (TreeNode treeNode in toolGroupsEnhancedTreeView.Nodes)
            {
                nodeStack.Push(treeNode);
            }
            TreeNode groupNodeToSelect = null;

            while (nodeStack.Count > 0)
            {
                var currentNode = nodeStack.Pop();

                foreach (TreeNode subNode in currentNode.Nodes)
                {
                    nodeStack.Push(subNode);
                }
                var group = currentNode.Tag as ToolGroup;
                if (group.Id != toolGroupId)
                {
                    continue;
                }
                groupNodeToSelect = currentNode;
                break;
            }            
            
            toolGroupsEnhancedTreeView.SelectedNode = groupNodeToSelect;
        }

        public void RenameSelectedGroup()
        {
            toolGroupsEnhancedTreeView.SelectedNode.BeginEdit();
        }

        #endregion

        protected virtual bool OnToolRenamed(Tool entity)
        {
            var updatedOk = false;

            var handler = ToolRenamed;
            if (handler != null) {
                updatedOk = handler(entity);
            }

            return updatedOk;
        }

        private void RecursivelyAddChildGroups(TreeNode parentNode)
        {
            var parentGroup = parentNode.Tag as ToolGroup;

            foreach (var childGroup in _model.ToolGroups.Where(g => g.ParentGroupId == parentGroup.Id)) {
                var childGroupNode = parentNode.Nodes.Add(childGroup.Name);
                childGroupNode.Tag = childGroup;
                RecursivelyAddChildGroups(childGroupNode);
            }
        }

        protected virtual void OnReloadLibrary()
        {
            var handler = LibraryRefreshStarted;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnToolSelected(ToolEventArgs e)
        {
            var handler = ToolSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnLibraryRefreshFinished()
        {
            var handler = LibraryRefreshFinished;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual bool OnToolGroupRenamed(ToolGroup toolGroup)
        {
            var updateSuccessful = false;

            var handler = ToolGroupRenamed;
            if (handler != null) {
                updateSuccessful = handler(toolGroup);
            }

            return updateSuccessful;
        }

        protected virtual void OnToolActivated(ToolEventArgs e)
        {
            var handler = ToolActivated;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnUpdateTool(ToolEventArgs e)
        {
            var handler = ChangedToolsGroup;
            if (handler != null) {
                handler(this, e);
            }
        }

        private void ToolLibraryView_Load(object sender, EventArgs e)
        {
            RefreshLibrary();
        }

        private void toolGroupsEnhancedTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            toolsEnhancedListView.Items.Clear();
            stockLevelsEnhancedListView.Items.Clear();

            var selectedGroup = e.Node.Tag as ToolGroup;

            if (selectedGroup == null) {
                return;
            }

            using (BusyCursor.Show()) {
                var tools = new List<Tool>();

                // recursively retrieve all tools in the selected group and all child groups
                var groupStack = new Stack<ToolGroup>();
                groupStack.Push(selectedGroup);
                while (groupStack.Count > 0) {
                    var currentGroup = groupStack.Pop();
                    var groupTools = _model.Tools.Where(t => t.ToolGroupId == currentGroup.Id);
                    tools.AddRange(groupTools);

                    foreach (var childGroup in _model.ToolGroups.Where(g => g.ParentGroupId == currentGroup.Id)) {
                        groupStack.Push(childGroup);
                    }
                }

                foreach (var tool in tools.OrderBy(t => t.Description)) {
                    var item = toolsEnhancedListView.Items.Add(tool.Description);
                    item.Tag = tool;
                }
            }
        }

        private void toolsEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolsEnhancedListView.SelectionCount == 0) {
                _lastSelectedTool = null;
                return;
            }

            stockLevelsEnhancedListView.Items.Clear();
            stockLevelsEnhancedListView.Items.Add("querying...");

            _lastSelectedTool = toolsEnhancedListView.SelectedItems[0].Tag as Tool;

            OnToolSelected(new ToolEventArgs(_lastSelectedTool));
        }

        private void toolGroupsEnhancedTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) {
                e.CancelEdit = true;
                return;
            }

            var groupToRename = e.Node.Tag as ToolGroup;

            var newName = e.Label.ToUpper().Trim();

            if (groupToRename.Name.Equals(newName, StringComparison.OrdinalIgnoreCase)) {
                e.CancelEdit = true;
                return;
            }

            groupToRename.Name = newName;

            var updatedOk = OnToolGroupRenamed(groupToRename);

            e.CancelEdit = !updatedOk;
        }

        private void toolsEnhancedListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            var toolToRename = toolsEnhancedListView.Items[e.Item].Tag as Tool;

            if (e.Label == null) {
                e.CancelEdit = true;
                return;
            }

            var newName = e.Label.ToUpper().Trim();

            if (toolToRename.Description.Equals(newName, StringComparison.OrdinalIgnoreCase)) {
                e.CancelEdit = true;
                return;
            }

            toolToRename.Description = newName;

            var updatedOk = OnToolRenamed(toolToRename);

            e.CancelEdit = !updatedOk;
        }

        private void toolGroupsEnhancedTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.F2:
                    if (EnableEditing) {
                        toolGroupsEnhancedTreeView.SelectedNode.BeginEdit();
                    }
                    break;
            }
        }

        private void toolsEnhancedListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!EnableEditing) {
                return;
            }

            toolsEnhancedListView.DoDragDrop(toolsEnhancedListView.SelectedItems[0], DragDropEffects.Move);
        }

        private void toolGroupsEnhancedTreeView_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof (ListView.SelectedListViewItemCollection))) {
            //e.Effect = DragDropEffects.Move;
            //}
        }

        private void toolGroupsEnhancedTreeView_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof (ListViewItem))) {
                e.Effect = DragDropEffects.None;
                return;
            }

            var pointToClient = toolGroupsEnhancedTreeView.PointToClient(new Point(e.X, e.Y));

            var node = toolGroupsEnhancedTreeView.GetNodeAt(pointToClient);

            if (node == null) {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (node.PrevVisibleNode != null) {
                node.PrevVisibleNode.BackColor = toolGroupsEnhancedTreeView.BackColor;
            }
            if (node.NextVisibleNode != null) {
                node.NextVisibleNode.BackColor = toolGroupsEnhancedTreeView.BackColor;
            }

            node.BackColor = Color.LightYellow;
            node.Expand();
            e.Effect = DragDropEffects.Move;
        }

        private void toolGroupsEnhancedTreeView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof (ListViewItem))) {
                var pointToClient = toolGroupsEnhancedTreeView.PointToClient(new Point(e.X, e.Y));
                var node = toolGroupsEnhancedTreeView.GetNodeAt(pointToClient);

                if (node == null) {
                    return;
                }

                // if this group has sub-groups, confirm move
                if (node.Nodes.Count > 0) {
                    var ok =
                        DialogService.AskQuestion(
                            "This group has child groups!\n\nAre you sure you're moving it to the correct group?");
                    if (!ok) {
                        return;
                    }
                }

                node.BackColor = toolGroupsEnhancedTreeView.BackColor;

                var droppedItem = (ListViewItem) e.Data.GetData(typeof (ListViewItem));

                var group = node.Tag as ToolGroup;
                var toolsToMove = new List<Tool>();

                var tool = droppedItem.Tag as Tool;
                tool.ToolGroupId = group.Id;
                toolsToMove.Add(tool);

                OnUpdateTool(new ToolEventArgs(tool));

                RefreshLibrary();
            }
        }

        private void toolGroupsEnhancedTreeView_DragLeave(object sender, EventArgs e)
        {
            ForEveryTreeNode(node => node.BackColor = Color.White);
        }

        private void ForEveryTreeNode(Action<TreeNode> action)
        {
            var nodeStack = new Stack<TreeNode>();

            foreach (TreeNode rootNode in toolGroupsEnhancedTreeView.Nodes) {
                nodeStack.Push(rootNode);
            }

            while (nodeStack.Count > 0) {
                var currentNode = nodeStack.Pop();
                action(currentNode);
                foreach (TreeNode childNode in currentNode.Nodes) {
                    nodeStack.Push(childNode);
                }
            }
        }

        private void toolsEnhancedListView_ItemActivate(object sender, EventArgs e)
        {
            var tool = toolsEnhancedListView.SelectedItems[0].Tag as Tool;
            OnToolActivated(new ToolEventArgs(tool));
        }

    }
}