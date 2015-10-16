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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartLibraryView));
            this.groupOlvColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.searchValueTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.resultsObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.drawingNumberOlvColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.searchingBarPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filePreviewPanel1 = new CPECentral.Controls.FilePreviewPanel();
            this.closableTabControl = new CPECentral.Controls.ClosableTabControl();
            this.searchTabPage = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsObjectListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchingBarPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.closableTabControl.SuspendLayout();
            this.searchTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupOlvColumn
            // 
            this.groupOlvColumn.AspectName = "Group";
            this.groupOlvColumn.CellPadding = null;
            this.groupOlvColumn.IsVisible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.searchValueTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.searchButton);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.resultsObjectListView);
            this.splitContainer1.Panel1.Controls.Add(this.searchingBarPictureBox);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(1128, 605);
            this.splitContainer1.SplitterDistance = 631;
            this.splitContainer1.TabIndex = 17;
            // 
            // searchValueTextBox
            // 
            this.searchValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchValueTextBox.DisableDoubleSpace = false;
            this.searchValueTextBox.DisableLeadingSpace = false;
            this.searchValueTextBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchValueTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.searchValueTextBox.Location = new System.Drawing.Point(25, 35);
            this.searchValueTextBox.MaxLength = 50;
            this.searchValueTextBox.Name = "searchValueTextBox";
            this.searchValueTextBox.NumericCharactersOnly = false;
            this.searchValueTextBox.Size = new System.Drawing.Size(470, 43);
            this.searchValueTextBox.SuppressEnterKey = true;
            this.searchValueTextBox.TabIndex = 14;
            this.searchValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchValueTextBox.EnterKeyPressed += new System.EventHandler(this.searchValueTextBox_EnterKeyPressed);
            this.searchValueTextBox.TextChanged += new System.EventHandler(this.searchValueTextBox_TextChanged);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(501, 35);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(117, 43);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Go";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(32, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(463, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Enter drawing number, part name or works order number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // resultsObjectListView
            // 
            this.resultsObjectListView.AllColumns.Add(this.drawingNumberOlvColumn);
            this.resultsObjectListView.AllColumns.Add(this.olvColumn2);
            this.resultsObjectListView.AllColumns.Add(this.olvColumn3);
            this.resultsObjectListView.AllColumns.Add(this.groupOlvColumn);
            this.resultsObjectListView.AlternateRowBackColor = System.Drawing.Color.Ivory;
            this.resultsObjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.drawingNumberOlvColumn,
            this.olvColumn2,
            this.olvColumn3});
            this.resultsObjectListView.EmptyListMsg = "";
            this.resultsObjectListView.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsObjectListView.FullRowSelect = true;
            this.resultsObjectListView.Location = new System.Drawing.Point(25, 122);
            this.resultsObjectListView.MultiSelect = false;
            this.resultsObjectListView.Name = "resultsObjectListView";
            this.resultsObjectListView.OwnerDraw = true;
            this.resultsObjectListView.ShowItemCountOnGroups = true;
            this.resultsObjectListView.Size = new System.Drawing.Size(593, 473);
            this.resultsObjectListView.TabIndex = 12;
            this.resultsObjectListView.UseAlternatingBackColors = true;
            this.resultsObjectListView.UseCompatibleStateImageBehavior = false;
            this.resultsObjectListView.View = System.Windows.Forms.View.Details;
            this.resultsObjectListView.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.resultsObjectListView_CellToolTipShowing);
            this.resultsObjectListView.SelectionChanged += new System.EventHandler(this.resultsObjectListView_SelectionChanged);
            this.resultsObjectListView.ItemActivate += new System.EventHandler(this.resultsObjectListView_ItemActivate);
            // 
            // drawingNumberOlvColumn
            // 
            this.drawingNumberOlvColumn.AspectName = "DrawingNumber";
            this.drawingNumberOlvColumn.CellPadding = null;
            this.drawingNumberOlvColumn.FillsFreeSpace = true;
            this.drawingNumberOlvColumn.Groupable = false;
            this.drawingNumberOlvColumn.Text = "Drawing number";
            this.drawingNumberOlvColumn.Width = 231;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "CurrentVersion";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.Groupable = false;
            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Text = "Current version";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Width = 130;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Name";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.FillsFreeSpace = true;
            this.olvColumn3.Groupable = false;
            this.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Text = "Name";
            this.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Width = 325;
            // 
            // searchingBarPictureBox
            // 
            this.searchingBarPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchingBarPictureBox.Image = global::CPECentral.Properties.Resources.PreloaderImage2;
            this.searchingBarPictureBox.Location = new System.Drawing.Point(25, 84);
            this.searchingBarPictureBox.Name = "searchingBarPictureBox";
            this.searchingBarPictureBox.Size = new System.Drawing.Size(593, 22);
            this.searchingBarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchingBarPictureBox.TabIndex = 11;
            this.searchingBarPictureBox.TabStop = false;
            this.searchingBarPictureBox.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filePreviewPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 585);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drawing file";
            // 
            // filePreviewPanel1
            // 
            this.filePreviewPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("filePreviewPanel1.BackgroundImage")));
            this.filePreviewPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filePreviewPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePreviewPanel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePreviewPanel1.Location = new System.Drawing.Point(3, 21);
            this.filePreviewPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filePreviewPanel1.Name = "filePreviewPanel1";
            this.filePreviewPanel1.Size = new System.Drawing.Size(467, 561);
            this.filePreviewPanel1.TabIndex = 0;
            // 
            // closableTabControl
            // 
            this.closableTabControl.Controls.Add(this.searchTabPage);
            this.closableTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closableTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.closableTabControl.ItemSize = new System.Drawing.Size(200, 35);
            this.closableTabControl.Location = new System.Drawing.Point(0, 0);
            this.closableTabControl.Margin = new System.Windows.Forms.Padding(10);
            this.closableTabControl.Name = "closableTabControl";
            this.closableTabControl.SelectedIndex = 0;
            this.closableTabControl.Size = new System.Drawing.Size(1142, 654);
            this.closableTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.closableTabControl.TabIndex = 18;
            // 
            // searchTabPage
            // 
            this.searchTabPage.Controls.Add(this.splitContainer1);
            this.searchTabPage.Location = new System.Drawing.Point(4, 39);
            this.searchTabPage.Name = "searchTabPage";
            this.searchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.searchTabPage.Size = new System.Drawing.Size(1134, 611);
            this.searchTabPage.TabIndex = 0;
            this.searchTabPage.Tag = "false";
            this.searchTabPage.Text = "Search";
            this.searchTabPage.UseVisualStyleBackColor = true;
            // 
            // PartLibraryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.closableTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(925, 630);
            this.Name = "PartLibraryView";
            this.Size = new System.Drawing.Size(1142, 654);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsObjectListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchingBarPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.closableTabControl.ResumeLayout(false);
            this.searchTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox searchingBarPictureBox;
        private BrightIdeasSoftware.ObjectListView resultsObjectListView;
        private BrightIdeasSoftware.OLVColumn drawingNumberOlvColumn;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button searchButton;
        private nGenLibrary.Controls.EnhancedTextBox searchValueTextBox;
        private Controls.FilePreviewPanel filePreviewPanel1;
        private BrightIdeasSoftware.OLVColumn groupOlvColumn;
        private Controls.ClosableTabControl closableTabControl;
        private System.Windows.Forms.TabPage searchTabPage;
    }
}
