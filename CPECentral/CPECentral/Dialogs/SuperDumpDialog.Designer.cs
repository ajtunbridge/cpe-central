namespace CPECentral.Dialogs
{
    partial class SuperDumpDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.machinesComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.getStartedButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.dumpListView = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "STEP 1: Select the machine to SuperDump™ from";
            // 
            // machinesComboBox
            // 
            this.machinesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machinesComboBox.FormattingEnabled = true;
            this.machinesComboBox.Location = new System.Drawing.Point(15, 29);
            this.machinesComboBox.Name = "machinesComboBox";
            this.machinesComboBox.Size = new System.Drawing.Size(418, 25);
            this.machinesComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(421, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "STEP 2: Push this fucking button, then go dump all them programs out!";
            // 
            // getStartedButton
            // 
            this.getStartedButton.Location = new System.Drawing.Point(15, 91);
            this.getStartedButton.Name = "getStartedButton";
            this.getStartedButton.Size = new System.Drawing.Size(418, 53);
            this.getStartedButton.TabIndex = 2;
            this.getStartedButton.Text = "Let\'s get this shit started...";
            this.getStartedButton.UseVisualStyleBackColor = true;
            this.getStartedButton.Click += new System.EventHandler(this.getStartedButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 183);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(418, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "STEP 3: Wait";
            // 
            // dumpListView
            // 
            this.dumpListView.Location = new System.Drawing.Point(15, 222);
            this.dumpListView.Name = "dumpListView";
            this.dumpListView.Size = new System.Drawing.Size(418, 239);
            this.dumpListView.TabIndex = 4;
            this.dumpListView.UseCompatibleStateImageBehavior = false;
            this.dumpListView.SelectedIndexChanged += new System.EventHandler(this.dumpListView_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 495);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(418, 59);
            this.button2.TabIndex = 5;
            this.button2.Text = "Flush the fucker";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 473);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(421, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "STEP 4: Push this button to save each program to it\'s respective part\r\n";
            // 
            // SuperDumpDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 572);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dumpListView);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.getStartedButton);
            this.Controls.Add(this.machinesComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuperDumpDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SuperDump™";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SuperDumpDialog_FormClosing);
            this.Load += new System.EventHandler(this.SuperDumpDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox machinesComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getStartedButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView dumpListView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
    }
}