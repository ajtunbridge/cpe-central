namespace CPECentral.Dialogs
{
    partial class NonConformanceViewerDialog
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nonConformanceSelectorView = new CPECentral.Views.NonConformanceSelectorView();
            this.nonConformanceView1 = new CPECentral.Views.NonConformanceView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.nonConformanceSelectorView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nonConformanceView1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 714);
            this.splitContainer1.SplitterDistance = 532;
            this.splitContainer1.TabIndex = 2;
            // 
            // nonConformanceSelectorView
            // 
            this.nonConformanceSelectorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nonConformanceSelectorView.DrawingNumber = null;
            this.nonConformanceSelectorView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nonConformanceSelectorView.Location = new System.Drawing.Point(0, 0);
            this.nonConformanceSelectorView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nonConformanceSelectorView.Name = "nonConformanceSelectorView";
            this.nonConformanceSelectorView.Size = new System.Drawing.Size(532, 714);
            this.nonConformanceSelectorView.TabIndex = 0;
            this.nonConformanceSelectorView.NonConformanceSelected += new System.EventHandler<CPECentral.CustomEventArgs.NonConformanceEventArgs>(this.nonConformanceSelectorView_NonConformanceSelected);
            this.nonConformanceSelectorView.Load += new System.EventHandler(this.nonConformanceSelectorView_Load);
            // 
            // nonConformanceView1
            // 
            this.nonConformanceView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nonConformanceView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nonConformanceView1.Location = new System.Drawing.Point(0, 0);
            this.nonConformanceView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nonConformanceView1.Name = "nonConformanceView1";
            this.nonConformanceView1.Size = new System.Drawing.Size(648, 714);
            this.nonConformanceView1.TabIndex = 0;
            this.nonConformanceView1.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 714);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please select a report from the list to view it";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NonConformanceViewerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 714);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NonConformanceViewerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Non-conformances for {DRAWINGNUMBER}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NonConformanceViewerDialog_FormClosing);
            this.Load += new System.EventHandler(this.NonConformanceViewerDialog_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.NonConformanceSelectorView nonConformanceSelectorView;
        private Views.NonConformanceView nonConformanceView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;

    }
}