namespace CPECentral.Views
{
    partial class GaugesViewOld
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.resultsObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsObjectListView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.filterComboBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 39);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Filter";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // filterComboBox
            // 
            this.filterComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Items.AddRange(new object[] {
            "Due for calibration",
            "All equipment"});
            this.filterComboBox.Location = new System.Drawing.Point(311, 8);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(209, 25);
            this.filterComboBox.TabIndex = 13;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(517, 31);
            this.label6.TabIndex = 2;
            this.label6.Text = "Metrology equipment";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // resultsObjectListView
            // 
            this.resultsObjectListView.AllColumns.Add(this.olvColumn1);
            this.resultsObjectListView.AllColumns.Add(this.olvColumn2);
            this.resultsObjectListView.AllColumns.Add(this.olvColumn3);
            this.resultsObjectListView.AllColumns.Add(this.olvColumn4);
            this.resultsObjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4});
            this.resultsObjectListView.Location = new System.Drawing.Point(3, 45);
            this.resultsObjectListView.Name = "resultsObjectListView";
            this.resultsObjectListView.ShowGroups = false;
            this.resultsObjectListView.Size = new System.Drawing.Size(517, 273);
            this.resultsObjectListView.TabIndex = 12;
            this.resultsObjectListView.UseCompatibleStateImageBehavior = false;
            this.resultsObjectListView.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "GaugeNumber";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "Number";
            this.olvColumn1.Width = 87;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Description";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.FillsFreeSpace = true;
            this.olvColumn2.Text = "Name";
            this.olvColumn2.Width = 186;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "SizeRange";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.FillsFreeSpace = true;
            this.olvColumn3.Text = "Size range";
            this.olvColumn3.Width = 140;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "CalibrationDueOn";
            this.olvColumn4.AspectToStringFormat = "{0:MM-yyyy}";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.Text = "Calibrate by";
            this.olvColumn4.Width = 94;
            // 
            // GaugesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.resultsObjectListView);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GaugesView";
            this.Size = new System.Drawing.Size(523, 321);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsObjectListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private BrightIdeasSoftware.ObjectListView resultsObjectListView;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox filterComboBox;
    }
}
