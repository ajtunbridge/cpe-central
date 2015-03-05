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
            this.panel1 = new System.Windows.Forms.Panel();
            this.partDescriptionLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.partPhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.partTabControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.versionDocumentsView = new CPECentral.Views.DocumentsView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.partDocumentsView = new CPECentral.Views.DocumentsView();
            this.label3 = new System.Windows.Forms.Label();
            this.operationDocumentsFlatTabControl = new FlatTabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.operationsView1 = new CPECentral.Views.OperationsView();
            this.documentsView1 = new CPECentral.Views.DocumentsView();
            this.partInformationView = new CPECentral.Views.PartInformationView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partPhotoPictureBox)).BeginInit();
            this.partTabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.operationDocumentsFlatTabControl.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.partDescriptionLabel);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1305, 50);
            this.panel1.TabIndex = 10;
            // 
            // partDescriptionLabel
            // 
            this.partDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partDescriptionLabel.Location = new System.Drawing.Point(48, 9);
            this.partDescriptionLabel.Name = "partDescriptionLabel";
            this.partDescriptionLabel.Size = new System.Drawing.Size(544, 32);
            this.partDescriptionLabel.TabIndex = 1;
            this.partDescriptionLabel.Text = "H514753B Version 06 ( CATHODE SIDEARM)";
            this.partDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CPECentral.Properties.Resources.PartIcon_64x64;
            this.pictureBox2.Location = new System.Drawing.Point(10, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.partPhotoPictureBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 232);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Photo";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(6, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // partPhotoPictureBox
            // 
            this.partPhotoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.partPhotoPictureBox.Image = global::CPECentral.Properties.Resources.NoImageAvailableImage;
            this.partPhotoPictureBox.Location = new System.Drawing.Point(6, 24);
            this.partPhotoPictureBox.Name = "partPhotoPictureBox";
            this.partPhotoPictureBox.Size = new System.Drawing.Size(166, 125);
            this.partPhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.partPhotoPictureBox.TabIndex = 0;
            this.partPhotoPictureBox.TabStop = false;
            // 
            // partTabControl
            // 
            this.partTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partTabControl.Controls.Add(this.tabPage3);
            this.partTabControl.Controls.Add(this.tabPage4);
            this.partTabControl.ItemSize = new System.Drawing.Size(140, 30);
            this.partTabControl.Location = new System.Drawing.Point(598, 64);
            this.partTabControl.Name = "partTabControl";
            this.partTabControl.SelectedIndex = 0;
            this.partTabControl.ShowToolTips = true;
            this.partTabControl.Size = new System.Drawing.Size(700, 239);
            this.partTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.partTabControl.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.versionDocumentsView);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(692, 201);
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
            this.versionDocumentsView.Size = new System.Drawing.Size(686, 195);
            this.versionDocumentsView.TabIndex = 0;
            this.versionDocumentsView.OpenDocument += new System.EventHandler(this.documentsView_OpenDocument);
            this.versionDocumentsView.OpenDocumentExternally += new System.EventHandler(this.documentsView_OpenDocumentExternally);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.partDocumentsView);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(692, 201);
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
            this.partDocumentsView.Size = new System.Drawing.Size(686, 195);
            this.partDocumentsView.TabIndex = 1;
            this.partDocumentsView.OpenDocument += new System.EventHandler(this.documentsView_OpenDocument);
            this.partDocumentsView.OpenDocumentExternally += new System.EventHandler(this.documentsView_OpenDocumentExternally);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1305, 2);
            this.label3.TabIndex = 2;
            // 
            // operationDocumentsFlatTabControl
            // 
            this.operationDocumentsFlatTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operationDocumentsFlatTabControl.Controls.Add(this.tabPage5);
            this.operationDocumentsFlatTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.operationDocumentsFlatTabControl.ItemSize = new System.Drawing.Size(150, 30);
            this.operationDocumentsFlatTabControl.Location = new System.Drawing.Point(598, 309);
            this.operationDocumentsFlatTabControl.myBackColor = System.Drawing.Color.White;
            this.operationDocumentsFlatTabControl.Name = "operationDocumentsFlatTabControl";
            this.operationDocumentsFlatTabControl.SelectedIndex = 0;
            this.operationDocumentsFlatTabControl.Size = new System.Drawing.Size(700, 576);
            this.operationDocumentsFlatTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.operationDocumentsFlatTabControl.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.splitContainer3);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(692, 538);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Operation documents";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.operationsView1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.documentsView1);
            this.splitContainer3.Size = new System.Drawing.Size(686, 532);
            this.splitContainer3.SplitterDistance = 319;
            this.splitContainer3.TabIndex = 0;
            // 
            // operationsView1
            // 
            this.operationsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationsView1.Location = new System.Drawing.Point(0, 0);
            this.operationsView1.Name = "operationsView1";
            this.operationsView1.Size = new System.Drawing.Size(686, 319);
            this.operationsView1.TabIndex = 0;
            this.operationsView1.OperationSelected += new System.EventHandler<CPECentral.CustomEventArgs.OperationEventArgs>(this.operationsView1_OperationSelected);
            // 
            // documentsView1
            // 
            this.documentsView1.AllowDrop = true;
            this.documentsView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentsView1.Location = new System.Drawing.Point(0, 0);
            this.documentsView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.documentsView1.Name = "documentsView1";
            this.documentsView1.Size = new System.Drawing.Size(686, 209);
            this.documentsView1.TabIndex = 0;
            // 
            // partInformationView
            // 
            this.partInformationView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partInformationView.Location = new System.Drawing.Point(199, 64);
            this.partInformationView.Name = "partInformationView";
            this.partInformationView.Size = new System.Drawing.Size(393, 239);
            this.partInformationView.TabIndex = 1;
            this.partInformationView.VersionSelected += new System.EventHandler<CPECentral.CustomEventArgs.PartVersionEventArgs>(this.partInformationView_VersionSelected);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(9, 309);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 569);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Something should go here";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 545);
            this.label1.TabIndex = 0;
            this.label1.Text = "I don\'t know what to put in this area!\r\n\r\nAny ideas would be greatly appreciated." +
    "\r\n\r\nKind regards\r\n\r\nAdam";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PartView
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.operationDocumentsFlatTabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.partTabControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.partInformationView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PartView";
            this.Size = new System.Drawing.Size(1305, 888);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.partPhotoPictureBox)).EndInit();
            this.partTabControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.operationDocumentsFlatTabControl.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PartInformationView partInformationView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl partTabControl;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private DocumentsView versionDocumentsView;
        private DocumentsView partDocumentsView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox partPhotoPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label partDescriptionLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private FlatTabControl operationDocumentsFlatTabControl;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private OperationsView operationsView1;
        private DocumentsView documentsView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;


    }
}
