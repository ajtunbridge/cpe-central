namespace CPECentral.Controls
{
    partial class AvalonNcEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvalonNcEditor));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.languageToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.findReplaceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.transmitToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.receiveToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.gotoNextToolCallToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.versionHistoryDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.languageToolStripComboBox,
            this.toolStripSeparator,
            this.saveToolStripButton,
            this.toolStripSeparator4,
            this.findReplaceToolStripButton,
            this.toolStripSeparator5,
            this.transmitToolStripDropDownButton,
            this.receiveToolStripDropDownButton,
            this.toolStripSeparator2,
            this.gotoNextToolCallToolStripButton,
            this.toolStripSeparator3,
            this.printToolStripButton,
            this.toolStripSeparator1,
            this.versionHistoryDropDownButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(810, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = "Language";
            // 
            // languageToolStripComboBox
            // 
            this.languageToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageToolStripComboBox.MaxDropDownItems = 3;
            this.languageToolStripComboBox.Name = "languageToolStripComboBox";
            this.languageToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.languageToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageToolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Enabled = false;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // findReplaceToolStripButton
            // 
            this.findReplaceToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findReplaceToolStripButton.Image = global::CPECentral.Properties.Resources.ReplaceTextIcon_16x16;
            this.findReplaceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findReplaceToolStripButton.Name = "findReplaceToolStripButton";
            this.findReplaceToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.findReplaceToolStripButton.Text = "Find and replace text";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // transmitToolStripDropDownButton
            // 
            this.transmitToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.transmitToolStripDropDownButton.Image = global::CPECentral.Properties.Resources.UploadIcon_16x16;
            this.transmitToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transmitToolStripDropDownButton.Name = "transmitToolStripDropDownButton";
            this.transmitToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.transmitToolStripDropDownButton.Text = "Transmit";
            this.transmitToolStripDropDownButton.ToolTipText = "Transmit this program to a machine";
            this.transmitToolStripDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.transmitToolStripDropDownButton_DropDownItemClicked);
            // 
            // receiveToolStripDropDownButton
            // 
            this.receiveToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.receiveToolStripDropDownButton.Image = global::CPECentral.Properties.Resources.DownloadIcon_16x16;
            this.receiveToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.receiveToolStripDropDownButton.Name = "receiveToolStripDropDownButton";
            this.receiveToolStripDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.receiveToolStripDropDownButton.Text = "Receive";
            this.receiveToolStripDropDownButton.ToolTipText = "Receive program from machine";
            this.receiveToolStripDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.receiveToolStripDropDownButton_DropDownItemClicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // gotoNextToolCallToolStripButton
            // 
            this.gotoNextToolCallToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gotoNextToolCallToolStripButton.Image = global::CPECentral.Properties.Resources.NextToolIcon_16x16;
            this.gotoNextToolCallToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gotoNextToolCallToolStripButton.Name = "gotoNextToolCallToolStripButton";
            this.gotoNextToolCallToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.gotoNextToolCallToolStripButton.Text = "Goto next tool call";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.toolListToolStripMenuItem});
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(29, 22);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.printToolStripButton_DropDownItemClicked);
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.programToolStripMenuItem.Text = "&Program";
            // 
            // toolListToolStripMenuItem
            // 
            this.toolListToolStripMenuItem.Name = "toolListToolStripMenuItem";
            this.toolListToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.toolListToolStripMenuItem.Text = "&Tool list";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // versionHistoryDropDownButton
            // 
            this.versionHistoryDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.versionHistoryDropDownButton.Image = global::CPECentral.Properties.Resources.ScanServerIcon_16x16;
            this.versionHistoryDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.versionHistoryDropDownButton.Name = "versionHistoryDropDownButton";
            this.versionHistoryDropDownButton.Size = new System.Drawing.Size(29, 22);
            this.versionHistoryDropDownButton.Text = "toolStripDropDownButton1";
            this.versionHistoryDropDownButton.ToolTipText = "Version history";
            this.versionHistoryDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.versionHistoryDropDownButton_DropDownItemClicked);
            this.versionHistoryDropDownButton.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // AvalonNcEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AvalonNcEditor";
            this.Size = new System.Drawing.Size(810, 488);
            this.Load += new System.EventHandler(this.AvalonNcEditor_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox languageToolStripComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton gotoNextToolCallToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton transmitToolStripDropDownButton;
        private System.Windows.Forms.ToolStripDropDownButton receiveToolStripDropDownButton;
        private System.Windows.Forms.ToolStripDropDownButton printToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolListToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton findReplaceToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripDropDownButton versionHistoryDropDownButton;
    }
}
