namespace CPECentral.Dialogs
{
    partial class SelectToolDialog
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Tools", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Holders", System.Windows.Forms.HorizontalAlignment.Left);
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.resultsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.optionalLabel = new System.Windows.Forms.Label();
            this.optionalComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search for tool";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(16, 33);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(475, 33);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // resultsListView
            // 
            this.resultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.resultsListView.FullRowSelect = true;
            this.resultsListView.GridLines = true;
            listViewGroup1.Header = "Tools";
            listViewGroup1.Name = "toolsListViewGroup";
            listViewGroup2.Header = "Holders";
            listViewGroup2.Name = "holdersListViewGroup";
            this.resultsListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.resultsListView.HideSelection = false;
            this.resultsListView.Location = new System.Drawing.Point(16, 100);
            this.resultsListView.MultiSelect = false;
            this.resultsListView.Name = "resultsListView";
            this.resultsListView.Size = new System.Drawing.Size(475, 326);
            this.resultsListView.TabIndex = 1;
            this.resultsListView.UseCompatibleStateImageBehavior = false;
            this.resultsListView.View = System.Windows.Forms.View.Details;
            this.resultsListView.SelectedIndexChanged += new System.EventHandler(this.resultsListView_SelectedIndexChanged);
            this.resultsListView.ClientSizeChanged += new System.EventHandler(this.resultsListView_ClientSizeChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 450;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Results";
            // 
            // optionalLabel
            // 
            this.optionalLabel.AutoSize = true;
            this.optionalLabel.Location = new System.Drawing.Point(13, 443);
            this.optionalLabel.Name = "optionalLabel";
            this.optionalLabel.Size = new System.Drawing.Size(17, 17);
            this.optionalLabel.TabIndex = 0;
            this.optionalLabel.Text = "...";
            // 
            // optionalComboBox
            // 
            this.optionalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optionalComboBox.Enabled = false;
            this.optionalComboBox.FormattingEnabled = true;
            this.optionalComboBox.Location = new System.Drawing.Point(17, 463);
            this.optionalComboBox.Name = "optionalComboBox";
            this.optionalComboBox.Size = new System.Drawing.Size(475, 25);
            this.optionalComboBox.TabIndex = 2;
            this.optionalComboBox.SelectedIndexChanged += new System.EventHandler(this.holdersComboBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(17, 514);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(283, 51);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Okay";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(306, 514);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(185, 51);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SelectToolDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(503, 587);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.optionalComboBox);
            this.Controls.Add(this.resultsListView);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.optionalLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectToolDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select a tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectToolDialog_FormClosing);
            this.Load += new System.EventHandler(this.SelectToolDialog2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ListView resultsListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label optionalLabel;
        private System.Windows.Forms.ComboBox optionalComboBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}