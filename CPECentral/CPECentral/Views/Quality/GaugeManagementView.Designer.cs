namespace CPECentral.Views.Quality
{
    partial class GaugeManagementView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gaugesView = new CPECentral.Views.Quality.GaugesView();
            this.gaugeDataView1 = new CPECentral.Views.Quality.GaugeDataView();
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
            this.splitContainer1.Panel1.Controls.Add(this.gaugesView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gaugeDataView1);
            this.splitContainer1.Size = new System.Drawing.Size(1436, 810);
            this.splitContainer1.SplitterDistance = 603;
            this.splitContainer1.TabIndex = 0;
            // 
            // gaugesView
            // 
            this.gaugesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugesView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugesView.Location = new System.Drawing.Point(0, 0);
            this.gaugesView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gaugesView.Name = "gaugesView";
            this.gaugesView.Size = new System.Drawing.Size(603, 810);
            this.gaugesView.TabIndex = 0;
            this.gaugesView.GaugeSelected += new System.EventHandler<CPECentral.CustomEventArgs.GaugeEventArgs>(this.gaugesView_GaugeSelected);
            // 
            // gaugeDataView1
            // 
            this.gaugeDataView1.BackColor = System.Drawing.Color.White;
            this.gaugeDataView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeDataView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeDataView1.Location = new System.Drawing.Point(0, 0);
            this.gaugeDataView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gaugeDataView1.Name = "gaugeDataView1";
            this.gaugeDataView1.Size = new System.Drawing.Size(829, 810);
            this.gaugeDataView1.TabIndex = 0;
            // 
            // GaugeManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GaugeManagementView";
            this.Size = new System.Drawing.Size(1436, 810);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private GaugesView gaugesView;
        private GaugeDataView gaugeDataView1;
    }
}
