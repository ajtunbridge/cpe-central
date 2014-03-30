namespace nGenLibrary.Controls
{
    partial class EnhancedListView
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
            this.SuspendLayout();
            // 
            // EnhancedListView
            // 
            this.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.EnhancedListView_ItemSelectionChanged);
            this.ClientSizeChanged += new System.EventHandler(this.EnhancedListView_ClientSizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnhancedListView_KeyDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EnhancedListView_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
