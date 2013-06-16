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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addOperationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editOperationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteOperationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.enhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.sequenceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOperationToolStripButton,
            this.editOperationToolStripButton,
            this.deleteOperationToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(438, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            // enhancedListView
            // 
            this.enhancedListView.AlternateBackColor = System.Drawing.Color.WhiteSmoke;
            this.enhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sequenceColumnHeader,
            this.descriptionColumnHeader});
            this.enhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhancedListView.EnsureSelection = true;
            this.enhancedListView.FullRowSelect = true;
            this.enhancedListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.enhancedListView.HideSelection = false;
            this.enhancedListView.ItemContextMenuStrip = null;
            this.enhancedListView.Location = new System.Drawing.Point(0, 25);
            this.enhancedListView.Name = "enhancedListView";
            this.enhancedListView.ResizeLastColumnToFill = true;
            this.enhancedListView.ShowItemToolTips = true;
            this.enhancedListView.Size = new System.Drawing.Size(438, 252);
            this.enhancedListView.TabIndex = 1;
            this.enhancedListView.UseAlternatingBackColor = true;
            this.enhancedListView.UseCompatibleStateImageBehavior = false;
            this.enhancedListView.View = System.Windows.Forms.View.Details;
            this.enhancedListView.SelectedIndexChanged += new System.EventHandler(this.enhancedListView_SelectedIndexChanged);
            this.enhancedListView.ClientSizeChanged += new System.EventHandler(this.enhancedListView_ClientSizeChanged);
            this.enhancedListView.Resize += new System.EventHandler(this.enhancedListView_Resize);
            // 
            // sequenceColumnHeader
            // 
            this.sequenceColumnHeader.Text = "Sequence";
            this.sequenceColumnHeader.Width = 70;
            // 
            // descriptionColumnHeader
            // 
            this.descriptionColumnHeader.Text = "Description";
            this.descriptionColumnHeader.Width = 361;
            // 
            // OperationsView
            // 
            this.Controls.Add(this.enhancedListView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OperationsView";
            this.Size = new System.Drawing.Size(438, 277);
            this.Load += new System.EventHandler(this.OperationsView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private nGenLibrary.Controls.EnhancedListView enhancedListView;
        private System.Windows.Forms.ToolStripButton addOperationToolStripButton;
        private System.Windows.Forms.ToolStripButton editOperationToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteOperationToolStripButton;
        private System.Windows.Forms.ColumnHeader sequenceColumnHeader;
        private System.Windows.Forms.ColumnHeader descriptionColumnHeader;
    }
}
