namespace CPECentral.Views.Quality
{
    partial class GaugeDetailView
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.heldByComboBox = new System.Windows.Forms.ComboBox();
            this.referenceOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.gaugeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.dueForCalibrationTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.removePhotoButton = new System.Windows.Forms.Button();
            this.setPhotoButton = new System.Windows.Forms.Button();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.saveChangesButton);
            this.groupBox2.Controls.Add(this.heldByComboBox);
            this.groupBox2.Controls.Add(this.referenceOnlyCheckBox);
            this.groupBox2.Controls.Add(this.gaugeTypeComboBox);
            this.groupBox2.Controls.Add(this.referenceTextBox);
            this.groupBox2.Controls.Add(this.dueForCalibrationTextBox);
            this.groupBox2.Controls.Add(this.nameTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 227);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveChangesButton.Enabled = false;
            this.saveChangesButton.Location = new System.Drawing.Point(10, 178);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(434, 38);
            this.saveChangesButton.TabIndex = 8;
            this.saveChangesButton.Text = "Save changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // heldByComboBox
            // 
            this.heldByComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heldByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.heldByComboBox.FormattingEnabled = true;
            this.heldByComboBox.Location = new System.Drawing.Point(10, 141);
            this.heldByComboBox.Name = "heldByComboBox";
            this.heldByComboBox.Size = new System.Drawing.Size(240, 25);
            this.heldByComboBox.TabIndex = 7;
            this.heldByComboBox.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxes_SelectionChangeCommitted);
            // 
            // referenceOnlyCheckBox
            // 
            this.referenceOnlyCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.referenceOnlyCheckBox.AutoSize = true;
            this.referenceOnlyCheckBox.Location = new System.Drawing.Point(325, 92);
            this.referenceOnlyCheckBox.Name = "referenceOnlyCheckBox";
            this.referenceOnlyCheckBox.Size = new System.Drawing.Size(119, 21);
            this.referenceOnlyCheckBox.TabIndex = 6;
            this.referenceOnlyCheckBox.Text = "Reference only?";
            this.referenceOnlyCheckBox.UseVisualStyleBackColor = true;
            this.referenceOnlyCheckBox.CheckedChanged += new System.EventHandler(this.referenceOnlyCheckBox_CheckedChanged);
            // 
            // gaugeTypeComboBox
            // 
            this.gaugeTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gaugeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gaugeTypeComboBox.FormattingEnabled = true;
            this.gaugeTypeComboBox.Location = new System.Drawing.Point(198, 44);
            this.gaugeTypeComboBox.Name = "gaugeTypeComboBox";
            this.gaugeTypeComboBox.Size = new System.Drawing.Size(246, 25);
            this.gaugeTypeComboBox.TabIndex = 3;
            this.gaugeTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxes_SelectionChangeCommitted);
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Location = new System.Drawing.Point(9, 44);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.Size = new System.Drawing.Size(183, 25);
            this.referenceTextBox.TabIndex = 2;
            this.referenceTextBox.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            // 
            // dueForCalibrationTextBox
            // 
            this.dueForCalibrationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dueForCalibrationTextBox.Location = new System.Drawing.Point(256, 140);
            this.dueForCalibrationTextBox.Name = "dueForCalibrationTextBox";
            this.dueForCalibrationTextBox.ReadOnly = true;
            this.dueForCalibrationTextBox.Size = new System.Drawing.Size(188, 25);
            this.dueForCalibrationTextBox.TabIndex = 2;
            this.dueForCalibrationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(9, 92);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(302, 25);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type of gauge";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(256, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Due for calibration on";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reference";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Held by";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.removePhotoButton);
            this.groupBox1.Controls.Add(this.setPhotoButton);
            this.groupBox1.Controls.Add(this.photoPictureBox);
            this.groupBox1.Location = new System.Drawing.Point(469, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 227);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Photo";
            // 
            // removePhotoButton
            // 
            this.removePhotoButton.Enabled = false;
            this.removePhotoButton.Location = new System.Drawing.Point(132, 156);
            this.removePhotoButton.Name = "removePhotoButton";
            this.removePhotoButton.Size = new System.Drawing.Size(99, 60);
            this.removePhotoButton.TabIndex = 1;
            this.removePhotoButton.Text = "Remove";
            this.removePhotoButton.UseVisualStyleBackColor = true;
            // 
            // setPhotoButton
            // 
            this.setPhotoButton.Location = new System.Drawing.Point(6, 156);
            this.setPhotoButton.Name = "setPhotoButton";
            this.setPhotoButton.Size = new System.Drawing.Size(120, 60);
            this.setPhotoButton.TabIndex = 1;
            this.setPhotoButton.Text = "Set";
            this.setPhotoButton.UseVisualStyleBackColor = true;
            this.setPhotoButton.Click += new System.EventHandler(this.setPhotoButton_Click);
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BackColor = System.Drawing.Color.White;
            this.photoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.photoPictureBox.Image = global::CPECentral.Properties.Resources.NoImageAvailableImage;
            this.photoPictureBox.Location = new System.Drawing.Point(6, 24);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(225, 126);
            this.photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoPictureBox.TabIndex = 0;
            this.photoPictureBox.TabStop = false;
            this.photoPictureBox.DoubleClick += new System.EventHandler(this.photoPictureBox_DoubleClick);
            // 
            // GaugeDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GaugeDetailView";
            this.Size = new System.Drawing.Size(713, 242);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox heldByComboBox;
        private System.Windows.Forms.CheckBox referenceOnlyCheckBox;
        private System.Windows.Forms.ComboBox gaugeTypeComboBox;
        private System.Windows.Forms.TextBox referenceTextBox;
        private System.Windows.Forms.TextBox dueForCalibrationTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button removePhotoButton;
        private System.Windows.Forms.Button setPhotoButton;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.Button saveChangesButton;
    }
}
