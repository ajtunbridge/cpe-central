namespace CPECentral.Controls
{
    partial class SettingsGeneralUserControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolFormatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.holderFormatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.programHeaderFormatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 388);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.programHeaderFormatRichTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(539, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Turning";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 201);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolFormatRichTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.holderFormatRichTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(524, 155);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 2;
            // 
            // toolFormatRichTextBox
            // 
            this.toolFormatRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolFormatRichTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolFormatRichTextBox.Location = new System.Drawing.Point(0, 13);
            this.toolFormatRichTextBox.Name = "toolFormatRichTextBox";
            this.toolFormatRichTextBox.Size = new System.Drawing.Size(262, 142);
            this.toolFormatRichTextBox.TabIndex = 0;
            this.toolFormatRichTextBox.Text = "";
            this.toolFormatRichTextBox.TextChanged += new System.EventHandler(this.toolFormatRichTextBox_TextChanged);
            this.toolFormatRichTextBox.Leave += new System.EventHandler(this.programFormatRichTextBoxes_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tool entry format";
            // 
            // holderFormatRichTextBox
            // 
            this.holderFormatRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holderFormatRichTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holderFormatRichTextBox.Location = new System.Drawing.Point(0, 13);
            this.holderFormatRichTextBox.Name = "holderFormatRichTextBox";
            this.holderFormatRichTextBox.Size = new System.Drawing.Size(258, 142);
            this.holderFormatRichTextBox.TabIndex = 0;
            this.holderFormatRichTextBox.Text = "";
            this.holderFormatRichTextBox.TextChanged += new System.EventHandler(this.holderFormatRichTextBox_TextChanged);
            this.holderFormatRichTextBox.Leave += new System.EventHandler(this.programFormatRichTextBoxes_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Holder entry format";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Program header format";
            // 
            // programHeaderFormatRichTextBox
            // 
            this.programHeaderFormatRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.programHeaderFormatRichTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programHeaderFormatRichTextBox.Location = new System.Drawing.Point(9, 19);
            this.programHeaderFormatRichTextBox.Name = "programHeaderFormatRichTextBox";
            this.programHeaderFormatRichTextBox.Size = new System.Drawing.Size(527, 176);
            this.programHeaderFormatRichTextBox.TabIndex = 0;
            this.programHeaderFormatRichTextBox.Text = "";
            this.programHeaderFormatRichTextBox.TextChanged += new System.EventHandler(this.programHeaderFormatRichTextBox_TextChanged);
            this.programHeaderFormatRichTextBox.Leave += new System.EventHandler(this.programFormatRichTextBoxes_Leave);
            // 
            // SettingsGeneralUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsGeneralUserControl";
            this.Size = new System.Drawing.Size(547, 388);
            this.Load += new System.EventHandler(this.SettingsGeneralUserControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox programHeaderFormatRichTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox holderFormatRichTextBox;
        private System.Windows.Forms.RichTextBox toolFormatRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
