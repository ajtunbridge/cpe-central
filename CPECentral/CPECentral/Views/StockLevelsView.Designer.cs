namespace CPECentral.Views
{
    partial class StockLevelsView
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
            this.stockLevelsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // stockLevelsEnhancedListView
            // 
            this.stockLevelsEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.stockLevelsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.stockLevelsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockLevelsEnhancedListView.EnsureSelection = false;
            this.stockLevelsEnhancedListView.FullRowSelect = true;
            this.stockLevelsEnhancedListView.GridLines = true;
            this.stockLevelsEnhancedListView.IndexOfColumnToResize = 2;
            this.stockLevelsEnhancedListView.ItemContextMenuStrip = null;
            this.stockLevelsEnhancedListView.Location = new System.Drawing.Point(0, 0);
            this.stockLevelsEnhancedListView.Name = "stockLevelsEnhancedListView";
            this.stockLevelsEnhancedListView.ResizeColumnToFill = true;
            this.stockLevelsEnhancedListView.Size = new System.Drawing.Size(548, 171);
            this.stockLevelsEnhancedListView.TabIndex = 0;
            this.stockLevelsEnhancedListView.UseAlternatingBackColor = true;
            this.stockLevelsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.stockLevelsEnhancedListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Batch number";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Location";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 316;
            // 
            // StockLevelsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stockLevelsEnhancedListView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StockLevelsView";
            this.Size = new System.Drawing.Size(548, 171);
            this.ResumeLayout(false);

        }

        #endregion

        private nGenLibrary.Controls.EnhancedListView stockLevelsEnhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}
