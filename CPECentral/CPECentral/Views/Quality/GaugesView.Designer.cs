namespace CPECentral.Views.Quality
{
    partial class GaugesView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gaugeTypesComboBox = new System.Windows.Forms.ComboBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bookedOutRadioButton = new System.Windows.Forms.RadioButton();
            this.dueForCalibrationRadioButton = new System.Windows.Forms.RadioButton();
            this.allGaugesRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gaugesObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnGaugeType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addGaugeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteGaugeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugesObjectListView)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gaugeTypesComboBox);
            this.groupBox1.Controls.Add(this.referenceTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // gaugeTypesComboBox
            // 
            this.gaugeTypesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gaugeTypesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gaugeTypesComboBox.FormattingEnabled = true;
            this.gaugeTypesComboBox.Location = new System.Drawing.Point(9, 91);
            this.gaugeTypesComboBox.Name = "gaugeTypesComboBox";
            this.gaugeTypesComboBox.Size = new System.Drawing.Size(440, 25);
            this.gaugeTypesComboBox.TabIndex = 1;
            this.gaugeTypesComboBox.SelectionChangeCommitted += new System.EventHandler(this.gaugeTypesComboBox_SelectionChangeCommitted);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(152, 41);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(297, 25);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type of gauge";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.bookedOutRadioButton);
            this.groupBox2.Controls.Add(this.dueForCalibrationRadioButton);
            this.groupBox2.Controls.Add(this.allGaugesRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(455, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 103);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // bookedOutRadioButton
            // 
            this.bookedOutRadioButton.AutoSize = true;
            this.bookedOutRadioButton.Location = new System.Drawing.Point(6, 78);
            this.bookedOutRadioButton.Name = "bookedOutRadioButton";
            this.bookedOutRadioButton.Size = new System.Drawing.Size(93, 21);
            this.bookedOutRadioButton.TabIndex = 2;
            this.bookedOutRadioButton.Text = "Booked out";
            this.bookedOutRadioButton.UseVisualStyleBackColor = true;
            this.bookedOutRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // dueForCalibrationRadioButton
            // 
            this.dueForCalibrationRadioButton.AutoSize = true;
            this.dueForCalibrationRadioButton.Location = new System.Drawing.Point(6, 51);
            this.dueForCalibrationRadioButton.Name = "dueForCalibrationRadioButton";
            this.dueForCalibrationRadioButton.Size = new System.Drawing.Size(135, 21);
            this.dueForCalibrationRadioButton.TabIndex = 1;
            this.dueForCalibrationRadioButton.Text = "Due for calibration";
            this.dueForCalibrationRadioButton.UseVisualStyleBackColor = true;
            this.dueForCalibrationRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // allGaugesRadioButton
            // 
            this.allGaugesRadioButton.AutoSize = true;
            this.allGaugesRadioButton.Checked = true;
            this.allGaugesRadioButton.Location = new System.Drawing.Point(6, 24);
            this.allGaugesRadioButton.Name = "allGaugesRadioButton";
            this.allGaugesRadioButton.Size = new System.Drawing.Size(87, 21);
            this.allGaugesRadioButton.TabIndex = 0;
            this.allGaugesRadioButton.TabStop = true;
            this.allGaugesRadioButton.Text = "All gauges";
            this.allGaugesRadioButton.UseVisualStyleBackColor = true;
            this.allGaugesRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.gaugesObjectListView);
            this.groupBox3.Controls.Add(this.toolStrip);
            this.groupBox3.Location = new System.Drawing.Point(3, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(616, 513);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gauges";
            // 
            // gaugesObjectListView
            // 
            this.gaugesObjectListView.AllColumns.Add(this.olvColumn1);
            this.gaugesObjectListView.AllColumns.Add(this.olvColumn2);
            this.gaugesObjectListView.AllColumns.Add(this.olvColumnGaugeType);
            this.gaugesObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumnGaugeType});
            this.gaugesObjectListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugesObjectListView.FullRowSelect = true;
            this.gaugesObjectListView.Location = new System.Drawing.Point(3, 46);
            this.gaugesObjectListView.Name = "gaugesObjectListView";
            this.gaugesObjectListView.ShowGroups = false;
            this.gaugesObjectListView.Size = new System.Drawing.Size(610, 464);
            this.gaugesObjectListView.TabIndex = 1;
            this.gaugesObjectListView.UseCompatibleStateImageBehavior = false;
            this.gaugesObjectListView.View = System.Windows.Forms.View.Details;
            this.gaugesObjectListView.SelectionChanged += new System.EventHandler(this.gaugesObjectListView_SelectionChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Reference";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "Reference";
            this.olvColumn1.Width = 125;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Name";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.FillsFreeSpace = true;
            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Text = "Name";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvColumnGaugeType
            // 
            this.olvColumnGaugeType.AspectName = "GaugeType";
            this.olvColumnGaugeType.CellPadding = null;
            this.olvColumnGaugeType.FillsFreeSpace = true;
            this.olvColumnGaugeType.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnGaugeType.Text = "Type";
            this.olvColumnGaugeType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGaugeToolStripButton,
            this.deleteGaugeToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(3, 21);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(610, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // addGaugeToolStripButton
            // 
            this.addGaugeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addGaugeToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addGaugeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addGaugeToolStripButton.Name = "addGaugeToolStripButton";
            this.addGaugeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addGaugeToolStripButton.Text = "toolStripButton1";
            // 
            // deleteGaugeToolStripButton
            // 
            this.deleteGaugeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteGaugeToolStripButton.Enabled = false;
            this.deleteGaugeToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteGaugeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteGaugeToolStripButton.Name = "deleteGaugeToolStripButton";
            this.deleteGaugeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteGaugeToolStripButton.Text = "toolStripButton2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Reference";
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.Location = new System.Drawing.Point(9, 41);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.Size = new System.Drawing.Size(137, 25);
            this.referenceTextBox.TabIndex = 0;
            this.referenceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            // 
            // GaugesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GaugesView";
            this.Size = new System.Drawing.Size(624, 655);
            this.Load += new System.EventHandler(this.GaugesView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gaugesObjectListView)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox gaugeTypesComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton bookedOutRadioButton;
        private System.Windows.Forms.RadioButton dueForCalibrationRadioButton;
        private System.Windows.Forms.RadioButton allGaugesRadioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private BrightIdeasSoftware.ObjectListView gaugesObjectListView;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumnGaugeType;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addGaugeToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteGaugeToolStripButton;
        private System.Windows.Forms.TextBox referenceTextBox;
        private System.Windows.Forms.Label label3;
    }
}
