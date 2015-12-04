namespace CPECentral.Views
{
    partial class StartPageView
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
            this.turnoverTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.workCentreScheduleView1 = new CPECentral.Views.WorkCentreScheduleView();
            this.checkStockLevelsView1 = new CPECentral.Views.StartPageCheckStockView();
            this.turnoverTargetView1 = new CPECentral.Views.StartPageTargetView();
            this.turnoverGraphView1 = new CPECentral.Views.TurnoverGraphView();
            this.engineerToolsView1 = new CPECentral.Views.StartPageCalculatorSelectView();
            this.startPageFindToolBoxView1 = new CPECentral.Views.StartPageFindToolBoxView();
            this.startPageUserInfoView1 = new CPECentral.Views.StartPageUserInfoView();
            this.turnoverTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // turnoverTabControl
            // 
            this.turnoverTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.turnoverTabControl.Controls.Add(this.tabPage1);
            this.turnoverTabControl.Controls.Add(this.tabPage2);
            this.turnoverTabControl.Location = new System.Drawing.Point(682, 10);
            this.turnoverTabControl.Name = "turnoverTabControl";
            this.turnoverTabControl.SelectedIndex = 0;
            this.turnoverTabControl.Size = new System.Drawing.Size(334, 222);
            this.turnoverTabControl.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.turnoverTargetView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(326, 192);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Targets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.turnoverGraphView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(326, 192);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Turnover trends";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ItemSize = new System.Drawing.Size(125, 22);
            this.tabControl1.Location = new System.Drawing.Point(10, 320);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(655, 477);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.workCentreScheduleView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(647, 447);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Work schedule";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.checkStockLevelsView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(647, 447);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Stock";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // workCentreScheduleView1
            // 
            this.workCentreScheduleView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workCentreScheduleView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workCentreScheduleView1.Location = new System.Drawing.Point(3, 3);
            this.workCentreScheduleView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.workCentreScheduleView1.Name = "workCentreScheduleView1";
            this.workCentreScheduleView1.Size = new System.Drawing.Size(641, 441);
            this.workCentreScheduleView1.TabIndex = 0;
            // 
            // checkStockLevelsView1
            // 
            this.checkStockLevelsView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkStockLevelsView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkStockLevelsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkStockLevelsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkStockLevelsView1.Location = new System.Drawing.Point(3, 3);
            this.checkStockLevelsView1.Margin = new System.Windows.Forms.Padding(10);
            this.checkStockLevelsView1.Name = "checkStockLevelsView1";
            this.checkStockLevelsView1.Size = new System.Drawing.Size(641, 441);
            this.checkStockLevelsView1.TabIndex = 1;
            // 
            // turnoverTargetView1
            // 
            this.turnoverTargetView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.turnoverTargetView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.turnoverTargetView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.turnoverTargetView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnoverTargetView1.Location = new System.Drawing.Point(3, 3);
            this.turnoverTargetView1.Margin = new System.Windows.Forms.Padding(10);
            this.turnoverTargetView1.MaximumSize = new System.Drawing.Size(800, 185);
            this.turnoverTargetView1.MinimumSize = new System.Drawing.Size(275, 185);
            this.turnoverTargetView1.Name = "turnoverTargetView1";
            this.turnoverTargetView1.Size = new System.Drawing.Size(320, 185);
            this.turnoverTargetView1.TabIndex = 4;
            // 
            // turnoverGraphView1
            // 
            this.turnoverGraphView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.turnoverGraphView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnoverGraphView1.Location = new System.Drawing.Point(3, 3);
            this.turnoverGraphView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.turnoverGraphView1.Name = "turnoverGraphView1";
            this.turnoverGraphView1.Size = new System.Drawing.Size(320, 190);
            this.turnoverGraphView1.TabIndex = 0;
            // 
            // engineerToolsView1
            // 
            this.engineerToolsView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.engineerToolsView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.engineerToolsView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.engineerToolsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.engineerToolsView1.Location = new System.Drawing.Point(682, 480);
            this.engineerToolsView1.Margin = new System.Windows.Forms.Padding(10);
            this.engineerToolsView1.Name = "engineerToolsView1";
            this.engineerToolsView1.Size = new System.Drawing.Size(334, 317);
            this.engineerToolsView1.TabIndex = 3;
            // 
            // startPageFindToolBoxView1
            // 
            this.startPageFindToolBoxView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startPageFindToolBoxView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.startPageFindToolBoxView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startPageFindToolBoxView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPageFindToolBoxView1.Location = new System.Drawing.Point(682, 245);
            this.startPageFindToolBoxView1.Margin = new System.Windows.Forms.Padding(10);
            this.startPageFindToolBoxView1.MaximumSize = new System.Drawing.Size(800, 215);
            this.startPageFindToolBoxView1.MinimumSize = new System.Drawing.Size(275, 215);
            this.startPageFindToolBoxView1.Name = "startPageFindToolBoxView1";
            this.startPageFindToolBoxView1.Size = new System.Drawing.Size(334, 215);
            this.startPageFindToolBoxView1.TabIndex = 2;
            // 
            // startPageUserInfoView1
            // 
            this.startPageUserInfoView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startPageUserInfoView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.startPageUserInfoView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startPageUserInfoView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPageUserInfoView1.Location = new System.Drawing.Point(10, 10);
            this.startPageUserInfoView1.Margin = new System.Windows.Forms.Padding(10);
            this.startPageUserInfoView1.Name = "startPageUserInfoView1";
            this.startPageUserInfoView1.Size = new System.Drawing.Size(652, 297);
            this.startPageUserInfoView1.TabIndex = 0;
            // 
            // StartPageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.turnoverTabControl);
            this.Controls.Add(this.engineerToolsView1);
            this.Controls.Add(this.startPageFindToolBoxView1);
            this.Controls.Add(this.startPageUserInfoView1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StartPageView";
            this.Size = new System.Drawing.Size(1026, 807);
            this.turnoverTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private StartPageUserInfoView startPageUserInfoView1;
        private StartPageCheckStockView checkStockLevelsView1;
        private StartPageFindToolBoxView startPageFindToolBoxView1;
        private StartPageCalculatorSelectView engineerToolsView1;
        private StartPageTargetView turnoverTargetView1;
        private System.Windows.Forms.TabControl turnoverTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private TurnoverGraphView turnoverGraphView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private WorkCentreScheduleView workCentreScheduleView1;
    }
}
