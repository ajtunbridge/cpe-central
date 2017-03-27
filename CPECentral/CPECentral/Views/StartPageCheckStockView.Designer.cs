namespace CPECentral.Views
{
    partial class StartPageCheckStockView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.resultsTreeListView = new BrightIdeasSoftware.TreeListView();
            this.nameBatchNumberOlvColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchValueTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.searchingPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultsTreeListView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(41, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Check stock levels";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "What are you looking for?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(375, 71);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(105, 35);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // resultsTreeListView
            // 
            this.resultsTreeListView.AllColumns.Add(this.nameBatchNumberOlvColumn);
            this.resultsTreeListView.AllColumns.Add(this.olvColumn1);
            this.resultsTreeListView.AllColumns.Add(this.olvColumn2);
            this.resultsTreeListView.AllColumns.Add(this.olvColumn3);
            this.resultsTreeListView.AlternateRowBackColor = System.Drawing.Color.Ivory;
            this.resultsTreeListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsTreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameBatchNumberOlvColumn,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.resultsTreeListView.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsTreeListView.FullRowSelect = true;
            this.resultsTreeListView.Location = new System.Drawing.Point(6, 136);
            this.resultsTreeListView.Name = "resultsTreeListView";
            this.resultsTreeListView.OwnerDraw = true;
            this.resultsTreeListView.ShowGroups = false;
            this.resultsTreeListView.Size = new System.Drawing.Size(494, 175);
            this.resultsTreeListView.TabIndex = 2;
            this.resultsTreeListView.UseAlternatingBackColors = true;
            this.resultsTreeListView.UseCompatibleStateImageBehavior = false;
            this.resultsTreeListView.View = System.Windows.Forms.View.Details;
            this.resultsTreeListView.VirtualMode = true;
            // 
            // nameBatchNumberOlvColumn
            // 
            this.nameBatchNumberOlvColumn.AspectName = "Label";
            this.nameBatchNumberOlvColumn.CellPadding = null;
            this.nameBatchNumberOlvColumn.FillsFreeSpace = true;
            this.nameBatchNumberOlvColumn.Text = "Name / Batch number";
            this.nameBatchNumberOlvColumn.Width = 200;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Specification";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn1.Text = "Specification";
            this.olvColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn1.Width = 130;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Quantity";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Text = "Quantity";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Width = 75;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Location";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Text = "Location";
            this.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Width = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Results";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 39);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CPECentral.Properties.Resources.SearchIcon_32x32;
            this.pictureBox1.Location = new System.Drawing.Point(3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // searchValueTextBox
            // 
            this.searchValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchValueTextBox.DisableDoubleSpace = false;
            this.searchValueTextBox.DisableLeadingSpace = false;
            this.searchValueTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchValueTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.searchValueTextBox.Location = new System.Drawing.Point(6, 71);
            this.searchValueTextBox.MaxLength = 50;
            this.searchValueTextBox.Name = "searchValueTextBox";
            this.searchValueTextBox.NumericCharactersOnly = false;
            this.searchValueTextBox.Size = new System.Drawing.Size(363, 35);
            this.searchValueTextBox.SuppressEnterKey = true;
            this.searchValueTextBox.TabIndex = 0;
            this.searchValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchValueTextBox.EnterKeyPressed += new System.EventHandler(this.searchValueTextBox_EnterKeyPressed);
            this.searchValueTextBox.SizeChanged += new System.EventHandler(this.searchValueTextBox_SizeChanged);
            // 
            // searchingPictureBox
            // 
            this.searchingPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchingPictureBox.Image = global::CPECentral.Properties.Resources.PreloaderImage2;
            this.searchingPictureBox.Location = new System.Drawing.Point(375, 112);
            this.searchingPictureBox.Name = "searchingPictureBox";
            this.searchingPictureBox.Size = new System.Drawing.Size(105, 18);
            this.searchingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchingPictureBox.TabIndex = 8;
            this.searchingPictureBox.TabStop = false;
            this.searchingPictureBox.Visible = false;
            // 
            // StartPageCheckStockView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.searchingPictureBox);
            this.Controls.Add(this.searchValueTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resultsTreeListView);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StartPageCheckStockView";
            this.Size = new System.Drawing.Size(507, 319);
            ((System.ComponentModel.ISupportInitialize)(this.resultsTreeListView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchButton;
        private BrightIdeasSoftware.TreeListView resultsTreeListView;
        private BrightIdeasSoftware.OLVColumn nameBatchNumberOlvColumn;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private nGenLibrary.Controls.EnhancedTextBox searchValueTextBox;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.PictureBox searchingPictureBox;

    }
}
