namespace CPECentral.Views
{
    partial class HoldersView
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
            this.holdersEnhancedTreeView = new nGenLibrary.Controls.EnhancedTreeView();
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holderGroupContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holderContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.rootGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.childGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addHolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mainContextMenuStrip.SuspendLayout();
            this.holderGroupContextMenuStrip.SuspendLayout();
            this.holderContextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // holdersEnhancedTreeView
            // 
            this.holdersEnhancedTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holdersEnhancedTreeView.HideSelection = false;
            this.holdersEnhancedTreeView.ImageIndex = 0;
            this.holdersEnhancedTreeView.ImageList = this.treeViewImageList;
            this.holdersEnhancedTreeView.Location = new System.Drawing.Point(0, 25);
            this.holdersEnhancedTreeView.Name = "holdersEnhancedTreeView";
            this.holdersEnhancedTreeView.NodeContextMenuStrip = null;
            this.holdersEnhancedTreeView.SelectedImageIndex = 0;
            this.holdersEnhancedTreeView.Size = new System.Drawing.Size(212, 267);
            this.holdersEnhancedTreeView.TabIndex = 0;
            this.holdersEnhancedTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.holdersEnhancedTreeView_AfterLabelEdit);
            this.holdersEnhancedTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.holdersEnhancedTreeView_AfterSelect);
            this.holdersEnhancedTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.holdersEnhancedTreeView_MouseDown);
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
            this.addGroupToolStripMenuItem});
            this.mainContextMenuStrip.Name = "mainContextMenuStrip";
            this.mainContextMenuStrip.Size = new System.Drawing.Size(132, 26);
            this.mainContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainContextMenuStrip_ItemClicked);
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.addGroupToolStripMenuItem.Text = "&Add group";
            // 
            // holderGroupContextMenuStrip
            // 
            this.holderGroupContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addHolderToolStripMenuItem,
            this.toolStripSeparator3,
            this.renameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.holderGroupContextMenuStrip.Name = "holderGroupContextMenuStrip";
            this.holderGroupContextMenuStrip.Size = new System.Drawing.Size(153, 104);
            this.holderGroupContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.holderGroupContextMenuStrip_ItemClicked);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::CPECentral.Properties.Resources.RenameIcon_16x16;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.renameToolStripMenuItem.Text = "&Rename";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // holderContextMenuStrip
            // 
            this.holderContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.toolStripMenuItem3});
            this.holderContextMenuStrip.Name = "holderGroupContextMenuStrip";
            this.holderContextMenuStrip.Size = new System.Drawing.Size(118, 76);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "E&dit";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::CPECentral.Properties.Resources.RenameIcon_16x16;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "&Rename";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "&Delete";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator2,
            this.renameToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(212, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
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
            this.addToolStripButton.Text = "toolStripButton1";
            // 
            // rootGroupToolStripMenuItem
            // 
            this.rootGroupToolStripMenuItem.Name = "rootGroupToolStripMenuItem";
            this.rootGroupToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.rootGroupToolStripMenuItem.Text = "Root group";
            // 
            // childGroupToolStripMenuItem
            // 
            this.childGroupToolStripMenuItem.Name = "childGroupToolStripMenuItem";
            this.childGroupToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.childGroupToolStripMenuItem.Text = "Child group";
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "toolStripButton2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // renameToolStripButton
            // 
            this.renameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameToolStripButton.Image = global::CPECentral.Properties.Resources.RenameIcon_16x16;
            this.renameToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameToolStripButton.Name = "renameToolStripButton";
            this.renameToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.renameToolStripButton.Text = "toolStripButton4";
            // 
            // addHolderToolStripMenuItem
            // 
            this.addHolderToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addHolderToolStripMenuItem.Name = "addHolderToolStripMenuItem";
            this.addHolderToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.addHolderToolStripMenuItem.Text = "&Add holder";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(130, 6);
            // 
            // HoldersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.holdersEnhancedTreeView);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HoldersView";
            this.Size = new System.Drawing.Size(212, 292);
            this.Load += new System.EventHandler(this.HoldersView_Load);
            this.mainContextMenuStrip.ResumeLayout(false);
            this.holderGroupContextMenuStrip.ResumeLayout(false);
            this.holderContextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private nGenLibrary.Controls.EnhancedTreeView holdersEnhancedTreeView;
        private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip holderGroupContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip holderContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ImageList treeViewImageList;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton addToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem rootGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem childGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton renameToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem addHolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
