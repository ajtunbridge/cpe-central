using System.Windows.Forms;
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
            this.partDocumentsTabControl = new CPECentral.Controls.ClosableTabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.versionDocumentsView = new CPECentral.Views.DocumentsView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.partDocumentsView = new CPECentral.Views.DocumentsView();
            this.operationDocumentsTabControl = new CPECentral.Controls.ClosableTabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.operationsView = new CPECentral.Views.OperationsView();
            this.selectedOperationTabControl = new CPECentral.Controls.ClosableTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.operationDocumentsView = new CPECentral.Views.DocumentsView();
            this.machineTransferView = new CPECentral.Views.MachineTransferView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.operationToolsView = new CPECentral.Views.OperationToolsView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkingQMSLabel = new System.Windows.Forms.Label();
            this.checkingQMSPictureBox = new System.Windows.Forms.PictureBox();
            this.partDescriptionLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.nonConformanceWarningPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.removeImageButton = new System.Windows.Forms.Button();
            this.setImageButton = new System.Windows.Forms.Button();
            this.partPhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.partInformationView = new CPECentral.Views.PartInformationView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TabControl1 = new CPECentral.Controls.ClosableTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.partWorksOrdersView = new CPECentral.Views.PartWorksOrdersView();
            this.partDocumentsTabControl.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.operationDocumentsTabControl.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.selectedOperationTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkingQMSPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonConformanceWarningPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partPhotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // partDocumentsTabControl
            // 
            this.partDocumentsTabControl.Controls.Add(this.tabPage6);
            this.partDocumentsTabControl.Controls.Add(this.tabPage7);
            this.partDocumentsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partDocumentsTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.partDocumentsTabControl.ItemSize = new System.Drawing.Size(175, 30);
            this.partDocumentsTabControl.Location = new System.Drawing.Point(0, 0);
            this.partDocumentsTabControl.Name = "partDocumentsTabControl";
            this.partDocumentsTabControl.SelectedIndex = 0;
            this.partDocumentsTabControl.Size = new System.Drawing.Size(692, 220);
            this.partDocumentsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.partDocumentsTabControl.TabIndex = 11;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage6.Controls.Add(this.versionDocumentsView);
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(684, 182);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Tag = "false";
            this.tabPage6.Text = "Version documents";
            // 
            // versionDocumentsView
            // 
            this.versionDocumentsView.AllowDrop = true;
            this.versionDocumentsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionDocumentsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionDocumentsView.Location = new System.Drawing.Point(3, 3);
            this.versionDocumentsView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.versionDocumentsView.Name = "versionDocumentsView";
            this.versionDocumentsView.Size = new System.Drawing.Size(678, 176);
            this.versionDocumentsView.TabIndex = 0;
            this.versionDocumentsView.OpenDocument += new System.EventHandler(this.documentsView_OpenDocument);
            this.versionDocumentsView.OpenDocumentExternally += new System.EventHandler(this.documentsView_OpenDocumentExternally);
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage7.Controls.Add(this.partDocumentsView);
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(684, 182);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Tag = "false";
            this.tabPage7.Text = "Part documents";
            // 
            // partDocumentsView
            // 
            this.partDocumentsView.AllowDrop = true;
            this.partDocumentsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partDocumentsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partDocumentsView.Location = new System.Drawing.Point(3, 3);
            this.partDocumentsView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.partDocumentsView.Name = "partDocumentsView";
            this.partDocumentsView.Size = new System.Drawing.Size(678, 176);
            this.partDocumentsView.TabIndex = 1;
            this.partDocumentsView.OpenDocument += new System.EventHandler(this.documentsView_OpenDocument);
            this.partDocumentsView.OpenDocumentExternally += new System.EventHandler(this.documentsView_OpenDocumentExternally);
            // 
            // operationDocumentsTabControl
            // 
            this.operationDocumentsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operationDocumentsTabControl.Controls.Add(this.tabPage5);
            this.operationDocumentsTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.operationDocumentsTabControl.ItemSize = new System.Drawing.Size(150, 30);
            this.operationDocumentsTabControl.Location = new System.Drawing.Point(707, 58);
            this.operationDocumentsTabControl.Name = "operationDocumentsTabControl";
            this.operationDocumentsTabControl.SelectedIndex = 0;
            this.operationDocumentsTabControl.Size = new System.Drawing.Size(481, 772);
            this.operationDocumentsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.operationDocumentsTabControl.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage5.Controls.Add(this.splitContainer3);
            this.tabPage5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(473, 734);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Tag = "false";
            this.tabPage5.Text = "Manufacturing";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.operationsView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.selectedOperationTabControl);
            this.splitContainer3.Size = new System.Drawing.Size(473, 734);
            this.splitContainer3.SplitterDistance = 437;
            this.splitContainer3.TabIndex = 0;
            // 
            // operationsView
            // 
            this.operationsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationsView.Location = new System.Drawing.Point(0, 0);
            this.operationsView.Name = "operationsView";
            this.operationsView.Size = new System.Drawing.Size(473, 437);
            this.operationsView.TabIndex = 0;
            this.operationsView.OperationSelected += new System.EventHandler<CPECentral.CustomEventArgs.OperationEventArgs>(this.operationsView1_OperationSelected);
            // 
            // selectedOperationTabControl
            // 
            this.selectedOperationTabControl.Controls.Add(this.tabPage1);
            this.selectedOperationTabControl.Controls.Add(this.tabPage2);
            this.selectedOperationTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedOperationTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.selectedOperationTabControl.ItemSize = new System.Drawing.Size(165, 30);
            this.selectedOperationTabControl.Location = new System.Drawing.Point(0, 0);
            this.selectedOperationTabControl.Name = "selectedOperationTabControl";
            this.selectedOperationTabControl.SelectedIndex = 0;
            this.selectedOperationTabControl.Size = new System.Drawing.Size(473, 293);
            this.selectedOperationTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.selectedOperationTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.operationDocumentsView);
            this.tabPage1.Controls.Add(this.machineTransferView);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(465, 255);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "false";
            this.tabPage1.Text = "Operation documents";
            // 
            // operationDocumentsView
            // 
            this.operationDocumentsView.AllowDrop = true;
            this.operationDocumentsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationDocumentsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationDocumentsView.Location = new System.Drawing.Point(0, 0);
            this.operationDocumentsView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.operationDocumentsView.Name = "operationDocumentsView";
            this.operationDocumentsView.Size = new System.Drawing.Size(124, 255);
            this.operationDocumentsView.TabIndex = 1;
            this.operationDocumentsView.OpenDocument += new System.EventHandler(this.documentsView_OpenDocument);
            this.operationDocumentsView.OpenDocumentExternally += new System.EventHandler(this.documentsView_OpenDocumentExternally);
            this.operationDocumentsView.SelectionChanged += new System.EventHandler(this.operationDocumentsView_SelectionChanged);
            this.operationDocumentsView.TextFileSelected += new System.EventHandler<CPECentral.CustomEventArgs.DocumentEventArgs>(this.operationDocumentsView_TextFileSelected);
            // 
            // machineTransferView
            // 
            this.machineTransferView.BackColor = System.Drawing.Color.Gainsboro;
            this.machineTransferView.Dock = System.Windows.Forms.DockStyle.Right;
            this.machineTransferView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.machineTransferView.Location = new System.Drawing.Point(124, 0);
            this.machineTransferView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.machineTransferView.Name = "machineTransferView";
            this.machineTransferView.Size = new System.Drawing.Size(341, 255);
            this.machineTransferView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.operationToolsView);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(465, 255);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "false";
            this.tabPage2.Text = "Tool list";
            // 
            // operationToolsView
            // 
            this.operationToolsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationToolsView.Location = new System.Drawing.Point(0, 0);
            this.operationToolsView.Name = "operationToolsView";
            this.operationToolsView.Size = new System.Drawing.Size(465, 255);
            this.operationToolsView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.checkingQMSLabel);
            this.panel1.Controls.Add(this.checkingQMSPictureBox);
            this.panel1.Controls.Add(this.partDescriptionLabel);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.nonConformanceWarningPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(7);
            this.panel1.Size = new System.Drawing.Size(1195, 50);
            this.panel1.TabIndex = 10;
            // 
            // checkingQMSLabel
            // 
            this.checkingQMSLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkingQMSLabel.AutoSize = true;
            this.checkingQMSLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkingQMSLabel.Location = new System.Drawing.Point(785, 17);
            this.checkingQMSLabel.Name = "checkingQMSLabel";
            this.checkingQMSLabel.Size = new System.Drawing.Size(250, 17);
            this.checkingQMSLabel.TabIndex = 3;
            this.checkingQMSLabel.Text = "Checking QMS for non-conformances...";
            // 
            // checkingQMSPictureBox
            // 
            this.checkingQMSPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkingQMSPictureBox.Image = global::CPECentral.Properties.Resources.PreloaderImage2;
            this.checkingQMSPictureBox.Location = new System.Drawing.Point(1041, 15);
            this.checkingQMSPictureBox.Name = "checkingQMSPictureBox";
            this.checkingQMSPictureBox.Size = new System.Drawing.Size(139, 21);
            this.checkingQMSPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.checkingQMSPictureBox.TabIndex = 2;
            this.checkingQMSPictureBox.TabStop = false;
            // 
            // partDescriptionLabel
            // 
            this.partDescriptionLabel.AutoSize = true;
            this.partDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partDescriptionLabel.Location = new System.Drawing.Point(55, 15);
            this.partDescriptionLabel.Name = "partDescriptionLabel";
            this.partDescriptionLabel.Size = new System.Drawing.Size(319, 21);
            this.partDescriptionLabel.TabIndex = 1;
            this.partDescriptionLabel.Text = "H514753B Version 06 ( CATHODE SIDEARM)";
            this.partDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::CPECentral.Properties.Resources.PartViewIcon_32x32;
            this.pictureBox2.Location = new System.Drawing.Point(7, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox2.Size = new System.Drawing.Size(42, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // nonConformanceWarningPictureBox
            // 
            this.nonConformanceWarningPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nonConformanceWarningPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nonConformanceWarningPictureBox.Image = global::CPECentral.Properties.Resources.NonConformanceWarningImage;
            this.nonConformanceWarningPictureBox.Location = new System.Drawing.Point(588, 8);
            this.nonConformanceWarningPictureBox.Name = "nonConformanceWarningPictureBox";
            this.nonConformanceWarningPictureBox.Size = new System.Drawing.Size(600, 35);
            this.nonConformanceWarningPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.nonConformanceWarningPictureBox.TabIndex = 4;
            this.nonConformanceWarningPictureBox.TabStop = false;
            this.nonConformanceWarningPictureBox.Visible = false;
            this.nonConformanceWarningPictureBox.Click += new System.EventHandler(this.nonConformanceWarningPictureBox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeImageButton);
            this.groupBox1.Controls.Add(this.setImageButton);
            this.groupBox1.Controls.Add(this.partPhotoPictureBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Photo";
            // 
            // removeImageButton
            // 
            this.removeImageButton.Enabled = false;
            this.removeImageButton.Location = new System.Drawing.Point(6, 194);
            this.removeImageButton.Name = "removeImageButton";
            this.removeImageButton.Size = new System.Drawing.Size(222, 32);
            this.removeImageButton.TabIndex = 1;
            this.removeImageButton.Text = "Remove";
            this.removeImageButton.UseVisualStyleBackColor = true;
            this.removeImageButton.Click += new System.EventHandler(this.removeImageButton_Click);
            // 
            // setImageButton
            // 
            this.setImageButton.Location = new System.Drawing.Point(6, 155);
            this.setImageButton.Name = "setImageButton";
            this.setImageButton.Size = new System.Drawing.Size(222, 32);
            this.setImageButton.TabIndex = 0;
            this.setImageButton.Text = "Set";
            this.setImageButton.UseVisualStyleBackColor = true;
            this.setImageButton.Click += new System.EventHandler(this.setImageButton_Click);
            // 
            // partPhotoPictureBox
            // 
            this.partPhotoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.partPhotoPictureBox.Image = global::CPECentral.Properties.Resources.PreloaderImage2;
            this.partPhotoPictureBox.Location = new System.Drawing.Point(6, 24);
            this.partPhotoPictureBox.Name = "partPhotoPictureBox";
            this.partPhotoPictureBox.Size = new System.Drawing.Size(222, 125);
            this.partPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.partPhotoPictureBox.TabIndex = 0;
            this.partPhotoPictureBox.TabStop = false;
            this.partPhotoPictureBox.DoubleClick += new System.EventHandler(this.partPhotoPictureBox_DoubleClick);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1195, 2);
            this.label3.TabIndex = 2;
            // 
            // partInformationView
            // 
            this.partInformationView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partInformationView.Location = new System.Drawing.Point(249, 64);
            this.partInformationView.Name = "partInformationView";
            this.partInformationView.Size = new System.Drawing.Size(452, 239);
            this.partInformationView.TabIndex = 1;
            this.partInformationView.VersionSelected += new System.EventHandler<CPECentral.CustomEventArgs.PartVersionEventArgs>(this.partInformationView_VersionSelected);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 309);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.partDocumentsTabControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(692, 521);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 12;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tabPage3);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.TabControl1.ItemSize = new System.Drawing.Size(175, 30);
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(692, 297);
            this.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3.Controls.Add(this.partWorksOrdersView);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(684, 259);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Tag = "false";
            this.tabPage3.Text = "Works orders";
            // 
            // partWorksOrdersView
            // 
            this.partWorksOrdersView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partWorksOrdersView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partWorksOrdersView.Location = new System.Drawing.Point(3, 3);
            this.partWorksOrdersView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.partWorksOrdersView.Name = "partWorksOrdersView";
            this.partWorksOrdersView.Size = new System.Drawing.Size(678, 253);
            this.partWorksOrdersView.TabIndex = 0;
            // 
            // PartView
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.operationDocumentsTabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.partInformationView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PartView";
            this.Size = new System.Drawing.Size(1195, 833);
            this.partDocumentsTabControl.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.operationDocumentsTabControl.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.selectedOperationTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkingQMSPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonConformanceWarningPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.partPhotoPictureBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PartInformationView partInformationView;
        private System.Windows.Forms.Label label3;
        private DocumentsView versionDocumentsView;
        private DocumentsView partDocumentsView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button removeImageButton;
        private System.Windows.Forms.Button setImageButton;
        private System.Windows.Forms.PictureBox partPhotoPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label partDescriptionLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private OperationsView operationsView;
        private System.Windows.Forms.TabPage tabPage1;
        private DocumentsView operationDocumentsView;
        private System.Windows.Forms.TabPage tabPage2;
        private OperationToolsView operationToolsView;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label checkingQMSLabel;
        private System.Windows.Forms.PictureBox checkingQMSPictureBox;
        private MachineTransferView machineTransferView;
        private System.Windows.Forms.PictureBox nonConformanceWarningPictureBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage3;
        private PartWorksOrdersView partWorksOrdersView;
        private ClosableTabControl operationDocumentsTabControl;
        private ClosableTabControl selectedOperationTabControl;
        private ClosableTabControl partDocumentsTabControl;
        private ClosableTabControl TabControl1;


    }
}
