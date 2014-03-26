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
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.rootGroupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.childGroupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addRootGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.childGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshLibraryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.selectedToolContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupTreeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedGroupContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addChildGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolLibraryView = new CPECentral.Views.ToolLibraryView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.selectedToolContextMenuStrip.SuspendLayout();
            this.groupTreeContextMenuStrip.SuspendLayout();
            this.selectedGroupContextMenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1101, 27);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolToolStripMenuItem,
            this.toolStripSeparator3,
            this.rootGroupToolStripMenuItem1,
            this.childGroupToolStripMenuItem1});
            this.newToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.Enabled = false;
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.toolToolStripMenuItem.Text = "&Tool";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(142, 6);
            // 
            // rootGroupToolStripMenuItem1
            // 
            this.rootGroupToolStripMenuItem1.Name = "rootGroupToolStripMenuItem1";
            this.rootGroupToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.rootGroupToolStripMenuItem1.Text = "Root group";
            // 
            // childGroupToolStripMenuItem1
            // 
            this.childGroupToolStripMenuItem1.Name = "childGroupToolStripMenuItem1";
            this.childGroupToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.childGroupToolStripMenuItem1.Text = "Child group";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(99, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.refreshLibraryToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 27);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1101, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolToolStripMenuItem1,
            this.toolStripSeparator4,
            this.addRootGroupToolStripMenuItem,
            this.childGroupToolStripMenuItem});
            this.toolStripButton1.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // toolToolStripMenuItem1
            // 
            this.toolToolStripMenuItem1.Name = "toolToolStripMenuItem1";
            this.toolToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolToolStripMenuItem1.Text = "&Tool";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // addRootGroupToolStripMenuItem
            // 
            this.addRootGroupToolStripMenuItem.Name = "addRootGroupToolStripMenuItem";
            this.addRootGroupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addRootGroupToolStripMenuItem.Text = "&Root group";
            // 
            // childGroupToolStripMenuItem
            // 
            this.childGroupToolStripMenuItem.Name = "childGroupToolStripMenuItem";
            this.childGroupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.childGroupToolStripMenuItem.Text = "&Child group";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // refreshLibraryToolStripButton
            // 
            this.refreshLibraryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshLibraryToolStripButton.Image = global::CPECentral.Properties.Resources.ReloadIcon_16x16;
            this.refreshLibraryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshLibraryToolStripButton.Name = "refreshLibraryToolStripButton";
            this.refreshLibraryToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshLibraryToolStripButton.Text = "Refresh library";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 632);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1101, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(131, 17);
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
            this.toolStripMenuItem2,
            this.deleteToolToolStripMenuItem});
            this.selectedToolContextMenuStrip.Name = "selectedToolContextMenuStrip";
            this.selectedToolContextMenuStrip.Size = new System.Drawing.Size(108, 54);
            // 
            // editToolToolStripMenuItem
            // 
            this.editToolToolStripMenuItem.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editToolToolStripMenuItem.Name = "editToolToolStripMenuItem";
            this.editToolToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolToolStripMenuItem.Text = "&Edit";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(104, 6);
            // 
            // deleteToolToolStripMenuItem
            // 
            this.deleteToolToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteToolToolStripMenuItem.Name = "deleteToolToolStripMenuItem";
            this.deleteToolToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolToolStripMenuItem.Text = "&Delete";
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
            this.addToolStripMenuItem,
            this.editGroupToolStripMenuItem,
            this.toolStripMenuItem4,
            this.deleteGroupToolStripMenuItem});
            this.selectedGroupContextMenuStrip.Name = "selectedToolContextMenuStrip";
            this.selectedGroupContextMenuStrip.Size = new System.Drawing.Size(108, 76);
            this.selectedGroupContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.selectedGroupContextMenuStrip_ItemClicked);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolToolStripMenuItem,
            this.addChildGroupToolStripMenuItem});
            this.addToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "&Add";
            this.addToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.selectedGroupContextMenuStrip_ItemClicked);
            // 
            // addToolToolStripMenuItem
            // 
            this.addToolToolStripMenuItem.Name = "addToolToolStripMenuItem";
            this.addToolToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.addToolToolStripMenuItem.Text = "&Tool";
            // 
            // addChildGroupToolStripMenuItem
            // 
            this.addChildGroupToolStripMenuItem.Name = "addChildGroupToolStripMenuItem";
            this.addChildGroupToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.addChildGroupToolStripMenuItem.Text = "&Child group";
            // 
            // editGroupToolStripMenuItem
            // 
            this.editGroupToolStripMenuItem.Image = global::CPECentral.Properties.Resources.EditIcon_16x16;
            this.editGroupToolStripMenuItem.Name = "editGroupToolStripMenuItem";
            this.editGroupToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editGroupToolStripMenuItem.Text = "Edit";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(104, 6);
            // 
            // deleteGroupToolStripMenuItem
            // 
            this.deleteGroupToolStripMenuItem.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
            this.deleteGroupToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteGroupToolStripMenuItem.Text = "&Delete";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(150, 22);
            this.tabControl.Location = new System.Drawing.Point(0, 52);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(1101, 580);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolLibraryView);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1093, 550);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tools";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolLibraryView
            // 
            this.toolLibraryView.AllowDrop = true;
            this.toolLibraryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolLibraryView.EnableEditing = true;
            this.toolLibraryView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolLibraryView.GroupTreeContextMenuStrip = this.groupTreeContextMenuStrip;
            this.toolLibraryView.Location = new System.Drawing.Point(3, 3);
            this.toolLibraryView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolLibraryView.Name = "toolLibraryView";
            this.toolLibraryView.SelectedGroupContextMenuStrip = this.selectedGroupContextMenuStrip;
            this.toolLibraryView.SelectedToolContextMenuStrip = this.selectedToolContextMenuStrip;
            this.toolLibraryView.Size = new System.Drawing.Size(1087, 544);
            this.toolLibraryView.TabIndex = 3;
            this.toolLibraryView.ToolListContextMenuStrip = null;
            this.toolLibraryView.ToolActivated += new System.EventHandler<CPECentral.CustomEventArgs.ToolEventArgs>(this.toolLibraryView_ToolActivated);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1093, 550);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Holders";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ToolManagementDialog
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 654);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip);
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
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.selectedToolContextMenuStrip.ResumeLayout(false);
            this.groupTreeContextMenuStrip.ResumeLayout(false);
            this.selectedGroupContextMenuStrip.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Views.ToolLibraryView toolLibraryView;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip selectedToolContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip groupTreeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newGroupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip selectedGroupContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem deleteGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshLibraryToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addChildGroupToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem addRootGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem childGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem rootGroupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem childGroupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}