namespace CPECentral.Views
{
    partial class StartPageTargetView
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
            this.lastMonthEasyProgressBar = new EasyProgressBar.EasyProgressBar();
            this.currentMonthEasyProgressBar = new EasyProgressBar.EasyProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fiscalYearEasyProgressBar = new EasyProgressBar.EasyProgressBar();
            this.updateNowLinkLabel = new System.Windows.Forms.LinkLabel();
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
            this.pictureBox1.Image = global::CPECentral.Properties.Resources.TurnoverTargetViewIcon_32x32;
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
            this.label1.Text = "Progress to target turnover";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lastMonthEasyProgressBar
            // 
            this.lastMonthEasyProgressBar.AlphaMaker = null;
            this.lastMonthEasyProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastMonthEasyProgressBar.DigitBoxGradient.ColorEnd = System.Drawing.Color.WhiteSmoke;
            this.lastMonthEasyProgressBar.DisplayFormat = "of target produced";
            this.lastMonthEasyProgressBar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastMonthEasyProgressBar.ForeColor = System.Drawing.Color.Black;
            this.lastMonthEasyProgressBar.Location = new System.Drawing.Point(6, 107);
            this.lastMonthEasyProgressBar.Name = "lastMonthEasyProgressBar";
            this.lastMonthEasyProgressBar.ProgressGradient.ColorEnd = System.Drawing.Color.Gold;
            this.lastMonthEasyProgressBar.ProgressGradient.ColorStart = System.Drawing.Color.PaleGoldenrod;
            this.lastMonthEasyProgressBar.Size = new System.Drawing.Size(266, 23);
            this.lastMonthEasyProgressBar.TabIndex = 3;
            this.lastMonthEasyProgressBar.Text = "0% of target produced";
            this.lastMonthEasyProgressBar.Value = 0;
            // 
            // currentMonthEasyProgressBar
            // 
            this.currentMonthEasyProgressBar.AlphaMaker = null;
            this.currentMonthEasyProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentMonthEasyProgressBar.DigitBoxGradient.ColorEnd = System.Drawing.Color.WhiteSmoke;
            this.currentMonthEasyProgressBar.DisplayFormat = "of target produced";
            this.currentMonthEasyProgressBar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMonthEasyProgressBar.ForeColor = System.Drawing.Color.Black;
            this.currentMonthEasyProgressBar.Location = new System.Drawing.Point(6, 62);
            this.currentMonthEasyProgressBar.Name = "currentMonthEasyProgressBar";
            this.currentMonthEasyProgressBar.ProgressGradient.ColorEnd = System.Drawing.Color.LightGreen;
            this.currentMonthEasyProgressBar.ProgressGradient.ColorStart = System.Drawing.Color.ForestGreen;
            this.currentMonthEasyProgressBar.Size = new System.Drawing.Size(266, 23);
            this.currentMonthEasyProgressBar.TabIndex = 3;
            this.currentMonthEasyProgressBar.Text = "0% of target produced";
            this.currentMonthEasyProgressBar.Value = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Current fiscal year";
            // 
            // fiscalYearEasyProgressBar
            // 
            this.fiscalYearEasyProgressBar.AlphaMaker = null;
            this.fiscalYearEasyProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fiscalYearEasyProgressBar.DigitBoxGradient.ColorEnd = System.Drawing.Color.WhiteSmoke;
            this.fiscalYearEasyProgressBar.DisplayFormat = "of target produced";
            this.fiscalYearEasyProgressBar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiscalYearEasyProgressBar.ForeColor = System.Drawing.Color.Black;
            this.fiscalYearEasyProgressBar.Location = new System.Drawing.Point(6, 153);
            this.fiscalYearEasyProgressBar.Name = "fiscalYearEasyProgressBar";
            this.fiscalYearEasyProgressBar.ProgressGradient.ColorEnd = System.Drawing.Color.Gold;
            this.fiscalYearEasyProgressBar.ProgressGradient.ColorStart = System.Drawing.Color.PaleGoldenrod;
            this.fiscalYearEasyProgressBar.Size = new System.Drawing.Size(266, 23);
            this.fiscalYearEasyProgressBar.TabIndex = 3;
            this.fiscalYearEasyProgressBar.Text = "0% of target produced";
            this.fiscalYearEasyProgressBar.Value = 0;
            // 
            // updateNowLinkLabel
            // 
            this.updateNowLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateNowLinkLabel.AutoSize = true;
            this.updateNowLinkLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateNowLinkLabel.Location = new System.Drawing.Point(202, 44);
            this.updateNowLinkLabel.Name = "updateNowLinkLabel";
            this.updateNowLinkLabel.Size = new System.Drawing.Size(70, 13);
            this.updateNowLinkLabel.TabIndex = 9;
            this.updateNowLinkLabel.TabStop = true;
            this.updateNowLinkLabel.Text = "update now";
            this.updateNowLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateNowLinkLabel_LinkClicked);
            // 
            // StartPageTargetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.updateNowLinkLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fiscalYearEasyProgressBar);
            this.Controls.Add(this.lastMonthEasyProgressBar);
            this.Controls.Add(this.currentMonthEasyProgressBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 185);
            this.MinimumSize = new System.Drawing.Size(275, 185);
            this.Name = "StartPageTargetView";
            this.Size = new System.Drawing.Size(275, 185);
            this.Load += new System.EventHandler(this.TurnoverTargetView_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private EasyProgressBar.EasyProgressBar currentMonthEasyProgressBar;
        private EasyProgressBar.EasyProgressBar lastMonthEasyProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private EasyProgressBar.EasyProgressBar fiscalYearEasyProgressBar;
        private System.Windows.Forms.LinkLabel updateNowLinkLabel;
    }
}
