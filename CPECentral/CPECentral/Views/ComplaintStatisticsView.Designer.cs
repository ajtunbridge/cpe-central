namespace CPECentral.Views
{
    partial class ComplaintStatisticsView
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.customerPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.timePeriodComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.supplierPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.internalPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.customerPieChart)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalPieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // customerPieChart
            // 
            this.customerPieChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerPieChart.BorderlineColor = System.Drawing.Color.Black;
            this.customerPieChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 60;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Area3DStyle.Rotation = 0;
            chartArea1.Name = "ChartArea1";
            this.customerPieChart.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Segoe UI", 8F);
            legend1.IsEquallySpacedItems = true;
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            legend1.Title = "Categories";
            legend1.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerPieChart.Legends.Add(legend1);
            this.customerPieChart.Location = new System.Drawing.Point(5, 5);
            this.customerPieChart.Margin = new System.Windows.Forms.Padding(5);
            this.customerPieChart.Name = "customerPieChart";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.LabelFormat = "{0}%";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            series1.YValuesPerPoint = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.customerPieChart.Series.Add(series1);
            this.customerPieChart.Series.Add(series2);
            this.customerPieChart.Size = new System.Drawing.Size(742, 267);
            this.customerPieChart.TabIndex = 0;
            this.customerPieChart.Text = "chart1";
            this.customerPieChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pieChart_MouseClick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 4;
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
            this.timePeriodComboBox.Location = new System.Drawing.Point(457, 6);
            this.timePeriodComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timePeriodComboBox.Name = "timePeriodComboBox";
            this.timePeriodComboBox.Size = new System.Drawing.Size(157, 25);
            this.timePeriodComboBox.TabIndex = 3;
            this.timePeriodComboBox.SelectedIndexChanged += new System.EventHandler(this.timePeriodComboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(645, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.supplierPieChart, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.internalPieChart, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.customerPieChart, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(6, 39);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(752, 832);
            this.tableLayoutPanel.TabIndex = 12;
            // 
            // supplierPieChart
            // 
            this.supplierPieChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierPieChart.BorderlineColor = System.Drawing.Color.Black;
            this.supplierPieChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.Area3DStyle.Inclination = 60;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.Area3DStyle.Rotation = 0;
            chartArea2.Name = "ChartArea1";
            this.supplierPieChart.ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Segoe UI", 8F);
            legend2.IsEquallySpacedItems = true;
            legend2.IsTextAutoFit = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend1";
            legend2.Title = "Categories";
            legend2.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierPieChart.Legends.Add(legend2);
            this.supplierPieChart.Location = new System.Drawing.Point(5, 559);
            this.supplierPieChart.Margin = new System.Windows.Forms.Padding(5);
            this.supplierPieChart.Name = "supplierPieChart";
            this.supplierPieChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.LabelFormat = "{0}%";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            series3.YValuesPerPoint = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            this.supplierPieChart.Series.Add(series3);
            this.supplierPieChart.Series.Add(series4);
            this.supplierPieChart.Size = new System.Drawing.Size(742, 268);
            this.supplierPieChart.TabIndex = 2;
            this.supplierPieChart.Text = "chart1";
            // 
            // internalPieChart
            // 
            this.internalPieChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.internalPieChart.BorderlineColor = System.Drawing.Color.Black;
            this.internalPieChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Area3DStyle.Enable3D = true;
            chartArea3.Area3DStyle.Inclination = 60;
            chartArea3.Area3DStyle.IsRightAngleAxes = false;
            chartArea3.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea3.Area3DStyle.Rotation = 0;
            chartArea3.Name = "ChartArea1";
            this.internalPieChart.ChartAreas.Add(chartArea3);
            legend3.Font = new System.Drawing.Font("Segoe UI", 8F);
            legend3.IsEquallySpacedItems = true;
            legend3.IsTextAutoFit = false;
            legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend3.Name = "Legend1";
            legend3.Title = "Categories";
            legend3.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.internalPieChart.Legends.Add(legend3);
            this.internalPieChart.Location = new System.Drawing.Point(5, 282);
            this.internalPieChart.Margin = new System.Windows.Forms.Padding(5);
            this.internalPieChart.Name = "internalPieChart";
            this.internalPieChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.IsValueShownAsLabel = true;
            series5.LabelForeColor = System.Drawing.Color.White;
            series5.LabelFormat = "{0}%";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            series5.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            series5.YValuesPerPoint = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Legend = "Legend1";
            series6.Name = "Series2";
            this.internalPieChart.Series.Add(series5);
            this.internalPieChart.Series.Add(series6);
            this.internalPieChart.Size = new System.Drawing.Size(742, 267);
            this.internalPieChart.TabIndex = 1;
            this.internalPieChart.Text = "chart1";
            // 
            // ComplaintStatisticsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timePeriodComboBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(670, 350);
            this.Name = "ComplaintStatisticsView";
            this.Size = new System.Drawing.Size(763, 876);
            this.Load += new System.EventHandler(this.QMSNcrStatisticsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerPieChart)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.supplierPieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.internalPieChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart customerPieChart;
        private System.Windows.Forms.ComboBox timePeriodComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart supplierPieChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart internalPieChart;
    }
}
