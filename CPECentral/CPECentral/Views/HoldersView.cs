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
        event EventHandler LoadHolders;
        event EventHandler<HolderEventArgs> HolderSelectionChanged;
        event UpdateResultCallbackDelegate<HolderGroup> HolderGroupRenamed;
        event UpdateResultCallbackDelegate<Holder> HolderRenamed;

        void DisplayHolders(IEnumerable<HolderGroup> groups, IEnumerable<Holder> holders);
        void ReloadHolders(Holder holderToSelect);
    }

    [DefaultEvent("HolderSelectionChanged")]
    public partial class HoldersView : ViewBase, IHoldersView
    {
        private readonly HoldersViewPresenter _presenter;

        private bool _editMode;

        public HoldersView()
        {
            InitializeComponent();

            treeViewImageList.Images.Add("FolderOpen", Resources.FolderOpenIcon_16x16);
            treeViewImageList.Images.Add("FolderClosed", Resources.FolderClosedIcon_16x16);
            treeViewImageList.Images.Add("Holder", Resources.HolderIcon_16x16);

            if (!IsInDesignMode) {
                _presenter = new HoldersViewPresenter(this);
            }
        }

        public event EventHandler LoadHolders;
        public event EventHandler<HolderEventArgs> HolderSelectionChanged;
        public event UpdateResultCallbackDelegate<HolderGroup> HolderGroupRenamed;
        public event UpdateResultCallbackDelegate<Holder> HolderRenamed;

        [Category("Behavior")]
        public bool EditMode
        {
            get { return _editMode; }
            set
            {
                holdersEnhancedTreeView.LabelEdit = value;
                
                holdersEnhancedTreeView.ContextMenuStrip = value
                    ? mainContextMenuStrip
                    : null;

                _editMode = value;
            }
        }

        public void DisplayHolders(IEnumerable<HolderGroup> groups, IEnumerable<Holder> holders)
        {
            holdersEnhancedTreeView.Nodes.Clear();

            foreach (HolderGroup group in groups) {
                TreeNode groupNode = holdersEnhancedTreeView.Nodes.Add(group.Name);
                groupNode.ImageKey = "FolderClosed";
                groupNode.SelectedImageKey = "FolderOpen";
                groupNode.Tag = group;

                foreach (Holder holder in holders.Where(h => h.HolderGroupId == group.Id)) {
                    TreeNode holderNode = groupNode.Nodes.Add(holder.Name);
                    holderNode.ImageKey = "Holder";
                    holderNode.SelectedImageKey = "Holder";
                    holderNode.Tag = holder;
                }
            }

            holdersEnhancedTreeView.Sort();
        }

        public void ReloadHolders(Holder holderToSelect)
        {
            holdersEnhancedTreeView.Nodes.Clear();
            holdersEnhancedTreeView.Nodes.Add("retrieving...");

            OnLoadHolders();
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

        private void HoldersView_Load(object sender, EventArgs e)
        {
            ReloadHolders(null);
        }

        private void holdersEnhancedTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is HolderGroup) {
                OnHolderSelectionChanged(new HolderEventArgs(null));
            }
            else if (e.Node.Tag is Holder) {
                OnHolderSelectionChanged(new HolderEventArgs(e.Node.Tag as Holder));
            }
        }

        private void holdersEnhancedTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            bool updatedOk = false;

            if (e.Node.Tag is Holder) {
                var holder = e.Node.Tag as Holder;
                holder.Name = e.Label.ToUpper().Trim();
                updatedOk = OnHolderRenamed(holder);
            }
            else if (e.Node.Tag is HolderGroup) {
                var holderGroup = e.Node.Tag as HolderGroup;
                holderGroup.Name = e.Label.ToUpper().Trim();
                updatedOk = OnHolderGroupRenamed(e.Node.Tag as HolderGroup);
            }

            e.CancelEdit = !updatedOk;
        }

        private void holdersEnhancedTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (!EditMode) {
                return;
            }

            // we have to set the context menu in the MouseDown event as it is shown on MouseUp
            var node = holdersEnhancedTreeView.GetNodeAt(e.X, e.Y);

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
    }
}