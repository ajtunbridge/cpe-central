namespace CPECentral.Dialogs
{
    partial class StockLevelsDialog
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
            this.enhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // enhancedListView
            // 
            this.enhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.enhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.enhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhancedListView.EnsureSelection = false;
            this.enhancedListView.FullRowSelect = true;
            this.enhancedListView.IndexOfColumnToResize = 2;
            this.enhancedListView.ItemContextMenuStrip = null;
            this.enhancedListView.Location = new System.Drawing.Point(0, 0);
            this.enhancedListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.enhancedListView.Name = "enhancedListView";
            this.enhancedListView.ResizeColumnToFill = true;
            this.enhancedListView.Size = new System.Drawing.Size(588, 336);
            this.enhancedListView.TabIndex = 0;
            this.enhancedListView.UseAlternatingBackColor = true;
            this.enhancedListView.UseCompatibleStateImageBehavior = false;
            this.enhancedListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Batch number";
            this.columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Location";
            this.columnHeader3.Width = 356;
            // 
            // StockLevelsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 336);
            this.Controls.Add(this.enhancedListView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockLevelsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock levels";
            this.Load += new System.EventHandler(this.StockLevelsDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private nGenLibrary.Controls.EnhancedListView enhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}