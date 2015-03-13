using CPECentral.Controls;

namespace CPECentral.Views
{
    partial class EmployeeSessionView
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
            this.components = new System.ComponentModel.Container();
            this.tabPageImageList = new System.Windows.Forms.ImageList(this.components);
            this.flatTabControl = new CPECentral.Controls.FlatTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.startPageView = new CPECentral.Views.StartPageView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.partLibraryView = new CPECentral.Views.PartLibraryView();
            this.flatTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageImageList
            // 
            this.tabPageImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.tabPageImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // flatTabControl
            // 
            this.flatTabControl.ClosableAfterIndex = 1;
            this.flatTabControl.Controls.Add(this.tabPage1);
            this.flatTabControl.Controls.Add(this.tabPage2);
            this.flatTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flatTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.flatTabControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatTabControl.ItemSize = new System.Drawing.Size(150, 32);
            this.flatTabControl.Location = new System.Drawing.Point(0, 0);
            this.flatTabControl.myBackColor = System.Drawing.SystemColors.Control;
            this.flatTabControl.Name = "flatTabControl";
            this.flatTabControl.SelectedIndex = 0;
            this.flatTabControl.Size = new System.Drawing.Size(1177, 815);
            this.flatTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.flatTabControl.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.startPageView);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1169, 775);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start page";
            // 
            // startPageView
            // 
            this.startPageView.BackColor = System.Drawing.Color.White;
            this.startPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startPageView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPageView.Location = new System.Drawing.Point(0, 0);
            this.startPageView.Margin = new System.Windows.Forms.Padding(0);
            this.startPageView.Name = "startPageView";
            this.startPageView.Size = new System.Drawing.Size(1169, 775);
            this.startPageView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.partLibraryView);
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1169, 775);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Part library";
            // 
            // partLibraryView
            // 
            this.partLibraryView.BackColor = System.Drawing.Color.White;
            this.partLibraryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partLibraryView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partLibraryView.Location = new System.Drawing.Point(0, 0);
            this.partLibraryView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.partLibraryView.MinimumSize = new System.Drawing.Size(925, 630);
            this.partLibraryView.Name = "partLibraryView";
            this.partLibraryView.Size = new System.Drawing.Size(1169, 775);
            this.partLibraryView.TabIndex = 0;
            this.partLibraryView.PartSelected += new System.EventHandler<CPECentral.CustomEventArgs.PartEventArgs>(this.partLibraryView_PartSelected);
            // 
            // EmployeeSessionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flatTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EmployeeSessionView";
            this.Size = new System.Drawing.Size(1177, 815);
            this.flatTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatTabControl flatTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private StartPageView startPageView;
        private System.Windows.Forms.TabPage tabPage2;
        private PartLibraryView partLibraryView;
        private System.Windows.Forms.ImageList tabPageImageList;
    }
}
