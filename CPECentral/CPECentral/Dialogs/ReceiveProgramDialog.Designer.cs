namespace CPECentral.Dialogs
{
    partial class ReceiveProgramDialog
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
            this.messageLabel = new System.Windows.Forms.Label();
            this.programTextBox = new System.Windows.Forms.TextBox();
            this.okayCancelFooter1 = new CPECentral.Controls.OkayCancelFooter();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(12, 9);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(141, 17);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.Text = "Waiting for program....";
            // 
            // programTextBox
            // 
            this.programTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.programTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programTextBox.Location = new System.Drawing.Point(15, 32);
            this.programTextBox.Multiline = true;
            this.programTextBox.Name = "programTextBox";
            this.programTextBox.ReadOnly = true;
            this.programTextBox.Size = new System.Drawing.Size(357, 192);
            this.programTextBox.TabIndex = 4;
            // 
            // okayCancelFooter1
            // 
            this.okayCancelFooter1.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter1.Location = new System.Drawing.Point(0, 239);
            this.okayCancelFooter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter1.Name = "okayCancelFooter1";
            this.okayCancelFooter1.Size = new System.Drawing.Size(384, 45);
            this.okayCancelFooter1.TabIndex = 5;
            this.okayCancelFooter1.OkayClicked += new System.EventHandler(this.okayCancelFooter1_OkayClicked);
            this.okayCancelFooter1.CancelClicked += new System.EventHandler(this.okayCancelFooter1_CancelClicked);
            // 
            // ReceiveProgramDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 284);
            this.Controls.Add(this.okayCancelFooter1);
            this.Controls.Add(this.programTextBox);
            this.Controls.Add(this.messageLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiveProgramDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Receive program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceiveProgramDialog_FormClosing);
            this.Load += new System.EventHandler(this.ReceiveProgramDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox programTextBox;
        private Controls.OkayCancelFooter okayCancelFooter1;
    }
}