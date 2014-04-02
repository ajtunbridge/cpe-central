using CPECentral.Controls;

namespace CPECentral.Dialogs
{
    partial class AddPartDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPartDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.scanServerButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.isNewCustomerCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.importFromTricornButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.worksOrderEnhancedTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.toolingLocationTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.nameTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.searchTermTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.drawingNumberTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.versionTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.newCustomerNameTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filesListView = new CPECentral.Controls.FilesListView();
            this.okayCancelFooter = new CPECentral.Controls.OkayCancelFooter();
            this.filePreviewPanel = new CPECentral.Controls.FilePreviewPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // customerComboBox
            // 
            this.customerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(9, 91);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(366, 25);
            this.customerComboBox.TabIndex = 2;
            // 
            // scanServerButton
            // 
            this.scanServerButton.Location = new System.Drawing.Point(9, 72);
            this.scanServerButton.Name = "scanServerButton";
            this.scanServerButton.Size = new System.Drawing.Size(348, 52);
            this.scanServerButton.TabIndex = 1;
            this.scanServerButton.Text = "Scan server for drawings and models";
            this.scanServerButton.UseVisualStyleBackColor = true;
            this.scanServerButton.Click += new System.EventHandler(this.ScanServerButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Drawing number";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(301, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Version";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tooling location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(381, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Document preview";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 130);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(348, 23);
            this.progressBar.TabIndex = 7;
            // 
            // isNewCustomerCheckBox
            // 
            this.isNewCustomerCheckBox.AutoSize = true;
            this.isNewCustomerCheckBox.Location = new System.Drawing.Point(248, 120);
            this.isNewCustomerCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.isNewCustomerCheckBox.Name = "isNewCustomerCheckBox";
            this.isNewCustomerCheckBox.Size = new System.Drawing.Size(127, 21);
            this.isNewCustomerCheckBox.TabIndex = 3;
            this.isNewCustomerCheckBox.Text = "Is new customer?";
            this.isNewCustomerCheckBox.UseVisualStyleBackColor = true;
            this.isNewCustomerCheckBox.CheckedChanged += new System.EventHandler(this.IsNewCustomerCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Search term";
            // 
            // importFromTricornButton
            // 
            this.importFromTricornButton.Enabled = false;
            this.importFromTricornButton.Location = new System.Drawing.Point(143, 12);
            this.importFromTricornButton.Name = "importFromTricornButton";
            this.importFromTricornButton.Size = new System.Drawing.Size(232, 42);
            this.importFromTricornButton.TabIndex = 1;
            this.importFromTricornButton.Text = "Import from Tricorn";
            this.importFromTricornButton.UseVisualStyleBackColor = true;
            this.importFromTricornButton.Click += new System.EventHandler(this.importFromTricornButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Works order number";
            // 
            // worksOrderEnhancedTextBox
            // 
            this.worksOrderEnhancedTextBox.DisableDoubleSpace = false;
            this.worksOrderEnhancedTextBox.DisableLeadingSpace = false;
            this.worksOrderEnhancedTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.worksOrderEnhancedTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.worksOrderEnhancedTextBox.Location = new System.Drawing.Point(9, 29);
            this.worksOrderEnhancedTextBox.MaxLength = 5;
            this.worksOrderEnhancedTextBox.Name = "worksOrderEnhancedTextBox";
            this.worksOrderEnhancedTextBox.NumericCharactersOnly = true;
            this.worksOrderEnhancedTextBox.Size = new System.Drawing.Size(128, 25);
            this.worksOrderEnhancedTextBox.SuppressEnterKey = true;
            this.worksOrderEnhancedTextBox.TabIndex = 0;
            this.worksOrderEnhancedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.worksOrderEnhancedTextBox.EnterKeyPressed += new System.EventHandler(this.worksOrderEnhancedTextBox_EnterKeyPressed);
            this.worksOrderEnhancedTextBox.TextChanged += new System.EventHandler(this.worksOrderEnhancedTextBox_TextChanged);
            // 
            // toolingLocationTextBox
            // 
            this.toolingLocationTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toolingLocationTextBox.DisableDoubleSpace = true;
            this.toolingLocationTextBox.DisableLeadingSpace = false;
            this.toolingLocationTextBox.Location = new System.Drawing.Point(12, 260);
            this.toolingLocationTextBox.MaxLength = 50;
            this.toolingLocationTextBox.Name = "toolingLocationTextBox";
            this.toolingLocationTextBox.NumericCharactersOnly = false;
            this.toolingLocationTextBox.Size = new System.Drawing.Size(363, 25);
            this.toolingLocationTextBox.SuppressEnterKey = false;
            this.toolingLocationTextBox.TabIndex = 7;
            // 
            // nameTextBox
            // 
            this.nameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nameTextBox.DisableDoubleSpace = true;
            this.nameTextBox.DisableLeadingSpace = false;
            this.nameTextBox.Location = new System.Drawing.Point(12, 212);
            this.nameTextBox.MaxLength = 50;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.NumericCharactersOnly = false;
            this.nameTextBox.Size = new System.Drawing.Size(363, 25);
            this.nameTextBox.SuppressEnterKey = false;
            this.nameTextBox.TabIndex = 6;
            // 
            // searchTermTextBox
            // 
            this.searchTermTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.searchTermTextBox.DisableDoubleSpace = true;
            this.searchTermTextBox.DisableLeadingSpace = false;
            this.searchTermTextBox.Location = new System.Drawing.Point(9, 41);
            this.searchTermTextBox.MaxLength = 50;
            this.searchTermTextBox.Name = "searchTermTextBox";
            this.searchTermTextBox.NumericCharactersOnly = false;
            this.searchTermTextBox.Size = new System.Drawing.Size(348, 25);
            this.searchTermTextBox.SuppressEnterKey = false;
            this.searchTermTextBox.TabIndex = 0;
            // 
            // drawingNumberTextBox
            // 
            this.drawingNumberTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.drawingNumberTextBox.DisableDoubleSpace = true;
            this.drawingNumberTextBox.DisableLeadingSpace = false;
            this.drawingNumberTextBox.Location = new System.Drawing.Point(12, 164);
            this.drawingNumberTextBox.MaxLength = 50;
            this.drawingNumberTextBox.Name = "drawingNumberTextBox";
            this.drawingNumberTextBox.NumericCharactersOnly = false;
            this.drawingNumberTextBox.Size = new System.Drawing.Size(283, 25);
            this.drawingNumberTextBox.SuppressEnterKey = false;
            this.drawingNumberTextBox.TabIndex = 4;
            this.drawingNumberTextBox.TextChanged += new System.EventHandler(this.DrawingNumberTextBox_TextChanged);
            // 
            // versionTextBox
            // 
            this.versionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.versionTextBox.DisableDoubleSpace = true;
            this.versionTextBox.DisableLeadingSpace = false;
            this.versionTextBox.Location = new System.Drawing.Point(301, 164);
            this.versionTextBox.MaxLength = 10;
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.NumericCharactersOnly = false;
            this.versionTextBox.Size = new System.Drawing.Size(74, 25);
            this.versionTextBox.SuppressEnterKey = false;
            this.versionTextBox.TabIndex = 5;
            this.versionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // newCustomerNameTextBox
            // 
            this.newCustomerNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.newCustomerNameTextBox.DisableDoubleSpace = true;
            this.newCustomerNameTextBox.DisableLeadingSpace = false;
            this.newCustomerNameTextBox.Location = new System.Drawing.Point(9, 91);
            this.newCustomerNameTextBox.MaxLength = 50;
            this.newCustomerNameTextBox.Name = "newCustomerNameTextBox";
            this.newCustomerNameTextBox.NumericCharactersOnly = false;
            this.newCustomerNameTextBox.Size = new System.Drawing.Size(333, 25);
            this.newCustomerNameTextBox.SuppressEnterKey = false;
            this.newCustomerNameTextBox.TabIndex = 5;
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
            this.groupBox1.Location = new System.Drawing.Point(12, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 290);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drawings/Models search";
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
            this.filesListView.Location = new System.Drawing.Point(9, 160);
            this.filesListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filesListView.MultiSelect = false;
            this.filesListView.Name = "filesListView";
            this.filesListView.ResizeColumnToFill = true;
            this.filesListView.ShowItemToolTips = true;
            this.filesListView.Size = new System.Drawing.Size(348, 123);
            this.filesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.filesListView.TabIndex = 2;
            this.filesListView.UseAlternatingBackColor = true;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            this.filesListView.SelectedIndexChanged += new System.EventHandler(this.FilesListView_SelectedIndexChanged);
            // 
            // okayCancelFooter
            // 
            this.okayCancelFooter.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter.Location = new System.Drawing.Point(0, 604);
            this.okayCancelFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter.Name = "okayCancelFooter";
            this.okayCancelFooter.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.okayCancelFooter.Size = new System.Drawing.Size(932, 45);
            this.okayCancelFooter.TabIndex = 12;
            this.okayCancelFooter.OkayClicked += new System.EventHandler(this.OkayCancelFooter_OkayClicked);
            this.okayCancelFooter.CancelClicked += new System.EventHandler(this.OkayCancelFooter_CancelClicked);
            // 
            // filePreviewPanel
            // 
            this.filePreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePreviewPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("filePreviewPanel.BackgroundImage")));
            this.filePreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filePreviewPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePreviewPanel.Location = new System.Drawing.Point(384, 29);
            this.filePreviewPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filePreviewPanel.Name = "filePreviewPanel";
            this.filePreviewPanel.Size = new System.Drawing.Size(536, 567);
            this.filePreviewPanel.TabIndex = 9;
            // 
            // AddPartDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 649);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.worksOrderEnhancedTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.importFromTricornButton);
            this.Controls.Add(this.isNewCustomerCheckBox);
            this.Controls.Add(this.okayCancelFooter);
            this.Controls.Add(this.filePreviewPanel);
            this.Controls.Add(this.toolingLocationTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.drawingNumberTextBox);
            this.Controls.Add(this.versionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.newCustomerNameTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPartDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create new part";
            this.Load += new System.EventHandler(this.AddPartDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Button scanServerButton;
        private Controls.FilesListView filesListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private nGenLibrary.Controls.EnhancedTextBox versionTextBox;
        private nGenLibrary.Controls.EnhancedTextBox drawingNumberTextBox;
        private System.Windows.Forms.Label label4;
        private nGenLibrary.Controls.EnhancedTextBox nameTextBox;
        private System.Windows.Forms.Label label5;
        private nGenLibrary.Controls.EnhancedTextBox toolingLocationTextBox;
        private FilePreviewPanel filePreviewPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar;
        private Controls.OkayCancelFooter okayCancelFooter;
        private System.Windows.Forms.CheckBox isNewCustomerCheckBox;
        private nGenLibrary.Controls.EnhancedTextBox newCustomerNameTextBox;
        private System.Windows.Forms.Label label7;
        private nGenLibrary.Controls.EnhancedTextBox searchTermTextBox;
        private System.Windows.Forms.Button importFromTricornButton;
        private System.Windows.Forms.Label label8;
        private nGenLibrary.Controls.EnhancedTextBox worksOrderEnhancedTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}