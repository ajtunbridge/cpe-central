namespace CPECentral.Views
{
    partial class PartLibraryView
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
            this.enhancedTreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.searchFieldComboBox = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.searchValueTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.enhancedTreeView = new nGenLibrary.Controls.EnhancedTreeView();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // enhancedTreeViewImageList
            // 
            this.enhancedTreeViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.enhancedTreeViewImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.enhancedTreeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(108, 26);
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // refreshButton
            // 
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.refreshButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Image = global::CPECentral.Properties.Resources.ReloadIcon_16x16;
            this.refreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshButton.Location = new System.Drawing.Point(0, 25);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(215, 36);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Text = "Reload library";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.searchFieldComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(215, 25);
            this.splitContainer1.SplitterDistance = 105;
            this.splitContainer1.TabIndex = 5;
            // 
            // searchFieldComboBox
            // 
            this.searchFieldComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchFieldComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchFieldComboBox.FormattingEnabled = true;
            this.searchFieldComboBox.Items.AddRange(new object[] {
            "Works order number",
            "Drawing number",
            "Name"});
            this.searchFieldComboBox.Location = new System.Drawing.Point(0, 0);
            this.searchFieldComboBox.Name = "searchFieldComboBox";
            this.searchFieldComboBox.Size = new System.Drawing.Size(105, 25);
            this.searchFieldComboBox.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.searchValueTextBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.searchButton);
            this.splitContainer2.Size = new System.Drawing.Size(106, 25);
            this.splitContainer2.SplitterDistance = 80;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 5;
            // 
            // searchValueTextBox
            // 
            this.searchValueTextBox.AcceptsReturn = true;
            this.searchValueTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.searchValueTextBox.DisableDoubleSpace = true;
            this.searchValueTextBox.DisableLeadingSpace = false;
            this.searchValueTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchValueTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchValueTextBox.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.searchValueTextBox.Location = new System.Drawing.Point(0, 0);
            this.searchValueTextBox.MaxLength = 50;
            this.searchValueTextBox.Name = "searchValueTextBox";
            this.searchValueTextBox.NumericCharactersOnly = false;
            this.searchValueTextBox.Size = new System.Drawing.Size(80, 25);
            this.searchValueTextBox.SuppressEnterKey = true;
            this.searchValueTextBox.TabIndex = 5;
            this.searchValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchValueTextBox.EnterKeyPressed += new System.EventHandler(this.searchValueTextBox_EnterKeyPressed);
            // 
            // searchButton
            // 
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Image = global::CPECentral.Properties.Resources.SearchIcon_16x16;
            this.searchButton.Location = new System.Drawing.Point(0, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(25, 25);
            this.searchButton.TabIndex = 0;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // enhancedTreeView
            // 
            this.enhancedTreeView.ContextMenuStrip = this.contextMenuStrip;
            this.enhancedTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhancedTreeView.HideSelection = false;
            this.enhancedTreeView.ImageIndex = 0;
            this.enhancedTreeView.ImageList = this.enhancedTreeViewImageList;
            this.enhancedTreeView.Location = new System.Drawing.Point(0, 61);
            this.enhancedTreeView.Name = "enhancedTreeView";
            this.enhancedTreeView.SelectedImageIndex = 0;
            this.enhancedTreeView.ShowNodeToolTips = true;
            this.enhancedTreeView.Size = new System.Drawing.Size(215, 219);
            this.enhancedTreeView.TabIndex = 0;
            this.enhancedTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.enhancedTreeView_AfterSelect);
            // 
            // PartLibraryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.enhancedTreeView);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PartLibraryView";
            this.Size = new System.Drawing.Size(215, 280);
            this.Load += new System.EventHandler(this.PartLibraryView_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private nGenLibrary.Controls.EnhancedTreeView enhancedTreeView;
        private System.Windows.Forms.ImageList enhancedTreeViewImageList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox searchFieldComboBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private nGenLibrary.Controls.EnhancedTextBox searchValueTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
