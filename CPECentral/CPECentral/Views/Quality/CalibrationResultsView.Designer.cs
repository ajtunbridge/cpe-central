namespace CPECentral.Views.Quality
{
    partial class CalibrationResultsView
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
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.calibrateNowButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.resultsTreeListView = new BrightIdeasSoftware.TreeListView();
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn11 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn12 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsTreeListView)).BeginInit();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(5, 56);
            this.editButton.Margin = new System.Windows.Forms.Padding(5);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(139, 41);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(5, 107);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(139, 41);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // calibrateNowButton
            // 
            this.calibrateNowButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrateNowButton.Location = new System.Drawing.Point(5, 5);
            this.calibrateNowButton.Margin = new System.Windows.Forms.Padding(5);
            this.calibrateNowButton.Name = "calibrateNowButton";
            this.calibrateNowButton.Size = new System.Drawing.Size(139, 41);
            this.calibrateNowButton.TabIndex = 3;
            this.calibrateNowButton.Text = "Calibrate now";
            this.calibrateNowButton.UseVisualStyleBackColor = true;
            this.calibrateNowButton.Click += new System.EventHandler(this.calibrateNowButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.calibrateNowButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.editButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.deleteButton, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(633, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(149, 153);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // resultsTreeListView
            // 
            this.resultsTreeListView.AllColumns.Add(this.olvColumn6);
            this.resultsTreeListView.AllColumns.Add(this.olvColumn8);
            this.resultsTreeListView.AllColumns.Add(this.olvColumn9);
            this.resultsTreeListView.AllColumns.Add(this.olvColumn10);
            this.resultsTreeListView.AllColumns.Add(this.olvColumn11);
            this.resultsTreeListView.AllColumns.Add(this.olvColumn12);
            this.resultsTreeListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsTreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn6,
            this.olvColumn8,
            this.olvColumn9,
            this.olvColumn10,
            this.olvColumn11,
            this.olvColumn12});
            this.resultsTreeListView.Location = new System.Drawing.Point(3, 3);
            this.resultsTreeListView.Name = "resultsTreeListView";
            this.resultsTreeListView.OwnerDraw = true;
            this.resultsTreeListView.ShowGroups = false;
            this.resultsTreeListView.Size = new System.Drawing.Size(632, 147);
            this.resultsTreeListView.TabIndex = 6;
            this.resultsTreeListView.UseCompatibleStateImageBehavior = false;
            this.resultsTreeListView.View = System.Windows.Forms.View.Details;
            this.resultsTreeListView.VirtualMode = true;
            this.resultsTreeListView.SelectionChanged += new System.EventHandler(this.resultsObjectListView_SelectionChanged);
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "CalibratedOn";
            this.olvColumn6.CellPadding = null;
            this.olvColumn6.Text = "Date";
            this.olvColumn6.Width = 75;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "CalibratedBy";
            this.olvColumn8.CellPadding = null;
            this.olvColumn8.FillsFreeSpace = true;
            this.olvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Text = "Calibrated by";
            this.olvColumn8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Width = 150;
            // 
            // olvColumn9
            // 
            this.olvColumn9.CellPadding = null;
            this.olvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn9.Text = "M1 Deviation";
            this.olvColumn9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn9.Width = 90;
            // 
            // olvColumn10
            // 
            this.olvColumn10.CellPadding = null;
            this.olvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn10.Text = "M2 Deviation";
            this.olvColumn10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn10.Width = 90;
            // 
            // olvColumn11
            // 
            this.olvColumn11.CellPadding = null;
            this.olvColumn11.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn11.Text = "M3 Deviation";
            this.olvColumn11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn11.Width = 90;
            // 
            // olvColumn12
            // 
            this.olvColumn12.CellPadding = null;
            this.olvColumn12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn12.Text = "M4 Deviation";
            this.olvColumn12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn12.Width = 90;
            // 
            // CalibrationResultsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resultsTreeListView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CalibrationResultsView";
            this.Size = new System.Drawing.Size(782, 153);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsTreeListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button calibrateNowButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BrightIdeasSoftware.TreeListView resultsTreeListView;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn olvColumn10;
        private BrightIdeasSoftware.OLVColumn olvColumn11;
        private BrightIdeasSoftware.OLVColumn olvColumn12;
    }
}
