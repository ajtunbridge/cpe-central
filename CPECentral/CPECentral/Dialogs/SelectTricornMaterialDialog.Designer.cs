namespace CPECentral.Dialogs
{
    partial class SelectTricornMaterialDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.searchButton = new System.Windows.Forms.Button();
            this.filterValueEnhancedTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resultsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.okayCancelFooter = new CPECentral.Controls.OkayCancelFooter();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.filterValueEnhancedTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 63);
            this.progressBar.MarqueeAnimationSpeed = 65;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(474, 23);
            this.progressBar.TabIndex = 3;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Image = global::CPECentral.Properties.Resources.SearchIcon_16x16;
            this.searchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchButton.Location = new System.Drawing.Point(406, 24);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(74, 33);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // filterValueEnhancedTextBox
            // 
            this.filterValueEnhancedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterValueEnhancedTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.filterValueEnhancedTextBox.DisableDoubleSpace = false;
            this.filterValueEnhancedTextBox.DisableLeadingSpace = false;
            this.filterValueEnhancedTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterValueEnhancedTextBox.Location = new System.Drawing.Point(6, 24);
            this.filterValueEnhancedTextBox.Name = "filterValueEnhancedTextBox";
            this.filterValueEnhancedTextBox.NumericCharactersOnly = false;
            this.filterValueEnhancedTextBox.Size = new System.Drawing.Size(394, 33);
            this.filterValueEnhancedTextBox.SuppressEnterKey = true;
            this.filterValueEnhancedTextBox.TabIndex = 1;
            this.filterValueEnhancedTextBox.Text = "%%";
            this.filterValueEnhancedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.filterValueEnhancedTextBox.EnterKeyPressed += new System.EventHandler(this.filterValueEnhancedTextBox_EnterKeyPressed);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.resultsEnhancedListView);
            this.groupBox2.Location = new System.Drawing.Point(12, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 204);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // resultsEnhancedListView
            // 
            this.resultsEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.resultsEnhancedListView.CheckBoxes = true;
            this.resultsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.resultsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsEnhancedListView.EnsureSelection = false;
            this.resultsEnhancedListView.FullRowSelect = true;
            this.resultsEnhancedListView.GridLines = true;
            this.resultsEnhancedListView.HideSelection = false;
            this.resultsEnhancedListView.IndexOfColumnToResize = 0;
            this.resultsEnhancedListView.ItemContextMenuStrip = null;
            this.resultsEnhancedListView.Location = new System.Drawing.Point(3, 21);
            this.resultsEnhancedListView.MultiSelect = false;
            this.resultsEnhancedListView.Name = "resultsEnhancedListView";
            this.resultsEnhancedListView.ResizeColumnToFill = true;
            this.resultsEnhancedListView.Size = new System.Drawing.Size(480, 180);
            this.resultsEnhancedListView.TabIndex = 0;
            this.resultsEnhancedListView.UseAlternatingBackColor = true;
            this.resultsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.resultsEnhancedListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 353;
            // 
            // okayCancelFooter
            // 
            this.okayCancelFooter.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter.Location = new System.Drawing.Point(0, 327);
            this.okayCancelFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter.Name = "okayCancelFooter";
            this.okayCancelFooter.Size = new System.Drawing.Size(510, 45);
            this.okayCancelFooter.TabIndex = 2;
            this.okayCancelFooter.OkayClicked += new System.EventHandler(this.okayCancelFooter1_OkayClicked);
            this.okayCancelFooter.CancelClicked += new System.EventHandler(this.okayCancelFooter1_CancelClicked);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Specification";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // SelectTricornMaterialDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 372);
            this.Controls.Add(this.okayCancelFooter);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectTricornMaterialDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Tricorn material";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button searchButton;
        private nGenLibrary.Controls.EnhancedTextBox filterValueEnhancedTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private nGenLibrary.Controls.EnhancedListView resultsEnhancedListView;
        private Controls.OkayCancelFooter okayCancelFooter;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}