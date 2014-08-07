using CPECentral.Controls;

namespace CPECentral.Views
{
    partial class PartView
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
            this.operationsView = new CPECentral.Views.OperationsView();
            this.operationsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.operationDocumentsView = new CPECentral.Views.DocumentsView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.operationToolsView1 = new CPECentral.Views.OperationToolsView();
            this.operationDescriptionLabel = new System.Windows.Forms.Label();
            this.partTabControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.versionDocumentsView = new CPECentral.Views.DocumentsView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.partDocumentsView = new CPECentral.Views.DocumentsView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.modifiedByLabel = new System.Windows.Forms.Label();
            this.createdByLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.filePreviewTabControl = new CPECentral.Controls.FilePreviewTabControl();
            this.partInformationView = new CPECentral.Views.PartInformationView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.operationsTabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.partTabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.operationsView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.operationsTabControl);
            this.splitContainer1.Panel2.Controls.Add(this.operationDescriptionLabel);
            this.splitContainer1.Size = new System.Drawing.Size(591, 490);
            this.splitContainer1.SplitterDistance = 243;
            this.splitContainer1.TabIndex = 7;
            // 
            // operationsView
            // 
            this.operationsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationsView.Location = new System.Drawing.Point(0, 0);
            this.operationsView.Name = "operationsView";
            this.operationsView.Size = new System.Drawing.Size(591, 243);
            this.operationsView.TabIndex = 3;
            this.operationsView.OperationSelected += new System.EventHandler<CPECentral.CustomEventArgs.OperationEventArgs>(this.operationsView_OperationSelected);
            // 
            // operationsTabControl
            // 
            this.operationsTabControl.Controls.Add(this.tabPage2);
            this.operationsTabControl.Controls.Add(this.tabPage1);
            this.operationsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsTabControl.Enabled = false;
            this.operationsTabControl.ItemSize = new System.Drawing.Size(140, 22);
            this.operationsTabControl.Location = new System.Drawing.Point(0, 50);
            this.operationsTabControl.Name = "operationsTabControl";
            this.operationsTabControl.SelectedIndex = 0;
            this.operationsTabControl.ShowToolTips = true;
            this.operationsTabControl.Size = new System.Drawing.Size(591, 193);
            this.operationsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.operationsTabControl.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.operationDocumentsView);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(583, 163);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Operation documents";
            this.tabPage2.ToolTipText = "Any documents for this operation (eg. CAM files, NC files etc)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // operationDocumentsView
            // 
            this.operationDocumentsView.AllowDrop = true;
            this.operationDocumentsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationDocumentsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationDocumentsView.Location = new System.Drawing.Point(3, 3);
            this.operationDocumentsView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.operationDocumentsView.Name = "operationDocumentsView";
            this.operationDocumentsView.Size = new System.Drawing.Size(577, 157);
            this.operationDocumentsView.TabIndex = 1;
            this.operationDocumentsView.OpenDocument += new System.EventHandler(this.documentsView_OpenDocument);
            this.operationDocumentsView.OpenDocumentExternally += new System.EventHandler(this.documentsView_OpenDocumentExternally);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.operationToolsView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(650, 163);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Tool list";
            this.tabPage1.ToolTipText = "The tool list for this operation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // operationToolsView1
            // 
            this.operationToolsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationToolsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationToolsView1.Location = new System.Drawing.Point(0, 0);
            this.operationToolsView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.operationToolsView1.Name = "operationToolsView1";
            this.operationToolsView1.Size = new System.Drawing.Size(650, 163);
            this.operationToolsView1.TabIndex = 0;
            // 
            // operationDescriptionLabel
            // 
            this.operationDescriptionLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.operationDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.operationDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationDescriptionLabel.ForeColor = System.Drawing.Color.White;
            this.operationDescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.operationDescriptionLabel.Name = "operationDescriptionLabel";
            this.operationDescriptionLabel.Size = new System.Drawing.Size(591, 50);
            this.operationDescriptionLabel.TabIndex = 6;
            // 
            // partTabControl
            // 
            this.partTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partTabControl.Controls.Add(this.tabPage3);
            this.partTabControl.Controls.Add(this.tabPage4);
            this.partTabControl.ItemSize = new System.Drawing.Size(140, 22);
            this.partTabControl.Location = new System.Drawing.Point(414, 53);
            this.partTabControl.Name = "partTabControl";
            this.partTabControl.SelectedIndex = 0;
            this.partTabControl.ShowToolTips = true;
            this.partTabControl.Size = new System.Drawing.Size(738, 239);
            this.partTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.partTabControl.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.versionDocumentsView);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(730, 209);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Version documents";
            this.tabPage3.ToolTipText = "This is where to store part drawings and models";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // versionDocumentsView
            // 
            this.versionDocumentsView.AllowDrop = true;
            this.versionDocumentsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionDocumentsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionDocumentsView.Location = new System.Drawing.Point(3, 3);
            this.versionDocumentsView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.versionDocumentsView.Name = "versionDocumentsView";
            this.versionDocumentsView.Size = new System.Drawing.Size(724, 203);
            this.versionDocumentsView.TabIndex = 0;
            this.versionDocumentsView.OpenDocument += new System.EventHandler(this.documentsView_OpenDocument);
            this.versionDocumentsView.OpenDocumentExternally += new System.EventHandler(this.documentsView_OpenDocumentExternally);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.partDocumentsView);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(730, 209);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Part documents";
            this.tabPage4.ToolTipText = "Here we can store non-version specific documents; N.C.R\'s for example";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // partDocumentsView
            // 
            this.partDocumentsView.AllowDrop = true;
            this.partDocumentsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partDocumentsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partDocumentsView.Location = new System.Drawing.Point(3, 3);
            this.partDocumentsView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.partDocumentsView.Name = "partDocumentsView";
            this.partDocumentsView.Size = new System.Drawing.Size(724, 203);
            this.partDocumentsView.TabIndex = 1;
            this.partDocumentsView.OpenDocument += new System.EventHandler(this.documentsView_OpenDocument);
            this.partDocumentsView.OpenDocumentExternally += new System.EventHandler(this.documentsView_OpenDocumentExternally);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1155, 2);
            this.label3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.modifiedByLabel);
            this.panel1.Controls.Add(this.createdByLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1155, 47);
            this.panel1.TabIndex = 1;
            // 
            // modifiedByLabel
            // 
            this.modifiedByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modifiedByLabel.AutoSize = true;
            this.modifiedByLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifiedByLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.modifiedByLabel.Location = new System.Drawing.Point(1065, 26);
            this.modifiedByLabel.Margin = new System.Windows.Forms.Padding(3);
            this.modifiedByLabel.Name = "modifiedByLabel";
            this.modifiedByLabel.Size = new System.Drawing.Size(87, 17);
            this.modifiedByLabel.TabIndex = 1;
            this.modifiedByLabel.Text = "Modified by:";
            // 
            // createdByLabel
            // 
            this.createdByLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createdByLabel.AutoSize = true;
            this.createdByLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdByLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.createdByLabel.Location = new System.Drawing.Point(1074, 3);
            this.createdByLabel.Margin = new System.Windows.Forms.Padding(3);
            this.createdByLabel.Name = "createdByLabel";
            this.createdByLabel.Size = new System.Drawing.Size(78, 17);
            this.createdByLabel.TabIndex = 1;
            this.createdByLabel.Text = "Created by:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::CPECentral.Properties.Resources.CompanyLogo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(7, 298);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.filePreviewTabControl);
            this.splitContainer2.Size = new System.Drawing.Size(1145, 490);
            this.splitContainer2.SplitterDistance = 591;
            this.splitContainer2.TabIndex = 8;
            // 
            // filePreviewTabControl
            // 
            this.filePreviewTabControl.AllowDrop = true;
            this.filePreviewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePreviewTabControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePreviewTabControl.Location = new System.Drawing.Point(0, 0);
            this.filePreviewTabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filePreviewTabControl.Name = "filePreviewTabControl";
            this.filePreviewTabControl.Size = new System.Drawing.Size(550, 490);
            this.filePreviewTabControl.TabIndex = 0;
            // 
            // partInformationView
            // 
            this.partInformationView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partInformationView.Location = new System.Drawing.Point(7, 53);
            this.partInformationView.Name = "partInformationView";
            this.partInformationView.Size = new System.Drawing.Size(401, 239);
            this.partInformationView.TabIndex = 0;
            this.partInformationView.VersionSelected += new System.EventHandler<CPECentral.CustomEventArgs.PartVersionEventArgs>(this.partInformationView_VersionSelected);
            // 
            // PartView
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.partTabControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.partInformationView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PartView";
            this.Size = new System.Drawing.Size(1155, 791);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.operationsTabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.partTabControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PartInformationView partInformationView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label modifiedByLabel;
        private System.Windows.Forms.Label createdByLabel;
        private OperationsView operationsView;
        private System.Windows.Forms.TabControl operationsTabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl partTabControl;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DocumentsView operationDocumentsView;
        private DocumentsView versionDocumentsView;
        private DocumentsView partDocumentsView;
        private System.Windows.Forms.Label operationDescriptionLabel;
        private FilePreviewTabControl filePreviewTabControl;
        private OperationToolsView operationToolsView1;


    }
}
