namespace CPECentral.Views
{
    sealed partial class LoginView2
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
            this.appLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.preloaderPictureBox = new System.Windows.Forms.PictureBox();
            this.timeMessageLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.loginToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loginIndicatorPictureBox = new System.Windows.Forms.PictureBox();
            this.centralPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appLogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preloaderPictureBox)).BeginInit();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginIndicatorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // centralPanel
            // 
            this.centralPanel.Controls.Add(this.appLogoPictureBox);
            this.centralPanel.Controls.Add(this.preloaderPictureBox);
            this.centralPanel.Controls.Add(this.timeMessageLabel);
            this.centralPanel.Controls.Add(this.statusLabel);
            this.centralPanel.Location = new System.Drawing.Point(332, 268);
            this.centralPanel.Name = "centralPanel";
            this.centralPanel.Size = new System.Drawing.Size(296, 139);
            this.centralPanel.TabIndex = 4;
            // 
            // appLogoPictureBox
            // 
            this.appLogoPictureBox.Image = global::CPECentral.Properties.Resources.LoginHeader;
            this.appLogoPictureBox.Location = new System.Drawing.Point(74, 27);
            this.appLogoPictureBox.Name = "appLogoPictureBox";
            this.appLogoPictureBox.Size = new System.Drawing.Size(140, 75);
            this.appLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.appLogoPictureBox.TabIndex = 0;
            this.appLogoPictureBox.TabStop = false;
            this.appLogoPictureBox.Visible = false;
            // 
            // preloaderPictureBox
            // 
            this.preloaderPictureBox.Image = global::CPECentral.Properties.Resources.PreloaderImage2;
            this.preloaderPictureBox.Location = new System.Drawing.Point(3, 33);
            this.preloaderPictureBox.Name = "preloaderPictureBox";
            this.preloaderPictureBox.Size = new System.Drawing.Size(290, 23);
            this.preloaderPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.preloaderPictureBox.TabIndex = 3;
            this.preloaderPictureBox.TabStop = false;
            // 
            // timeMessageLabel
            // 
            this.timeMessageLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeMessageLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.timeMessageLabel.Location = new System.Drawing.Point(3, 92);
            this.timeMessageLabel.Margin = new System.Windows.Forms.Padding(3);
            this.timeMessageLabel.Name = "timeMessageLabel";
            this.timeMessageLabel.Size = new System.Drawing.Size(290, 44);
            this.timeMessageLabel.TabIndex = 4;
            this.timeMessageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(3, 3);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(3);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(290, 25);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "connecting to server...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripDropDownButton,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1292, 50);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // loginToolStripDropDownButton
            // 
            this.loginToolStripDropDownButton.Enabled = false;
            this.loginToolStripDropDownButton.Image = global::CPECentral.Properties.Resources.LoginIcon_32x32;
            this.loginToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loginToolStripDropDownButton.Name = "loginToolStripDropDownButton";
            this.loginToolStripDropDownButton.Size = new System.Drawing.Size(94, 47);
            this.loginToolStripDropDownButton.Text = "    Login";
            this.loginToolStripDropDownButton.ToolTipText = "Select your name from the drop down list to login";
            this.loginToolStripDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.loginToolStripDropDownButton_DropDownItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // loginIndicatorPictureBox
            // 
            this.loginIndicatorPictureBox.Image = global::CPECentral.Properties.Resources.LoginIndicatorArrow_1024x512;
            this.loginIndicatorPictureBox.Location = new System.Drawing.Point(12, 17);
            this.loginIndicatorPictureBox.Name = "loginIndicatorPictureBox";
            this.loginIndicatorPictureBox.Size = new System.Drawing.Size(404, 248);
            this.loginIndicatorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loginIndicatorPictureBox.TabIndex = 6;
            this.loginIndicatorPictureBox.TabStop = false;
            this.loginIndicatorPictureBox.Visible = false;
            // 
            // LoginView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.centralPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.loginIndicatorPictureBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginView2";
            this.Size = new System.Drawing.Size(1292, 861);
            this.Load += new System.EventHandler(this.LoginView2_Load);
            this.Resize += new System.EventHandler(this.LoginView2_Resize);
            this.centralPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appLogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preloaderPictureBox)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginIndicatorPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton loginToolStripDropDownButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel centralPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label timeMessageLabel;
        private System.Windows.Forms.PictureBox loginIndicatorPictureBox;
        private System.Windows.Forms.PictureBox appLogoPictureBox;
        private System.Windows.Forms.PictureBox preloaderPictureBox;
    }
}
