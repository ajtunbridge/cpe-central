#region Using directives

using System.Diagnostics;
using System.Windows.Forms;

#endregion

namespace nGenLibrary.Controls
{
    public partial class EnhancedTreeView : TreeView
    {
        public EnhancedTreeView()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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

        [DebuggerStepThrough]
        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x14;

            //Filter out the WM_ERASEBKGND message to prevent flicker when redrawing
            if (m.Msg == WM_ERASEBKGND) return;

            base.WndProc(ref m);
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