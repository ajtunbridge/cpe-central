namespace CPECentral.Dialogs
{
    partial class ReceiveMillingProgramDialog
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
            this.machinesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.switchBoxLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.beginButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.receivedTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // machinesListBox
            // 
            this.machinesListBox.DisplayMember = "Name";
            this.machinesListBox.FormattingEnabled = true;
            this.machinesListBox.ItemHeight = 17;
            this.machinesListBox.Location = new System.Drawing.Point(12, 29);
            this.machinesListBox.Name = "machinesListBox";
            this.machinesListBox.Size = new System.Drawing.Size(202, 276);
            this.machinesListBox.TabIndex = 0;
            this.machinesListBox.ValueMember = "Name";
            this.machinesListBox.SelectedIndexChanged += new System.EventHandler(this.machinesListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a machine";
            // 
            // switchBoxLabel
            // 
            this.switchBoxLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchBoxLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.switchBoxLabel.Location = new System.Drawing.Point(12, 308);
            this.switchBoxLabel.Name = "switchBoxLabel";
            this.switchBoxLabel.Size = new System.Drawing.Size(202, 39);
            this.switchBoxLabel.TabIndex = 2;
            this.switchBoxLabel.Text = "CHANGE SB1 TO B";
            this.switchBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Received data";
            // 
            // beginButton
            // 
            this.beginButton.Location = new System.Drawing.Point(223, 311);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(207, 36);
            this.beginButton.TabIndex = 3;
            this.beginButton.Text = "Begin";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(433, 311);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(171, 36);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // receivedTextBox
            // 
            this.receivedTextBox.BackColor = System.Drawing.Color.White;
            this.receivedTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receivedTextBox.Location = new System.Drawing.Point(223, 29);
            this.receivedTextBox.Multiline = true;
            this.receivedTextBox.Name = "receivedTextBox";
            this.receivedTextBox.ReadOnly = true;
            this.receivedTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receivedTextBox.Size = new System.Drawing.Size(381, 276);
            this.receivedTextBox.TabIndex = 4;
            // 
            // ReceiveMillingProgramDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 357);
            this.Controls.Add(this.receivedTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.beginButton);
            this.Controls.Add(this.switchBoxLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.machinesListBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiveMillingProgramDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Receive milling program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiveMillingProgramDialog_FormClosing);
            this.Load += new System.EventHandler(this.ReceiveMillingProgramDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox machinesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label switchBoxLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox receivedTextBox;
    }
}