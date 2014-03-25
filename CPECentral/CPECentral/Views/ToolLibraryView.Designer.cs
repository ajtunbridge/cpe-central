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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.toolsEnhancedListView);
            this.splitContainer1.Size = new System.Drawing.Size(692, 367);
            this.splitContainer1.SplitterDistance = 200;
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
            this.toolGroupsEnhancedTreeView.Size = new System.Drawing.Size(200, 367);
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
            this.toolsEnhancedListView.Size = new System.Drawing.Size(488, 367);
            this.toolsEnhancedListView.TabIndex = 0;
            this.toolsEnhancedListView.UseAlternatingBackColor = true;
            this.toolsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.toolsEnhancedListView.View = System.Windows.Forms.View.Details;
            this.toolsEnhancedListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.toolsEnhancedListView_ItemDrag);
            this.toolsEnhancedListView.SelectedIndexChanged += new System.EventHandler(this.toolsEnhancedListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 481;
            // 
            // ToolLibraryView
            // 
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ToolLibraryView";
            this.Size = new System.Drawing.Size(692, 367);
            this.Load += new System.EventHandler(this.ToolLibraryView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private nGenLibrary.Controls.EnhancedTreeView toolGroupsEnhancedTreeView;
        private nGenLibrary.Controls.EnhancedListView toolsEnhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
