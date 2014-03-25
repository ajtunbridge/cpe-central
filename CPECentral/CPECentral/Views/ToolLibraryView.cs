#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Presenters;
using CPECentral.ViewModels;
using nGenLibrary;

#endregion

namespace CPECentral.Views
{
    public interface IToolLibraryView
    {
        event EventHandler LibraryRefreshStarted;
        event EventHandler LibraryRefreshFinished;
        event EventHandler<ToolEventArgs> ToolSelected;

        ToolGroup SelectedToolGroup { get; }

        Tool SelectedTool { get; }

        void DisplayModel(ToolLibraryViewModel model);
        void RefreshLibrary();
        void SelectTool(Tool toolToSelect);
    }

    public partial class ToolLibraryView : ViewBase, IToolLibraryView
    {
        private const string PlaceholderNodeText = "delete";
        private const string ReloadingLibraryMessage = "reloading...";
        private readonly ToolLibraryViewPresenter _presenter;
        private ToolLibraryViewModel _model;

        public ToolLibraryView()
        {
            InitializeComponent();
            if (!IsInDesignMode) {
                _presenter = new ToolLibraryViewPresenter(this);
            }
        }

        #region IToolLibraryView Members

        public event EventHandler LibraryRefreshStarted;
        public event EventHandler LibraryRefreshFinished;
        public event EventHandler<ToolEventArgs> ToolSelected;

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

        public void DisplayModel(ToolLibraryViewModel model)
        {
            _model = model;

            toolGroupsEnhancedTreeView.Nodes.Clear();

            var rootGroups = _model.ToolGroups.Where(t => !t.ParentGroupId.HasValue);

            foreach (var rootGroup in rootGroups) {
                var rootGroupNode = toolGroupsEnhancedTreeView.Nodes.Add(rootGroup.Name);
                rootGroupNode.Tag = rootGroup;
                RecursivelyAddChildGroups(rootGroupNode);
            }

            OnLibraryRefreshFinished();
        }

        public void RefreshLibrary()
        {
            toolGroupsEnhancedTreeView.Nodes.Clear();
            toolsEnhancedListView.Items.Clear();

            toolGroupsEnhancedTreeView.Nodes.Add(ReloadingLibraryMessage);

            OnReloadLibrary();
        }

        public void SelectTool(Tool toolToSelect)
        {
            // recursively search TreeNodes to find the group the tool belongs to
            var nodeStack = new Stack<TreeNode>();
            foreach (TreeNode treeNode in toolGroupsEnhancedTreeView.Nodes) {
                nodeStack.Push(treeNode);
            }
            TreeNode groupNodeToSelect = null;

            while (nodeStack.Count > 0) {
                var currentNode = nodeStack.Pop();

                foreach (TreeNode subNode in currentNode.Nodes) {
                    nodeStack.Push(subNode);
                }
                var group = currentNode.Tag as ToolGroup;
                if (group.Id != toolToSelect.ToolGroupId) {
                    continue;
                }
                groupNodeToSelect = currentNode;
                break;
            }

            // selecting the node also populates the tools ListView
            toolGroupsEnhancedTreeView.SelectedNode = groupNodeToSelect;

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

        #endregion

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
            EventHandler<ToolEventArgs> handler = ToolSelected;
            if (handler != null)
            {
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

        private void ToolLibraryView_Load(object sender, EventArgs e)
        {
            RefreshLibrary();
        }

        private void toolGroupsEnhancedTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == PlaceholderNodeText) {
                e.Node.Nodes.Clear();

                var parentGroup = e.Node.Tag as ToolGroup;
                var childGroups = _model.ToolGroups.Where(group => group.ParentGroupId == parentGroup.Id);

                foreach (var childGroup in childGroups) {
                    var childNode = e.Node.Nodes.Add(childGroup.Name);
                    childNode.Tag = childGroup;
                    if (_model.ToolGroups.Any(g => g.ParentGroupId == childGroup.Id)) {
                        childNode.Nodes.Add(PlaceholderNodeText);
                    }
                }
            }
        }

        private void toolGroupsEnhancedTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            toolsEnhancedListView.Items.Clear();

            var selectedGroup = e.Node.Tag as ToolGroup;

            if (selectedGroup == null) {
                return;
            }

            using (BusyCursor.Show()) {
                var tools = new List<Tool>();

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
            if (toolsEnhancedListView.SelectionCount == 0)
                return;

            var selectedTool = toolsEnhancedListView.SelectedItems[0].Tag as Tool;

            OnToolSelected(new ToolEventArgs(selectedTool));
        }
    }
}