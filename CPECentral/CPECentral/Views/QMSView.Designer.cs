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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.qmsMetrologyEquipmentView1 = new CPECentral.Views.QMSMetrologyEquipmentView();
            this.complaintStatisticsView1 = new CPECentral.Views.ComplaintStatisticsView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.qmsMetrologyEquipmentView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.complaintStatisticsView1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1508, 974);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // qmsMetrologyEquipmentView1
            // 
            this.qmsMetrologyEquipmentView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.qmsMetrologyEquipmentView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qmsMetrologyEquipmentView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qmsMetrologyEquipmentView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qmsMetrologyEquipmentView1.Location = new System.Drawing.Point(10, 10);
            this.qmsMetrologyEquipmentView1.Margin = new System.Windows.Forms.Padding(10);
            this.qmsMetrologyEquipmentView1.Name = "qmsMetrologyEquipmentView1";
            this.qmsMetrologyEquipmentView1.Size = new System.Drawing.Size(734, 467);
            this.qmsMetrologyEquipmentView1.TabIndex = 0;
            // 
            // complaintStatisticsView1
            // 
            this.complaintStatisticsView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.complaintStatisticsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.complaintStatisticsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complaintStatisticsView1.Location = new System.Drawing.Point(764, 10);
            this.complaintStatisticsView1.Margin = new System.Windows.Forms.Padding(10);
            this.complaintStatisticsView1.MinimumSize = new System.Drawing.Size(670, 470);
            this.complaintStatisticsView1.Name = "complaintStatisticsView1";
            this.complaintStatisticsView1.Size = new System.Drawing.Size(734, 470);
            this.complaintStatisticsView1.TabIndex = 1;
            // 
            // QMSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QMSView";
            this.Size = new System.Drawing.Size(1508, 974);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private QMSMetrologyEquipmentView qmsMetrologyEquipmentView1;
        private ComplaintStatisticsView complaintStatisticsView1;
    }
}
