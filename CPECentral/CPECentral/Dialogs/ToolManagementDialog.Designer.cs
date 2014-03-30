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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolsView = new CPECentral.Views.ToolsView();
            this.toolGroupsView = new CPECentral.Views.ToolGroupsView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.holderToolsView = new CPECentral.Views.HolderToolsView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.holdersView = new CPECentral.Views.HoldersView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(864, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(864, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolsView
            // 
            this.toolsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsView.EditMode = true;
            this.toolsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsView.Location = new System.Drawing.Point(253, 3);
            this.toolsView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.toolsView.Name = "toolsView";
            this.toolsView.Size = new System.Drawing.Size(600, 451);
            this.toolsView.TabIndex = 4;
            // 
            // toolGroupsView
            // 
            this.toolGroupsView.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolGroupsView.EditMode = true;
            this.toolGroupsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolGroupsView.Location = new System.Drawing.Point(3, 3);
            this.toolGroupsView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.toolGroupsView.Name = "toolGroupsView";
            this.toolGroupsView.Size = new System.Drawing.Size(250, 451);
            this.toolGroupsView.TabIndex = 3;
            this.toolGroupsView.ToolGroupSelected += new System.EventHandler<CPECentral.CustomEventArgs.ToolGroupEventArgs>(this.toolGroupsView_ToolGroupSelected);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(125, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 487);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.toolsView);
            this.tabPage1.Controls.Add(this.toolGroupsView);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(856, 457);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tools";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(253, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 451);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.holderToolsView);
            this.tabPage2.Controls.Add(this.splitter2);
            this.tabPage2.Controls.Add(this.holdersView);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(856, 457);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Holders";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // holderToolsView
            // 
            this.holderToolsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holderToolsView.Enabled = false;
            this.holderToolsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holderToolsView.Location = new System.Drawing.Point(256, 3);
            this.holderToolsView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.holderToolsView.Name = "holderToolsView";
            this.holderToolsView.Size = new System.Drawing.Size(597, 451);
            this.holderToolsView.TabIndex = 2;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(253, 3);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 451);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // holdersView
            // 
            this.holdersView.Dock = System.Windows.Forms.DockStyle.Left;
            this.holdersView.EditMode = true;
            this.holdersView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holdersView.Location = new System.Drawing.Point(3, 3);
            this.holdersView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.holdersView.Name = "holdersView";
            this.holdersView.Size = new System.Drawing.Size(250, 451);
            this.holdersView.TabIndex = 0;
            this.holdersView.HolderSelectionChanged += new System.EventHandler<CPECentral.CustomEventArgs.HolderEventArgs>(this.HoldersView_HolderSelectionChanged);
            // 
            // ToolManagementDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 561);
            this.Controls.Add(this.tabControl1);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolManagementDialog_FormClosing);
            this.Load += new System.EventHandler(this.ToolManagementDialog_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Views.ToolGroupsView toolGroupsView;
        private Views.ToolsView toolsView;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Splitter splitter2;
        private Views.HoldersView holdersView;
        private Views.HolderToolsView holderToolsView;
    }
}