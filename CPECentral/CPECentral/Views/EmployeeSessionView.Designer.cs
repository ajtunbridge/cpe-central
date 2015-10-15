using System.Windows.Forms;
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
            this.tabControl = new CPECentral.Controls.ClosableTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.startPageView = new CPECentral.Views.StartPageView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.partLibraryView = new CPECentral.Views.PartLibraryView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.qmsView1 = new CPECentral.Views.QMSView();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageImageList
            // 
            this.tabPageImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.tabPageImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ItemSize = new System.Drawing.Size(150, 32);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1520, 1038);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.startPageView);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1512, 998);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "false";
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
            this.startPageView.Size = new System.Drawing.Size(1512, 998);
            this.startPageView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.partLibraryView);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.ForeColor = System.Drawing.Color.Black;
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1512, 998);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "false";
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
            this.partLibraryView.Size = new System.Drawing.Size(1512, 998);
            this.partLibraryView.TabIndex = 0;
            this.partLibraryView.PartSelected += new System.EventHandler<CPECentral.CustomEventArgs.PartEventArgs>(this.partLibraryView_PartSelected);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.qmsView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 36);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1512, 998);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "false";
            this.tabPage3.Text = "Quality";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // qmsView1
            // 
            this.qmsView1.BackColor = System.Drawing.Color.White;
            this.qmsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qmsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qmsView1.Location = new System.Drawing.Point(3, 3);
            this.qmsView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.qmsView1.Name = "qmsView1";
            this.qmsView1.Size = new System.Drawing.Size(1506, 992);
            this.qmsView1.TabIndex = 0;
            // 
            // EmployeeSessionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EmployeeSessionView";
            this.Size = new System.Drawing.Size(1520, 1038);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClosableTabControl tabControl;
        private new System.Windows.Forms.TabPage tabPage1;
        private StartPageView startPageView;
        private new System.Windows.Forms.TabPage tabPage2;
        private PartLibraryView partLibraryView;
        private System.Windows.Forms.ImageList tabPageImageList;
        private TabPage tabPage3;
        private QMSView qmsView1;
    }
}
