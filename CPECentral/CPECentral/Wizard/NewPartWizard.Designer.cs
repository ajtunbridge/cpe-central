namespace CPECentral.Wizard
{
    partial class NewPartWizard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextFinishButton = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.wizardPages = new CPECentral.Wizard.WizardPages();
            this.partInformationPage = new System.Windows.Forms.TabPage();
            this.isNewCustomerCheckBox = new System.Windows.Forms.CheckBox();
            this.toolingLocationTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.versionTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.nameTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.drawingNumberTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.customerTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.scanForDocumentsPage = new System.Windows.Forms.TabPage();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.scanOrCancelButton = new System.Windows.Forms.Button();
            this.filesListView = new CPECentral.Controls.FilesListView();
            this.label3 = new System.Windows.Forms.Label();
            this.summaryPage = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.filesToImportListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.toolingLocationLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.drawingNumberLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.wizardPages.SuspendLayout();
            this.partInformationPage.SuspendLayout();
            this.scanForDocumentsPage.SuspendLayout();
            this.summaryPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.previousButton);
            this.panel1.Controls.Add(this.nextFinishButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 369);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 54);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 2);
            this.label1.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(7, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(110, 38);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.TabStop = false;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previousButton.Enabled = false;
            this.previousButton.Location = new System.Drawing.Point(203, 8);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(111, 38);
            this.previousButton.TabIndex = 1;
            this.previousButton.TabStop = false;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // nextFinishButton
            // 
            this.nextFinishButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nextFinishButton.Location = new System.Drawing.Point(320, 8);
            this.nextFinishButton.Name = "nextFinishButton";
            this.nextFinishButton.Size = new System.Drawing.Size(111, 38);
            this.nextFinishButton.TabIndex = 1;
            this.nextFinishButton.TabStop = false;
            this.nextFinishButton.Text = "Next";
            this.nextFinishButton.UseVisualStyleBackColor = true;
            this.nextFinishButton.Click += new System.EventHandler(this.NextFinishButton_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.headerLabel);
            this.headerPanel.Controls.Add(this.pictureBox1);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(438, 50);
            this.headerPanel.TabIndex = 0;
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLabel.ForeColor = System.Drawing.Color.DimGray;
            this.headerLabel.Location = new System.Drawing.Point(112, 3);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(323, 49);
            this.headerLabel.TabIndex = 23;
            this.headerLabel.Text = "Part information";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::CPECentral.Properties.Resources.CompanyLogo;
            this.pictureBox1.Location = new System.Drawing.Point(7, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Location = new System.Drawing.Point(0, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(438, 2);
            this.label10.TabIndex = 21;
            // 
            // wizardPages
            // 
            this.wizardPages.Controls.Add(this.partInformationPage);
            this.wizardPages.Controls.Add(this.scanForDocumentsPage);
            this.wizardPages.Controls.Add(this.summaryPage);
            this.wizardPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPages.Location = new System.Drawing.Point(0, 50);
            this.wizardPages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wizardPages.Name = "wizardPages";
            this.wizardPages.SelectedIndex = 0;
            this.wizardPages.Size = new System.Drawing.Size(438, 319);
            this.wizardPages.TabIndex = 0;
            this.wizardPages.SelectedIndexChanged += new System.EventHandler(this.WizardPages_SelectedIndexChanged);
            // 
            // partInformationPage
            // 
            this.partInformationPage.BackColor = System.Drawing.SystemColors.Control;
            this.partInformationPage.Controls.Add(this.isNewCustomerCheckBox);
            this.partInformationPage.Controls.Add(this.toolingLocationTextBox);
            this.partInformationPage.Controls.Add(this.versionTextBox);
            this.partInformationPage.Controls.Add(this.nameTextBox);
            this.partInformationPage.Controls.Add(this.drawingNumberTextBox);
            this.partInformationPage.Controls.Add(this.label2);
            this.partInformationPage.Controls.Add(this.label5);
            this.partInformationPage.Controls.Add(this.label6);
            this.partInformationPage.Controls.Add(this.label7);
            this.partInformationPage.Controls.Add(this.label8);
            this.partInformationPage.Controls.Add(this.customerComboBox);
            this.partInformationPage.Controls.Add(this.customerTextBox);
            this.partInformationPage.Location = new System.Drawing.Point(4, 26);
            this.partInformationPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.partInformationPage.Name = "partInformationPage";
            this.partInformationPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.partInformationPage.Size = new System.Drawing.Size(430, 289);
            this.partInformationPage.TabIndex = 0;
            this.partInformationPage.Text = "Part information";
            // 
            // isNewCustomerCheckBox
            // 
            this.isNewCustomerCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.isNewCustomerCheckBox.AutoSize = true;
            this.isNewCustomerCheckBox.Location = new System.Drawing.Point(297, 55);
            this.isNewCustomerCheckBox.Name = "isNewCustomerCheckBox";
            this.isNewCustomerCheckBox.Size = new System.Drawing.Size(127, 21);
            this.isNewCustomerCheckBox.TabIndex = 1;
            this.isNewCustomerCheckBox.Text = "Is new customer?";
            this.isNewCustomerCheckBox.UseVisualStyleBackColor = true;
            this.isNewCustomerCheckBox.CheckedChanged += new System.EventHandler(this.IsNewCustomerCheckBox_CheckedChanged);
            // 
            // toolingLocationTextBox
            // 
            this.toolingLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolingLocationTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toolingLocationTextBox.DisableDoubleSpace = false;
            this.toolingLocationTextBox.Location = new System.Drawing.Point(100, 189);
            this.toolingLocationTextBox.MaxLength = 50;
            this.toolingLocationTextBox.Name = "toolingLocationTextBox";
            this.toolingLocationTextBox.Size = new System.Drawing.Size(322, 25);
            this.toolingLocationTextBox.TabIndex = 5;
            this.toolingLocationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // versionTextBox
            // 
            this.versionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.versionTextBox.DisableDoubleSpace = true;
            this.versionTextBox.Location = new System.Drawing.Point(6, 189);
            this.versionTextBox.MaxLength = 10;
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(88, 25);
            this.versionTextBox.TabIndex = 4;
            this.versionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nameTextBox.DisableDoubleSpace = true;
            this.nameTextBox.Location = new System.Drawing.Point(6, 140);
            this.nameTextBox.MaxLength = 50;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(416, 25);
            this.nameTextBox.TabIndex = 3;
            // 
            // drawingNumberTextBox
            // 
            this.drawingNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingNumberTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.drawingNumberTextBox.DisableDoubleSpace = true;
            this.drawingNumberTextBox.Location = new System.Drawing.Point(6, 92);
            this.drawingNumberTextBox.MaxLength = 50;
            this.drawingNumberTextBox.Name = "drawingNumberTextBox";
            this.drawingNumberTextBox.Size = new System.Drawing.Size(416, 25);
            this.drawingNumberTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Version";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(100, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(322, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tooling location";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Drawing number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Customer";
            // 
            // customerComboBox
            // 
            this.customerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(6, 24);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(418, 25);
            this.customerComboBox.TabIndex = 0;
            // 
            // customerTextBox
            // 
            this.customerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.customerTextBox.DisableDoubleSpace = true;
            this.customerTextBox.Location = new System.Drawing.Point(11, 24);
            this.customerTextBox.MaxLength = 50;
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(413, 25);
            this.customerTextBox.TabIndex = 19;
            // 
            // scanForDocumentsPage
            // 
            this.scanForDocumentsPage.BackColor = System.Drawing.SystemColors.Control;
            this.scanForDocumentsPage.Controls.Add(this.progressBar);
            this.scanForDocumentsPage.Controls.Add(this.scanOrCancelButton);
            this.scanForDocumentsPage.Controls.Add(this.filesListView);
            this.scanForDocumentsPage.Controls.Add(this.label3);
            this.scanForDocumentsPage.Location = new System.Drawing.Point(4, 26);
            this.scanForDocumentsPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scanForDocumentsPage.Name = "scanForDocumentsPage";
            this.scanForDocumentsPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scanForDocumentsPage.Size = new System.Drawing.Size(430, 289);
            this.scanForDocumentsPage.TabIndex = 1;
            this.scanForDocumentsPage.Text = "Scan for documents";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(3, 149);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(424, 23);
            this.progressBar.TabIndex = 5;
            // 
            // scanOrCancelButton
            // 
            this.scanOrCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scanOrCancelButton.Location = new System.Drawing.Point(3, 178);
            this.scanOrCancelButton.Name = "scanOrCancelButton";
            this.scanOrCancelButton.Size = new System.Drawing.Size(424, 54);
            this.scanOrCancelButton.TabIndex = 4;
            this.scanOrCancelButton.Text = "Scan";
            this.scanOrCancelButton.UseVisualStyleBackColor = true;
            this.scanOrCancelButton.Click += new System.EventHandler(this.scanOrCancelButton_Click);
            // 
            // filesListView
            // 
            this.filesListView.AlternateBackColor = System.Drawing.Color.WhiteSmoke;
            this.filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesListView.CheckBoxes = true;
            this.filesListView.EnsureSelection = false;
            this.filesListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesListView.FullRowSelect = true;
            this.filesListView.IndexOfColumnToResize = 0;
            this.filesListView.ItemContextMenuStrip = null;
            this.filesListView.Location = new System.Drawing.Point(4, 45);
            this.filesListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filesListView.Name = "filesListView";
            this.filesListView.ResizeColumnToFill = true;
            this.filesListView.ShowItemToolTips = true;
            this.filesListView.Size = new System.Drawing.Size(423, 97);
            this.filesListView.TabIndex = 2;
            this.filesListView.UseAlternatingBackColor = true;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            this.filesListView.ItemActivate += new System.EventHandler(this.FilesListView_ItemActivate);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(1, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(426, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "Here you can scan the server for any drawings/models related to this part";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // summaryPage
            // 
            this.summaryPage.BackColor = System.Drawing.SystemColors.Control;
            this.summaryPage.Controls.Add(this.label16);
            this.summaryPage.Controls.Add(this.filesToImportListView);
            this.summaryPage.Controls.Add(this.label14);
            this.summaryPage.Controls.Add(this.label13);
            this.summaryPage.Controls.Add(this.label12);
            this.summaryPage.Controls.Add(this.label11);
            this.summaryPage.Controls.Add(this.label9);
            this.summaryPage.Controls.Add(this.label15);
            this.summaryPage.Controls.Add(this.toolingLocationLabel);
            this.summaryPage.Controls.Add(this.versionLabel);
            this.summaryPage.Controls.Add(this.nameLabel);
            this.summaryPage.Controls.Add(this.customerLabel);
            this.summaryPage.Controls.Add(this.drawingNumberLabel);
            this.summaryPage.Controls.Add(this.label4);
            this.summaryPage.Location = new System.Drawing.Point(4, 26);
            this.summaryPage.Name = "summaryPage";
            this.summaryPage.Size = new System.Drawing.Size(430, 289);
            this.summaryPage.TabIndex = 2;
            this.summaryPage.Text = "Summary";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 17);
            this.label16.TabIndex = 2;
            this.label16.Text = "Files to import";
            // 
            // filesToImportListView
            // 
            this.filesToImportListView.AlternateBackColor = System.Drawing.Color.WhiteSmoke;
            this.filesToImportListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesToImportListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.filesToImportListView.EnsureSelection = false;
            this.filesToImportListView.FullRowSelect = true;
            this.filesToImportListView.IndexOfColumnToResize = 0;
            this.filesToImportListView.ItemContextMenuStrip = null;
            this.filesToImportListView.Location = new System.Drawing.Point(9, 189);
            this.filesToImportListView.MultiSelect = false;
            this.filesToImportListView.Name = "filesToImportListView";
            this.filesToImportListView.ResizeColumnToFill = false;
            this.filesToImportListView.Size = new System.Drawing.Size(413, 97);
            this.filesToImportListView.TabIndex = 1;
            this.filesToImportListView.UseAlternatingBackColor = true;
            this.filesToImportListView.UseCompatibleStateImageBehavior = false;
            this.filesToImportListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Filename";
            this.columnHeader1.Width = 331;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Progress";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 75;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 140);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Tooling location:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(5, 117);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Version:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 94);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 71);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Drawing number:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 71);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Customer: {0}";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(422, 38);
            this.label15.TabIndex = 0;
            this.label15.Text = "That\'s all we need for now. Press finish to create this part and upload any selec" +
    "ted documents";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolingLocationLabel
            // 
            this.toolingLocationLabel.AutoSize = true;
            this.toolingLocationLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolingLocationLabel.Location = new System.Drawing.Point(123, 140);
            this.toolingLocationLabel.Margin = new System.Windows.Forms.Padding(3);
            this.toolingLocationLabel.Name = "toolingLocationLabel";
            this.toolingLocationLabel.Size = new System.Drawing.Size(138, 17);
            this.toolingLocationLabel.TabIndex = 0;
            this.toolingLocationLabel.Text = "{TOOLING_LOCATION}";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(123, 117);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(3);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(69, 17);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "{VERSION}";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(123, 94);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(53, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "{NAME}";
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLabel.Location = new System.Drawing.Point(123, 48);
            this.customerLabel.Margin = new System.Windows.Forms.Padding(3);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(84, 17);
            this.customerLabel.TabIndex = 0;
            this.customerLabel.Text = "{CUSTOMER}";
            // 
            // drawingNumberLabel
            // 
            this.drawingNumberLabel.AutoSize = true;
            this.drawingNumberLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingNumberLabel.Location = new System.Drawing.Point(123, 71);
            this.drawingNumberLabel.Margin = new System.Windows.Forms.Padding(3);
            this.drawingNumberLabel.Name = "drawingNumberLabel";
            this.drawingNumberLabel.Size = new System.Drawing.Size(133, 17);
            this.drawingNumberLabel.TabIndex = 0;
            this.drawingNumberLabel.Text = "{DRAWING_NUMBER}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Customer:";
            // 
            // NewPartWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 423);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.wizardPages);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPartWizard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New part wizard";
            this.Load += new System.EventHandler(this.NewPartWizard_Load);
            this.panel1.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.wizardPages.ResumeLayout(false);
            this.partInformationPage.ResumeLayout(false);
            this.partInformationPage.PerformLayout();
            this.scanForDocumentsPage.ResumeLayout(false);
            this.summaryPage.ResumeLayout(false);
            this.summaryPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardPages wizardPages;
        private System.Windows.Forms.TabPage partInformationPage;
        private System.Windows.Forms.TabPage scanForDocumentsPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextFinishButton;
        private System.Windows.Forms.TabPage summaryPage;
        private System.Windows.Forms.Label label1;
        private nGenLibrary.Controls.EnhancedTextBox toolingLocationTextBox;
        private nGenLibrary.Controls.EnhancedTextBox nameTextBox;
        private nGenLibrary.Controls.EnhancedTextBox drawingNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.CheckBox isNewCustomerCheckBox;
        private nGenLibrary.Controls.EnhancedTextBox versionTextBox;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label label10;
        private nGenLibrary.Controls.EnhancedTextBox customerTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label label3;
        private Controls.FilesListView filesListView;
        private System.Windows.Forms.Button scanOrCancelButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private nGenLibrary.Controls.EnhancedListView filesToImportListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label toolingLocationLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label drawingNumberLabel;
    }
}