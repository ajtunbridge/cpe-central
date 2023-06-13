namespace CPECentral.Views
{
    sealed partial class WorkCentreScheduleView
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
            this.components = new System.ComponentModel.Container();
            this.jobsObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label2 = new System.Windows.Forms.Label();
            this.machinesComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolingRequirementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.jobsObjectListView)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // jobsObjectListView
            // 
            this.jobsObjectListView.AllColumns.Add(this.olvColumn1);
            this.jobsObjectListView.AllColumns.Add(this.olvColumn2);
            this.jobsObjectListView.AllColumns.Add(this.olvColumn3);
            this.jobsObjectListView.AllColumns.Add(this.olvColumn4);
            this.jobsObjectListView.AllColumns.Add(this.olvColumn8);
            this.jobsObjectListView.AllColumns.Add(this.olvColumn5);
            this.jobsObjectListView.AllColumns.Add(this.olvColumn6);
            this.jobsObjectListView.AllColumns.Add(this.olvColumn7);
            this.jobsObjectListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jobsObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn8,
            this.olvColumn5,
            this.olvColumn6,
            this.olvColumn7});
            this.jobsObjectListView.FullRowSelect = true;
            this.jobsObjectListView.HideSelection = false;
            this.jobsObjectListView.Location = new System.Drawing.Point(10, 61);
            this.jobsObjectListView.Margin = new System.Windows.Forms.Padding(10);
            this.jobsObjectListView.Name = "jobsObjectListView";
            this.jobsObjectListView.ShowGroups = false;
            this.jobsObjectListView.Size = new System.Drawing.Size(734, 267);
            this.jobsObjectListView.TabIndex = 12;
            this.jobsObjectListView.UseCompatibleStateImageBehavior = false;
            this.jobsObjectListView.UseTranslucentSelection = true;
            this.jobsObjectListView.View = System.Windows.Forms.View.Details;
            this.jobsObjectListView.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.jobsObjectListView_FormatRow);
            this.jobsObjectListView.ItemActivate += new System.EventHandler(this.jobsObjectListView_ItemActivate);
            this.jobsObjectListView.SelectedIndexChanged += new System.EventHandler(this.jobsObjectListView_SelectedIndexChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "WorksOrderNumber";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "Works order";
            this.olvColumn1.Width = 100;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "DrawingNumber";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.FillsFreeSpace = true;
            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Text = "Drawing number";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Width = 125;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Version";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Text = "Version";
            this.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Name";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.FillsFreeSpace = true;
            this.olvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Text = "Name";
            this.olvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Width = 125;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "Quantity";
            this.olvColumn8.CellPadding = null;
            this.olvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Sortable = false;
            this.olvColumn8.Text = "Quantity";
            this.olvColumn8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "DueOn";
            this.olvColumn5.AspectToStringFormat = "{0:dd/MM/yyyy}";
            this.olvColumn5.CellPadding = null;
            this.olvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Text = "Due on";
            this.olvColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Width = 105;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "ScheduledStart";
            this.olvColumn6.AspectToStringFormat = "{0:dd/MM/yyyy}";
            this.olvColumn6.CellPadding = null;
            this.olvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Text = "Scheduled start";
            this.olvColumn6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Width = 105;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "ScheduledEnd";
            this.olvColumn7.AspectToStringFormat = "{0:dd/MM/yyyy}";
            this.olvColumn7.CellPadding = null;
            this.olvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.Text = "Scheduled end";
            this.olvColumn7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.Width = 105;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select a machine";
            // 
            // machinesComboBox
            // 
            this.machinesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machinesComboBox.Enabled = false;
            this.machinesComboBox.FormattingEnabled = true;
            this.machinesComboBox.Location = new System.Drawing.Point(10, 22);
            this.machinesComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.machinesComboBox.Name = "machinesComboBox";
            this.machinesComboBox.Size = new System.Drawing.Size(291, 25);
            this.machinesComboBox.TabIndex = 10;
            this.machinesComboBox.SelectedIndexChanged += new System.EventHandler(this.machinesComboBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.machinesComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 53);
            this.panel1.TabIndex = 9;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(307, 22);
            this.progressBar.MarqueeAnimationSpeed = 50;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(164, 25);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 12;
            this.progressBar.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolingRequirementsToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(187, 54);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // toolingRequirementsToolStripMenuItem
            // 
            this.toolingRequirementsToolStripMenuItem.Name = "toolingRequirementsToolStripMenuItem";
            this.toolingRequirementsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.toolingRequirementsToolStripMenuItem.Text = "Tooling requirements";
            // 
            // WorkCentreScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.jobsObjectListView);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WorkCentreScheduleView";
            this.Size = new System.Drawing.Size(754, 338);
            this.Load += new System.EventHandler(this.WorkCentreScheduleView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jobsObjectListView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox machinesComboBox;
        private System.Windows.Forms.Label label2;
        private BrightIdeasSoftware.ObjectListView jobsObjectListView;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolingRequirementsToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
    }
}
