namespace CPECentral.Views
{
    partial class LoginView
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
            this.centralPanel = new System.Windows.Forms.Panel();
            this.passwordTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.userNameTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.preloaderPictureBox = new System.Windows.Forms.PictureBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.verifyingLabel = new System.Windows.Forms.Label();
            this.centralPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preloaderPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // centralPanel
            // 
            this.centralPanel.Controls.Add(this.verifyingLabel);
            this.centralPanel.Controls.Add(this.passwordTextBox);
            this.centralPanel.Controls.Add(this.userNameTextBox);
            this.centralPanel.Controls.Add(this.preloaderPictureBox);
            this.centralPanel.Controls.Add(this.loginButton);
            this.centralPanel.Controls.Add(this.label2);
            this.centralPanel.Controls.Add(this.label1);
            this.centralPanel.Controls.Add(this.pictureBox1);
            this.centralPanel.Location = new System.Drawing.Point(195, 26);
            this.centralPanel.Name = "centralPanel";
            this.centralPanel.Size = new System.Drawing.Size(336, 375);
            this.centralPanel.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.AcceptsReturn = true;
            this.passwordTextBox.DisableDoubleSpace = true;
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(58, 210);
            this.passwordTextBox.MaxLength = 30;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(220, 29);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.AcceptsReturn = true;
            this.userNameTextBox.DisableDoubleSpace = true;
            this.userNameTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameTextBox.Location = new System.Drawing.Point(58, 143);
            this.userNameTextBox.MaxLength = 30;
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(220, 29);
            this.userNameTextBox.TabIndex = 0;
            this.userNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.userNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxes_KeyDown);
            // 
            // preloaderPictureBox
            // 
            this.preloaderPictureBox.Image = global::CPECentral.Properties.Resources.PreloaderImage;
            this.preloaderPictureBox.Location = new System.Drawing.Point(58, 322);
            this.preloaderPictureBox.Name = "preloaderPictureBox";
            this.preloaderPictureBox.Size = new System.Drawing.Size(220, 20);
            this.preloaderPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.preloaderPictureBox.TabIndex = 3;
            this.preloaderPictureBox.TabStop = false;
            this.preloaderPictureBox.Visible = false;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(58, 254);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(220, 50);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "User name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CPECentral.Properties.Resources.CompanyLogo;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // verifyingLabel
            // 
            this.verifyingLabel.Location = new System.Drawing.Point(55, 345);
            this.verifyingLabel.Name = "verifyingLabel";
            this.verifyingLabel.Size = new System.Drawing.Size(223, 20);
            this.verifyingLabel.TabIndex = 4;
            this.verifyingLabel.Text = "verifying credentials...";
            this.verifyingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.verifyingLabel.Visible = false;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.centralPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(726, 436);
            this.Load += new System.EventHandler(this.LoginView_Load);
            this.Resize += new System.EventHandler(this.LoginView_Resize);
            this.centralPanel.ResumeLayout(false);
            this.centralPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preloaderPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel centralPanel;
        private System.Windows.Forms.PictureBox preloaderPictureBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private nGenLibrary.Controls.EnhancedTextBox passwordTextBox;
        private nGenLibrary.Controls.EnhancedTextBox userNameTextBox;
        private System.Windows.Forms.Label verifyingLabel;

    }
}
