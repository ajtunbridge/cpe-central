namespace CPECentral.Views
{
    partial class ToolsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewContextMenuStrip.SuspendLayout();
            this.listViewItemContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolsEnhancedListView
            // 
            this.toolsEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.toolsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
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
            this.toolsEnhancedListView.Size = new System.Drawing.Size(453, 270);
            this.toolsEnhancedListView.TabIndex = 0;
            this.toolsEnhancedListView.UseAlternatingBackColor = true;
            this.toolsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.toolsEnhancedListView.View = System.Windows.Forms.View.Details;
            this.toolsEnhancedListView.ItemActivate += new System.EventHandler(this.toolsEnhancedListView_ItemActivate);
            this.toolsEnhancedListView.SelectedIndexChanged += new System.EventHandler(this.toolsEnhancedListView_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 446;
            // 
            // listViewContextMenuStrip
            // 
            this.listViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolToolStripMenuItem});
            this.listViewContextMenuStrip.Name = "listViewContextMenuStrip";
            this.listViewContextMenuStrip.Size = new System.Drawing.Size(121, 26);
            this.listViewContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.listViewContextMenuStrip_ItemClicked);
            // 
            // addToolToolStripMenuItem
            // 
            this.addToolToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addToolToolStripMenuItem.Name = "addToolToolStripMenuItem";
            this.addToolToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.addToolToolStripMenuItem.Text = "&Add tool";
            // 
            // listViewItemContextMenuStrip
            // 
            this.listViewItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.listViewItemContextMenuStrip.Name = "listViewItemContextMenuStrip";
            this.listViewItemContextMenuStrip.Size = new System.Drawing.Size(118, 76);
            this.listViewItemContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.listViewItemContextMenuStrip_ItemClicked);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameToolStripMenuItem.Text = "&Rename";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // ToolsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolsEnhancedListView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ToolsView";
            this.Size = new System.Drawing.Size(453, 270);
            this.listViewContextMenuStrip.ResumeLayout(false);
            this.listViewItemContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private nGenLibrary.Controls.EnhancedListView toolsEnhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip listViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip listViewItemContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
    }
}
