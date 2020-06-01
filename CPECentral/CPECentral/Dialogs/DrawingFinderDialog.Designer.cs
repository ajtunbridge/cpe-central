namespace CPECentral.Dialogs
{
    partial class DrawingFinderDialog
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.scanServerButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.importSelectedButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchTermTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.filesListView = new CPECentral.Controls.FilesListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.searchTermTextBox);
            this.groupBox1.Controls.Add(this.scanServerButton);
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.filesListView);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(423, 394);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Search term";
            // 
            // scanServerButton
            // 
            this.scanServerButton.Location = new System.Drawing.Point(10, 85);
            this.scanServerButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scanServerButton.Name = "scanServerButton";
            this.scanServerButton.Size = new System.Drawing.Size(406, 55);
            this.scanServerButton.TabIndex = 10;
            this.scanServerButton.Text = "Search";
            this.scanServerButton.UseVisualStyleBackColor = true;
            this.scanServerButton.Click += new System.EventHandler(this.ScanServerButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(10, 148);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(406, 30);
            this.progressBar.TabIndex = 12;
            // 
            // importSelectedButton
            // 
            this.importSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importSelectedButton.Enabled = false;
            this.importSelectedButton.Location = new System.Drawing.Point(12, 414);
            this.importSelectedButton.Name = "importSelectedButton";
            this.importSelectedButton.Size = new System.Drawing.Size(245, 42);
            this.importSelectedButton.TabIndex = 10;
            this.importSelectedButton.Text = "Import selected";
            this.importSelectedButton.UseVisualStyleBackColor = true;
            this.importSelectedButton.Click += new System.EventHandler(this.importSelectedButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(264, 414);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(172, 42);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // searchTermTextBox
            // 
            this.searchTermTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.searchTermTextBox.DisableDoubleSpace = true;
            this.searchTermTextBox.DisableLeadingSpace = false;
            this.searchTermTextBox.Location = new System.Drawing.Point(10, 45);
            this.searchTermTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchTermTextBox.MaxLength = 50;
            this.searchTermTextBox.Name = "searchTermTextBox";
            this.searchTermTextBox.NumericCharactersOnly = false;
            this.searchTermTextBox.Size = new System.Drawing.Size(405, 25);
            this.searchTermTextBox.SuppressEnterKey = false;
            this.searchTermTextBox.TabIndex = 9;
            // 
            // filesListView
            // 
            this.filesListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filesListView.CheckBoxes = true;
            this.filesListView.EnsureSelection = false;
            this.filesListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesListView.FullRowSelect = true;
            this.filesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.filesListView.HideSelection = false;
            this.filesListView.IndexOfColumnToResize = 0;
            this.filesListView.ItemContextMenuStrip = null;
            this.filesListView.Location = new System.Drawing.Point(10, 187);
            this.filesListView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.filesListView.MultiSelect = false;
            this.filesListView.Name = "filesListView";
            this.filesListView.ResizeColumnToFill = true;
            this.filesListView.ShowItemToolTips = true;
            this.filesListView.Size = new System.Drawing.Size(405, 188);
            this.filesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.filesListView.TabIndex = 11;
            this.filesListView.UseAlternatingBackColor = true;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            this.filesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.filesListView_ItemChecked);
            // 
            // DrawingFinderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 468);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.importSelectedButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrawingFinderDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Drawing/model finder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private nGenLibrary.Controls.EnhancedTextBox searchTermTextBox;
        private System.Windows.Forms.Button scanServerButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private Controls.FilesListView filesListView;
        private System.Windows.Forms.Button importSelectedButton;
        private System.Windows.Forms.Button cancelButton;
    }
}