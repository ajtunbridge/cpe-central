namespace CPECentral.Views
{
    partial class ToolLibraryView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolGroupsEnhancedTreeView = new nGenLibrary.Controls.EnhancedTreeView();
            this.toolsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.stockLevelsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolGroupsEnhancedTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(654, 351);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 3;
            // 
            // toolGroupsEnhancedTreeView
            // 
            this.toolGroupsEnhancedTreeView.AllowDrop = true;
            this.toolGroupsEnhancedTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolGroupsEnhancedTreeView.HideSelection = false;
            this.toolGroupsEnhancedTreeView.Location = new System.Drawing.Point(0, 0);
            this.toolGroupsEnhancedTreeView.Name = "toolGroupsEnhancedTreeView";
            this.toolGroupsEnhancedTreeView.NodeContextMenuStrip = null;
            this.toolGroupsEnhancedTreeView.Size = new System.Drawing.Size(189, 351);
            this.toolGroupsEnhancedTreeView.TabIndex = 0;
            this.toolGroupsEnhancedTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.toolGroupsEnhancedTreeView_AfterLabelEdit);
            this.toolGroupsEnhancedTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.toolGroupsEnhancedTreeView_AfterSelect);
            this.toolGroupsEnhancedTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.toolGroupsEnhancedTreeView_DragDrop);
            this.toolGroupsEnhancedTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.toolGroupsEnhancedTreeView_DragEnter);
            this.toolGroupsEnhancedTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.toolGroupsEnhancedTreeView_DragOver);
            this.toolGroupsEnhancedTreeView.DragLeave += new System.EventHandler(this.toolGroupsEnhancedTreeView_DragLeave);
            this.toolGroupsEnhancedTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolGroupsEnhancedTreeView_KeyDown);
            // 
            // toolsEnhancedListView
            // 
            this.toolsEnhancedListView.AllowDrop = true;
            this.toolsEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.toolsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.toolsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsEnhancedListView.EnsureSelection = false;
            this.toolsEnhancedListView.FullRowSelect = true;
            this.toolsEnhancedListView.GridLines = true;
            this.toolsEnhancedListView.HideSelection = false;
            this.toolsEnhancedListView.IndexOfColumnToResize = 0;
            this.toolsEnhancedListView.ItemContextMenuStrip = null;
            this.toolsEnhancedListView.Location = new System.Drawing.Point(0, 0);
            this.toolsEnhancedListView.MultiSelect = false;
            this.toolsEnhancedListView.Name = "toolsEnhancedListView";
            this.toolsEnhancedListView.ResizeColumnToFill = true;
            this.toolsEnhancedListView.ShowItemToolTips = true;
            this.toolsEnhancedListView.Size = new System.Drawing.Size(461, 167);
            this.toolsEnhancedListView.TabIndex = 0;
            this.toolsEnhancedListView.UseAlternatingBackColor = true;
            this.toolsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.toolsEnhancedListView.View = System.Windows.Forms.View.Details;
            this.toolsEnhancedListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.toolsEnhancedListView_AfterLabelEdit);
            this.toolsEnhancedListView.ItemActivate += new System.EventHandler(this.toolsEnhancedListView_ItemActivate);
            this.toolsEnhancedListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.toolsEnhancedListView_ItemDrag);
            this.toolsEnhancedListView.SelectedIndexChanged += new System.EventHandler(this.toolsEnhancedListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 454;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.toolsEnhancedListView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.stockLevelsEnhancedListView);
            this.splitContainer2.Size = new System.Drawing.Size(461, 351);
            this.splitContainer2.SplitterDistance = 167;
            this.splitContainer2.TabIndex = 1;
            // 
            // stockLevelsEnhancedListView
            // 
            this.stockLevelsEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.stockLevelsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.stockLevelsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockLevelsEnhancedListView.EnsureSelection = false;
            this.stockLevelsEnhancedListView.FullRowSelect = true;
            this.stockLevelsEnhancedListView.GridLines = true;
            this.stockLevelsEnhancedListView.IndexOfColumnToResize = 2;
            this.stockLevelsEnhancedListView.ItemContextMenuStrip = null;
            this.stockLevelsEnhancedListView.Location = new System.Drawing.Point(0, 0);
            this.stockLevelsEnhancedListView.Name = "stockLevelsEnhancedListView";
            this.stockLevelsEnhancedListView.ResizeColumnToFill = true;
            this.stockLevelsEnhancedListView.Size = new System.Drawing.Size(461, 180);
            this.stockLevelsEnhancedListView.TabIndex = 0;
            this.stockLevelsEnhancedListView.UseAlternatingBackColor = true;
            this.stockLevelsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.stockLevelsEnhancedListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Batch number";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Location";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 254;
            // 
            // ToolLibraryView
            // 
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ToolLibraryView";
            this.Size = new System.Drawing.Size(654, 351);
            this.Load += new System.EventHandler(this.ToolLibraryView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private nGenLibrary.Controls.EnhancedTreeView toolGroupsEnhancedTreeView;
        private nGenLibrary.Controls.EnhancedListView toolsEnhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private nGenLibrary.Controls.EnhancedListView stockLevelsEnhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
