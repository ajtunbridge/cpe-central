namespace CPECentral.Dialogs
{
    partial class SelectWorksOrderDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.okayCancelFooter1 = new CPECentral.Controls.OkayCancelFooter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.drawingNumberTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.versionTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customerNameTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.matchesListBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.matchesListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matches";
            // 
            // okayCancelFooter1
            // 
            this.okayCancelFooter1.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter1.Location = new System.Drawing.Point(0, 199);
            this.okayCancelFooter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter1.Name = "okayCancelFooter1";
            this.okayCancelFooter1.Size = new System.Drawing.Size(515, 45);
            this.okayCancelFooter1.TabIndex = 1;
            this.okayCancelFooter1.OkayClicked += new System.EventHandler(this.okayCancelFooter1_OkayClicked);
            this.okayCancelFooter1.CancelClicked += new System.EventHandler(this.okayCancelFooter1_CancelClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nameTextBox);
            this.groupBox2.Controls.Add(this.drawingNumberTextBox);
            this.groupBox2.Controls.Add(this.versionTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.customerNameTextBox);
            this.groupBox2.Location = new System.Drawing.Point(155, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 180);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected works order details";
            // 
            // nameTextBox
            // 
            this.nameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nameTextBox.DisableDoubleSpace = true;
            this.nameTextBox.DisableLeadingSpace = false;
            this.nameTextBox.Location = new System.Drawing.Point(9, 137);
            this.nameTextBox.MaxLength = 50;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.NumericCharactersOnly = false;
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(330, 25);
            this.nameTextBox.SuppressEnterKey = false;
            this.nameTextBox.TabIndex = 16;
            // 
            // drawingNumberTextBox
            // 
            this.drawingNumberTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.drawingNumberTextBox.DisableDoubleSpace = true;
            this.drawingNumberTextBox.DisableLeadingSpace = false;
            this.drawingNumberTextBox.Location = new System.Drawing.Point(9, 89);
            this.drawingNumberTextBox.MaxLength = 50;
            this.drawingNumberTextBox.Name = "drawingNumberTextBox";
            this.drawingNumberTextBox.NumericCharactersOnly = false;
            this.drawingNumberTextBox.ReadOnly = true;
            this.drawingNumberTextBox.Size = new System.Drawing.Size(250, 25);
            this.drawingNumberTextBox.SuppressEnterKey = false;
            this.drawingNumberTextBox.TabIndex = 13;
            // 
            // versionTextBox
            // 
            this.versionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.versionTextBox.DisableDoubleSpace = true;
            this.versionTextBox.DisableLeadingSpace = false;
            this.versionTextBox.Location = new System.Drawing.Point(265, 89);
            this.versionTextBox.MaxLength = 10;
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.NumericCharactersOnly = false;
            this.versionTextBox.ReadOnly = true;
            this.versionTextBox.Size = new System.Drawing.Size(74, 25);
            this.versionTextBox.SuppressEnterKey = false;
            this.versionTextBox.TabIndex = 14;
            this.versionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(265, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Version";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Drawing number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Customer";
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.customerNameTextBox.DisableDoubleSpace = true;
            this.customerNameTextBox.DisableLeadingSpace = false;
            this.customerNameTextBox.Location = new System.Drawing.Point(9, 41);
            this.customerNameTextBox.MaxLength = 50;
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.NumericCharactersOnly = false;
            this.customerNameTextBox.ReadOnly = true;
            this.customerNameTextBox.Size = new System.Drawing.Size(333, 25);
            this.customerNameTextBox.SuppressEnterKey = false;
            this.customerNameTextBox.TabIndex = 15;
            // 
            // matchesListBox
            // 
            this.matchesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matchesListBox.FormattingEnabled = true;
            this.matchesListBox.ItemHeight = 17;
            this.matchesListBox.Location = new System.Drawing.Point(3, 21);
            this.matchesListBox.Name = "matchesListBox";
            this.matchesListBox.Size = new System.Drawing.Size(131, 156);
            this.matchesListBox.TabIndex = 0;
            this.matchesListBox.SelectedIndexChanged += new System.EventHandler(this.matchesListBox_SelectedIndexChanged);
            // 
            // SelectWorksOrderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 244);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.okayCancelFooter1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectWorksOrderDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select a works order";
            this.Load += new System.EventHandler(this.SelectWorksOrderDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.OkayCancelFooter okayCancelFooter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private nGenLibrary.Controls.EnhancedTextBox nameTextBox;
        private nGenLibrary.Controls.EnhancedTextBox drawingNumberTextBox;
        private nGenLibrary.Controls.EnhancedTextBox versionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private nGenLibrary.Controls.EnhancedTextBox customerNameTextBox;
        private System.Windows.Forms.ListBox matchesListBox;
    }
}