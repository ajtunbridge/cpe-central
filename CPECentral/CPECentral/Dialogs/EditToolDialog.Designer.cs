namespace CPECentral.Dialogs
{
    partial class EditToolDialog
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
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.tricornLinksEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionEnhancedTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.okayCancelFooter = new CPECentral.Controls.OkayCancelFooter();
            this.generateDescriptionButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.tricornLinksEnhancedListView);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tricorn links";
            // 
            // addButton
            // 
            this.addButton.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addButton.Location = new System.Drawing.Point(437, 24);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(32, 32);
            this.addButton.TabIndex = 3;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteButton.Location = new System.Drawing.Point(437, 62);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(32, 32);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // tricornLinksEnhancedListView
            // 
            this.tricornLinksEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.tricornLinksEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.tricornLinksEnhancedListView.EnsureSelection = false;
            this.tricornLinksEnhancedListView.FullRowSelect = true;
            this.tricornLinksEnhancedListView.GridLines = true;
            this.tricornLinksEnhancedListView.IndexOfColumnToResize = 0;
            this.tricornLinksEnhancedListView.ItemContextMenuStrip = null;
            this.tricornLinksEnhancedListView.Location = new System.Drawing.Point(6, 24);
            this.tricornLinksEnhancedListView.MultiSelect = false;
            this.tricornLinksEnhancedListView.Name = "tricornLinksEnhancedListView";
            this.tricornLinksEnhancedListView.ResizeColumnToFill = true;
            this.tricornLinksEnhancedListView.Size = new System.Drawing.Size(425, 185);
            this.tricornLinksEnhancedListView.TabIndex = 2;
            this.tricornLinksEnhancedListView.UseAlternatingBackColor = true;
            this.tricornLinksEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.tricornLinksEnhancedListView.View = System.Windows.Forms.View.Details;
            this.tricornLinksEnhancedListView.SelectedIndexChanged += new System.EventHandler(this.tricornLinksEnhancedListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 418;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description";
            // 
            // descriptionEnhancedTextBox
            // 
            this.descriptionEnhancedTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descriptionEnhancedTextBox.DisableDoubleSpace = true;
            this.descriptionEnhancedTextBox.DisableLeadingSpace = true;
            this.descriptionEnhancedTextBox.Location = new System.Drawing.Point(12, 29);
            this.descriptionEnhancedTextBox.MaxLength = 50;
            this.descriptionEnhancedTextBox.Name = "descriptionEnhancedTextBox";
            this.descriptionEnhancedTextBox.NumericCharactersOnly = false;
            this.descriptionEnhancedTextBox.Size = new System.Drawing.Size(401, 25);
            this.descriptionEnhancedTextBox.SuppressEnterKey = false;
            this.descriptionEnhancedTextBox.TabIndex = 1;
            // 
            // okayCancelFooter
            // 
            this.okayCancelFooter.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter.Location = new System.Drawing.Point(0, 291);
            this.okayCancelFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter.Name = "okayCancelFooter";
            this.okayCancelFooter.Size = new System.Drawing.Size(499, 45);
            this.okayCancelFooter.TabIndex = 2;
            this.okayCancelFooter.OkayClicked += new System.EventHandler(this.okayCancelFooter_OkayClicked);
            this.okayCancelFooter.CancelClicked += new System.EventHandler(this.okayCancelFooter_CancelClicked);
            // 
            // generateDescriptionButton
            // 
            this.generateDescriptionButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateDescriptionButton.Location = new System.Drawing.Point(419, 29);
            this.generateDescriptionButton.Name = "generateDescriptionButton";
            this.generateDescriptionButton.Size = new System.Drawing.Size(68, 25);
            this.generateDescriptionButton.TabIndex = 3;
            this.generateDescriptionButton.Text = "Generate";
            this.generateDescriptionButton.UseVisualStyleBackColor = true;
            this.generateDescriptionButton.Click += new System.EventHandler(this.generateDescriptionButton_Click);
            // 
            // EditToolDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 336);
            this.Controls.Add(this.generateDescriptionButton);
            this.Controls.Add(this.okayCancelFooter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descriptionEnhancedTextBox);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditToolDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit tool";
            this.Load += new System.EventHandler(this.EditToolDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private nGenLibrary.Controls.EnhancedListView tricornLinksEnhancedListView;
        private nGenLibrary.Controls.EnhancedTextBox descriptionEnhancedTextBox;
        private System.Windows.Forms.Label label1;
        private Controls.OkayCancelFooter okayCancelFooter;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button generateDescriptionButton;
    }
}