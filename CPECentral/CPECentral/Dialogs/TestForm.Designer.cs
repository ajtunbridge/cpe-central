namespace CPECentral.Dialogs
{
    partial class TestForm
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
            this.toolGroupsView1 = new CPECentral.Views.ToolGroupsView();
            this.SuspendLayout();
            // 
            // toolGroupsView1
            // 
            this.toolGroupsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolGroupsView1.Location = new System.Drawing.Point(12, 13);
            this.toolGroupsView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolGroupsView1.Name = "toolGroupsView1";
            this.toolGroupsView1.Size = new System.Drawing.Size(215, 253);
            this.toolGroupsView1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 430);
            this.Controls.Add(this.toolGroupsView1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ToolGroupsView toolGroupsView1;
    }
}