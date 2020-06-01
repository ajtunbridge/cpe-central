namespace CPECentral.Views
{
    sealed partial class MainView
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.switchUserToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addPartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolManagementToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.superDumpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.logoutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.documentTransferStatusStrip = new System.Windows.Forms.StatusStrip();
            this.documentTransferStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.documentTransferToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.employeeSessionPanel = new System.Windows.Forms.Panel();
            this.toolStrip.SuspendLayout();
            this.documentTransferStatusStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchUserToolStripDropDownButton,
            this.toolStripSeparator1,
            this.addPartToolStripButton,
            this.toolStripSeparator5,
            this.toolManagementToolStripButton,
            this.toolStripSeparator4,
            this.settingsToolStripButton,
            this.toolStripSeparator2,
            this.logoutToolStripButton,
            this.toolStripSeparator3,
            this.superDumpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1214, 50);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // switchUserToolStripDropDownButton
            // 
            this.switchUserToolStripDropDownButton.Enabled = false;
            this.switchUserToolStripDropDownButton.Image = global::CPECentral.Properties.Resources.SwitchUserIcon_32x32;
            this.switchUserToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.switchUserToolStripDropDownButton.Name = "switchUserToolStripDropDownButton";
            this.switchUserToolStripDropDownButton.Size = new System.Drawing.Size(118, 47);
            this.switchUserToolStripDropDownButton.Text = "  Switch user";
            this.switchUserToolStripDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.switchUserToolStripDropDownButton_DropDownItemClicked);
            this.switchUserToolStripDropDownButton.Click += new System.EventHandler(this.logoutToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // addPartToolStripButton
            // 
            this.addPartToolStripButton.AutoToolTip = false;
            this.addPartToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_32x32;
            this.addPartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addPartToolStripButton.Name = "addPartToolStripButton";
            this.addPartToolStripButton.Size = new System.Drawing.Size(95, 47);
            this.addPartToolStripButton.Text = "  Add part";
            this.addPartToolStripButton.ToolTipText = "Add a new part to the library";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 50);
            // 
            // toolManagementToolStripButton
            // 
            this.toolManagementToolStripButton.Image = global::CPECentral.Properties.Resources.StartPageFindToolBoxViewIcon_32x32;
            this.toolManagementToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolManagementToolStripButton.Name = "toolManagementToolStripButton";
            this.toolManagementToolStripButton.Size = new System.Drawing.Size(145, 47);
            this.toolManagementToolStripButton.Text = "  Tool management";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 50);
            // 
            // settingsToolStripButton
            // 
            this.settingsToolStripButton.Image = global::CPECentral.Properties.Resources.SettingsIcon_32x32;
            this.settingsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsToolStripButton.Name = "settingsToolStripButton";
            this.settingsToolStripButton.Size = new System.Drawing.Size(85, 47);
            this.settingsToolStripButton.Text = "Settings";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // superDumpToolStripButton
            // 
            this.superDumpToolStripButton.Image = global::CPECentral.Properties.Resources.SuperDumpLogo;
            this.superDumpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.superDumpToolStripButton.Name = "superDumpToolStripButton";
            this.superDumpToolStripButton.Size = new System.Drawing.Size(115, 47);
            this.superDumpToolStripButton.Text = "SuperDump™";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 50);
            // 
            // logoutToolStripButton
            // 
            this.logoutToolStripButton.Image = global::CPECentral.Properties.Resources.LogoutIcon_32x32;
            this.logoutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logoutToolStripButton.Name = "logoutToolStripButton";
            this.logoutToolStripButton.Size = new System.Drawing.Size(81, 47);
            this.logoutToolStripButton.Text = "Logout";
            this.logoutToolStripButton.ToolTipText = "Logout of your session";
            this.logoutToolStripButton.Click += new System.EventHandler(this.logoutToolStripButton_Click);
            // 
            // documentTransferStatusStrip
            // 
            this.documentTransferStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentTransferStatusLabel,
            this.documentTransferToolStripProgressBar});
            this.documentTransferStatusStrip.Location = new System.Drawing.Point(0, 841);
            this.documentTransferStatusStrip.Name = "documentTransferStatusStrip";
            this.documentTransferStatusStrip.Size = new System.Drawing.Size(1214, 22);
            this.documentTransferStatusStrip.SizingGrip = false;
            this.documentTransferStatusStrip.TabIndex = 3;
            this.documentTransferStatusStrip.Text = "statusStrip1";
            // 
            // documentTransferStatusLabel
            // 
            this.documentTransferStatusLabel.Name = "documentTransferStatusLabel";
            this.documentTransferStatusLabel.Size = new System.Drawing.Size(173, 17);
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
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 863);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1214, 22);
            this.mainStatusStrip.TabIndex = 6;
            this.mainStatusStrip.Text = "statusStrip2";
            // 
            // mainToolStripStatusLabel
            // 
            this.mainToolStripStatusLabel.Name = "mainToolStripStatusLabel";
            this.mainToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // employeeSessionPanel
            // 
            this.employeeSessionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeSessionPanel.Location = new System.Drawing.Point(0, 50);
            this.employeeSessionPanel.Name = "employeeSessionPanel";
            this.employeeSessionPanel.Size = new System.Drawing.Size(1214, 791);
            this.employeeSessionPanel.TabIndex = 7;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.employeeSessionPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.documentTransferStatusStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(1214, 885);
            this.Load += new System.EventHandler(this.MainView2_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.documentTransferStatusStrip.ResumeLayout(false);
            this.documentTransferStatusStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip documentTransferStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel documentTransferStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar documentTransferToolStripProgressBar;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel mainToolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton addPartToolStripButton;
        private System.Windows.Forms.ToolStripButton toolManagementToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton switchUserToolStripDropDownButton;
        private System.Windows.Forms.Panel employeeSessionPanel;
        private System.Windows.Forms.ToolStripButton superDumpToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton settingsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton logoutToolStripButton;
    }
}
