#region Using directives

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace nGenLibrary.Controls
{
    public partial class EnhancedListView : ListView
    {
        private const int SWP_NOSIZE = 1;
        private Color _alternateBackgroundColor = Color.LightYellow;
        private int _lastSelectedIndex;

        public EnhancedListView()
        {
            InitializeComponent();

            IndexOfColumnToResize = 0;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, false);
        }

        [Category("Misc")]
        [Description("The number of items in the ListView")]
        public int ItemCount
        {
            get { return Items.Count; }
        }

        [Category("Behavior")]
        [Description("If true, resizes the column to fill the remaining space when resized")]
        public bool ResizeColumnToFill { get; set; }

        public int IndexOfColumnToResize { get; set; }

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

        /// <summary>
        ///     If there are items, this selects the first one
        /// </summary>
        public void SelectFirstItem()
        {
            if (ItemCount > 0) {
                Items[0].Selected = true;
            }
        }

        protected virtual void OnItemsRemoved()
        {
            EventHandler handler = ItemsRemoved;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }

            if (UseAlternatingBackColor) {
                PaintAlternatingBackColor();
            }
        }

        protected virtual void OnItemsAdded()
        {
            EventHandler handler = ItemsAdded;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }

            if (UseAlternatingBackColor) {
                PaintAlternatingBackColor();
            }
        }

        private void EnhancedListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected) {
                _lastSelectedIndex = e.ItemIndex;
            }
        }

        private void EnhancedListView_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = GetItemAt(e.X, e.Y);

            if (e.Button == MouseButtons.Right) {
                ContextMenuStrip menuToShow = (clickedItem == null) ? ContextMenuStrip : ItemContextMenuStrip;

                if (menuToShow == null) {
                    return;
                }

                menuToShow.Show(this, e.X, e.Y);
            }

            if (EnsureSelection) {
                if (clickedItem == null && Items.Count > 0) {
                    Items[_lastSelectedIndex].Selected = true;
                }
            }
        }

        private void PaintAlternatingBackColor()
        {
            int index = 0;

            foreach (ListViewItem item in Items) {
                if (item == null) {
                    continue;
                }

                item.BackColor = (index%2 == 0) ? BackColor : _alternateBackgroundColor;
                index++;
            }
        }

        [DebuggerStepThrough]
        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x14;
            const int LVM_FIRST = 0x1000;
            const int WM_WINDOWPOSCHANGING = 0x46;
            const int LVM_DELETEITEM = LVM_FIRST + 8;
            const int LVM_DELETEALLITEMS = LVM_FIRST + 9;
            const int LVM_INSERTITEMA = LVM_FIRST + 7;
            const int LVM_INSERTITEMW = LVM_FIRST + 77;

            //Filter out the WM_ERASEBKGND message to prevent flicker when redrawing
            if (m.Msg == WM_ERASEBKGND) {
                return;
            }

            base.WndProc(ref m);

            switch (m.Msg) {
                case WM_WINDOWPOSCHANGING:
                    HandleWindowPosChanging(ref m);
                    break;
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

        protected virtual void HandleWindowPosChanging(ref Message m)
        {
            try {
                var pos = new WINDOWPOS();
                pos = (WINDOWPOS) Marshal.PtrToStructure(m.LParam, pos.GetType());
                if (Columns.Count > 0 && ResizeColumnToFill && (pos.flags & SWP_NOSIZE) == 0) {
                    ResizeFreeSpaceFillingColumns(pos.cx - (Bounds.Width - ClientSize.Width));
                }
            }
            catch (ArgumentException) {
            }
        }

        private void ResizeFreeSpaceFillingColumns(int listViewWidth)
        {
            if (Columns.Count == 0) {
                return;
            }

            int sumWidth =
                (from ColumnHeader column in Columns where column.Index != IndexOfColumnToResize select column.Width)
                    .Sum();

            Columns[IndexOfColumnToResize].Width = listViewWidth - sumWidth - 3;
        }

        private void EnhancedListView_ClientSizeChanged(object sender, EventArgs e)
        {
            ResizeFreeSpaceFillingColumns(ClientSize.Width);
        }

        private void EnhancedListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && LabelEdit && SelectionCount == 1) {
                SelectedItems[0].BeginEdit();
            }
        }

        #region Nested type: WINDOWPOS

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int flags;
        }

        #endregion
    }
}