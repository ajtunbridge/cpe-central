#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public interface IHoldersView : IView
    {
        bool EditMode { get; set; }
        Holder SelectedHolder { get; set; }
        HolderGroup SelectedHolderGroup { get; set; }
        event EventHandler LoadHolders;
        event EventHandler<HolderEventArgs> HolderSelectionChanged;
        event EventHandler AddHolderGroup;
        event EventHandler<HolderGroupEventArgs> AddHolder;
        event UpdateResultCallbackDelegate<HolderGroup> HolderGroupRenamed;
        event UpdateResultCallbackDelegate<HolderGroup> DeleteHolderGroup;
        event UpdateResultCallbackDelegate<Holder> HolderRenamed;
        event UpdateResultCallbackDelegate<Holder> DeleteHolder;

        void DisplayHolders(IEnumerable<HolderGroup> groups, IEnumerable<Holder> holders);
        void ReloadHolders(Holder holderToSelect, bool inEditMode);
        void ReloadHolders(HolderGroup holderGroupToSelect, bool inEditMode);
        void ReloadHolders();
    }

    [DefaultEvent("HolderSelectionChanged")]
    public partial class HoldersView : ViewBase, IHoldersView
    {
        private readonly HoldersViewPresenter _presenter;
        private bool _editMode;
        private HolderGroup _holderGroupToSelect;
        private Holder _holderToSelect;
        private bool _selectInEditMode;
        private Holder _selectedHolder;
        private HolderGroup _selectedHolderGroup;

        public HoldersView()
        {
            InitializeComponent();

            Font = Session.AppFont;

            treeViewImageList.Images.Add("FolderOpen", Resources.FolderOpenIcon_16x16);
            treeViewImageList.Images.Add("FolderClosed", Resources.FolderClosedIcon_16x16);
            treeViewImageList.Images.Add("Holder", Resources.HolderIcon_16x16);

            if (!IsInDesignMode) {
                _presenter = new HoldersViewPresenter(this);
            }
        }

        #region IHoldersView Members

        public event EventHandler LoadHolders;
        public event EventHandler<HolderEventArgs> HolderSelectionChanged;
        public event EventHandler AddHolderGroup;
        public event EventHandler<HolderGroupEventArgs> AddHolder;

        public event UpdateResultCallbackDelegate<HolderGroup> HolderGroupRenamed;
        public event UpdateResultCallbackDelegate<HolderGroup> DeleteHolderGroup;
        public event UpdateResultCallbackDelegate<Holder> HolderRenamed;
        public event UpdateResultCallbackDelegate<Holder> DeleteHolder;

        public Holder SelectedHolder
        {
            get { return _selectedHolder; }
            set { SelectHolder(value); }
        }

        public HolderGroup SelectedHolderGroup
        {
            get { return _selectedHolderGroup; }
            set { SelectHolderGroup(value); }
        }

        [Category("Behavior")]
        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                holdersEnhancedTreeView.LabelEdit = value;
                toolStrip.Visible = value;
                holdersEnhancedTreeView.ContextMenuStrip = value
                    ? mainContextMenuStrip
                    : null;

                _editMode = value;
            }
        }

        public void DisplayHolders(IEnumerable<HolderGroup> groups, IEnumerable<Holder> holders)
        {
            holdersEnhancedTreeView.Nodes.Clear();

            TreeNode nodeToSelect = null;

            foreach (HolderGroup group in groups) {
                TreeNode groupNode = holdersEnhancedTreeView.Nodes.Add(group.Name);
                groupNode.ImageKey = "FolderClosed";
                groupNode.SelectedImageKey = "FolderOpen";
                groupNode.Tag = group;

                if (_holderGroupToSelect != null) {
                    if (group.Equals(_holderGroupToSelect)) {
                        nodeToSelect = groupNode;
                    }
                }

                foreach (Holder holder in holders.Where(h => h.HolderGroupId == group.Id)) {
                    TreeNode holderNode = groupNode.Nodes.Add(holder.Name);
                    holderNode.ImageKey = "Holder";
                    holderNode.SelectedImageKey = "Holder";
                    holderNode.Tag = holder;

                    if (_holderToSelect != null) {
                        if (holder.Equals(_holderToSelect)) {
                            nodeToSelect = holderNode;
                        }
                    }
                }
            }

            holdersEnhancedTreeView.Sort();

            if (nodeToSelect != null) {
                holdersEnhancedTreeView.SelectedNode = nodeToSelect;
                if (_selectInEditMode) {
                    _selectInEditMode = false;
                    nodeToSelect.BeginEdit();
                }
            }
            else {
                if (holdersEnhancedTreeView.Nodes.Count > 0) {
                    holdersEnhancedTreeView.SelectedNode = holdersEnhancedTreeView.Nodes[0];
                }
            }
        }

        public void ReloadHolders(Holder holderToSelect, bool inEditMode)
        {
            _holderToSelect = holderToSelect;
            _holderGroupToSelect = null;

            _selectInEditMode = inEditMode;

            ReloadHolders();
        }

        public void ReloadHolders(HolderGroup holderGroupToSelect, bool inEditMode)
        {
            _holderGroupToSelect = holderGroupToSelect;
            _holderToSelect = null;

            _selectInEditMode = inEditMode;

            ReloadHolders();
        }

        public void ReloadHolders()
        {
            holdersEnhancedTreeView.Nodes.Clear();
            holdersEnhancedTreeView.Nodes.Add("retrieving...");

            OnLoadHolders();
        }

        #endregion

        #region Event Invocators

        protected virtual bool OnDeleteHolder(Holder entity)
        {
            bool deletedOk = false;

            UpdateResultCallbackDelegate<Holder> handler = DeleteHolder;
            if (handler != null) {
                deletedOk = handler(entity);
            }

            return deletedOk;
        }

        protected virtual bool OnDeleteHolderGroup(HolderGroup entity)
        {
            bool deletedOk = false;

            UpdateResultCallbackDelegate<HolderGroup> handler = DeleteHolderGroup;
            if (handler != null) {
                deletedOk = handler(entity);
            }

            return deletedOk;
        }

        protected virtual void OnHolderSelectionChanged(HolderEventArgs e)
        {
            EventHandler<HolderEventArgs> handler = HolderSelectionChanged;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnLoadHolders()
        {
            EventHandler handler = LoadHolders;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnAddHolderGroup()
        {
            EventHandler handler = AddHolderGroup;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnAddHolder(HolderGroupEventArgs e)
        {
            EventHandler<HolderGroupEventArgs> handler = AddHolder;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual bool OnHolderGroupRenamed(HolderGroup entity)
        {
            bool updatedOk = false;

            UpdateResultCallbackDelegate<HolderGroup> handler = HolderGroupRenamed;
            if (handler != null) {
                updatedOk = handler(entity);
            }

            return updatedOk;
        }

        protected virtual bool OnHolderRenamed(Holder entity)
        {
            bool updatedOk = false;

            UpdateResultCallbackDelegate<Holder> handler = HolderRenamed;
            if (handler != null) {
                updatedOk = handler(entity);
            }

            return updatedOk;
        }

        #endregion

        private void HoldersView_Load(object sender, EventArgs e)
        {
            ReloadHolders();
        }

        private void holdersEnhancedTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is HolderGroup) {
                _selectedHolderGroup = e.Node.Tag as HolderGroup;
                _selectedHolder = null;
                addGroupDropDownToolStripMenuItem.Enabled = true;
                OnHolderSelectionChanged(new HolderEventArgs(null));
            }
            else if (e.Node.Tag is Holder) {
                var holder = e.Node.Tag as Holder;
                _selectedHolder = holder;
                _selectedHolderGroup = null;
                addHolderDropDownToolStripMenuItem.Enabled = false;
                OnHolderSelectionChanged(new HolderEventArgs(holder));
            }
        }

        private void holdersEnhancedTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) {
                e.CancelEdit = true;
                return;
            }

            bool updatedOk = false;

            if (e.Node.Tag is Holder) {
                var holder = e.Node.Tag as Holder;
                holder.Name = e.Label.ToUpper().Trim();
                updatedOk = OnHolderRenamed(holder);

                if (updatedOk) {
                    _holderToSelect = holder;
                    _holderGroupToSelect = null;
                }
            }
            else if (e.Node.Tag is HolderGroup) {
                var holderGroup = e.Node.Tag as HolderGroup;
                holderGroup.Name = e.Label.ToUpper().Trim();
                updatedOk = OnHolderGroupRenamed(e.Node.Tag as HolderGroup);

                if (updatedOk) {
                    _holderGroupToSelect = holderGroup;
                    _holderToSelect = null;
                }
            }

            if (updatedOk) {
                OnLoadHolders();
            }
        }

        private void holdersEnhancedTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (!EditMode) {
                return;
            }

            // we have to set the context menu in the MouseDown event as it is shown on MouseUp
            TreeNode node = holdersEnhancedTreeView.GetNodeAt(e.X, e.Y);

            if (node == null) {
                return;
            }

            if (node.Tag is Holder) {
                holdersEnhancedTreeView.NodeContextMenuStrip = holderContextMenuStrip;
            }
            else if (node.Tag is HolderGroup) {
                holdersEnhancedTreeView.NodeContextMenuStrip = holderGroupContextMenuStrip;
            }
        }

        private void holdersEnhancedTreeView_DeleteKeyPressed(object sender, EventArgs e)
        {
            DeleteSelectedEntity();
        }

        private void mainContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            mainContextMenuStrip.Hide();

            switch (e.ClickedItem.Name) {
                case "addGroupToolStripMenuItem":
                    OnAddHolderGroup();
                    break;
            }
        }

        private void holderGroupContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            holderGroupContextMenuStrip.Hide();

            switch (e.ClickedItem.Name) {
                case "addHolderToolStripMenuItem":
                    OnAddHolder(new HolderGroupEventArgs(_selectedHolderGroup));
                    break;
                case "deleteHolderGroupToolStripMenuItem":
                    DeleteSelectedEntity();
                    break;
                case "renameHolderGroupToolStripMenuItem":
                    EditLabelOnSelectedNode();
                    break;
            }
        }

        private void holderContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            holderContextMenuStrip.Hide();

            switch (e.ClickedItem.Name) {
                case "deleteHolderToolStripMenuItem":
                    DeleteSelectedEntity();
                    break;
                case "renameHolderToolStripMenuItem":
                    EditLabelOnSelectedNode();
                    break;
            }
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name) {
                case "addGroup2ToolStripMenuItem":
                    OnAddHolderGroup();
                    break;
                case "addHolder2ToolStripMenuItem":
                    OnAddHolder(new HolderGroupEventArgs(_selectedHolderGroup));
                    break;
                case "deleteToolStripButton":
                    DeleteSelectedEntity();
                    break;
                case "renameToolStripButton":
                    EditLabelOnSelectedNode();
                    break;
            }
        }

        /// <summary>
        /// Recurses through the TreeView's nodes and selects the specified <see cref="Holder"/> node if it exists
        /// </summary>
        /// <param name="holder">The <see cref="Holder"/> to select</param>
        private void SelectHolder(Holder holder)
        {
            foreach (TreeNode groupNode in holdersEnhancedTreeView.Nodes)
            {
                foreach (TreeNode holderNode in groupNode.Nodes)
                {
                    var currentHolder = holderNode.Tag as Holder;
                    if (currentHolder.Equals(holder))
                    {
                        holdersEnhancedTreeView.SelectedNode = holderNode;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Recurses through the TreeView's nodes and selects the specified <see cref="HolderGroup"/> node if it exists
        /// </summary>
        /// <param name="holderGroup">The <see cref="HolderGroup"/> to select</param>
        private void SelectHolderGroup(HolderGroup holderGroup)
        {
            foreach (TreeNode groupNode in holdersEnhancedTreeView.Nodes)
            {
                var currentGroup = groupNode.Tag as HolderGroup;
                if (currentGroup.Equals(holderGroup))
                {
                    holdersEnhancedTreeView.SelectedNode = groupNode;
                    break;
                }
            }
        }

        /// <summary>
        /// If a node is selected in the TreeView and EditMode is true, begins LabelEdit
        /// </summary>
        private void EditLabelOnSelectedNode()
        {
            if (holdersEnhancedTreeView.SelectedNode != null && EditMode)
            {
                holdersEnhancedTreeView.SelectedNode.BeginEdit();
            }
        }

        /// <summary>
        ///     If a node is selected in the TreeView, deletes the entity it relates to
        /// </summary>
        private void DeleteSelectedEntity()
        {
            if (holdersEnhancedTreeView.SelectedNode == null)
            {
                return;
            }

            bool deletedOk = false;

            if (_selectedHolder != null)
            {
                deletedOk = OnDeleteHolder(_selectedHolder);
            }
            else if (_selectedHolderGroup != null)
            {
                deletedOk = OnDeleteHolderGroup(_selectedHolderGroup);
            }

            if (deletedOk)
            {
                ReloadHolders();
            }
        }
    }
}