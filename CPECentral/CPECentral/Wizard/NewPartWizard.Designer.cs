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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextFinishButton = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.headerLabel = new System.Windows.Forms.Label();
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
            this.documentsPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.summaryPage = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.wizardPages.SuspendLayout();
            this.partInformationPage.SuspendLayout();
            this.documentsPage.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(0, 298);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 54);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 2);
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
            this.cancelButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previousButton.Enabled = false;
            this.previousButton.Location = new System.Drawing.Point(123, 8);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(111, 38);
            this.previousButton.TabIndex = 1;
            this.previousButton.TabStop = false;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextFinishButton
            // 
            this.nextFinishButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nextFinishButton.Location = new System.Drawing.Point(240, 8);
            this.nextFinishButton.Name = "nextFinishButton";
            this.nextFinishButton.Size = new System.Drawing.Size(111, 38);
            this.nextFinishButton.TabIndex = 1;
            this.nextFinishButton.TabStop = false;
            this.nextFinishButton.Text = "Next";
            this.nextFinishButton.UseVisualStyleBackColor = true;
            this.nextFinishButton.Click += new System.EventHandler(this.nextFinishButton_Click);
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
            this.headerPanel.Size = new System.Drawing.Size(358, 50);
            this.headerPanel.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Location = new System.Drawing.Point(0, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(358, 2);
            this.label10.TabIndex = 21;
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
            // headerLabel
            // 
            this.headerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLabel.ForeColor = System.Drawing.Color.DimGray;
            this.headerLabel.Location = new System.Drawing.Point(112, 3);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(243, 43);
            this.headerLabel.TabIndex = 23;
            this.headerLabel.Text = "Part information";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // wizardPages
            // 
            this.wizardPages.Controls.Add(this.partInformationPage);
            this.wizardPages.Controls.Add(this.documentsPage);
            this.wizardPages.Controls.Add(this.summaryPage);
            this.wizardPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPages.Location = new System.Drawing.Point(0, 50);
            this.wizardPages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wizardPages.Name = "wizardPages";
            this.wizardPages.SelectedIndex = 0;
            this.wizardPages.Size = new System.Drawing.Size(358, 302);
            this.wizardPages.TabIndex = 0;
            this.wizardPages.SelectedIndexChanged += new System.EventHandler(this.wizardPages_SelectedIndexChanged);
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
            this.partInformationPage.Size = new System.Drawing.Size(350, 272);
            this.partInformationPage.TabIndex = 0;
            this.partInformationPage.Text = "Part information";
            // 
            // isNewCustomerCheckBox
            // 
            this.isNewCustomerCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.isNewCustomerCheckBox.AutoSize = true;
            this.isNewCustomerCheckBox.Location = new System.Drawing.Point(215, 55);
            this.isNewCustomerCheckBox.Name = "isNewCustomerCheckBox";
            this.isNewCustomerCheckBox.Size = new System.Drawing.Size(127, 21);
            this.isNewCustomerCheckBox.TabIndex = 1;
            this.isNewCustomerCheckBox.Text = "Is new customer?";
            this.isNewCustomerCheckBox.UseVisualStyleBackColor = true;
            this.isNewCustomerCheckBox.CheckedChanged += new System.EventHandler(this.isNewCustomerCheckBox_CheckedChanged);
            // 
            // toolingLocationTextBox
            // 
            this.toolingLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolingLocationTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toolingLocationTextBox.DisableDoubleSpace = false;
            this.toolingLocationTextBox.Location = new System.Drawing.Point(108, 189);
            this.toolingLocationTextBox.MaxLength = 50;
            this.toolingLocationTextBox.Name = "toolingLocationTextBox";
            this.toolingLocationTextBox.Size = new System.Drawing.Size(234, 25);
            this.toolingLocationTextBox.TabIndex = 5;
            this.toolingLocationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // versionTextBox
            // 
            this.versionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.versionTextBox.DisableDoubleSpace = true;
            this.versionTextBox.Location = new System.Drawing.Point(11, 189);
            this.versionTextBox.MaxLength = 10;
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(91, 25);
            this.versionTextBox.TabIndex = 4;
            this.versionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nameTextBox.DisableDoubleSpace = true;
            this.nameTextBox.Location = new System.Drawing.Point(11, 140);
            this.nameTextBox.MaxLength = 50;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(331, 25);
            this.nameTextBox.TabIndex = 3;
            // 
            // drawingNumberTextBox
            // 
            this.drawingNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingNumberTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.drawingNumberTextBox.DisableDoubleSpace = true;
            this.drawingNumberTextBox.Location = new System.Drawing.Point(11, 92);
            this.drawingNumberTextBox.MaxLength = 50;
            this.drawingNumberTextBox.Name = "drawingNumberTextBox";
            this.drawingNumberTextBox.Size = new System.Drawing.Size(331, 25);
            this.drawingNumberTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Version";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(108, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tooling location";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Drawing number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 4);
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
            this.customerComboBox.Location = new System.Drawing.Point(11, 24);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(331, 25);
            this.customerComboBox.TabIndex = 0;
            // 
            // customerTextBox
            // 
            this.customerTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.customerTextBox.DisableDoubleSpace = true;
            this.customerTextBox.Location = new System.Drawing.Point(11, 24);
            this.customerTextBox.MaxLength = 50;
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(341, 25);
            this.customerTextBox.TabIndex = 19;
            // 
            // documentsPage
            // 
            this.documentsPage.BackColor = System.Drawing.SystemColors.Control;
            this.documentsPage.Controls.Add(this.label3);
            this.documentsPage.Location = new System.Drawing.Point(4, 26);
            this.documentsPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.documentsPage.Name = "documentsPage";
            this.documentsPage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.documentsPage.Size = new System.Drawing.Size(350, 272);
            this.documentsPage.TabIndex = 1;
            this.documentsPage.Text = "Version documents";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // summaryPage
            // 
            this.summaryPage.BackColor = System.Drawing.SystemColors.Control;
            this.summaryPage.Controls.Add(this.label4);
            this.summaryPage.Location = new System.Drawing.Point(4, 26);
            this.summaryPage.Name = "summaryPage";
            this.summaryPage.Size = new System.Drawing.Size(350, 272);
            this.summaryPage.TabIndex = 2;
            this.summaryPage.Text = "Summary";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            // 
            // NewPartWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 352);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.wizardPages);
            this.Controls.Add(this.headerPanel);
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
            this.documentsPage.ResumeLayout(false);
            this.documentsPage.PerformLayout();
            this.summaryPage.ResumeLayout(false);
            this.summaryPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardPages wizardPages;
        private System.Windows.Forms.TabPage partInformationPage;
        private System.Windows.Forms.TabPage documentsPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextFinishButton;
        private System.Windows.Forms.TabPage summaryPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
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
    }
}