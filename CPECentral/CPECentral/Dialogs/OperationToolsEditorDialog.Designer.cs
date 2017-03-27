namespace CPECentral.Dialogs
{
    partial class OperationToolsEditorDialog
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
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.selectedToolGroupBox = new System.Windows.Forms.GroupBox();
            this.browseForToolButton = new System.Windows.Forms.Button();
            this.offsetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.positionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTextBox = new System.Windows.Forms.TextBox();
            this.toolComboBox = new System.Windows.Forms.ComboBox();
            this.holderTextBox = new System.Windows.Forms.TextBox();
            this.holderComboBox = new System.Windows.Forms.ComboBox();
            this.toolsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectedToolGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(647, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(117, 39);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(647, 57);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(117, 39);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(647, 172);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(117, 41);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // selectedToolGroupBox
            // 
            this.selectedToolGroupBox.Controls.Add(this.browseForToolButton);
            this.selectedToolGroupBox.Controls.Add(this.offsetNumericUpDown);
            this.selectedToolGroupBox.Controls.Add(this.positionNumericUpDown);
            this.selectedToolGroupBox.Controls.Add(this.textBox1);
            this.selectedToolGroupBox.Controls.Add(this.label2);
            this.selectedToolGroupBox.Controls.Add(this.label4);
            this.selectedToolGroupBox.Controls.Add(this.label3);
            this.selectedToolGroupBox.Controls.Add(this.label5);
            this.selectedToolGroupBox.Controls.Add(this.label1);
            this.selectedToolGroupBox.Controls.Add(this.toolTextBox);
            this.selectedToolGroupBox.Controls.Add(this.toolComboBox);
            this.selectedToolGroupBox.Controls.Add(this.holderTextBox);
            this.selectedToolGroupBox.Controls.Add(this.holderComboBox);
            this.selectedToolGroupBox.Enabled = false;
            this.selectedToolGroupBox.Location = new System.Drawing.Point(12, 274);
            this.selectedToolGroupBox.Name = "selectedToolGroupBox";
            this.selectedToolGroupBox.Size = new System.Drawing.Size(752, 137);
            this.selectedToolGroupBox.TabIndex = 1;
            this.selectedToolGroupBox.TabStop = false;
            this.selectedToolGroupBox.Text = "Selected tool";
            // 
            // browseForToolButton
            // 
            this.browseForToolButton.Location = new System.Drawing.Point(416, 49);
            this.browseForToolButton.Name = "browseForToolButton";
            this.browseForToolButton.Size = new System.Drawing.Size(69, 72);
            this.browseForToolButton.TabIndex = 10;
            this.browseForToolButton.Text = "Browse for tool";
            this.browseForToolButton.UseVisualStyleBackColor = true;
            this.browseForToolButton.Click += new System.EventHandler(this.browseForToolButton_Click);
            // 
            // offsetNumericUpDown
            // 
            this.offsetNumericUpDown.Location = new System.Drawing.Point(9, 98);
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
            this.offsetNumericUpDown.ValueChanged += new System.EventHandler(this.offsetNumericUpDown_ValueChanged);
            // 
            // positionNumericUpDown
            // 
            this.positionNumericUpDown.Location = new System.Drawing.Point(9, 50);
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
            this.positionNumericUpDown.ValueChanged += new System.EventHandler(this.positionNumericUpDown_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(499, 49);
            this.textBox1.MaxLength = 50;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 72);
            this.textBox1.TabIndex = 4;
            this.textBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Holder";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Offset";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Position";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(496, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Notes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tool";
            // 
            // toolTextBox
            // 
            this.toolTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.toolTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.toolTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toolTextBox.Location = new System.Drawing.Point(102, 49);
            this.toolTextBox.MaxLength = 255;
            this.toolTextBox.Name = "toolTextBox";
            this.toolTextBox.Size = new System.Drawing.Size(308, 25);
            this.toolTextBox.TabIndex = 2;
            this.toolTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxes_MouseClicked);
            this.toolTextBox.Enter += new System.EventHandler(this.TextBoxes_Entered);
            this.toolTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolTextBox_KeyDown);
            // 
            // toolComboBox
            // 
            this.toolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolComboBox.FormattingEnabled = true;
            this.toolComboBox.Location = new System.Drawing.Point(102, 49);
            this.toolComboBox.Name = "toolComboBox";
            this.toolComboBox.Size = new System.Drawing.Size(308, 25);
            this.toolComboBox.TabIndex = 9;
            this.toolComboBox.DropDown += new System.EventHandler(this.toolComboBox_DropDown);
            this.toolComboBox.SelectedIndexChanged += new System.EventHandler(this.toolComboBox_SelectedIndexChanged);
            this.toolComboBox.DropDownClosed += new System.EventHandler(this.toolComboBox_DropDownClosed);
            // 
            // holderTextBox
            // 
            this.holderTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.holderTextBox.Location = new System.Drawing.Point(102, 97);
            this.holderTextBox.MaxLength = 255;
            this.holderTextBox.Name = "holderTextBox";
            this.holderTextBox.Size = new System.Drawing.Size(308, 25);
            this.holderTextBox.TabIndex = 3;
            this.holderTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxes_MouseClicked);
            this.holderTextBox.Enter += new System.EventHandler(this.TextBoxes_Entered);
            this.holderTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.holderTextBox_KeyDown);
            // 
            // holderComboBox
            // 
            this.holderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.holderComboBox.FormattingEnabled = true;
            this.holderComboBox.Location = new System.Drawing.Point(102, 97);
            this.holderComboBox.Name = "holderComboBox";
            this.holderComboBox.Size = new System.Drawing.Size(308, 25);
            this.holderComboBox.TabIndex = 9;
            this.holderComboBox.SelectedIndexChanged += new System.EventHandler(this.holderComboBox_SelectedIndexChanged);
            this.holderComboBox.DropDownClosed += new System.EventHandler(this.holderComboBox_DropDownClosed);
            // 
            // toolsEnhancedListView
            // 
            this.toolsEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.toolsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.toolsEnhancedListView.EnsureSelection = false;
            this.toolsEnhancedListView.FullRowSelect = true;
            this.toolsEnhancedListView.GridLines = true;
            this.toolsEnhancedListView.HideSelection = false;
            this.toolsEnhancedListView.IndexOfColumnToResize = 2;
            this.toolsEnhancedListView.ItemContextMenuStrip = null;
            this.toolsEnhancedListView.Location = new System.Drawing.Point(8, 8);
            this.toolsEnhancedListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolsEnhancedListView.MultiSelect = false;
            this.toolsEnhancedListView.Name = "toolsEnhancedListView";
            this.toolsEnhancedListView.ResizeColumnToFill = true;
            this.toolsEnhancedListView.ShowItemToolTips = true;
            this.toolsEnhancedListView.Size = new System.Drawing.Size(633, 252);
            this.toolsEnhancedListView.TabIndex = 0;
            this.toolsEnhancedListView.UseAlternatingBackColor = true;
            this.toolsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.toolsEnhancedListView.View = System.Windows.Forms.View.Details;
            this.toolsEnhancedListView.SelectedIndexChanged += new System.EventHandler(this.toolsEnhancedListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Position";
            this.columnHeader1.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Offset";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 270;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Holder";
            this.columnHeader4.Width = 230;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(647, 219);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(117, 41);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OperationToolsEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 423);
            this.Controls.Add(this.toolsEnhancedListView);
            this.Controls.Add(this.selectedToolGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperationToolsEditorDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool list editor";
            this.Load += new System.EventHandler(this.OperationToolsEditorDialog_Load);
            this.selectedToolGroupBox.ResumeLayout(false);
            this.selectedToolGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox selectedToolGroupBox;
        private System.Windows.Forms.NumericUpDown offsetNumericUpDown;
        private System.Windows.Forms.NumericUpDown positionNumericUpDown;
        private System.Windows.Forms.TextBox holderTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox toolTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private nGenLibrary.Controls.EnhancedListView toolsEnhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox holderComboBox;
        private System.Windows.Forms.ComboBox toolComboBox;
        private System.Windows.Forms.Button browseForToolButton;
    }
}