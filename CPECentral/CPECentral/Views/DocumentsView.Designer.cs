namespace CPECentral.Views
{
    partial class DocumentsView
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
            this.openDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteDocumentsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.importMillingProgramToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newTurningProgramToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newFeatureCAMFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.filesListView = new CPECentral.Controls.FilesListView();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDocumentToolStripButton,
            this.deleteDocumentsToolStripButton,
            this.toolStripSeparator,
            this.importMillingProgramToolStripButton,
            this.newTurningProgramToolStripButton,
            this.newFeatureCAMFileToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(367, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // openDocumentToolStripButton
            // 
            this.openDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openDocumentToolStripButton.Enabled = false;
            this.openDocumentToolStripButton.Image = global::CPECentral.Properties.Resources.OpenIcon_16x16;
            this.openDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openDocumentToolStripButton.Name = "openDocumentToolStripButton";
            this.openDocumentToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openDocumentToolStripButton.Text = "Open document";
            // 
            // deleteDocumentsToolStripButton
            // 
            this.deleteDocumentsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteDocumentsToolStripButton.Enabled = false;
            this.deleteDocumentsToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteDocumentsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteDocumentsToolStripButton.Name = "deleteDocumentsToolStripButton";
            this.deleteDocumentsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteDocumentsToolStripButton.Text = "toolStripButton2";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // importMillingProgramToolStripButton
            // 
            this.importMillingProgramToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importMillingProgramToolStripButton.Image = global::CPECentral.Properties.Resources.ImportMillingProgram_16x16;
            this.importMillingProgramToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importMillingProgramToolStripButton.Name = "importMillingProgramToolStripButton";
            this.importMillingProgramToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.importMillingProgramToolStripButton.Text = "Import milling program";
            this.importMillingProgramToolStripButton.Visible = false;
            // 
            // newTurningProgramToolStripButton
            // 
            this.newTurningProgramToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newTurningProgramToolStripButton.Image = global::CPECentral.Properties.Resources.NewTurningProgramIcon_16x16;
            this.newTurningProgramToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newTurningProgramToolStripButton.Name = "newTurningProgramToolStripButton";
            this.newTurningProgramToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newTurningProgramToolStripButton.Text = "New turning program";
            this.newTurningProgramToolStripButton.Visible = false;
            // 
            // newFeatureCAMFileToolStripButton
            // 
            this.newFeatureCAMFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFeatureCAMFileToolStripButton.Image = global::CPECentral.Properties.Resources.NewCAMFileIcon_16x16;
            this.newFeatureCAMFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFeatureCAMFileToolStripButton.Name = "newFeatureCAMFileToolStripButton";
            this.newFeatureCAMFileToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newFeatureCAMFileToolStripButton.Text = "New FeatureCAM file";
            this.newFeatureCAMFileToolStripButton.Visible = false;
            // 
            // filesListView
            // 
            this.filesListView.AllowDrop = true;
            this.filesListView.AlternateBackColor = System.Drawing.Color.WhiteSmoke;
            this.filesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesListView.EnsureSelection = false;
            this.filesListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesListView.FullRowSelect = true;
            this.filesListView.IndexOfColumnToResize = 0;
            this.filesListView.ItemContextMenuStrip = null;
            this.filesListView.Location = new System.Drawing.Point(0, 25);
            this.filesListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filesListView.Name = "filesListView";
            this.filesListView.ResizeColumnToFill = true;
            this.filesListView.ShowItemToolTips = true;
            this.filesListView.Size = new System.Drawing.Size(367, 173);
            this.filesListView.TabIndex = 1;
            this.filesListView.UseAlternatingBackColor = true;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            this.filesListView.ItemActivate += new System.EventHandler(this.filesListView_ItemActivate);
            this.filesListView.SelectedIndexChanged += new System.EventHandler(this.filesListView_SelectedIndexChanged);
            this.filesListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.filesListView_DragDrop);
            this.filesListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.filesListView_DragEnter);
            // 
            // DocumentsView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.filesListView);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DocumentsView";
            this.Size = new System.Drawing.Size(367, 198);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newFeatureCAMFileToolStripButton;
        private System.Windows.Forms.ToolStripButton importMillingProgramToolStripButton;
        private System.Windows.Forms.ToolStripButton newTurningProgramToolStripButton;
        private Controls.FilesListView filesListView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton openDocumentToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteDocumentsToolStripButton;
    }
}
