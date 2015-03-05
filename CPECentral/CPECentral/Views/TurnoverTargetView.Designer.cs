namespace CPECentral.Views
{
    partial class TurnoverTargetView
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
            this.label4 = new System.Windows.Forms.Label();
            this.lastMonthEasyProgressBar = new EasyProgressBar.EasyProgressBar();
            this.currentMonthEasyProgressBar = new EasyProgressBar.EasyProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
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
            this.pictureBox1.Image = global::CPECentral.Properties.Resources.TargetImage_128x128;
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
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(41, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "How productive are we?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "refreshing data....";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastMonthEasyProgressBar
            // 
            this.lastMonthEasyProgressBar.AlphaMaker = null;
            this.lastMonthEasyProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastMonthEasyProgressBar.DigitBoxGradient.ColorEnd = System.Drawing.Color.WhiteSmoke;
            this.lastMonthEasyProgressBar.DisplayFormat = "of target produced";
            this.lastMonthEasyProgressBar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastMonthEasyProgressBar.ForeColor = System.Drawing.Color.DimGray;
            this.lastMonthEasyProgressBar.Location = new System.Drawing.Point(6, 128);
            this.lastMonthEasyProgressBar.Name = "lastMonthEasyProgressBar";
            this.lastMonthEasyProgressBar.ProgressGradient.ColorEnd = System.Drawing.Color.Gold;
            this.lastMonthEasyProgressBar.ProgressGradient.ColorStart = System.Drawing.Color.PaleGoldenrod;
            this.lastMonthEasyProgressBar.Size = new System.Drawing.Size(262, 30);
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
            this.currentMonthEasyProgressBar.ForeColor = System.Drawing.Color.DimGray;
            this.currentMonthEasyProgressBar.Location = new System.Drawing.Point(6, 72);
            this.currentMonthEasyProgressBar.Name = "currentMonthEasyProgressBar";
            this.currentMonthEasyProgressBar.ProgressGradient.ColorEnd = System.Drawing.Color.LightGreen;
            this.currentMonthEasyProgressBar.ProgressGradient.ColorStart = System.Drawing.Color.ForestGreen;
            this.currentMonthEasyProgressBar.Size = new System.Drawing.Size(262, 30);
            this.currentMonthEasyProgressBar.TabIndex = 3;
            this.currentMonthEasyProgressBar.Text = "0% of target produced";
            this.currentMonthEasyProgressBar.Value = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current month";
            // 
            // TurnoverTargetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lastMonthEasyProgressBar);
            this.Controls.Add(this.currentMonthEasyProgressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(800, 185);
            this.MinimumSize = new System.Drawing.Size(275, 185);
            this.Name = "TurnoverTargetView";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
