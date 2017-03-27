using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Properties;

namespace CPECentral.Controls
{
    public partial class ClosableTabControl : TabControl
    {
        private Color _selectedTabBackColor = Color.WhiteSmoke;
        private Color _unselectedTabBackColor = Color.Gainsboro;

        public ClosableTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            var tabPage = TabPages[e.Index];
            var rectArea = GetTabRect(e.Index);
            bool isSelected = SelectedIndex == e.Index;

            var fillBrush = isSelected ? new SolidBrush(_selectedTabBackColor) : new SolidBrush(_unselectedTabBackColor);

            using (fillBrush) {
                e.Graphics.FillRectangle(fillBrush, rectArea);
            }

            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            var textColor = isSelected ? tabPage.ForeColor : Color.DimGray;

            using (var brush = new SolidBrush(textColor)) {
                e.Graphics.DrawString(tabPage.Text, tabPage.Font, brush, rectArea, stringFormat);
            }

            // yuk. hacky I know. set the Tag for each TabPage you don't want to show the close
            // button on to 'true'
            if (!(tabPage.Tag is string && (string)tabPage.Tag != "true")){
                var closeImage = e.Index == SelectedIndex
                    ? Resources.CloseIconHighlighted_16x16
                    : Resources.CloseIconNotHighlighted_16x16;

                e.Graphics.DrawImage(closeImage, rectArea.X + rectArea.Width - 16, 4, 12, 12);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            TabPage tabToRemove = null;

            foreach (TabPage tab in TabPages) {
                if (tab.Tag is string && (string) tab.Tag == "false") {
                    continue;
                }

                int index = TabPages.IndexOf(tab);
                
                Rectangle r = GetTabRect(index);

                if (e.Button == MouseButtons.Middle && r.Contains(e.Location)) {
                    tabToRemove = tab;
                    break;
                }

                //Getting the position of the "x" mark.
                var closeButtonArea = new Rectangle(r.Right - 20, r.Top + 0, 16, 16);
                if (closeButtonArea.Contains(e.Location)) {
                    tabToRemove = tab;
                    break;
                }
            }

            if (tabToRemove != null) {
                var dialog = Session.GetInstanceOf<IDialogService>();
                if (dialog.AskQuestion("Are you sure you want to close this page?")) {
                    TabPages.Remove(tabToRemove);
                }
            }
        }
    }
}