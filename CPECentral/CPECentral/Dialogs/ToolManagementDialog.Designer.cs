namespace CPECentral.Dialogs
{
    partial class ToolManagementDialog
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.selectedToolContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupTreeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedGroupContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addChildGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLibraryView1 = new CPECentral.Views.ToolLibraryView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.selectedToolContextMenuStrip.SuspendLayout();
            this.toolListContextMenuStrip.SuspendLayout();
            this.groupTreeContextMenuStrip.SuspendLayout();
            this.selectedGroupContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(805, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.newToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.groupToolStripMenuItem.Text = "&Group";
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.Enabled = false;
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.toolToolStripMenuItem.Text = "&Tool";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(805, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(805, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(125, 16);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // selectedToolContextMenuStrip
            // 
            this.selectedToolContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolToolStripMenuItem,
            this.stockLevelsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolToolStripMenuItem});
            this.selectedToolContextMenuStrip.Name = "selectedToolContextMenuStrip";
            this.selectedToolContextMenuStrip.Size = new System.Drawing.Size(136, 76);
            // 
            // editToolToolStripMenuItem
            // 
            this.editToolToolStripMenuItem.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editToolToolStripMenuItem.Name = "editToolToolStripMenuItem";
            this.editToolToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.editToolToolStripMenuItem.Text = "&Edit";
            // 
            // stockLevelsToolStripMenuItem
            // 
            this.stockLevelsToolStripMenuItem.Image = global::CPECentral.Properties.Resources.StockIcon_16x16;
            this.stockLevelsToolStripMenuItem.Name = "stockLevelsToolStripMenuItem";
            this.stockLevelsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.stockLevelsToolStripMenuItem.Text = "&Stock levels";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(132, 6);
            // 
            // deleteToolToolStripMenuItem
            // 
            this.deleteToolToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolToolStripMenuItem.Name = "deleteToolToolStripMenuItem";
            this.deleteToolToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.deleteToolToolStripMenuItem.Text = "&Delete";
            // 
            // toolListContextMenuStrip
            // 
            this.toolListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolToolStripMenuItem});
            this.toolListContextMenuStrip.Name = "selectedToolContextMenuStrip";
            this.toolListContextMenuStrip.Size = new System.Drawing.Size(99, 26);
            // 
            // newToolToolStripMenuItem
            // 
            this.newToolToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.newToolToolStripMenuItem.Name = "newToolToolStripMenuItem";
            this.newToolToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolToolStripMenuItem.Text = "&New";
            // 
            // groupTreeContextMenuStrip
            // 
            this.groupTreeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGroupToolStripMenuItem});
            this.groupTreeContextMenuStrip.Name = "selectedToolContextMenuStrip";
            this.groupTreeContextMenuStrip.Size = new System.Drawing.Size(134, 26);
            // 
            // newGroupToolStripMenuItem
            // 
            this.newGroupToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.newGroupToolStripMenuItem.Name = "newGroupToolStripMenuItem";
            this.newGroupToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.newGroupToolStripMenuItem.Text = "&New group";
            // 
            // selectedGroupContextMenuStrip
            // 
            this.selectedGroupContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChildGroupToolStripMenuItem,
            this.editGroupToolStripMenuItem,
            this.toolStripMenuItem4,
            this.deleteGroupToolStripMenuItem});
            this.selectedGroupContextMenuStrip.Name = "selectedToolContextMenuStrip";
            this.selectedGroupContextMenuStrip.Size = new System.Drawing.Size(161, 98);
            // 
            // addChildGroupToolStripMenuItem
            // 
            this.addChildGroupToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addChildGroupToolStripMenuItem.Name = "addChildGroupToolStripMenuItem";
            this.addChildGroupToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addChildGroupToolStripMenuItem.Text = "&Add child group";
            // 
            // editGroupToolStripMenuItem
            // 
            this.editGroupToolStripMenuItem.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editGroupToolStripMenuItem.Name = "editGroupToolStripMenuItem";
            this.editGroupToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.editGroupToolStripMenuItem.Text = "Edit";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(157, 6);
            // 
            // deleteGroupToolStripMenuItem
            // 
            this.deleteGroupToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
            this.deleteGroupToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.deleteGroupToolStripMenuItem.Text = "&Delete";
            // 
            // toolLibraryView1
            // 
            this.toolLibraryView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolLibraryView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolLibraryView1.GroupTreeContextMenuStrip = this.groupTreeContextMenuStrip;
            this.toolLibraryView1.Location = new System.Drawing.Point(0, 50);
            this.toolLibraryView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolLibraryView1.Name = "toolLibraryView1";
            this.toolLibraryView1.SelectedGroupContextMenuStrip = this.selectedGroupContextMenuStrip;
            this.toolLibraryView1.SelectedToolContextMenuStrip = this.selectedToolContextMenuStrip;
            this.toolLibraryView1.Size = new System.Drawing.Size(805, 402);
            this.toolLibraryView1.TabIndex = 3;
            this.toolLibraryView1.ToolListContextMenuStrip = this.toolListContextMenuStrip;
            // 
            // ToolManagementDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 474);
            this.Controls.Add(this.toolLibraryView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolManagementDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool management";
            this.Load += new System.EventHandler(this.ToolManagementDialog_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.selectedToolContextMenuStrip.ResumeLayout(false);
            this.toolListContextMenuStrip.ResumeLayout(false);
            this.groupTreeContextMenuStrip.ResumeLayout(false);
            this.selectedGroupContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Views.ToolLibraryView toolLibraryView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip selectedToolContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockLevelsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip toolListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newToolToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip groupTreeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newGroupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip selectedGroupContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addChildGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem deleteGroupToolStripMenuItem;
    }
}