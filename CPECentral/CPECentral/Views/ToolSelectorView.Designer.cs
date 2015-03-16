namespace CPECentral.Views
{
    partial class ToolSelectorView
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
            this.resultsObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.filterButton = new System.Windows.Forms.Button();
            this.filterTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.asyncIndicatorPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultsObjectListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asyncIndicatorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // resultsObjectListView
            // 
            this.resultsObjectListView.AllColumns.Add(this.olvColumn1);
            this.resultsObjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.resultsObjectListView.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsObjectListView.FullRowSelect = true;
            this.resultsObjectListView.GridLines = true;
            this.resultsObjectListView.Location = new System.Drawing.Point(6, 127);
            this.resultsObjectListView.Name = "resultsObjectListView";
            this.resultsObjectListView.ShowGroups = false;
            this.resultsObjectListView.Size = new System.Drawing.Size(383, 338);
            this.resultsObjectListView.TabIndex = 2;
            this.resultsObjectListView.UseCompatibleStateImageBehavior = false;
            this.resultsObjectListView.View = System.Windows.Forms.View.Details;
            this.resultsObjectListView.SelectionChanged += new System.EventHandler(this.resultsObjectListView_SelectionChanged);
            this.resultsObjectListView.ItemActivate += new System.EventHandler(this.resultsObjectListView_ItemActivate);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Description";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.FillsFreeSpace = true;
            this.olvColumn1.Text = "Description";
            // 
            // filterButton
            // 
            this.filterButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterButton.Enabled = false;
            this.filterButton.Location = new System.Drawing.Point(6, 82);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(383, 33);
            this.filterButton.TabIndex = 1;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTextBox.DisableDoubleSpace = false;
            this.filterTextBox.DisableLeadingSpace = false;
            this.filterTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterTextBox.Location = new System.Drawing.Point(6, 47);
            this.filterTextBox.MaxLength = 50;
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.NumericCharactersOnly = false;
            this.filterTextBox.Size = new System.Drawing.Size(383, 29);
            this.filterTextBox.SuppressEnterKey = true;
            this.filterTextBox.TabIndex = 0;
            this.filterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.filterTextBox.EnterKeyPressed += new System.EventHandler(this.filterTextBox_EnterKeyPressed);
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // asyncIndicatorPictureBox
            // 
            this.asyncIndicatorPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.asyncIndicatorPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.asyncIndicatorPictureBox.Image = global::CPECentral.Properties.Resources.PreloaderImage2;
            this.asyncIndicatorPictureBox.Location = new System.Drawing.Point(6, 47);
            this.asyncIndicatorPictureBox.Name = "asyncIndicatorPictureBox";
            this.asyncIndicatorPictureBox.Size = new System.Drawing.Size(383, 29);
            this.asyncIndicatorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.asyncIndicatorPictureBox.TabIndex = 3;
            this.asyncIndicatorPictureBox.TabStop = false;
            this.asyncIndicatorPictureBox.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type in what you are looking for and press the \'Filter\' button";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToolSelectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.resultsObjectListView);
            this.Controls.Add(this.asyncIndicatorPictureBox);
            this.Controls.Add(this.filterTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ToolSelectorView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(397, 471);
            ((System.ComponentModel.ISupportInitialize)(this.resultsObjectListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asyncIndicatorPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView resultsObjectListView;
        private System.Windows.Forms.Button filterButton;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private nGenLibrary.Controls.EnhancedTextBox filterTextBox;
        private System.Windows.Forms.PictureBox asyncIndicatorPictureBox;
        private System.Windows.Forms.Label label1;
    }
}
