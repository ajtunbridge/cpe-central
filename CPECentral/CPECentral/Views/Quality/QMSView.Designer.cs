namespace CPECentral.Views
{
    partial class QMSView
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gaugeManagementView1 = new CPECentral.Views.Quality.GaugeManagementView();
            this.complaintStatisticsView1 = new CPECentral.Views.ComplaintStatisticsView();
            this.complaintTrendsView1 = new CPECentral.Views.Quality.ComplaintTrendsView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1404, 832);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gaugeManagementView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1396, 794);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gauges";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1396, 794);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Maintenance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.complaintTrendsView1);
            this.tabPage3.Controls.Add(this.complaintStatisticsView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1396, 794);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Metrics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gaugeManagementView1
            // 
            this.gaugeManagementView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeManagementView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaugeManagementView1.Location = new System.Drawing.Point(3, 3);
            this.gaugeManagementView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gaugeManagementView1.Name = "gaugeManagementView1";
            this.gaugeManagementView1.Size = new System.Drawing.Size(1390, 788);
            this.gaugeManagementView1.TabIndex = 0;
            // 
            // complaintStatisticsView1
            // 
            this.complaintStatisticsView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.complaintStatisticsView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.complaintStatisticsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complaintStatisticsView1.Location = new System.Drawing.Point(3, 3);
            this.complaintStatisticsView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.complaintStatisticsView1.MinimumSize = new System.Drawing.Size(670, 350);
            this.complaintStatisticsView1.Name = "complaintStatisticsView1";
            this.complaintStatisticsView1.Size = new System.Drawing.Size(763, 788);
            this.complaintStatisticsView1.TabIndex = 0;
            // 
            // complaintTrendsView1
            // 
            this.complaintTrendsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.complaintTrendsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complaintTrendsView1.Location = new System.Drawing.Point(766, 3);
            this.complaintTrendsView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.complaintTrendsView1.Name = "complaintTrendsView1";
            this.complaintTrendsView1.Size = new System.Drawing.Size(627, 788);
            this.complaintTrendsView1.TabIndex = 1;
            // 
            // QMSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QMSView";
            this.Size = new System.Drawing.Size(1404, 832);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Quality.GaugeManagementView gaugeManagementView1;
        private Quality.ComplaintTrendsView complaintTrendsView1;
        private ComplaintStatisticsView complaintStatisticsView1;
    }
}
