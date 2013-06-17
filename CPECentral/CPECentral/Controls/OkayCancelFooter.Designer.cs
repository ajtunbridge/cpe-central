namespace CPECentral.Controls
{
    partial class OkayCancelFooter
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
            this.separatorLabel = new System.Windows.Forms.Label();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // separatorLabel
            // 
            this.separatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.separatorLabel.Location = new System.Drawing.Point(0, 0);
            this.separatorLabel.Name = "separatorLabel";
            this.separatorLabel.Size = new System.Drawing.Size(340, 2);
            this.separatorLabel.TabIndex = 0;
            // 
            // okayButton
            // 
            this.okayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okayButton.Location = new System.Drawing.Point(97, 5);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(118, 34);
            this.okayButton.TabIndex = 1;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(221, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(116, 34);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OkayCancelFooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.separatorLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OkayCancelFooter";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.Size = new System.Drawing.Size(343, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label separatorLabel;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
