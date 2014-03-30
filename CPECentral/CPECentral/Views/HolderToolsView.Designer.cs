namespace CPECentral.Views
{
    partial class HolderToolsView
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
            this.holderToolsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.assignToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.unassignToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.assignToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.unassignToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.mainContextMenuStrip.SuspendLayout();
            this.itemContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // holderToolsEnhancedListView
            // 
            this.holderToolsEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.holderToolsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.holderToolsEnhancedListView.ContextMenuStrip = this.mainContextMenuStrip;
            this.holderToolsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holderToolsEnhancedListView.EnsureSelection = false;
            this.holderToolsEnhancedListView.FullRowSelect = true;
            this.holderToolsEnhancedListView.GridLines = true;
            this.holderToolsEnhancedListView.IndexOfColumnToResize = 0;
            this.holderToolsEnhancedListView.ItemContextMenuStrip = this.itemContextMenuStrip;
            this.holderToolsEnhancedListView.Location = new System.Drawing.Point(0, 25);
            this.holderToolsEnhancedListView.MultiSelect = false;
            this.holderToolsEnhancedListView.Name = "holderToolsEnhancedListView";
            this.holderToolsEnhancedListView.ResizeColumnToFill = true;
            this.holderToolsEnhancedListView.Size = new System.Drawing.Size(497, 302);
            this.holderToolsEnhancedListView.TabIndex = 0;
            this.holderToolsEnhancedListView.UseAlternatingBackColor = true;
            this.holderToolsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.holderToolsEnhancedListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tool";
            this.columnHeader1.Width = 490;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignToolStripButton,
            this.unassignToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(497, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // assignToolStripButton
            // 
            this.assignToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.assignToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.assignToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.assignToolStripButton.Name = "assignToolStripButton";
            this.assignToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.assignToolStripButton.Text = "Assign a tool to this holder";
            // 
            // unassignToolStripButton
            // 
            this.unassignToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.unassignToolStripButton.Enabled = false;
            this.unassignToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.unassignToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.unassignToolStripButton.Name = "unassignToolStripButton";
            this.unassignToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.unassignToolStripButton.Text = "Unassign this tool from this holder";
            // 
            // mainContextMenuStrip
            // 
            this.mainContextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignToolToolStripMenuItem});
            this.mainContextMenuStrip.Name = "mainContextMenuStrip";
            this.mainContextMenuStrip.Size = new System.Drawing.Size(142, 26);
            this.mainContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainContextMenuStrip_ItemClicked);
            // 
            // assignToolToolStripMenuItem
            // 
            this.assignToolToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.assignToolToolStripMenuItem.Name = "assignToolToolStripMenuItem";
            this.assignToolToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.assignToolToolStripMenuItem.Text = "&Assign tool";
            // 
            // itemContextMenuStrip
            // 
            this.itemContextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unassignToolToolStripMenuItem});
            this.itemContextMenuStrip.Name = "itemContextMenuStrip";
            this.itemContextMenuStrip.Size = new System.Drawing.Size(157, 26);
            // 
            // unassignToolToolStripMenuItem
            // 
            this.unassignToolToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.unassignToolToolStripMenuItem.Name = "unassignToolToolStripMenuItem";
            this.unassignToolToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.unassignToolToolStripMenuItem.Text = "&Unassign tool";
            // 
            // HolderToolsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.holderToolsEnhancedListView);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HolderToolsView";
            this.Size = new System.Drawing.Size(497, 327);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.mainContextMenuStrip.ResumeLayout(false);
            this.itemContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private nGenLibrary.Controls.EnhancedListView holderToolsEnhancedListView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripButton assignToolStripButton;
        private System.Windows.Forms.ToolStripButton unassignToolStripButton;
        private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem assignToolToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip itemContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem unassignToolToolStripMenuItem;

    }
}
