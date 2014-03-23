namespace CPECentral.Controls
{
    partial class SettingsEmployeesUserControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.employeesTabPage = new System.Windows.Forms.TabPage();
            this.groupsTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.enhancedListView1 = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.employeesTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.employeesTabPage);
            this.tabControl1.Controls.Add(this.groupsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(125, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 388);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // employeesTabPage
            // 
            this.employeesTabPage.Controls.Add(this.groupBox1);
            this.employeesTabPage.Controls.Add(this.panel1);
            this.employeesTabPage.Controls.Add(this.toolStrip1);
            this.employeesTabPage.Location = new System.Drawing.Point(4, 26);
            this.employeesTabPage.Name = "employeesTabPage";
            this.employeesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.employeesTabPage.Size = new System.Drawing.Size(539, 358);
            this.employeesTabPage.TabIndex = 0;
            this.employeesTabPage.Text = "Employees";
            this.employeesTabPage.UseVisualStyleBackColor = true;
            // 
            // groupsTabPage
            // 
            this.groupsTabPage.Location = new System.Drawing.Point(4, 26);
            this.groupsTabPage.Name = "groupsTabPage";
            this.groupsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.groupsTabPage.Size = new System.Drawing.Size(539, 358);
            this.groupsTabPage.TabIndex = 1;
            this.groupsTabPage.Text = "Groups";
            this.groupsTabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.enhancedListView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(324, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 327);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(533, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // enhancedListView1
            // 
            this.enhancedListView1.AlternateBackColor = System.Drawing.Color.WhiteSmoke;
            this.enhancedListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.enhancedListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhancedListView1.EnsureSelection = false;
            this.enhancedListView1.IndexOfColumnToResize = 0;
            this.enhancedListView1.ItemContextMenuStrip = null;
            this.enhancedListView1.Location = new System.Drawing.Point(0, 0);
            this.enhancedListView1.Name = "enhancedListView1";
            this.enhancedListView1.ResizeColumnToFill = true;
            this.enhancedListView1.Size = new System.Drawing.Size(212, 327);
            this.enhancedListView1.TabIndex = 0;
            this.enhancedListView1.UseAlternatingBackColor = false;
            this.enhancedListView1.UseCompatibleStateImageBehavior = false;
            this.enhancedListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Employee";
            this.columnHeader1.Width = 205;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 327);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected employee";
            // 
            // SettingsEmployeesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsEmployeesUserControl";
            this.Size = new System.Drawing.Size(547, 388);
            this.tabControl1.ResumeLayout(false);
            this.employeesTabPage.ResumeLayout(false);
            this.employeesTabPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage employeesTabPage;
        private System.Windows.Forms.TabPage groupsTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private nGenLibrary.Controls.EnhancedListView enhancedListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;

    }
}
