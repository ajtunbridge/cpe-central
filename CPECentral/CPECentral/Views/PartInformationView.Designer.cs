namespace CPECentral.Views
{
    partial class PartInformationView
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
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.versionsComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.versionOptionsButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.drawingNumberTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.nameTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.toolingLocationTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.SuspendLayout();
            // 
            // customerTextBox
            // 
            this.customerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerTextBox.Location = new System.Drawing.Point(0, 20);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.ReadOnly = true;
            this.customerTextBox.Size = new System.Drawing.Size(282, 25);
            this.customerTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Drawing number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name";
            // 
            // versionsComboBox
            // 
            this.versionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionsComboBox.FormattingEnabled = true;
            this.versionsComboBox.Location = new System.Drawing.Point(0, 164);
            this.versionsComboBox.Name = "versionsComboBox";
            this.versionsComboBox.Size = new System.Drawing.Size(55, 25);
            this.versionsComboBox.TabIndex = 2;
            this.versionsComboBox.SelectedIndexChanged += new System.EventHandler(this.versionsComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-3, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Versions";
            // 
            // versionOptionsButton
            // 
            this.versionOptionsButton.Location = new System.Drawing.Point(61, 164);
            this.versionOptionsButton.Name = "versionOptionsButton";
            this.versionOptionsButton.Size = new System.Drawing.Size(25, 25);
            this.versionOptionsButton.TabIndex = 3;
            this.versionOptionsButton.Text = "..";
            this.versionOptionsButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(92, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tooling location";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveChangesButton.Enabled = false;
            this.saveChangesButton.Location = new System.Drawing.Point(0, 196);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(282, 37);
            this.saveChangesButton.TabIndex = 4;
            this.saveChangesButton.Text = "No changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // drawingNumberTextBox
            // 
            this.drawingNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingNumberTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.drawingNumberTextBox.DisableDoubleSpace = true;
            this.drawingNumberTextBox.Location = new System.Drawing.Point(0, 68);
            this.drawingNumberTextBox.MaxLength = 50;
            this.drawingNumberTextBox.Name = "drawingNumberTextBox";
            this.drawingNumberTextBox.Size = new System.Drawing.Size(282, 25);
            this.drawingNumberTextBox.TabIndex = 5;
            this.drawingNumberTextBox.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nameTextBox.DisableDoubleSpace = true;
            this.nameTextBox.Location = new System.Drawing.Point(0, 116);
            this.nameTextBox.MaxLength = 50;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(282, 25);
            this.nameTextBox.TabIndex = 5;
            this.nameTextBox.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            // 
            // toolingLocationTextBox
            // 
            this.toolingLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolingLocationTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toolingLocationTextBox.DisableDoubleSpace = false;
            this.toolingLocationTextBox.Location = new System.Drawing.Point(92, 165);
            this.toolingLocationTextBox.MaxLength = 50;
            this.toolingLocationTextBox.Name = "toolingLocationTextBox";
            this.toolingLocationTextBox.Size = new System.Drawing.Size(190, 25);
            this.toolingLocationTextBox.TabIndex = 5;
            this.toolingLocationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolingLocationTextBox.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            // 
            // PartInformationView
            // 
            this.Controls.Add(this.toolingLocationTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.drawingNumberTextBox);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.versionOptionsButton);
            this.Controls.Add(this.versionsComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PartInformationView";
            this.Size = new System.Drawing.Size(285, 239);
            this.Load += new System.EventHandler(this.PartInformationView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox versionsComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button versionOptionsButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveChangesButton;
        private nGenLibrary.Controls.EnhancedTextBox drawingNumberTextBox;
        private nGenLibrary.Controls.EnhancedTextBox nameTextBox;
        private nGenLibrary.Controls.EnhancedTextBox toolingLocationTextBox;
    }
}
