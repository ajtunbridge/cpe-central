namespace CPECentral.Dialogs
{
    partial class SettingsDialog
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Machines");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Paths");
            this.categoriesTreeView = new System.Windows.Forms.TreeView();
            this.selectedCategoryPanel = new System.Windows.Forms.Panel();
            this.okayCancelFooter = new CPECentral.Controls.OkayCancelFooter();
            this.SuspendLayout();
            // 
            // categoriesTreeView
            // 
            this.categoriesTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.categoriesTreeView.Location = new System.Drawing.Point(12, 12);
            this.categoriesTreeView.Name = "categoriesTreeView";
            treeNode1.Name = "generalTreeNode";
            treeNode1.Text = "General";
            treeNode2.Name = "machinesTreeNode";
            treeNode2.Text = "Machines";
            treeNode3.Name = "pathsTreeNode";
            treeNode3.Text = "Paths";
            this.categoriesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.categoriesTreeView.Size = new System.Drawing.Size(219, 388);
            this.categoriesTreeView.TabIndex = 0;
            this.categoriesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.categoriesTreeView_AfterSelect);
            // 
            // selectedCategoryPanel
            // 
            this.selectedCategoryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedCategoryPanel.Location = new System.Drawing.Point(237, 12);
            this.selectedCategoryPanel.Name = "selectedCategoryPanel";
            this.selectedCategoryPanel.Size = new System.Drawing.Size(547, 388);
            this.selectedCategoryPanel.TabIndex = 3;
            // 
            // okayCancelFooter
            // 
            this.okayCancelFooter.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter.Location = new System.Drawing.Point(0, 411);
            this.okayCancelFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter.Name = "okayCancelFooter";
            this.okayCancelFooter.Size = new System.Drawing.Size(792, 45);
            this.okayCancelFooter.TabIndex = 2;
            this.okayCancelFooter.OkayClicked += new System.EventHandler(this.okayCancelFooter_OkayClicked);
            this.okayCancelFooter.CancelClicked += new System.EventHandler(this.okayCancelFooter_CancelClicked);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 456);
            this.Controls.Add(this.selectedCategoryPanel);
            this.Controls.Add(this.okayCancelFooter);
            this.Controls.Add(this.categoriesTreeView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView categoriesTreeView;
        private Controls.OkayCancelFooter okayCancelFooter;
        private System.Windows.Forms.Panel selectedCategoryPanel;

    }
}