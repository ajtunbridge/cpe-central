namespace CPECentral.Dialogs
{
    partial class NewVersionDialog
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
            this.newVersionNumberTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.copyOperationDocumentsCheckBox = new System.Windows.Forms.CheckBox();
            this.copyToolListsCheckBox = new System.Windows.Forms.CheckBox();
            this.copyMethodsAndOperationsCheckBox = new System.Windows.Forms.CheckBox();
            this.okayCancelFooter = new CPECentral.Controls.OkayCancelFooter();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "New version number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // newVersionNumberTextBox
            // 
            this.newVersionNumberTextBox.Location = new System.Drawing.Point(12, 25);
            this.newVersionNumberTextBox.MaxLength = 10;
            this.newVersionNumberTextBox.Name = "newVersionNumberTextBox";
            this.newVersionNumberTextBox.Size = new System.Drawing.Size(200, 20);
            this.newVersionNumberTextBox.TabIndex = 0;
            this.newVersionNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.copyOperationDocumentsCheckBox);
            this.groupBox1.Controls.Add(this.copyToolListsCheckBox);
            this.groupBox1.Controls.Add(this.copyMethodsAndOperationsCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // copyOperationDocumentsCheckBox
            // 
            this.copyOperationDocumentsCheckBox.AutoSize = true;
            this.copyOperationDocumentsCheckBox.ForeColor = System.Drawing.Color.Red;
            this.copyOperationDocumentsCheckBox.Location = new System.Drawing.Point(6, 65);
            this.copyOperationDocumentsCheckBox.Name = "copyOperationDocumentsCheckBox";
            this.copyOperationDocumentsCheckBox.Size = new System.Drawing.Size(152, 17);
            this.copyOperationDocumentsCheckBox.TabIndex = 2;
            this.copyOperationDocumentsCheckBox.Text = "Copy operation documents";
            this.copyOperationDocumentsCheckBox.UseVisualStyleBackColor = true;
            this.copyOperationDocumentsCheckBox.CheckedChanged += new System.EventHandler(this.copyOperationDocumentsCheckBox_CheckedChanged);
            // 
            // copyToolListsCheckBox
            // 
            this.copyToolListsCheckBox.AutoSize = true;
            this.copyToolListsCheckBox.Checked = true;
            this.copyToolListsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.copyToolListsCheckBox.Location = new System.Drawing.Point(6, 42);
            this.copyToolListsCheckBox.Name = "copyToolListsCheckBox";
            this.copyToolListsCheckBox.Size = new System.Drawing.Size(90, 17);
            this.copyToolListsCheckBox.TabIndex = 1;
            this.copyToolListsCheckBox.Text = "Copy tool lists";
            this.copyToolListsCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyMethodsAndOperationsCheckBox
            // 
            this.copyMethodsAndOperationsCheckBox.AutoSize = true;
            this.copyMethodsAndOperationsCheckBox.Checked = true;
            this.copyMethodsAndOperationsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.copyMethodsAndOperationsCheckBox.Location = new System.Drawing.Point(6, 19);
            this.copyMethodsAndOperationsCheckBox.Name = "copyMethodsAndOperationsCheckBox";
            this.copyMethodsAndOperationsCheckBox.Size = new System.Drawing.Size(166, 17);
            this.copyMethodsAndOperationsCheckBox.TabIndex = 0;
            this.copyMethodsAndOperationsCheckBox.Text = "Copy methods and operations";
            this.copyMethodsAndOperationsCheckBox.UseVisualStyleBackColor = true;
            this.copyMethodsAndOperationsCheckBox.CheckedChanged += new System.EventHandler(this.copyMethodsAndOperationsCheckBox_CheckedChanged);
            // 
            // okayCancelFooter
            // 
            this.okayCancelFooter.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter.Location = new System.Drawing.Point(0, 151);
            this.okayCancelFooter.Name = "okayCancelFooter";
            this.okayCancelFooter.Size = new System.Drawing.Size(225, 34);
            this.okayCancelFooter.TabIndex = 2;
            this.okayCancelFooter.OkayClicked += new System.EventHandler(this.okayCancelFooter_OkayClicked);
            this.okayCancelFooter.CancelClicked += new System.EventHandler(this.okayCancelFooter_CancelClicked);
            // 
            // NewVersionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 185);
            this.Controls.Add(this.okayCancelFooter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.newVersionNumberTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewVersionDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New version";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newVersionNumberTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox copyOperationDocumentsCheckBox;
        private System.Windows.Forms.CheckBox copyToolListsCheckBox;
        private System.Windows.Forms.CheckBox copyMethodsAndOperationsCheckBox;
        private Controls.OkayCancelFooter okayCancelFooter;
    }
}