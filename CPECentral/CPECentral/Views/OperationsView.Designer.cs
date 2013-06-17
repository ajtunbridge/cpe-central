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
            this.operationsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.sequenceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.methodsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.methodsToolStrip = new System.Windows.Forms.ToolStrip();
            this.addOperationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editOperationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteOperationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.operationsToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
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
            this.operationsEnhancedListView.AlternateBackColor = System.Drawing.Color.WhiteSmoke;
            this.operationsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sequenceColumnHeader,
            this.descriptionColumnHeader});
            this.operationsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsEnhancedListView.EnsureSelection = true;
            this.operationsEnhancedListView.FullRowSelect = true;
            this.operationsEnhancedListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.operationsEnhancedListView.HideSelection = false;
            this.operationsEnhancedListView.IndexOfColumnToResize = 1;
            this.operationsEnhancedListView.ItemContextMenuStrip = null;
            this.operationsEnhancedListView.Location = new System.Drawing.Point(0, 25);
            this.operationsEnhancedListView.Name = "operationsEnhancedListView";
            this.operationsEnhancedListView.ResizeColumnToFill = true;
            this.operationsEnhancedListView.ShowItemToolTips = true;
            this.operationsEnhancedListView.Size = new System.Drawing.Size(333, 157);
            this.operationsEnhancedListView.TabIndex = 1;
            this.operationsEnhancedListView.UseAlternatingBackColor = true;
            this.operationsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.operationsEnhancedListView.View = System.Windows.Forms.View.Details;
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
            this.descriptionColumnHeader.Width = 254;
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
            this.splitContainer1.Size = new System.Drawing.Size(333, 310);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // methodsEnhancedListView
            // 
            this.methodsEnhancedListView.AlternateBackColor = System.Drawing.Color.WhiteSmoke;
            this.methodsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.methodsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.methodsEnhancedListView.EnsureSelection = true;
            this.methodsEnhancedListView.FullRowSelect = true;
            this.methodsEnhancedListView.HideSelection = false;
            this.methodsEnhancedListView.IndexOfColumnToResize = 0;
            this.methodsEnhancedListView.ItemContextMenuStrip = null;
            this.methodsEnhancedListView.Location = new System.Drawing.Point(0, 25);
            this.methodsEnhancedListView.Name = "methodsEnhancedListView";
            this.methodsEnhancedListView.ResizeColumnToFill = true;
            this.methodsEnhancedListView.ShowItemToolTips = true;
            this.methodsEnhancedListView.Size = new System.Drawing.Size(333, 98);
            this.methodsEnhancedListView.TabIndex = 2;
            this.methodsEnhancedListView.UseAlternatingBackColor = true;
            this.methodsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.methodsEnhancedListView.View = System.Windows.Forms.View.Details;
            this.methodsEnhancedListView.SelectedIndexChanged += new System.EventHandler(this.MethodsEnhancedListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Method";
            this.columnHeader1.Width = 331;
            // 
            // methodsToolStrip
            // 
            this.methodsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.methodsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOperationToolStripButton,
            this.editOperationToolStripButton,
            this.deleteOperationToolStripButton});
            this.methodsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.methodsToolStrip.Name = "methodsToolStrip";
            this.methodsToolStrip.Size = new System.Drawing.Size(333, 25);
            this.methodsToolStrip.TabIndex = 1;
            this.methodsToolStrip.Text = "toolStrip1";
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
            // operationsToolStrip
            // 
            this.operationsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.operationsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.operationsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.operationsToolStrip.Name = "operationsToolStrip";
            this.operationsToolStrip.Size = new System.Drawing.Size(333, 25);
            this.operationsToolStrip.TabIndex = 5;
            this.operationsToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Add operation";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Edit operation";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Delete operation";
            // 
            // OperationsView
            // 
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OperationsView";
            this.Size = new System.Drawing.Size(331, 310);
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
        private System.Windows.Forms.ToolStripButton addOperationToolStripButton;
        private System.Windows.Forms.ToolStripButton editOperationToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteOperationToolStripButton;
        private System.Windows.Forms.ToolStrip operationsToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}
