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
            this.listViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExternallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makePrimaryDrawingFileForThisVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openDocumentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteDocumentsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.renameToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.importMillingProgramToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newTurningProgramToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newFeatureCAMFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.filesListView = new CPECentral.Controls.FilesListView();
            this.scanServerForDrawingsmodelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.listViewContextMenuStrip.SuspendLayout();
            this.listViewItemContextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewContextMenuStrip
            // 
            this.listViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDocumentsToolStripMenuItem,
            this.scanServerForDrawingsmodelsToolStripMenuItem,
            this.toolStripSeparator4,
            this.viewToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator2,
            this.pasteToolStripMenuItem});
            this.listViewContextMenuStrip.Name = "listViewContextMenuStrip";
            this.listViewContextMenuStrip.Size = new System.Drawing.Size(270, 148);
            this.listViewContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.listViewContextMenuStrip_Opening);
            this.listViewContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStrip_ItemClicked);
            // 
            // addDocumentsToolStripMenuItem
            // 
            this.addDocumentsToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addDocumentsToolStripMenuItem.Name = "addDocumentsToolStripMenuItem";
            this.addDocumentsToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.addDocumentsToolStripMenuItem.Text = "&Add documents";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconsToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStrip_ItemClicked);
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.largeIconsToolStripMenuItem.Text = "&Large icons";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.detailsToolStripMenuItem.Text = "&Details";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::CPECentral.Properties.Resources.ReloadIcon_16x16;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(266, 6);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // listViewItemContextMenuStrip
            // 
            this.listViewItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openExternallyToolStripMenuItem,
            this.makePrimaryDrawingFileForThisVersionToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator5,
            this.copyToolStripMenuItem});
            this.listViewItemContextMenuStrip.Name = "listViewContextMenuStrip";
            this.listViewItemContextMenuStrip.Size = new System.Drawing.Size(321, 126);
            this.listViewItemContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStrip_ItemClicked);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::CPECentral.Properties.Resources.OpenIcon_16x16;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(320, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // openExternallyToolStripMenuItem
            // 
            this.openExternallyToolStripMenuItem.Name = "openExternallyToolStripMenuItem";
            this.openExternallyToolStripMenuItem.Size = new System.Drawing.Size(320, 22);
            this.openExternallyToolStripMenuItem.Text = "Open &externally";
            // 
            // makePrimaryDrawingFileForThisVersionToolStripMenuItem
            // 
            this.makePrimaryDrawingFileForThisVersionToolStripMenuItem.Name = "makePrimaryDrawingFileForThisVersionToolStripMenuItem";
            this.makePrimaryDrawingFileForThisVersionToolStripMenuItem.Size = new System.Drawing.Size(320, 22);
            this.makePrimaryDrawingFileForThisVersionToolStripMenuItem.Text = "Make primary drawing file for this version";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(317, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(320, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(317, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(320, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripButton,
            this.toolStripSeparator1,
            this.addDocumentToolStripButton,
            this.openDocumentToolStripButton,
            this.deleteDocumentsToolStripButton,
            this.renameToolStripButton,
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
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::CPECentral.Properties.Resources.ReloadIcon_16x16;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolStripButton.Text = "Refresh";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // addDocumentToolStripButton
            // 
            this.addDocumentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addDocumentToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addDocumentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addDocumentToolStripButton.Name = "addDocumentToolStripButton";
            this.addDocumentToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addDocumentToolStripButton.Text = "Add document";
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
            // renameToolStripButton
            // 
            this.renameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameToolStripButton.Enabled = false;
            this.renameToolStripButton.Image = global::CPECentral.Properties.Resources.RenameIcon_16x16;
            this.renameToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameToolStripButton.Name = "renameToolStripButton";
            this.renameToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.renameToolStripButton.Text = "Rename";
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
            this.filesListView.AlternateBackColor = System.Drawing.Color.Azure;
            this.filesListView.ContextMenuStrip = this.listViewContextMenuStrip;
            this.filesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesListView.EnsureSelection = false;
            this.filesListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesListView.FullRowSelect = true;
            this.filesListView.GridLines = true;
            this.filesListView.IndexOfColumnToResize = 0;
            this.filesListView.ItemContextMenuStrip = this.listViewItemContextMenuStrip;
            this.filesListView.LabelEdit = true;
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
            this.filesListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.filesListView_AfterLabelEdit);
            this.filesListView.ItemActivate += new System.EventHandler(this.filesListView_ItemActivate);
            this.filesListView.SelectedIndexChanged += new System.EventHandler(this.filesListView_SelectedIndexChanged);
            this.filesListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.filesListView_DragDrop);
            this.filesListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.filesListView_DragEnter);
            this.filesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filesListView_KeyDown);
            // 
            // scanServerForDrawingsmodelsToolStripMenuItem
            // 
            this.scanServerForDrawingsmodelsToolStripMenuItem.Name = "scanServerForDrawingsmodelsToolStripMenuItem";
            this.scanServerForDrawingsmodelsToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.scanServerForDrawingsmodelsToolStripMenuItem.Text = "Scan server for drawings/models";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(266, 6);
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
            this.listViewContextMenuStrip.ResumeLayout(false);
            this.listViewItemContextMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton addDocumentToolStripButton;
        private System.Windows.Forms.ToolStripButton renameToolStripButton;
        private System.Windows.Forms.ContextMenuStrip listViewContextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip listViewItemContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openExternallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem makePrimaryDrawingFileForThisVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanServerForDrawingsmodelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}
