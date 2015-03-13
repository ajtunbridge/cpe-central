using CPECentral.Controls;

namespace CPECentral.Views
{
    partial class StartPageCalculatorHexagonView
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
            this.acrossFlatsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.hexagonDiameterPanel1 = new CPECentral.Controls.HexagonDiameterPanel();
            this.hexagonPanel1 = new CPECentral.Controls.HexagonPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acrossFlatsNumericUpDown)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(340, 39);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CPECentral.Properties.Resources.CalculatorIcon_32x32;
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
            this.label1.Size = new System.Drawing.Size(296, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hexagon solver";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // acrossFlatsNumericUpDown
            // 
            this.acrossFlatsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.acrossFlatsNumericUpDown.DecimalPlaces = 2;
            this.acrossFlatsNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acrossFlatsNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.acrossFlatsNumericUpDown.Location = new System.Drawing.Point(92, 229);
            this.acrossFlatsNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.acrossFlatsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.acrossFlatsNumericUpDown.Name = "acrossFlatsNumericUpDown";
            this.acrossFlatsNumericUpDown.Size = new System.Drawing.Size(86, 33);
            this.acrossFlatsNumericUpDown.TabIndex = 12;
            this.acrossFlatsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.acrossFlatsNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.acrossFlatsNumericUpDown.ValueChanged += new System.EventHandler(this.acrossFlatsNumericUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Across flats";
            // 
            // hexagonDiameterPanel1
            // 
            this.hexagonDiameterPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hexagonDiameterPanel1.Diameter = "Ø9.24";
            this.hexagonDiameterPanel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexagonDiameterPanel1.Location = new System.Drawing.Point(169, 48);
            this.hexagonDiameterPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hexagonDiameterPanel1.Name = "hexagonDiameterPanel1";
            this.hexagonDiameterPanel1.Size = new System.Drawing.Size(168, 158);
            this.hexagonDiameterPanel1.TabIndex = 14;
            // 
            // hexagonPanel1
            // 
            this.hexagonPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.hexagonPanel1.Location = new System.Drawing.Point(14, 45);
            this.hexagonPanel1.Name = "hexagonPanel1";
            this.hexagonPanel1.Size = new System.Drawing.Size(154, 161);
            this.hexagonPanel1.TabIndex = 10;
            // 
            // StartPageCalculatorHexagonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.hexagonDiameterPanel1);
            this.Controls.Add(this.acrossFlatsNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hexagonPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(340, 270);
            this.MinimumSize = new System.Drawing.Size(340, 185);
            this.Name = "StartPageCalculatorHexagonView";
            this.Size = new System.Drawing.Size(340, 270);
            this.SizeChanged += new System.EventHandler(this.HexagonDiameterCalculatorView_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acrossFlatsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private HexagonPanel hexagonPanel1;
        private System.Windows.Forms.NumericUpDown acrossFlatsNumericUpDown;
        private System.Windows.Forms.Label label3;
        private HexagonDiameterPanel hexagonDiameterPanel1;
    }
}
