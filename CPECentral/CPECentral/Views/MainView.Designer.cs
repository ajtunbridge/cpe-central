namespace CPECentral.Views
{
    partial class MainView
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
            this.partLibraryView = new CPECentral.Views.PartLibraryView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.logoutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.documentTransferStatusStrip = new System.Windows.Forms.StatusStrip();
            this.documentTransferStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.documentTransferToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librarySelectionPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip.SuspendLayout();
            this.documentTransferStatusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // partLibraryView
            // 
            this.partLibraryView.BackColor = System.Drawing.SystemColors.Control;
            this.partLibraryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partLibraryView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partLibraryView.Location = new System.Drawing.Point(0, 0);
            this.partLibraryView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.partLibraryView.Name = "partLibraryView";
            this.partLibraryView.Size = new System.Drawing.Size(186, 350);
            this.partLibraryView.TabIndex = 0;
            this.partLibraryView.CustomerSelected += new System.EventHandler<CPECentral.CustomEventArgs.CustomerEventArgs>(this.partLibraryView_CustomerSelected);
            this.partLibraryView.PartSelected += new System.EventHandler<CPECentral.CustomEventArgs.PartEventArgs>(this.partLibraryView_PartSelected);
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 25);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(694, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // logoutToolStripButton
            // 
            this.logoutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logoutToolStripButton.Image = global::CPECentral.Properties.Resources.LogoutIcon_16x16;
            this.logoutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logoutToolStripButton.Name = "logoutToolStripButton";
            this.logoutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.logoutToolStripButton.Text = "Logout";
            // 
            // documentTransferStatusStrip
            // 
            this.documentTransferStatusStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentTransferStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentTransferStatusLabel,
            this.documentTransferToolStripProgressBar});
            this.documentTransferStatusStrip.Location = new System.Drawing.Point(0, 400);
            this.documentTransferStatusStrip.Name = "documentTransferStatusStrip";
            this.documentTransferStatusStrip.Size = new System.Drawing.Size(694, 22);
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
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(694, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPartToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // addNewPartToolStripMenuItem
            // 
            this.addNewPartToolStripMenuItem.Name = "addNewPartToolStripMenuItem";
            this.addNewPartToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addNewPartToolStripMenuItem.Text = "&Add new part";
            this.addNewPartToolStripMenuItem.Click += new System.EventHandler(this.MainMenuStrip_ItemClicked);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // librarySelectionPanel
            // 
            this.librarySelectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.librarySelectionPanel.Location = new System.Drawing.Point(0, 0);
            this.librarySelectionPanel.Name = "librarySelectionPanel";
            this.librarySelectionPanel.Size = new System.Drawing.Size(503, 350);
            this.librarySelectionPanel.TabIndex = 4;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 50);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.partLibraryView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.librarySelectionPanel);
            this.splitContainer.Size = new System.Drawing.Size(694, 350);
            this.splitContainer.SplitterDistance = 186;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 5;
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 422);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(694, 22);
            this.mainStatusStrip.TabIndex = 6;
            this.mainStatusStrip.Text = "statusStrip2";
            // 
            // mainToolStripStatusLabel
            // 
            this.mainToolStripStatusLabel.Name = "mainToolStripStatusLabel";
            this.mainToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.documentTransferStatusStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(694, 444);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.documentTransferStatusStrip.ResumeLayout(false);
            this.documentTransferStatusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PartLibraryView partLibraryView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip documentTransferStatusStrip;
        private System.Windows.Forms.Panel librarySelectionPanel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem addNewPartToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel documentTransferStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar documentTransferToolStripProgressBar;
        private System.Windows.Forms.ToolStripButton logoutToolStripButton;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel mainToolStripStatusLabel;
    }
}
