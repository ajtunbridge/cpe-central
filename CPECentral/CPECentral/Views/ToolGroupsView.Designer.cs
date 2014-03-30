namespace CPECentral.Views
{
    partial class ToolGroupsView
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
            this.groupsEnhancedTreeView = new nGenLibrary.Controls.EnhancedTreeView();
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRootGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addChildGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.rootGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.childGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mainContextMenuStrip.SuspendLayout();
            this.nodeContextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupsEnhancedTreeView
            // 
            this.groupsEnhancedTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupsEnhancedTreeView.HideSelection = false;
            this.groupsEnhancedTreeView.ImageIndex = 0;
            this.groupsEnhancedTreeView.ImageList = this.treeViewImageList;
            this.groupsEnhancedTreeView.Location = new System.Drawing.Point(0, 25);
            this.groupsEnhancedTreeView.Name = "groupsEnhancedTreeView";
            this.groupsEnhancedTreeView.NodeContextMenuStrip = null;
            this.groupsEnhancedTreeView.SelectedImageIndex = 0;
            this.groupsEnhancedTreeView.Size = new System.Drawing.Size(215, 228);
            this.groupsEnhancedTreeView.TabIndex = 0;
            this.groupsEnhancedTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.enhancedTreeView_AfterLabelEdit);
            this.groupsEnhancedTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.groupsEnhancedTreeView_AfterSelect);
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.treeViewImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mainContextMenuStrip
            // 
            this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRootGroupToolStripMenuItem});
            this.mainContextMenuStrip.Name = "mainContextMenuStrip";
            this.mainContextMenuStrip.Size = new System.Drawing.Size(157, 26);
            this.mainContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainContextMenuStrip_ItemClicked);
            // 
            // addRootGroupToolStripMenuItem
            // 
            this.addRootGroupToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addRootGroupToolStripMenuItem.Name = "addRootGroupToolStripMenuItem";
            this.addRootGroupToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addRootGroupToolStripMenuItem.Text = "&Add root group";
            // 
            // nodeContextMenuStrip
            // 
            this.nodeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChildGroupToolStripMenuItem,
            this.toolStripMenuItem1,
            this.renameToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem});
            this.nodeContextMenuStrip.Name = "nodeContextMenuStrip";
            this.nodeContextMenuStrip.Size = new System.Drawing.Size(161, 82);
            this.nodeContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.nodeContextMenuStrip_ItemClicked);
            // 
            // addChildGroupToolStripMenuItem
            // 
            this.addChildGroupToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addChildGroupToolStripMenuItem.Name = "addChildGroupToolStripMenuItem";
            this.addChildGroupToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addChildGroupToolStripMenuItem.Text = "&Add child group";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::CPECentral.Properties.Resources.RenameIcon_16x16;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.renameToolStripMenuItem.Text = "&Rename";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator1,
            this.renameToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(215, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rootGroupToolStripMenuItem,
            this.childGroupToolStripMenuItem});
            this.addToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(29, 22);
            this.addToolStripButton.Text = "Add new tool group";
            this.addToolStripButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // rootGroupToolStripMenuItem
            // 
            this.rootGroupToolStripMenuItem.Name = "rootGroupToolStripMenuItem";
            this.rootGroupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rootGroupToolStripMenuItem.Text = "Root group";
            this.rootGroupToolStripMenuItem.ToolTipText = "Add a new root group";
            // 
            // childGroupToolStripMenuItem
            // 
            this.childGroupToolStripMenuItem.Name = "childGroupToolStripMenuItem";
            this.childGroupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.childGroupToolStripMenuItem.Text = "Child group";
            this.childGroupToolStripMenuItem.ToolTipText = "Add a new child group to the select group";
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.ToolTipText = "Delete the currently selected tool group";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // renameToolStripButton
            // 
            this.renameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameToolStripButton.Image = global::CPECentral.Properties.Resources.RenameIcon_16x16;
            this.renameToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameToolStripButton.Name = "renameToolStripButton";
            this.renameToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.renameToolStripButton.Text = "Rename";
            this.renameToolStripButton.ToolTipText = "Rename the currently selected tool group";
            // 
            // ToolGroupsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupsEnhancedTreeView);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ToolGroupsView";
            this.Size = new System.Drawing.Size(215, 253);
            this.Load += new System.EventHandler(this.ToolGroupsView_Load);
            this.mainContextMenuStrip.ResumeLayout(false);
            this.nodeContextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private nGenLibrary.Controls.EnhancedTreeView groupsEnhancedTreeView;
        private System.Windows.Forms.ContextMenuStrip nodeContextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addChildGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRootGroupToolStripMenuItem;
        private System.Windows.Forms.ImageList treeViewImageList;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton addToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem rootGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem childGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton renameToolStripButton;
    }
}
