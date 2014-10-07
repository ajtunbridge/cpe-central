namespace CPECentral.Views
{
    partial class OperationsView
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
            this.components = new System.ComponentModel.Container();
            this.operationsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.sequenceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.operationsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodsItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.methodsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.methodsToolStrip = new System.Windows.Forms.ToolStrip();
            this.addMethodToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editMethodToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteMethodToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.operationsToolStrip = new System.Windows.Forms.ToolStrip();
            this.addOperationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editOperationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteOperationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.operationsContextMenuStrip.SuspendLayout();
            this.operationsItemContextMenuStrip.SuspendLayout();
            this.methodsContextMenuStrip.SuspendLayout();
            this.methodsItemContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.methodsToolStrip.SuspendLayout();
            this.operationsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // operationsEnhancedListView
            // 
            this.operationsEnhancedListView.AlternateBackColor = System.Drawing.Color.Azure;
            this.operationsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sequenceColumnHeader,
            this.descriptionColumnHeader});
            this.operationsEnhancedListView.ContextMenuStrip = this.operationsContextMenuStrip;
            this.operationsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsEnhancedListView.Enabled = false;
            this.operationsEnhancedListView.EnsureSelection = true;
            this.operationsEnhancedListView.FullRowSelect = true;
            this.operationsEnhancedListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.operationsEnhancedListView.HideSelection = false;
            this.operationsEnhancedListView.IndexOfColumnToResize = 1;
            this.operationsEnhancedListView.ItemContextMenuStrip = this.operationsItemContextMenuStrip;
            this.operationsEnhancedListView.Location = new System.Drawing.Point(0, 25);
            this.operationsEnhancedListView.MultiSelect = false;
            this.operationsEnhancedListView.Name = "operationsEnhancedListView";
            this.operationsEnhancedListView.ResizeColumnToFill = true;
            this.operationsEnhancedListView.ShowItemToolTips = true;
            this.operationsEnhancedListView.Size = new System.Drawing.Size(331, 146);
            this.operationsEnhancedListView.TabIndex = 1;
            this.operationsEnhancedListView.UseAlternatingBackColor = true;
            this.operationsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.operationsEnhancedListView.View = System.Windows.Forms.View.Details;
            this.operationsEnhancedListView.ItemActivate += new System.EventHandler(this.operationsEnhancedListView_ItemActivate);
            this.operationsEnhancedListView.SelectedIndexChanged += new System.EventHandler(this.OperationsEnhancedListView_SelectedIndexChanged);
            // 
            // sequenceColumnHeader
            // 
            this.sequenceColumnHeader.Text = "Sequence";
            this.sequenceColumnHeader.Width = 77;
            // 
            // descriptionColumnHeader
            // 
            this.descriptionColumnHeader.Text = "Description";
            this.descriptionColumnHeader.Width = 247;
            // 
            // operationsContextMenuStrip
            // 
            this.operationsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOperationToolStripMenuItem});
            this.operationsContextMenuStrip.Name = "contextMenuStrip";
            this.operationsContextMenuStrip.Size = new System.Drawing.Size(101, 26);
            this.operationsContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.operationsContextMenuStrip_ItemClicked);
            // 
            // addOperationToolStripMenuItem
            // 
            this.addOperationToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addOperationToolStripMenuItem.Name = "addOperationToolStripMenuItem";
            this.addOperationToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.addOperationToolStripMenuItem.Text = "&Add";
            // 
            // operationsItemContextMenuStrip
            // 
            this.operationsItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editOperationToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteOperationToolStripMenuItem});
            this.operationsItemContextMenuStrip.Name = "itemContextMenuStrip";
            this.operationsItemContextMenuStrip.Size = new System.Drawing.Size(153, 76);
            this.operationsItemContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.operationsItemContextMenuStrip_ItemClicked);
            // 
            // editOperationToolStripMenuItem
            // 
            this.editOperationToolStripMenuItem.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editOperationToolStripMenuItem.Name = "editOperationToolStripMenuItem";
            this.editOperationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editOperationToolStripMenuItem.Text = "E&dit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // deleteOperationToolStripMenuItem
            // 
            this.deleteOperationToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteOperationToolStripMenuItem.Name = "deleteOperationToolStripMenuItem";
            this.deleteOperationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteOperationToolStripMenuItem.Text = "&Delete";
            // 
            // methodsContextMenuStrip
            // 
            this.methodsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMethodToolStripMenuItem});
            this.methodsContextMenuStrip.Name = "contextMenuStrip";
            this.methodsContextMenuStrip.Size = new System.Drawing.Size(101, 26);
            this.methodsContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.methodsContextMenuStrip_ItemClicked);
            // 
            // addMethodToolStripMenuItem
            // 
            this.addMethodToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addMethodToolStripMenuItem.Name = "addMethodToolStripMenuItem";
            this.addMethodToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.addMethodToolStripMenuItem.Text = "&Add";
            // 
            // methodsItemContextMenuStrip
            // 
            this.methodsItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMethodToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteMethodToolStripMenuItem});
            this.methodsItemContextMenuStrip.Name = "itemContextMenuStrip";
            this.methodsItemContextMenuStrip.Size = new System.Drawing.Size(114, 54);
            this.methodsItemContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.methodsItemContextMenuStrip_ItemClicked);
            // 
            // editMethodToolStripMenuItem
            // 
            this.editMethodToolStripMenuItem.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editMethodToolStripMenuItem.Name = "editMethodToolStripMenuItem";
            this.editMethodToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.editMethodToolStripMenuItem.Text = "E&dit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(110, 6);
            // 
            // deleteMethodToolStripMenuItem
            // 
            this.deleteMethodToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteMethodToolStripMenuItem.Name = "deleteMethodToolStripMenuItem";
            this.deleteMethodToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.deleteMethodToolStripMenuItem.Text = "&Delete";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.methodsEnhancedListView);
            this.splitContainer1.Panel1.Controls.Add(this.methodsToolStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.operationsEnhancedListView);
            this.splitContainer1.Panel2.Controls.Add(this.operationsToolStrip);
            this.splitContainer1.Size = new System.Drawing.Size(331, 310);
            this.splitContainer1.SplitterDistance = 134;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // methodsEnhancedListView
            // 
            this.methodsEnhancedListView.AlternateBackColor = System.Drawing.Color.Azure;
            this.methodsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.methodsEnhancedListView.ContextMenuStrip = this.methodsContextMenuStrip;
            this.methodsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.methodsEnhancedListView.EnsureSelection = true;
            this.methodsEnhancedListView.FullRowSelect = true;
            this.methodsEnhancedListView.HideSelection = false;
            this.methodsEnhancedListView.IndexOfColumnToResize = 0;
            this.methodsEnhancedListView.ItemContextMenuStrip = this.methodsItemContextMenuStrip;
            this.methodsEnhancedListView.Location = new System.Drawing.Point(0, 25);
            this.methodsEnhancedListView.MultiSelect = false;
            this.methodsEnhancedListView.Name = "methodsEnhancedListView";
            this.methodsEnhancedListView.ResizeColumnToFill = true;
            this.methodsEnhancedListView.ShowItemToolTips = true;
            this.methodsEnhancedListView.Size = new System.Drawing.Size(331, 109);
            this.methodsEnhancedListView.TabIndex = 2;
            this.methodsEnhancedListView.UseAlternatingBackColor = true;
            this.methodsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.methodsEnhancedListView.View = System.Windows.Forms.View.Details;
            this.methodsEnhancedListView.ItemActivate += new System.EventHandler(this.methodsEnhancedListView_ItemActivate);
            this.methodsEnhancedListView.SelectedIndexChanged += new System.EventHandler(this.MethodsEnhancedListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Method";
            this.columnHeader1.Width = 244;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Preferred?";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 80;
            // 
            // methodsToolStrip
            // 
            this.methodsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.methodsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMethodToolStripButton,
            this.editMethodToolStripButton,
            this.deleteMethodToolStripButton});
            this.methodsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.methodsToolStrip.Name = "methodsToolStrip";
            this.methodsToolStrip.Size = new System.Drawing.Size(331, 25);
            this.methodsToolStrip.TabIndex = 1;
            this.methodsToolStrip.Text = "toolStrip1";
            this.methodsToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.methodsToolStrip_ItemClicked);
            // 
            // addMethodToolStripButton
            // 
            this.addMethodToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addMethodToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addMethodToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addMethodToolStripButton.Name = "addMethodToolStripButton";
            this.addMethodToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addMethodToolStripButton.Text = "Add method";
            // 
            // editMethodToolStripButton
            // 
            this.editMethodToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editMethodToolStripButton.Enabled = false;
            this.editMethodToolStripButton.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editMethodToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editMethodToolStripButton.Name = "editMethodToolStripButton";
            this.editMethodToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editMethodToolStripButton.Text = "Edit method";
            // 
            // deleteMethodToolStripButton
            // 
            this.deleteMethodToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteMethodToolStripButton.Enabled = false;
            this.deleteMethodToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteMethodToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteMethodToolStripButton.Name = "deleteMethodToolStripButton";
            this.deleteMethodToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteMethodToolStripButton.Text = "Delete method";
            // 
            // operationsToolStrip
            // 
            this.operationsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.operationsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOperationToolStripButton,
            this.editOperationToolStripButton,
            this.deleteOperationToolStripButton});
            this.operationsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.operationsToolStrip.Name = "operationsToolStrip";
            this.operationsToolStrip.Size = new System.Drawing.Size(331, 25);
            this.operationsToolStrip.TabIndex = 5;
            this.operationsToolStrip.Text = "toolStrip1";
            this.operationsToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.operationsToolStrip_ItemClicked);
            // 
            // addOperationToolStripButton
            // 
            this.addOperationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addOperationToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addOperationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addOperationToolStripButton.Name = "addOperationToolStripButton";
            this.addOperationToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addOperationToolStripButton.Text = "Add operation";
            // 
            // editOperationToolStripButton
            // 
            this.editOperationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editOperationToolStripButton.Enabled = false;
            this.editOperationToolStripButton.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editOperationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editOperationToolStripButton.Name = "editOperationToolStripButton";
            this.editOperationToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editOperationToolStripButton.Text = "Edit operation";
            // 
            // deleteOperationToolStripButton
            // 
            this.deleteOperationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteOperationToolStripButton.Enabled = false;
            this.deleteOperationToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteOperationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteOperationToolStripButton.Name = "deleteOperationToolStripButton";
            this.deleteOperationToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteOperationToolStripButton.Text = "Delete operation";
            // 
            // OperationsView
            // 
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OperationsView";
            this.Size = new System.Drawing.Size(331, 310);
            this.operationsContextMenuStrip.ResumeLayout(false);
            this.operationsItemContextMenuStrip.ResumeLayout(false);
            this.methodsContextMenuStrip.ResumeLayout(false);
            this.methodsItemContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.methodsToolStrip.ResumeLayout(false);
            this.methodsToolStrip.PerformLayout();
            this.operationsToolStrip.ResumeLayout(false);
            this.operationsToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private nGenLibrary.Controls.EnhancedListView operationsEnhancedListView;
        private System.Windows.Forms.ColumnHeader sequenceColumnHeader;
        private System.Windows.Forms.ColumnHeader descriptionColumnHeader;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private nGenLibrary.Controls.EnhancedListView methodsEnhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStrip methodsToolStrip;
        private System.Windows.Forms.ToolStripButton addMethodToolStripButton;
        private System.Windows.Forms.ToolStripButton editMethodToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteMethodToolStripButton;
        private System.Windows.Forms.ToolStrip operationsToolStrip;
        private System.Windows.Forms.ToolStripButton addOperationToolStripButton;
        private System.Windows.Forms.ToolStripButton editOperationToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteOperationToolStripButton;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip methodsContextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip methodsItemContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMethodToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip operationsItemContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteOperationToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip operationsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addOperationToolStripMenuItem;
    }
}
