namespace CPECentral.Views
{
    partial class PartLibraryView2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartLibraryView2));
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.partsTreeView = new nGenLibrary.Controls.EnhancedTreeView();
            this.reloadButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.searchValueTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeViewImageList.Images.SetKeyName(0, "FolderClosedIcon_16x16.png");
            this.treeViewImageList.Images.SetKeyName(1, "FolderOpenIcon_16x16.png");
            this.treeViewImageList.Images.SetKeyName(2, "CustomerIcon_16x16.png");
            // 
            // partsTreeView
            // 
            this.partsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partsTreeView.HideSelection = false;
            this.partsTreeView.ImageIndex = 0;
            this.partsTreeView.ImageList = this.treeViewImageList;
            this.partsTreeView.Location = new System.Drawing.Point(0, 65);
            this.partsTreeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.partsTreeView.Name = "partsTreeView";
            this.partsTreeView.NodeContextMenuStrip = null;
            this.partsTreeView.SelectedImageIndex = 1;
            this.partsTreeView.Size = new System.Drawing.Size(286, 368);
            this.partsTreeView.TabIndex = 1;
            this.partsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.partsTreeView_AfterSelect);
            // 
            // reloadButton
            // 
            this.reloadButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.reloadButton.Location = new System.Drawing.Point(0, 29);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(286, 36);
            this.reloadButton.TabIndex = 2;
            this.reloadButton.Text = "Reload";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.searchValueTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.searchButton);
            this.splitContainer1.Size = new System.Drawing.Size(286, 29);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // searchValueTextBox
            // 
            this.searchValueTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.searchValueTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchValueTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchValueTextBox.ForeColor = System.Drawing.Color.Firebrick;
            this.searchValueTextBox.Location = new System.Drawing.Point(0, 0);
            this.searchValueTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchValueTextBox.MaxLength = 50;
            this.searchValueTextBox.Name = "searchValueTextBox";
            this.searchValueTextBox.Size = new System.Drawing.Size(203, 29);
            this.searchValueTextBox.TabIndex = 0;
            this.searchValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchValueTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchValueTextBox_KeyDown);
            // 
            // searchButton
            // 
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchButton.Image = global::CPECentral.Properties.Resources.SearchIcon_16x16;
            this.searchButton.Location = new System.Drawing.Point(0, 0);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(78, 29);
            this.searchButton.TabIndex = 0;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // PartLibraryView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.partsTreeView);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PartLibraryView2";
            this.Size = new System.Drawing.Size(286, 433);
            this.Load += new System.EventHandler(this.PartLibraryView2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox searchValueTextBox;
        private System.Windows.Forms.Button searchButton;
        private nGenLibrary.Controls.EnhancedTreeView partsTreeView;
        private System.Windows.Forms.ImageList treeViewImageList;
        private System.Windows.Forms.Button reloadButton;
    }
}
