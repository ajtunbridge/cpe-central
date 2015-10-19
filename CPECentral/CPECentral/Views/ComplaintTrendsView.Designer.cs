namespace CPECentral.Views
{
    partial class ComplaintTrendsView
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2008D, "1,0,0");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2009D, "8,0,0");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2010D, "2,0,0");
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2011D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2012D, 6D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2013D, 3D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2008D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2009D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2010D, 4D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2011D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2012D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2013D, 4D);
            this.complaintCategoryTrendChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.timePeriodComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.complaintCategoryTrendChart)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // complaintCategoryTrendChart
            // 
            this.complaintCategoryTrendChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.complaintCategoryTrendChart.BorderlineColor = System.Drawing.Color.Black;
            this.complaintCategoryTrendChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Area3DStyle.Inclination = 20;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Area3DStyle.Rotation = 0;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.Name = "ChartArea1";
            this.complaintCategoryTrendChart.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Segoe UI", 8F);
            legend1.IsEquallySpacedItems = true;
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            legend1.Title = "Categories";
            legend1.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.complaintCategoryTrendChart.Legends.Add(legend1);
            this.complaintCategoryTrendChart.Location = new System.Drawing.Point(5, 5);
            this.complaintCategoryTrendChart.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.complaintCategoryTrendChart.Name = "complaintCategoryTrendChart";
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.LabelFormat = "{0}";
            series1.Legend = "Legend1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Plating issues";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            series1.YValuesPerPoint = 3;
            series2.BorderWidth = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.LabelBackColor = System.Drawing.Color.White;
            series2.LabelFormat = "{0}";
            series2.Legend = "Legend1";
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Dimensional error";
            series2.Points.Add(dataPoint7);
            series2.Points.Add(dataPoint8);
            series2.Points.Add(dataPoint9);
            series2.Points.Add(dataPoint10);
            series2.Points.Add(dataPoint11);
            series2.Points.Add(dataPoint12);
            this.complaintCategoryTrendChart.Series.Add(series1);
            this.complaintCategoryTrendChart.Series.Add(series2);
            this.complaintCategoryTrendChart.Size = new System.Drawing.Size(652, 225);
            this.complaintCategoryTrendChart.TabIndex = 0;
            this.complaintCategoryTrendChart.Text = "chart1";
            this.complaintCategoryTrendChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.complaintCategoryTrendChart_MouseMove);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.complaintCategoryTrendChart, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(5, 42);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(662, 705);
            this.tableLayoutPanel.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(554, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 29);
            this.button1.TabIndex = 15;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Time period";
            // 
            // timePeriodComboBox
            // 
            this.timePeriodComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timePeriodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timePeriodComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePeriodComboBox.FormattingEnabled = true;
            this.timePeriodComboBox.Items.AddRange(new object[] {
            "This month",
            "Past 3 months",
            "Past 6 months",
            "Past year",
            "All time"});
            this.timePeriodComboBox.Location = new System.Drawing.Point(390, 12);
            this.timePeriodComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timePeriodComboBox.Name = "timePeriodComboBox";
            this.timePeriodComboBox.Size = new System.Drawing.Size(157, 25);
            this.timePeriodComboBox.TabIndex = 13;
            // 
            // ComplaintTrendsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timePeriodComboBox);
            this.Font = new System.Drawing.Font("Bell MT", 8.25F);
            this.Name = "ComplaintTrendsView";
            this.Size = new System.Drawing.Size(672, 752);
            ((System.ComponentModel.ISupportInitialize)(this.complaintCategoryTrendChart)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart complaintCategoryTrendChart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox timePeriodComboBox;
    }
}
