#region Using directives

using System.Windows.Forms;

#endregion

namespace nGenLibrary.Controls
{
    public partial class EnhancedTreeView : TreeView
    {
        public EnhancedTreeView()
        {
            InitializeComponent();
        }

        public new TreeNode SelectedNode
        {
            get { return base.SelectedNode; }
            set
            {
                base.SelectedNode = value;

                OnAfterSelect(new TreeViewEventArgs(value, TreeViewAction.Unknown));
            }
        }

        private void EnhancedTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var clickedNode = GetNodeAt(e.X, e.Y);

            if (clickedNode == null)
                return;

            SelectedNode = clickedNode;
        }
    }
}