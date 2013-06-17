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
            this.versionTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.drawingNumberTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolingLocationTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.isNewCustomerCheckBox = new System.Windows.Forms.CheckBox();
            this.newCustomerNameTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.okayCancelFooter = new CPECentral.Controls.OkayCancelFooter();
            this.filePreviewPanel = new CPECentral.Controls.FilePreviewPanel();
            this.filesListView = new CPECentral.Controls.FilesListView();
            this.label7 = new System.Windows.Forms.Label();
            this.searchTermTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // customerComboBox
            // 
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(12, 29);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(333, 25);
            this.customerComboBox.TabIndex = 1;
            // 
            // scanServerButton
            // 
            this.scanServerButton.Location = new System.Drawing.Point(12, 239);
            this.scanServerButton.Name = "scanServerButton";
            this.scanServerButton.Size = new System.Drawing.Size(333, 52);
            this.scanServerButton.TabIndex = 3;
            this.scanServerButton.Text = "Scan server for drawings and models";
            this.scanServerButton.UseVisualStyleBackColor = true;
            this.scanServerButton.Click += new System.EventHandler(this.scanServerButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Drawing number";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(271, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Version";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // versionTextBox
            // 
            this.versionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.versionTextBox.DisableDoubleSpace = true;
            this.versionTextBox.Location = new System.Drawing.Point(271, 112);
            this.versionTextBox.MaxLength = 10;
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(74, 25);
            this.versionTextBox.TabIndex = 5;
            // 
            // drawingNumberTextBox
            // 
            this.drawingNumberTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.drawingNumberTextBox.DisableDoubleSpace = true;
            this.drawingNumberTextBox.Location = new System.Drawing.Point(12, 112);
            this.drawingNumberTextBox.MaxLength = 50;
            this.drawingNumberTextBox.Name = "drawingNumberTextBox";
            this.drawingNumberTextBox.Size = new System.Drawing.Size(253, 25);
            this.drawingNumberTextBox.TabIndex = 5;
            this.drawingNumberTextBox.TextChanged += new System.EventHandler(this.drawingNumberTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nameTextBox.DisableDoubleSpace = true;
            this.nameTextBox.Location = new System.Drawing.Point(12, 160);
            this.nameTextBox.MaxLength = 50;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(333, 25);
            this.nameTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tooling location";
            // 
            // toolingLocationTextBox
            // 
            this.toolingLocationTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toolingLocationTextBox.DisableDoubleSpace = true;
            this.toolingLocationTextBox.Location = new System.Drawing.Point(12, 208);
            this.toolingLocationTextBox.MaxLength = 50;
            this.toolingLocationTextBox.Name = "toolingLocationTextBox";
            this.toolingLocationTextBox.Size = new System.Drawing.Size(333, 25);
            this.toolingLocationTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Document preview";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 297);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(333, 23);
            this.progressBar.TabIndex = 7;
            // 
            // isNewCustomerCheckBox
            // 
            this.isNewCustomerCheckBox.AutoSize = true;
            this.isNewCustomerCheckBox.Location = new System.Drawing.Point(221, 60);
            this.isNewCustomerCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.isNewCustomerCheckBox.Name = "isNewCustomerCheckBox";
            this.isNewCustomerCheckBox.Size = new System.Drawing.Size(127, 21);
            this.isNewCustomerCheckBox.TabIndex = 9;
            this.isNewCustomerCheckBox.Text = "Is new customer?";
            this.isNewCustomerCheckBox.UseVisualStyleBackColor = true;
            this.isNewCustomerCheckBox.CheckedChanged += new System.EventHandler(this.isNewCustomerCheckBox_CheckedChanged);
            // 
            // newCustomerNameTextBox
            // 
            this.newCustomerNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.newCustomerNameTextBox.DisableDoubleSpace = true;
            this.newCustomerNameTextBox.Location = new System.Drawing.Point(12, 29);
            this.newCustomerNameTextBox.MaxLength = 50;
            this.newCustomerNameTextBox.Name = "newCustomerNameTextBox";
            this.newCustomerNameTextBox.Size = new System.Drawing.Size(333, 25);
            this.newCustomerNameTextBox.TabIndex = 5;
            // 
            // okayCancelFooter
            // 
            this.okayCancelFooter.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter.Location = new System.Drawing.Point(0, 527);
            this.okayCancelFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter.Name = "okayCancelFooter";
            this.okayCancelFooter.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.okayCancelFooter.Size = new System.Drawing.Size(811, 45);
            this.okayCancelFooter.TabIndex = 8;
            this.okayCancelFooter.OkayClicked += new System.EventHandler(this.okayCancelFooter_OkayClicked);
            this.okayCancelFooter.CancelClicked += new System.EventHandler(this.okayCancelFooter_CancelClicked);
            // 
            // filePreviewPanel
            // 
            this.filePreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePreviewPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("filePreviewPanel.BackgroundImage")));
            this.filePreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filePreviewPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePreviewPanel.Location = new System.Drawing.Point(351, 29);
            this.filePreviewPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filePreviewPanel.Name = "filePreviewPanel";
            this.filePreviewPanel.Size = new System.Drawing.Size(448, 490);
            this.filePreviewPanel.TabIndex = 6;
            // 
            // filesListView
            // 
            this.filesListView.AlternateBackColor = System.Drawing.Color.WhiteSmoke;
            this.filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filesListView.CheckBoxes = true;
            this.filesListView.EnsureSelection = false;
            this.filesListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesListView.FullRowSelect = true;
            this.filesListView.HideSelection = false;
            this.filesListView.IndexOfColumnToResize = 0;
            this.filesListView.ItemContextMenuStrip = null;
            this.filesListView.Location = new System.Drawing.Point(12, 375);
            this.filesListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filesListView.Name = "filesListView";
            this.filesListView.ResizeColumnToFill = true;
            this.filesListView.ShowItemToolTips = true;
            this.filesListView.Size = new System.Drawing.Size(333, 144);
            this.filesListView.TabIndex = 4;
            this.filesListView.UseAlternatingBackColor = true;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            this.filesListView.SelectedIndexChanged += new System.EventHandler(this.filesListView_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Search term";
            // 
            // searchTermTextBox
            // 
            this.searchTermTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.searchTermTextBox.DisableDoubleSpace = true;
            this.searchTermTextBox.Location = new System.Drawing.Point(12, 343);
            this.searchTermTextBox.MaxLength = 50;
            this.searchTermTextBox.Name = "searchTermTextBox";
            this.searchTermTextBox.Size = new System.Drawing.Size(333, 25);
            this.searchTermTextBox.TabIndex = 5;
            // 
            // AddPartDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 572);
            this.Controls.Add(this.isNewCustomerCheckBox);
            this.Controls.Add(this.okayCancelFooter);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.filePreviewPanel);
            this.Controls.Add(this.toolingLocationTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.searchTermTextBox);
            this.Controls.Add(this.drawingNumberTextBox);
            this.Controls.Add(this.versionTextBox);
            this.Controls.Add(this.filesListView);
            this.Controls.Add(this.scanServerButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
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
    }
}