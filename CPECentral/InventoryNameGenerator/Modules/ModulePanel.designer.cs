namespace InventoryNameGenerator.Modules
{
    partial class ModulePanel
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
            this.generatedNameTextBox = new System.Windows.Forms.TextBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // generatedNameTextBox
            // 
            this.generatedNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.generatedNameTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generatedNameTextBox.Location = new System.Drawing.Point(0, 292);
            this.generatedNameTextBox.MaxLength = 150;
            this.generatedNameTextBox.Name = "generatedNameTextBox";
            this.generatedNameTextBox.ReadOnly = true;
            this.generatedNameTextBox.Size = new System.Drawing.Size(398, 22);
            this.generatedNameTextBox.TabIndex = 2;
            this.generatedNameTextBox.TabStop = false;
            this.generatedNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(404, 277);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(64, 40);
            this.copyButton.TabIndex = 1;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButtonClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Generated name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox
            // 
            this.groupBox.Location = new System.Drawing.Point(0, 6);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(468, 265);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "MODULE NAME";
            // 
            // ModulePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.generatedNameTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(476, 326);
            this.MinimumSize = new System.Drawing.Size(476, 326);
            this.Name = "ModulePanel";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 5, 0);
            this.Size = new System.Drawing.Size(476, 326);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.GroupBox groupBox;
        protected System.Windows.Forms.TextBox generatedNameTextBox;
    }
}
