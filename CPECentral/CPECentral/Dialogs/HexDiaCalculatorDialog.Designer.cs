namespace CPECentral.Dialogs
{
    partial class HexDiaCalculatorDialog
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
            this.hexagonPanel1 = new CPECentral.Dialogs.HexagonPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.acrossFlatsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.minimumDiameterLabel = new System.Windows.Forms.Label();
            this.okayButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.acrossFlatsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // hexagonPanel1
            // 
            this.hexagonPanel1.Location = new System.Drawing.Point(-27, -13);
            this.hexagonPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.hexagonPanel1.Name = "hexagonPanel1";
            this.hexagonPanel1.Size = new System.Drawing.Size(251, 213);
            this.hexagonPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Across flats";
            // 
            // acrossFlatsNumericUpDown
            // 
            this.acrossFlatsNumericUpDown.DecimalPlaces = 2;
            this.acrossFlatsNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.acrossFlatsNumericUpDown.Location = new System.Drawing.Point(223, 40);
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
            this.acrossFlatsNumericUpDown.Size = new System.Drawing.Size(86, 25);
            this.acrossFlatsNumericUpDown.TabIndex = 2;
            this.acrossFlatsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.acrossFlatsNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.acrossFlatsNumericUpDown.ValueChanged += new System.EventHandler(this.acrossFlatsNumericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minimum diameter";
            // 
            // minimumDiameterLabel
            // 
            this.minimumDiameterLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.minimumDiameterLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimumDiameterLabel.Location = new System.Drawing.Point(207, 94);
            this.minimumDiameterLabel.Name = "minimumDiameterLabel";
            this.minimumDiameterLabel.Size = new System.Drawing.Size(115, 103);
            this.minimumDiameterLabel.TabIndex = 3;
            this.minimumDiameterLabel.Text = "Ø9.238";
            this.minimumDiameterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(12, 212);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(310, 48);
            this.okayButton.TabIndex = 4;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // HexDiaCalculatorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 270);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.minimumDiameterLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.acrossFlatsNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hexagonPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HexDiaCalculatorDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hexagon to diameter";
            this.Load += new System.EventHandler(this.HexDiaCalculatorDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.acrossFlatsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HexagonPanel hexagonPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown acrossFlatsNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label minimumDiameterLabel;
        private System.Windows.Forms.Button okayButton;

    }
}