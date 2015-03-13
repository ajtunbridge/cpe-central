namespace CPECentral.Views
{
    partial class StartPageFindToolBoxView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.locationTextBox = new System.Windows.Forms.Label();
            this.drawingNumberEnhancedTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.drawingNumberMatchesComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 39);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CPECentral.Properties.Resources.StartPageFindToolBoxViewIcon_32x32;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(41, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Where\'s that fixture?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Enter the drawing number of the part";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(6, 104);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(262, 32);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // locationTextBox
            // 
            this.locationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationTextBox.BackColor = System.Drawing.Color.White;
            this.locationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.locationTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationTextBox.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.locationTextBox.Location = new System.Drawing.Point(6, 143);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(262, 35);
            this.locationTextBox.TabIndex = 12;
            this.locationTextBox.Text = "...";
            this.locationTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drawingNumberEnhancedTextBox
            // 
            this.drawingNumberEnhancedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingNumberEnhancedTextBox.DisableDoubleSpace = false;
            this.drawingNumberEnhancedTextBox.DisableLeadingSpace = false;
            this.drawingNumberEnhancedTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingNumberEnhancedTextBox.ForeColor = System.Drawing.Color.Gray;
            this.drawingNumberEnhancedTextBox.Location = new System.Drawing.Point(6, 65);
            this.drawingNumberEnhancedTextBox.MaxLength = 50;
            this.drawingNumberEnhancedTextBox.Name = "drawingNumberEnhancedTextBox";
            this.drawingNumberEnhancedTextBox.NumericCharactersOnly = false;
            this.drawingNumberEnhancedTextBox.Size = new System.Drawing.Size(262, 33);
            this.drawingNumberEnhancedTextBox.SuppressEnterKey = true;
            this.drawingNumberEnhancedTextBox.TabIndex = 0;
            this.drawingNumberEnhancedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.drawingNumberEnhancedTextBox.EnterKeyPressed += new System.EventHandler(this.drawingNumberEnhancedTextBox_EnterKeyPressed);
            // 
            // drawingNumberMatchesComboBox
            // 
            this.drawingNumberMatchesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingNumberMatchesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drawingNumberMatchesComboBox.FormattingEnabled = true;
            this.drawingNumberMatchesComboBox.Location = new System.Drawing.Point(6, 184);
            this.drawingNumberMatchesComboBox.Name = "drawingNumberMatchesComboBox";
            this.drawingNumberMatchesComboBox.Size = new System.Drawing.Size(262, 25);
            this.drawingNumberMatchesComboBox.TabIndex = 13;
            this.drawingNumberMatchesComboBox.SelectedIndexChanged += new System.EventHandler(this.drawingNumberMatchesComboBox_SelectedIndexChanged);
            // 
            // StartPageFindToolBoxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.drawingNumberMatchesComboBox);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.drawingNumberEnhancedTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 215);
            this.MinimumSize = new System.Drawing.Size(275, 215);
            this.Name = "StartPageFindToolBoxView";
            this.Size = new System.Drawing.Size(275, 213);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private nGenLibrary.Controls.EnhancedTextBox drawingNumberEnhancedTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label locationTextBox;
        private System.Windows.Forms.ComboBox drawingNumberMatchesComboBox;
    }
}
