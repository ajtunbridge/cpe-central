namespace CPECentral.Views
{
    sealed partial class MainView2
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.startPageView1 = new CPECentral.Views.StartPageView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.partLibraryView = new CPECentral.Views.PartLibraryView3();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addPartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolManagementToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.logoutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.documentTransferStatusStrip = new System.Windows.Forms.StatusStrip();
            this.documentTransferStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.documentTransferToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexagonCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.documentTransferStatusStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(150, 22);
            this.tabControl.Location = new System.Drawing.Point(0, 77);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1139, 780);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.startPageView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1131, 750);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start page";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // startPageView1
            // 
            this.startPageView1.BackColor = System.Drawing.Color.White;
            this.startPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startPageView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPageView1.Location = new System.Drawing.Point(3, 3);
            this.startPageView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startPageView1.Name = "startPageView1";
            this.startPageView1.Size = new System.Drawing.Size(1125, 744);
            this.startPageView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.partLibraryView);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1131, 750);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Part library";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // partLibraryView
            // 
            this.partLibraryView.BackColor = System.Drawing.Color.White;
            this.partLibraryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partLibraryView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partLibraryView.Location = new System.Drawing.Point(3, 3);
            this.partLibraryView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.partLibraryView.MinimumSize = new System.Drawing.Size(925, 630);
            this.partLibraryView.Name = "partLibraryView";
            this.partLibraryView.Size = new System.Drawing.Size(1125, 744);
            this.partLibraryView.TabIndex = 0;
            this.partLibraryView.PartSelected += new System.EventHandler<CPECentral.CustomEventArgs.PartEventArgs>(this.partLibraryView_PartSelected);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPartToolStripButton,
            this.toolStripSeparator1,
            this.toolManagementToolStripButton,
            this.toolStripSeparator5,
            this.logoutToolStripButton,
            this.toolStripSeparator4});
            this.toolStrip.Location = new System.Drawing.Point(0, 27);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1139, 50);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // addPartToolStripButton
            // 
            this.addPartToolStripButton.AutoToolTip = false;
            this.addPartToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_32x32;
            this.addPartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addPartToolStripButton.Name = "addPartToolStripButton";
            this.addPartToolStripButton.Size = new System.Drawing.Size(98, 47);
            this.addPartToolStripButton.Text = "New part";
            this.addPartToolStripButton.ToolTipText = "Add a new part to the library";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // toolManagementToolStripButton
            // 
            this.toolManagementToolStripButton.Image = global::CPECentral.Properties.Resources.ToolsIcon_32x32;
            this.toolManagementToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolManagementToolStripButton.Name = "toolManagementToolStripButton";
            this.toolManagementToolStripButton.Size = new System.Drawing.Size(150, 47);
            this.toolManagementToolStripButton.Text = "Tool management";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 50);
            // 
            // logoutToolStripButton
            // 
            this.logoutToolStripButton.Image = global::CPECentral.Properties.Resources.LogoutIcon_32x32;
            this.logoutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logoutToolStripButton.Name = "logoutToolStripButton";
            this.logoutToolStripButton.Size = new System.Drawing.Size(85, 47);
            this.logoutToolStripButton.Text = "Logout";
            this.logoutToolStripButton.Click += new System.EventHandler(this.logoutToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 50);
            // 
            // documentTransferStatusStrip
            // 
            this.documentTransferStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentTransferStatusLabel,
            this.documentTransferToolStripProgressBar});
            this.documentTransferStatusStrip.Location = new System.Drawing.Point(0, 857);
            this.documentTransferStatusStrip.Name = "documentTransferStatusStrip";
            this.documentTransferStatusStrip.Size = new System.Drawing.Size(1139, 22);
            this.documentTransferStatusStrip.SizingGrip = false;
            this.documentTransferStatusStrip.TabIndex = 3;
            this.documentTransferStatusStrip.Text = "statusStrip1";
            // 
            // documentTransferStatusLabel
            // 
            this.documentTransferStatusLabel.Name = "documentTransferStatusLabel";
            this.documentTransferStatusLabel.Size = new System.Drawing.Size(191, 17);
            this.documentTransferStatusLabel.Text = "No documents pending upload";
            // 
            // documentTransferToolStripProgressBar
            // 
            this.documentTransferToolStripProgressBar.Name = "documentTransferToolStripProgressBar";
            this.documentTransferToolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            this.documentTransferToolStripProgressBar.Visible = false;
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 879);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1139, 22);
            this.mainStatusStrip.TabIndex = 6;
            this.mainStatusStrip.Text = "statusStrip2";
            // 
            // mainToolStripStatusLabel
            // 
            this.mainToolStripStatusLabel.Name = "mainToolStripStatusLabel";
            this.mainToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1139, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPartToolStripMenuItem,
            this.toolStripMenuItem1,
            this.logoutToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // addNewPartToolStripMenuItem
            // 
            this.addNewPartToolStripMenuItem.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addNewPartToolStripMenuItem.Name = "addNewPartToolStripMenuItem";
            this.addNewPartToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.addNewPartToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.addNewPartToolStripMenuItem.Text = "&Add new part";
            this.addNewPartToolStripMenuItem.Click += new System.EventHandler(this.MainMenuStrip_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 6);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = global::CPECentral.Properties.Resources.LogoutIcon_16x16;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.logoutToolStripMenuItem.Text = "&Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.MainMenuStrip_ItemClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.MainMenuStrip_ItemClicked);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolManagementToolStripMenuItem,
            this.toolStripSeparator3,
            this.utilitiesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // toolManagementToolStripMenuItem
            // 
            this.toolManagementToolStripMenuItem.Image = global::CPECentral.Properties.Resources.ToolIcon_16x16;
            this.toolManagementToolStripMenuItem.Name = "toolManagementToolStripMenuItem";
            this.toolManagementToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.toolManagementToolStripMenuItem.Text = "&Tool management";
            this.toolManagementToolStripMenuItem.Click += new System.EventHandler(this.MainMenuStrip_ItemClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hexagonCalculatorToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.utilitiesToolStripMenuItem.Text = "&Utilities";
            // 
            // hexagonCalculatorToolStripMenuItem
            // 
            this.hexagonCalculatorToolStripMenuItem.Image = global::CPECentral.Properties.Resources.HexagonIcon_16x16;
            this.hexagonCalculatorToolStripMenuItem.Name = "hexagonCalculatorToolStripMenuItem";
            this.hexagonCalculatorToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.hexagonCalculatorToolStripMenuItem.Text = "&Hexagon calculator";
            this.hexagonCalculatorToolStripMenuItem.Click += new System.EventHandler(this.MainMenuStrip_ItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(179, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::CPECentral.Properties.Resources.SettingsIcon_16x16;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.MainMenuStrip_ItemClicked);
            // 
            // MainView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.documentTransferStatusStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainView2";
            this.Size = new System.Drawing.Size(1139, 901);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.documentTransferStatusStrip.ResumeLayout(false);
            this.documentTransferStatusStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip documentTransferStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem addNewPartToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel documentTransferStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar documentTransferToolStripProgressBar;
        private System.Windows.Forms.ToolStripButton logoutToolStripButton;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel mainToolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton addPartToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexagonCalculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolManagementToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private StartPageView startPageView1;
        private PartLibraryView3 partLibraryView;
    }
}
