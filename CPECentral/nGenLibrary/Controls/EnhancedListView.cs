using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nGenLibrary.Controls
{
    public partial class EnhancedListView : ListView
    {
        private int _lastSelectedIndex;
        private Color _alternateBackgroundColor = Color.WhiteSmoke;

        public EnhancedListView()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, false);
        }

        [Category("Misc")]
        [Description("The number of items in the ListView")]
        public int ItemCount
        {
            get { return Items.Count; }
        }

        [Category("Misc")]
        [Description("The number of items currently selected")]
        public int SelectionCount
        {
            get { return SelectedItems.Count; }
        }

        [Category("Misc")]
        [Description("The number of items currently checked")]
        public int CheckedCount
        {
            get { return CheckedItems.Count; }
        }

        [Category("Behavior")]
        [Description("Ensures that at least one item is selected at all times")]
        public bool EnsureSelection { get; set; }

        [Category("Behavior")]
        [Description("If true, uses a different back color for every other item")]
        public bool UseAlternatingBackColor { get; set; }

        [Category("Appearance")]
        [Description("The back color to use when UseAlternatingBackColor is true")]
        public Color AlternateBackColor
        {
            get { return _alternateBackgroundColor; }
            set
            {
                _alternateBackgroundColor = value;
                PaintAlternatingBackColor();
            }
        }

        [Category("Behavior")]
        [Description("The context menu to show when an item is right-mouse clicked")]
        public ContextMenuStrip ItemContextMenuStrip { get; set; }

        [Category("Behavior")]
        public new ContextMenuStrip ContextMenuStrip { get; set; }

        /// <summary>
        ///     Raised whenever an item is added to the ListView
        /// </summary>
        public event EventHandler ItemsAdded;

        /// <summary>
        ///     Raised whenever an item is removed from the ListView
        /// </summary>
        public event EventHandler ItemsRemoved;

        protected virtual void OnItemsRemoved()
        {
            var handler = ItemsRemoved;
            if (handler != null) handler(this, EventArgs.Empty);

            if (UseAlternatingBackColor)
                PaintAlternatingBackColor();
        }

        protected virtual void OnItemsAdded()
        {
            var handler = ItemsAdded;
            if (handler != null) handler(this, EventArgs.Empty);

            if (UseAlternatingBackColor)
                PaintAlternatingBackColor();
        }

        private void EnhancedListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                _lastSelectedIndex = e.ItemIndex;
        }

        private void EnhancedListView_MouseUp(object sender, MouseEventArgs e)
        {
            var clickedItem = GetItemAt(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
            {
                if (ItemContextMenuStrip == null && ContextMenuStrip == null)
                    return;

                ContextMenuStrip menuStrip = null;

                if (ItemContextMenuStrip != null && clickedItem != null)
                    menuStrip = ItemContextMenuStrip;
                else
                    menuStrip = ContextMenuStrip;

                menuStrip.Show(this, e.X, e.Y);
            }

            if (EnsureSelection)
            {
                if (clickedItem == null && Items.Count > 0)
                    Items[_lastSelectedIndex].Selected = true;
            }
        }

        private void PaintAlternatingBackColor()
        {
            var index = 0;

            foreach (ListViewItem item in Items)
            {
                if (item == null) continue;

                item.BackColor = (index % 2 == 0) ? BackColor : _alternateBackgroundColor;
                index++;
            }
        }

        [DebuggerStepThrough]
        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x14;
            const int LVM_FIRST = 0x1000;
            const int LVM_DELETEITEM = LVM_FIRST + 8;
            const int LVM_DELETEALLITEMS = LVM_FIRST + 9;
            const int LVM_INSERTITEMA = LVM_FIRST + 7;
            const int LVM_INSERTITEMW = LVM_FIRST + 77;

            //Filter out the WM_ERASEBKGND message to prevent flicker when redrawing
            if (m.Msg == WM_ERASEBKGND) return;

            base.WndProc(ref m);

            switch (m.Msg)
            {
                case LVM_DELETEALLITEMS:
                case LVM_DELETEITEM:
                    OnItemsRemoved();
                    break;
                case LVM_INSERTITEMW:
                case LVM_INSERTITEMA:
                    OnItemsAdded();
                    break;
            }
        }
    }
}
