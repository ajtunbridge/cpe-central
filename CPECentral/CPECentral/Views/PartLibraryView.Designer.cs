namespace CPECentral.Views
{
    partial class PartLibraryView
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
            this.enhancedTreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.enhancedTreeView = new nGenLibrary.Controls.EnhancedTreeView();
            this.SuspendLayout();
            // 
            // enhancedTreeViewImageList
            // 
            this.enhancedTreeViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.enhancedTreeViewImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.enhancedTreeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // enhancedTreeView
            // 
            this.enhancedTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhancedTreeView.ImageIndex = 0;
            this.enhancedTreeView.ImageList = this.enhancedTreeViewImageList;
            this.enhancedTreeView.Location = new System.Drawing.Point(0, 0);
            this.enhancedTreeView.Name = "enhancedTreeView";
            this.enhancedTreeView.SelectedImageIndex = 0;
            this.enhancedTreeView.Size = new System.Drawing.Size(215, 280);
            this.enhancedTreeView.TabIndex = 0;
            this.enhancedTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.enhancedTreeView_AfterSelect);
            // 
            // PartLibraryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.enhancedTreeView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PartLibraryView";
            this.Size = new System.Drawing.Size(215, 280);
            this.Load += new System.EventHandler(this.PartLibraryView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private nGenLibrary.Controls.EnhancedTreeView enhancedTreeView;
        private System.Windows.Forms.ImageList enhancedTreeViewImageList;
    }
}
