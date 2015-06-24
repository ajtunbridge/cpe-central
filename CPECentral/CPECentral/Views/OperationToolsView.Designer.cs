namespace CPECentral.Views
{
    partial class OperationToolsView
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewStockLevelsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.operationToolsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip.SuspendLayout();
            this.mainContextMenuStrip.SuspendLayout();
            this.itemContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.editToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator1,
            this.printToolStripButton,
            this.toolStripSeparator2,
            this.viewStockLevelsToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(528, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addToolStripButton.Text = "Add";
            this.addToolStripButton.ToolTipText = "Add a tool to this operation";
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Enabled = false;
            this.editToolStripButton.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editToolStripButton.Text = "Edit";
            this.editToolStripButton.ToolTipText = "Edit selected operation tool";
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Enabled = false;
            this.deleteToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.ToolTipText = "Delete selected operation tool";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = global::CPECentral.Properties.Resources.PrintIcon_16x16;
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "Print";
            this.printToolStripButton.ToolTipText = "S";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // viewStockLevelsToolStripButton
            // 
            this.viewStockLevelsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.viewStockLevelsToolStripButton.Image = global::CPECentral.Properties.Resources.StockIcon_16x16;
            this.viewStockLevelsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewStockLevelsToolStripButton.Name = "viewStockLevelsToolStripButton";
            this.viewStockLevelsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.viewStockLevelsToolStripButton.Text = "View stock levels";
            // 
            // operationToolsEnhancedListView
            // 
            this.operationToolsEnhancedListView.AlternateBackColor = System.Drawing.Color.Ivory;
            this.operationToolsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.operationToolsEnhancedListView.ContextMenuStrip = this.mainContextMenuStrip;
            this.operationToolsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationToolsEnhancedListView.EnsureSelection = false;
            this.operationToolsEnhancedListView.FullRowSelect = true;
            this.operationToolsEnhancedListView.GridLines = true;
            this.operationToolsEnhancedListView.IndexOfColumnToResize = 2;
            this.operationToolsEnhancedListView.ItemContextMenuStrip = this.itemContextMenuStrip;
            this.operationToolsEnhancedListView.Location = new System.Drawing.Point(0, 25);
            this.operationToolsEnhancedListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.operationToolsEnhancedListView.MultiSelect = false;
            this.operationToolsEnhancedListView.Name = "operationToolsEnhancedListView";
            this.operationToolsEnhancedListView.ResizeColumnToFill = true;
            this.operationToolsEnhancedListView.ShowItemToolTips = true;
            this.operationToolsEnhancedListView.Size = new System.Drawing.Size(528, 194);
            this.operationToolsEnhancedListView.TabIndex = 2;
            this.operationToolsEnhancedListView.UseAlternatingBackColor = true;
            this.operationToolsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.operationToolsEnhancedListView.View = System.Windows.Forms.View.Details;
            this.operationToolsEnhancedListView.ItemActivate += new System.EventHandler(this.operationToolsEnhancedListView_ItemActivate);
            this.operationToolsEnhancedListView.SelectedIndexChanged += new System.EventHandler(this.operationToolsEnhancedListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Position";
            this.columnHeader1.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Offset";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 132;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Holder";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Stock";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 63;
            // 
            // mainContextMenuStrip
            // 
            this.mainContextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolToolStripMenuItem});
            this.mainContextMenuStrip.Name = "mainContextMenuStrip";
            this.mainContextMenuStrip.Size = new System.Drawing.Size(128, 26);
            this.mainContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainContextMenuStrip_ItemClicked);
            // 
            // addToolToolStripMenuItem
            // 
            this.addToolToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addToolToolStripMenuItem.Name = "addToolToolStripMenuItem";
            this.addToolToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.addToolToolStripMenuItem.Text = "&Add tool";
            // 
            // itemContextMenuStrip
            // 
            this.itemContextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.itemContextMenuStrip.Name = "itemContextMenuStrip";
            this.itemContextMenuStrip.Size = new System.Drawing.Size(114, 54);
            this.itemContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.itemContextMenuStrip_ItemClicked);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(110, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // OperationToolsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.operationToolsEnhancedListView);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OperationToolsView";
            this.Size = new System.Drawing.Size(528, 219);
            this.Load += new System.EventHandler(this.OperationToolsView_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.mainContextMenuStrip.ResumeLayout(false);
            this.itemContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private nGenLibrary.Controls.EnhancedListView operationToolsEnhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip itemContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton viewStockLevelsToolStripButton;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
