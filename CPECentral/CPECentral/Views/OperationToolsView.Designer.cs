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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.operationToolsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.editToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator1,
            this.printToolStripButton});
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
            this.addToolStripButton.Text = "Add operation tool";
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripButton.Enabled = false;
            this.editToolStripButton.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.editToolStripButton.Text = "Edit selected operation tool";
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Enabled = false;
            this.deleteToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "Delete selected operation tool";
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
            this.printToolStripButton.Text = "toolStripButton3";
            // 
            // operationToolsEnhancedListView
            // 
            this.operationToolsEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.operationToolsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.operationToolsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationToolsEnhancedListView.EnsureSelection = false;
            this.operationToolsEnhancedListView.FullRowSelect = true;
            this.operationToolsEnhancedListView.GridLines = true;
            this.operationToolsEnhancedListView.IndexOfColumnToResize = 2;
            this.operationToolsEnhancedListView.ItemContextMenuStrip = null;
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
            this.columnHeader3.Width = 195;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Holder";
            this.columnHeader4.Width = 200;
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
    }
}
