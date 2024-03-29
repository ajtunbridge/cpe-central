﻿namespace CPECentral.Dialogs
{
    partial class EditOperationDialog
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.sequenceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.setupNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cycleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.machineGroupComboBox = new System.Windows.Forms.ComboBox();
            this.diameterButton = new System.Windows.Forms.Button();
            this.plusMinusButton = new System.Windows.Forms.Button();
            this.degreesButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.okayCancelFooter = new CPECentral.Controls.OkayCancelFooter();
            ((System.ComponentModel.ISupportInitialize)(this.sequenceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setupNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cycleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sequence";
            // 
            // sequenceNumericUpDown
            // 
            this.sequenceNumericUpDown.Location = new System.Drawing.Point(12, 28);
            this.sequenceNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.sequenceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sequenceNumericUpDown.Name = "sequenceNumericUpDown";
            this.sequenceNumericUpDown.Size = new System.Drawing.Size(70, 25);
            this.sequenceNumericUpDown.TabIndex = 0;
            this.sequenceNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sequenceNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Setup";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // setupNumericUpDown
            // 
            this.setupNumericUpDown.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.setupNumericUpDown.Location = new System.Drawing.Point(12, 90);
            this.setupNumericUpDown.Maximum = new decimal(new int[] {
            2880,
            0,
            0,
            0});
            this.setupNumericUpDown.Name = "setupNumericUpDown";
            this.setupNumericUpDown.Size = new System.Drawing.Size(70, 25);
            this.setupNumericUpDown.TabIndex = 1;
            this.setupNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cycle";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cycleNumericUpDown
            // 
            this.cycleNumericUpDown.DecimalPlaces = 2;
            this.cycleNumericUpDown.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.cycleNumericUpDown.Location = new System.Drawing.Point(12, 138);
            this.cycleNumericUpDown.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.cycleNumericUpDown.Name = "cycleNumericUpDown";
            this.cycleNumericUpDown.Size = new System.Drawing.Size(70, 25);
            this.cycleNumericUpDown.TabIndex = 2;
            this.cycleNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descriptionTextBox.DisableDoubleSpace = false;
            this.descriptionTextBox.DisableLeadingSpace = false;
            this.descriptionTextBox.Location = new System.Drawing.Point(94, 29);
            this.descriptionTextBox.MaxLength = 30000;
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.NumericCharactersOnly = false;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(336, 86);
            this.descriptionTextBox.SuppressEnterKey = true;
            this.descriptionTextBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Machine group";
            // 
            // machineGroupComboBox
            // 
            this.machineGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machineGroupComboBox.FormattingEnabled = true;
            this.machineGroupComboBox.Location = new System.Drawing.Point(94, 138);
            this.machineGroupComboBox.Name = "machineGroupComboBox";
            this.machineGroupComboBox.Size = new System.Drawing.Size(373, 25);
            this.machineGroupComboBox.TabIndex = 4;
            // 
            // diameterButton
            // 
            this.diameterButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diameterButton.Location = new System.Drawing.Point(442, 28);
            this.diameterButton.Name = "diameterButton";
            this.diameterButton.Size = new System.Drawing.Size(25, 25);
            this.diameterButton.TabIndex = 7;
            this.diameterButton.Text = "Ø";
            this.toolTip.SetToolTip(this.diameterButton, "Shortcut = Alt Key + 216");
            this.diameterButton.UseVisualStyleBackColor = true;
            this.diameterButton.Click += new System.EventHandler(this.symbolButtons_Click);
            // 
            // plusMinusButton
            // 
            this.plusMinusButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plusMinusButton.Location = new System.Drawing.Point(442, 59);
            this.plusMinusButton.Name = "plusMinusButton";
            this.plusMinusButton.Size = new System.Drawing.Size(25, 25);
            this.plusMinusButton.TabIndex = 7;
            this.plusMinusButton.Text = "±";
            this.toolTip.SetToolTip(this.plusMinusButton, "Shortcut = Alt Key + 177");
            this.plusMinusButton.UseVisualStyleBackColor = true;
            this.plusMinusButton.Click += new System.EventHandler(this.symbolButtons_Click);
            // 
            // degreesButton
            // 
            this.degreesButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.degreesButton.Location = new System.Drawing.Point(442, 90);
            this.degreesButton.Name = "degreesButton";
            this.degreesButton.Size = new System.Drawing.Size(25, 25);
            this.degreesButton.TabIndex = 7;
            this.degreesButton.Text = "°";
            this.toolTip.SetToolTip(this.degreesButton, "Shortcut = Alt Key + 0176");
            this.degreesButton.UseVisualStyleBackColor = true;
            this.degreesButton.Click += new System.EventHandler(this.symbolButtons_Click);
            // 
            // okayCancelFooter
            // 
            this.okayCancelFooter.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter.Location = new System.Drawing.Point(0, 181);
            this.okayCancelFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter.Name = "okayCancelFooter";
            this.okayCancelFooter.Size = new System.Drawing.Size(479, 45);
            this.okayCancelFooter.TabIndex = 6;
            this.okayCancelFooter.OkayClicked += new System.EventHandler(this.OkayCancelFooter_OkayClicked);
            this.okayCancelFooter.CancelClicked += new System.EventHandler(this.OkayCancelFooter_CancelClicked);
            // 
            // EditOperationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 226);
            this.Controls.Add(this.degreesButton);
            this.Controls.Add(this.plusMinusButton);
            this.Controls.Add(this.diameterButton);
            this.Controls.Add(this.machineGroupComboBox);
            this.Controls.Add(this.okayCancelFooter);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cycleNumericUpDown);
            this.Controls.Add(this.setupNumericUpDown);
            this.Controls.Add(this.sequenceNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditOperationDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit operation";
            this.Load += new System.EventHandler(this.EditOperationDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sequenceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setupNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cycleNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown sequenceNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown setupNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown cycleNumericUpDown;
        private System.Windows.Forms.Label label4;
        private nGenLibrary.Controls.EnhancedTextBox descriptionTextBox;
        private Controls.OkayCancelFooter okayCancelFooter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox machineGroupComboBox;
        private System.Windows.Forms.Button diameterButton;
        private System.Windows.Forms.Button plusMinusButton;
        private System.Windows.Forms.Button degreesButton;
        private System.Windows.Forms.ToolTip toolTip;
    }
}