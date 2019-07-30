namespace CPECentral.Views.Quality
{
    partial class VernierCalibrationView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VernierCalibrationView));
            this.finishedButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.internalM1NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.internalM2NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.internalM3NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.internalM4NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.internalM2Label = new System.Windows.Forms.Label();
            this.internalM3Label = new System.Windows.Forms.Label();
            this.internalM4Label = new System.Windows.Forms.Label();
            this.internalM1Label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.externalM1NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.externalM2NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.externalM3NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.externalM4NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.externalM2Label = new System.Windows.Forms.Label();
            this.externalM3Label = new System.Windows.Forms.Label();
            this.externalM4Label = new System.Windows.Forms.Label();
            this.externalM1Label = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.internalM1NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalM2NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalM3NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalM4NumUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.externalM1NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.externalM2NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.externalM3NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.externalM4NumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // finishedButton
            // 
            this.finishedButton.Location = new System.Drawing.Point(6, 498);
            this.finishedButton.Name = "finishedButton";
            this.finishedButton.Size = new System.Drawing.Size(386, 41);
            this.finishedButton.TabIndex = 2;
            this.finishedButton.Text = "Finished";
            this.finishedButton.UseVisualStyleBackColor = true;
            this.finishedButton.Click += new System.EventHandler(this.finishedButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(398, 498);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(168, 41);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1, 399);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "INTERNAL JAWS RESULTS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "EXTERNAL JAWS RESULTS";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.internalM1NumUpDown, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.internalM2NumUpDown, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.internalM3NumUpDown, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.internalM4NumUpDown, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.internalM2Label, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.internalM3Label, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.internalM4Label, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.internalM1Label, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 421);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(563, 49);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // internalM1NumUpDown
            // 
            this.internalM1NumUpDown.DecimalPlaces = 3;
            this.internalM1NumUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.internalM1NumUpDown.ForeColor = System.Drawing.Color.Green;
            this.internalM1NumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.internalM1NumUpDown.Location = new System.Drawing.Point(3, 20);
            this.internalM1NumUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.internalM1NumUpDown.Name = "internalM1NumUpDown";
            this.internalM1NumUpDown.Size = new System.Drawing.Size(134, 25);
            this.internalM1NumUpDown.TabIndex = 0;
            this.internalM1NumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.internalM1NumUpDown.ValueChanged += new System.EventHandler(this.m1_ValueChanged);
            // 
            // internalM2NumUpDown
            // 
            this.internalM2NumUpDown.DecimalPlaces = 3;
            this.internalM2NumUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.internalM2NumUpDown.ForeColor = System.Drawing.Color.Green;
            this.internalM2NumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.internalM2NumUpDown.Location = new System.Drawing.Point(143, 20);
            this.internalM2NumUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.internalM2NumUpDown.Name = "internalM2NumUpDown";
            this.internalM2NumUpDown.Size = new System.Drawing.Size(134, 25);
            this.internalM2NumUpDown.TabIndex = 1;
            this.internalM2NumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.internalM2NumUpDown.ValueChanged += new System.EventHandler(this.m2_ValueChanged);
            // 
            // internalM3NumUpDown
            // 
            this.internalM3NumUpDown.DecimalPlaces = 3;
            this.internalM3NumUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.internalM3NumUpDown.ForeColor = System.Drawing.Color.Green;
            this.internalM3NumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.internalM3NumUpDown.Location = new System.Drawing.Point(283, 20);
            this.internalM3NumUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.internalM3NumUpDown.Name = "internalM3NumUpDown";
            this.internalM3NumUpDown.Size = new System.Drawing.Size(134, 25);
            this.internalM3NumUpDown.TabIndex = 2;
            this.internalM3NumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.internalM3NumUpDown.ValueChanged += new System.EventHandler(this.m3_ValueChanged);
            // 
            // internalM4NumUpDown
            // 
            this.internalM4NumUpDown.DecimalPlaces = 3;
            this.internalM4NumUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.internalM4NumUpDown.ForeColor = System.Drawing.Color.Green;
            this.internalM4NumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.internalM4NumUpDown.Location = new System.Drawing.Point(423, 20);
            this.internalM4NumUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.internalM4NumUpDown.Name = "internalM4NumUpDown";
            this.internalM4NumUpDown.Size = new System.Drawing.Size(137, 25);
            this.internalM4NumUpDown.TabIndex = 3;
            this.internalM4NumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.internalM4NumUpDown.ValueChanged += new System.EventHandler(this.m4_ValueChanged);
            // 
            // internalM2Label
            // 
            this.internalM2Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.internalM2Label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.internalM2Label.ForeColor = System.Drawing.Color.DimGray;
            this.internalM2Label.Location = new System.Drawing.Point(143, 0);
            this.internalM2Label.Name = "internalM2Label";
            this.internalM2Label.Size = new System.Drawing.Size(134, 17);
            this.internalM2Label.TabIndex = 0;
            this.internalM2Label.Text = "internalM2Label";
            this.internalM2Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // internalM3Label
            // 
            this.internalM3Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.internalM3Label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.internalM3Label.ForeColor = System.Drawing.Color.DimGray;
            this.internalM3Label.Location = new System.Drawing.Point(283, 0);
            this.internalM3Label.Name = "internalM3Label";
            this.internalM3Label.Size = new System.Drawing.Size(134, 17);
            this.internalM3Label.TabIndex = 0;
            this.internalM3Label.Text = "internalM3Label";
            this.internalM3Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // internalM4Label
            // 
            this.internalM4Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.internalM4Label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.internalM4Label.ForeColor = System.Drawing.Color.DimGray;
            this.internalM4Label.Location = new System.Drawing.Point(423, 0);
            this.internalM4Label.Name = "internalM4Label";
            this.internalM4Label.Size = new System.Drawing.Size(137, 17);
            this.internalM4Label.TabIndex = 0;
            this.internalM4Label.Text = "internalM4Label";
            this.internalM4Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // internalM1Label
            // 
            this.internalM1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.internalM1Label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.internalM1Label.ForeColor = System.Drawing.Color.DimGray;
            this.internalM1Label.Location = new System.Drawing.Point(3, 0);
            this.internalM1Label.Name = "internalM1Label";
            this.internalM1Label.Size = new System.Drawing.Size(134, 17);
            this.internalM1Label.TabIndex = 0;
            this.internalM1Label.Text = "internalM1Label";
            this.internalM1Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(563, 283);
            this.label5.TabIndex = 1;
            this.label5.Text = resources.GetString("label5.Text");
            this.label5.UseMnemonic = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.externalM1NumUpDown, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.externalM2NumUpDown, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.externalM3NumUpDown, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.externalM4NumUpDown, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.externalM2Label, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.externalM3Label, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.externalM4Label, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.externalM1Label, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 341);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(563, 49);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // externalM1NumUpDown
            // 
            this.externalM1NumUpDown.DecimalPlaces = 3;
            this.externalM1NumUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.externalM1NumUpDown.ForeColor = System.Drawing.Color.Green;
            this.externalM1NumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.externalM1NumUpDown.Location = new System.Drawing.Point(3, 20);
            this.externalM1NumUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.externalM1NumUpDown.Name = "externalM1NumUpDown";
            this.externalM1NumUpDown.Size = new System.Drawing.Size(134, 25);
            this.externalM1NumUpDown.TabIndex = 0;
            this.externalM1NumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.externalM1NumUpDown.ValueChanged += new System.EventHandler(this.m1_ValueChanged);
            // 
            // externalM2NumUpDown
            // 
            this.externalM2NumUpDown.DecimalPlaces = 3;
            this.externalM2NumUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.externalM2NumUpDown.ForeColor = System.Drawing.Color.Green;
            this.externalM2NumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.externalM2NumUpDown.Location = new System.Drawing.Point(143, 20);
            this.externalM2NumUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.externalM2NumUpDown.Name = "externalM2NumUpDown";
            this.externalM2NumUpDown.Size = new System.Drawing.Size(134, 25);
            this.externalM2NumUpDown.TabIndex = 1;
            this.externalM2NumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.externalM2NumUpDown.ValueChanged += new System.EventHandler(this.m2_ValueChanged);
            // 
            // externalM3NumUpDown
            // 
            this.externalM3NumUpDown.DecimalPlaces = 3;
            this.externalM3NumUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.externalM3NumUpDown.ForeColor = System.Drawing.Color.Green;
            this.externalM3NumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.externalM3NumUpDown.Location = new System.Drawing.Point(283, 20);
            this.externalM3NumUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.externalM3NumUpDown.Name = "externalM3NumUpDown";
            this.externalM3NumUpDown.Size = new System.Drawing.Size(134, 25);
            this.externalM3NumUpDown.TabIndex = 2;
            this.externalM3NumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.externalM3NumUpDown.ValueChanged += new System.EventHandler(this.m3_ValueChanged);
            // 
            // externalM4NumUpDown
            // 
            this.externalM4NumUpDown.DecimalPlaces = 3;
            this.externalM4NumUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.externalM4NumUpDown.ForeColor = System.Drawing.Color.Green;
            this.externalM4NumUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.externalM4NumUpDown.Location = new System.Drawing.Point(423, 20);
            this.externalM4NumUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.externalM4NumUpDown.Name = "externalM4NumUpDown";
            this.externalM4NumUpDown.Size = new System.Drawing.Size(137, 25);
            this.externalM4NumUpDown.TabIndex = 3;
            this.externalM4NumUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.externalM4NumUpDown.ValueChanged += new System.EventHandler(this.m4_ValueChanged);
            // 
            // externalM2Label
            // 
            this.externalM2Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.externalM2Label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalM2Label.ForeColor = System.Drawing.Color.DimGray;
            this.externalM2Label.Location = new System.Drawing.Point(143, 0);
            this.externalM2Label.Name = "externalM2Label";
            this.externalM2Label.Size = new System.Drawing.Size(134, 17);
            this.externalM2Label.TabIndex = 0;
            this.externalM2Label.Text = "externalM2Label";
            this.externalM2Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // externalM3Label
            // 
            this.externalM3Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.externalM3Label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalM3Label.ForeColor = System.Drawing.Color.DimGray;
            this.externalM3Label.Location = new System.Drawing.Point(283, 0);
            this.externalM3Label.Name = "externalM3Label";
            this.externalM3Label.Size = new System.Drawing.Size(134, 17);
            this.externalM3Label.TabIndex = 0;
            this.externalM3Label.Text = "externalM3Label";
            this.externalM3Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // externalM4Label
            // 
            this.externalM4Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.externalM4Label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalM4Label.ForeColor = System.Drawing.Color.DimGray;
            this.externalM4Label.Location = new System.Drawing.Point(423, 0);
            this.externalM4Label.Name = "externalM4Label";
            this.externalM4Label.Size = new System.Drawing.Size(137, 17);
            this.externalM4Label.TabIndex = 0;
            this.externalM4Label.Text = "externalM4Label";
            this.externalM4Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // externalM1Label
            // 
            this.externalM1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.externalM1Label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.externalM1Label.ForeColor = System.Drawing.Color.DimGray;
            this.externalM1Label.Location = new System.Drawing.Point(3, 0);
            this.externalM1Label.Name = "externalM1Label";
            this.externalM1Label.Size = new System.Drawing.Size(134, 17);
            this.externalM1Label.TabIndex = 0;
            this.externalM1Label.Text = "externalM1Label";
            this.externalM1Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // VernierCalibrationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.finishedButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VernierCalibrationView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(575, 547);
            this.Load += new System.EventHandler(this.VernierCalibrationView_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.internalM1NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalM2NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalM3NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalM4NumUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.externalM1NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.externalM2NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.externalM3NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.externalM4NumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label externalM1Label;
        private System.Windows.Forms.NumericUpDown externalM1NumUpDown;
        private System.Windows.Forms.NumericUpDown externalM2NumUpDown;
        private System.Windows.Forms.NumericUpDown externalM3NumUpDown;
        private System.Windows.Forms.NumericUpDown externalM4NumUpDown;
        private System.Windows.Forms.Label externalM2Label;
        private System.Windows.Forms.Label externalM3Label;
        private System.Windows.Forms.Label externalM4Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown internalM1NumUpDown;
        private System.Windows.Forms.NumericUpDown internalM2NumUpDown;
        private System.Windows.Forms.NumericUpDown internalM3NumUpDown;
        private System.Windows.Forms.NumericUpDown internalM4NumUpDown;
        private System.Windows.Forms.Label internalM2Label;
        private System.Windows.Forms.Label internalM3Label;
        private System.Windows.Forms.Label internalM4Label;
        private System.Windows.Forms.Label internalM1Label;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button finishedButton;
    }
}
