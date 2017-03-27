namespace CPECentral.Dialogs
{
    partial class EditMethodDialog
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
            this.okayCancelFooter = new CPECentral.Controls.OkayCancelFooter();
            this.label1 = new System.Windows.Forms.Label();
            this.isPreferredMethodCheckBox = new System.Windows.Forms.CheckBox();
            this.descriptionTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.SuspendLayout();
            // 
            // okayCancelFooter
            // 
            this.okayCancelFooter.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter.Location = new System.Drawing.Point(0, 168);
            this.okayCancelFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter.Name = "okayCancelFooter";
            this.okayCancelFooter.Size = new System.Drawing.Size(375, 45);
            this.okayCancelFooter.TabIndex = 2;
            this.okayCancelFooter.OkayClicked += new System.EventHandler(this.OkayCancelFooter_OkayClicked);
            this.okayCancelFooter.CancelClicked += new System.EventHandler(this.OkayCancelFooter_CancelClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Description";
            // 
            // isPreferredMethodCheckBox
            // 
            this.isPreferredMethodCheckBox.AutoSize = true;
            this.isPreferredMethodCheckBox.Checked = true;
            this.isPreferredMethodCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isPreferredMethodCheckBox.Location = new System.Drawing.Point(188, 140);
            this.isPreferredMethodCheckBox.Name = "isPreferredMethodCheckBox";
            this.isPreferredMethodCheckBox.Size = new System.Drawing.Size(173, 21);
            this.isPreferredMethodCheckBox.TabIndex = 1;
            this.isPreferredMethodCheckBox.Text = "Is the preferred method?";
            this.isPreferredMethodCheckBox.UseVisualStyleBackColor = true;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descriptionTextBox.DisableDoubleSpace = false;
            this.descriptionTextBox.DisableLeadingSpace = false;
            this.descriptionTextBox.Location = new System.Drawing.Point(15, 29);
            this.descriptionTextBox.MaxLength = 255;
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.NumericCharactersOnly = false;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(346, 105);
            this.descriptionTextBox.SuppressEnterKey = true;
            this.descriptionTextBox.TabIndex = 3;
            // 
            // EditMethodDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 213);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.isPreferredMethodCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okayCancelFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditMethodDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit method";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.OkayCancelFooter okayCancelFooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox isPreferredMethodCheckBox;
        private nGenLibrary.Controls.EnhancedTextBox descriptionTextBox;
    }
}