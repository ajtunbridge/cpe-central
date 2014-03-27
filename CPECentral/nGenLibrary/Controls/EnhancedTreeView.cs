#region Using directives

using System.ComponentModel;
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

        [Category("Behavior")]
        [Description("The context menu to show when a node is right-mouse clicked.")]
        public ContextMenuStrip NodeContextMenuStrip { get; set; }

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
            if (e.Button == MouseButtons.Right) {

                var clickedNode = GetNodeAt(e.X, e.Y);

                var contextMenu = (clickedNode == null) ? ContextMenuStrip : NodeContextMenuStrip;

                if (contextMenu != null) {
                    contextMenu.Show(this, e.X, e.Y);
                }

                if (clickedNode == null) {
                    return;
                }

                if (SelectedNode != null && SelectedNode == clickedNode)
                    return;

                SelectedNode = clickedNode;
            }
        }
    }
}