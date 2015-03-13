namespace CPECentral.Views
{
    partial class StartPageCalculatorTriangleView
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
            this.trianglePanel = new CPECentral.Controls.TrianglePanel();
            this.oppTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.adjTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hypTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.angleATextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.angleBTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.goResetButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // trianglePanel
            // 
            this.trianglePanel.Adjacent = 0D;
            this.trianglePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trianglePanel.AngleA = 0D;
            this.trianglePanel.AngleB = 0D;
            this.trianglePanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trianglePanel.ForeColor = System.Drawing.Color.DimGray;
            this.trianglePanel.Hypotenuse = 0D;
            this.trianglePanel.LineColor = System.Drawing.Color.Firebrick;
            this.trianglePanel.LineWidth = 4;
            this.trianglePanel.Location = new System.Drawing.Point(3, 42);
            this.trianglePanel.Name = "trianglePanel";
            this.trianglePanel.Opposite = 0D;
            this.trianglePanel.Padding = new System.Windows.Forms.Padding(3);
            this.trianglePanel.Size = new System.Drawing.Size(244, 148);
            this.trianglePanel.SuspendDrawing = false;
            this.trianglePanel.TabIndex = 0;
            this.trianglePanel.Text = "trianglePanel1";
            // 
            // oppTextBox
            // 
            this.oppTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oppTextBox.Location = new System.Drawing.Point(3, 23);
            this.oppTextBox.Name = "oppTextBox";
            this.oppTextBox.Size = new System.Drawing.Size(75, 25);
            this.oppTextBox.TabIndex = 0;
            this.oppTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.oppTextBox.TextChanged += new System.EventHandler(this.oppTextBox_TextChanged);
            this.oppTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.oppTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Opp";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // adjTextBox
            // 
            this.adjTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adjTextBox.Location = new System.Drawing.Point(84, 23);
            this.adjTextBox.Name = "adjTextBox";
            this.adjTextBox.Size = new System.Drawing.Size(75, 25);
            this.adjTextBox.TabIndex = 1;
            this.adjTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.adjTextBox.TextChanged += new System.EventHandler(this.adjTextBox_TextChanged);
            this.adjTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.oppTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(84, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adj";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // hypTextBox
            // 
            this.hypTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hypTextBox.Location = new System.Drawing.Point(165, 23);
            this.hypTextBox.Name = "hypTextBox";
            this.hypTextBox.Size = new System.Drawing.Size(76, 25);
            this.hypTextBox.TabIndex = 2;
            this.hypTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hypTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.oppTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(165, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hyp";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // angleATextBox
            // 
            this.angleATextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.angleATextBox.Location = new System.Drawing.Point(3, 76);
            this.angleATextBox.Name = "angleATextBox";
            this.angleATextBox.Size = new System.Drawing.Size(75, 25);
            this.angleATextBox.TabIndex = 3;
            this.angleATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.angleATextBox.TextChanged += new System.EventHandler(this.angleATextBox_TextChanged);
            this.angleATextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.oppTextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Angle A";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // angleBTextBox
            // 
            this.angleBTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.angleBTextBox.Location = new System.Drawing.Point(84, 76);
            this.angleBTextBox.Name = "angleBTextBox";
            this.angleBTextBox.Size = new System.Drawing.Size(75, 25);
            this.angleBTextBox.TabIndex = 4;
            this.angleBTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.angleBTextBox.TextChanged += new System.EventHandler(this.angleBTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(84, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Angle B";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 39);
            this.panel1.TabIndex = 10;
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
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(41, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 31);
            this.label6.TabIndex = 2;
            this.label6.Text = "Triangle solver";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.oppTextBox, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.angleBTextBox, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.angleATextBox, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.hypTextBox, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.adjTextBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.goResetButton, 2, 2);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 190);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(244, 107);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // goResetButton
            // 
            this.goResetButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.goResetButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goResetButton.Location = new System.Drawing.Point(165, 56);
            this.goResetButton.Name = "goResetButton";
            this.tableLayoutPanel.SetRowSpan(this.goResetButton, 2);
            this.goResetButton.Size = new System.Drawing.Size(76, 48);
            this.goResetButton.TabIndex = 5;
            this.goResetButton.Text = "Go";
            this.goResetButton.UseVisualStyleBackColor = true;
            this.goResetButton.Click += new System.EventHandler(this.goResetButton_Click);
            // 
            // StartPageCalculatorTriangleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.trianglePanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(200, 255);
            this.Name = "StartPageCalculatorTriangleView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(253, 305);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TrianglePanel trianglePanel;
        private System.Windows.Forms.TextBox oppTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox adjTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hypTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox angleATextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox angleBTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button goResetButton;
    }
}
