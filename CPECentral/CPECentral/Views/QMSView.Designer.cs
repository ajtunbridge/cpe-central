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
            this.complaintStatisticsView1 = new CPECentral.Views.ComplaintStatisticsView();
            this.qmsMetrologyEquipmentView1 = new CPECentral.Views.GaugesView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.complaintStatisticsView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.qmsMetrologyEquipmentView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1508, 974);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // complaintStatisticsView1
            // 
            this.complaintStatisticsView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.complaintStatisticsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.complaintStatisticsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complaintStatisticsView1.Location = new System.Drawing.Point(10, 497);
            this.complaintStatisticsView1.Margin = new System.Windows.Forms.Padding(10);
            this.complaintStatisticsView1.MinimumSize = new System.Drawing.Size(670, 350);
            this.complaintStatisticsView1.Name = "complaintStatisticsView1";
            this.complaintStatisticsView1.Size = new System.Drawing.Size(734, 467);
            this.complaintStatisticsView1.TabIndex = 2;
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(757, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
        private GaugesView qmsMetrologyEquipmentView1;
        private ComplaintStatisticsView complaintStatisticsView1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
