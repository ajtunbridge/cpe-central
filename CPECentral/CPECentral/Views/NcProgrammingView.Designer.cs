namespace CPECentral.Views
{
    partial class NcProgrammingView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.avalonNcEditor = new CPECentral.Controls.AvalonNcEditor2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.machinesComboBox = new System.Windows.Forms.ComboBox();
            this.operationToolsView = new CPECentral.Views.OperationToolsView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.operationToolsView);
            this.splitContainer1.Size = new System.Drawing.Size(859, 833);
            this.splitContainer1.SplitterDistance = 566;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.avalonNcEditor);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(859, 566);
            this.splitContainer2.SplitterDistance = 622;
            this.splitContainer2.TabIndex = 0;
            // 
            // avalonNcEditor
            // 
            this.avalonNcEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avalonNcEditor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avalonNcEditor.Location = new System.Drawing.Point(0, 0);
            this.avalonNcEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.avalonNcEditor.Name = "avalonNcEditor";
            this.avalonNcEditor.Size = new System.Drawing.Size(622, 566);
            this.avalonNcEditor.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.machinesComboBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select a machine";
            // 
            // machinesComboBox
            // 
            this.machinesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.machinesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machinesComboBox.FormattingEnabled = true;
            this.machinesComboBox.Location = new System.Drawing.Point(6, 24);
            this.machinesComboBox.Name = "machinesComboBox";
            this.machinesComboBox.Size = new System.Drawing.Size(221, 25);
            this.machinesComboBox.TabIndex = 0;
            this.machinesComboBox.SelectedIndexChanged += new System.EventHandler(this.machinesComboBox_SelectedIndexChanged);
            // 
            // operationToolsView
            // 
            this.operationToolsView.CurrentOperation = null;
            this.operationToolsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationToolsView.Location = new System.Drawing.Point(0, 0);
            this.operationToolsView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.operationToolsView.Name = "operationToolsView";
            this.operationToolsView.Size = new System.Drawing.Size(859, 263);
            this.operationToolsView.TabIndex = 0;
            // 
            // NcProgrammingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NcProgrammingView";
            this.Size = new System.Drawing.Size(859, 833);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private OperationToolsView operationToolsView;
        private Controls.AvalonNcEditor2 avalonNcEditor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox machinesComboBox;



    }
}
