namespace CPECentral.Views
{
    sealed partial class PartWorksOrdersView
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
            this.worksOrdersObjectListView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.worksOrdersObjectListView)).BeginInit();
            this.SuspendLayout();
            // 
            // worksOrdersObjectListView
            // 
            this.worksOrdersObjectListView.AllColumns.Add(this.olvColumn1);
            this.worksOrdersObjectListView.AllColumns.Add(this.olvColumn2);
            this.worksOrdersObjectListView.AllColumns.Add(this.olvColumn6);
            this.worksOrdersObjectListView.AllColumns.Add(this.olvColumn3);
            this.worksOrdersObjectListView.AllColumns.Add(this.olvColumn4);
            this.worksOrdersObjectListView.AllColumns.Add(this.olvColumn5);
            this.worksOrdersObjectListView.AlternateRowBackColor = System.Drawing.Color.Ivory;
            this.worksOrdersObjectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn6,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5});
            this.worksOrdersObjectListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worksOrdersObjectListView.EmptyListMsgFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.worksOrdersObjectListView.FullRowSelect = true;
            this.worksOrdersObjectListView.HasCollapsibleGroups = false;
            this.worksOrdersObjectListView.Location = new System.Drawing.Point(0, 0);
            this.worksOrdersObjectListView.Name = "worksOrdersObjectListView";
            this.worksOrdersObjectListView.ShowGroups = false;
            this.worksOrdersObjectListView.Size = new System.Drawing.Size(472, 269);
            this.worksOrdersObjectListView.TabIndex = 0;
            this.worksOrdersObjectListView.UseAlternatingBackColors = true;
            this.worksOrdersObjectListView.UseCompatibleStateImageBehavior = false;
            this.worksOrdersObjectListView.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "WorksOrderNumber";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.FillsFreeSpace = true;
            this.olvColumn1.Text = "WO#";
            this.olvColumn1.Width = 75;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "DueOn";
            this.olvColumn2.AspectToStringFormat = "{0:dd/MM/yyyy}";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.FillsFreeSpace = true;
            this.olvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Text = "Delivery";
            this.olvColumn2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn2.Width = 100;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Quantity";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.FillsFreeSpace = true;
            this.olvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Text = "Order qty";
            this.olvColumn3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn3.Width = 80;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "BuildQuantity";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.FillsFreeSpace = true;
            this.olvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Text = "Build qty";
            this.olvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Width = 80;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "OrderNumber";
            this.olvColumn5.CellPadding = null;
            this.olvColumn5.FillsFreeSpace = true;
            this.olvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Text = "Order number";
            this.olvColumn5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn5.Width = 130;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "Version";
            this.olvColumn6.CellPadding = null;
            this.olvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Text = "Version";
            this.olvColumn6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PartWorksOrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.worksOrdersObjectListView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PartWorksOrdersView";
            this.Size = new System.Drawing.Size(472, 269);
            ((System.ComponentModel.ISupportInitialize)(this.worksOrdersObjectListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView worksOrdersObjectListView;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
    }
}
