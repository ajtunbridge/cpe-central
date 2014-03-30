namespace CPECentral.Dialogs
{
    partial class EditOperationToolDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.toolTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.holderTextBox = new System.Windows.Forms.TextBox();
            this.selectToolButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.positionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.offsetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.useOnePerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.okayCancelFooter = new CPECentral.Controls.OkayCancelFooter();
            ((System.ComponentModel.ISupportInitialize)(this.positionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.useOnePerNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tool";
            // 
            // toolTextBox
            // 
            this.toolTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolTextBox.Location = new System.Drawing.Point(108, 28);
            this.toolTextBox.Name = "toolTextBox";
            this.toolTextBox.ReadOnly = true;
            this.toolTextBox.Size = new System.Drawing.Size(350, 25);
            this.toolTextBox.TabIndex = 1;
            this.toolTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Holder";
            // 
            // holderTextBox
            // 
            this.holderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.holderTextBox.Location = new System.Drawing.Point(108, 76);
            this.holderTextBox.Name = "holderTextBox";
            this.holderTextBox.ReadOnly = true;
            this.holderTextBox.Size = new System.Drawing.Size(350, 25);
            this.holderTextBox.TabIndex = 1;
            this.holderTextBox.TabStop = false;
            // 
            // selectToolButton
            // 
            this.selectToolButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectToolButton.Location = new System.Drawing.Point(108, 112);
            this.selectToolButton.Name = "selectToolButton";
            this.selectToolButton.Size = new System.Drawing.Size(350, 38);
            this.selectToolButton.TabIndex = 3;
            this.selectToolButton.Text = "Select tool";
            this.selectToolButton.UseVisualStyleBackColor = true;
            this.selectToolButton.Click += new System.EventHandler(this.SelectToolButton_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Position";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // positionNumericUpDown
            // 
            this.positionNumericUpDown.Location = new System.Drawing.Point(15, 29);
            this.positionNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.positionNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.positionNumericUpDown.Name = "positionNumericUpDown";
            this.positionNumericUpDown.Size = new System.Drawing.Size(77, 25);
            this.positionNumericUpDown.TabIndex = 0;
            this.positionNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.positionNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.positionNumericUpDown.ValueChanged += new System.EventHandler(this.PositionNumericUpDown_ValueChanged);
            // 
            // offsetNumericUpDown
            // 
            this.offsetNumericUpDown.Location = new System.Drawing.Point(15, 77);
            this.offsetNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.offsetNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.offsetNumericUpDown.Name = "offsetNumericUpDown";
            this.offsetNumericUpDown.Size = new System.Drawing.Size(77, 25);
            this.offsetNumericUpDown.TabIndex = 1;
            this.offsetNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.offsetNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.offsetNumericUpDown.ValueChanged += new System.EventHandler(this.OffsetNumericUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Offset";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Use one per";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // useOnePerNumericUpDown
            // 
            this.useOnePerNumericUpDown.Location = new System.Drawing.Point(15, 125);
            this.useOnePerNumericUpDown.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.useOnePerNumericUpDown.Name = "useOnePerNumericUpDown";
            this.useOnePerNumericUpDown.Size = new System.Drawing.Size(77, 25);
            this.useOnePerNumericUpDown.TabIndex = 2;
            this.useOnePerNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.useOnePerNumericUpDown.ValueChanged += new System.EventHandler(this.UseOnePerNumericUpDown_ValueChanged);
            // 
            // okayCancelFooter
            // 
            this.okayCancelFooter.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter.Location = new System.Drawing.Point(0, 167);
            this.okayCancelFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter.Name = "okayCancelFooter";
            this.okayCancelFooter.Size = new System.Drawing.Size(475, 45);
            this.okayCancelFooter.TabIndex = 4;
            this.okayCancelFooter.OkayClicked += new System.EventHandler(this.okayCancelFooter_OkayClicked);
            this.okayCancelFooter.CancelClicked += new System.EventHandler(this.okayCancelFooter_CancelClicked);
            // 
            // EditOperationToolDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 212);
            this.Controls.Add(this.okayCancelFooter);
            this.Controls.Add(this.useOnePerNumericUpDown);
            this.Controls.Add(this.offsetNumericUpDown);
            this.Controls.Add(this.positionNumericUpDown);
            this.Controls.Add(this.selectToolButton);
            this.Controls.Add(this.holderTextBox);
            this.Controls.Add(this.toolTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditOperationToolDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operation tool editor";
            this.Load += new System.EventHandler(this.EditOperationToolDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.positionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.useOnePerNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox toolTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox holderTextBox;
        private System.Windows.Forms.Button selectToolButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown positionNumericUpDown;
        private System.Windows.Forms.NumericUpDown offsetNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown useOnePerNumericUpDown;
        private Controls.OkayCancelFooter okayCancelFooter;
    }
}