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
            this.toolsView1 = new CPECentral.Views.ToolsView();
            this.SuspendLayout();
            // 
            // toolGroupsView1
            // 
            this.toolGroupsView1.EnableEditing = true;
            this.toolGroupsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolGroupsView1.Location = new System.Drawing.Point(12, 13);
            this.toolGroupsView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolGroupsView1.Name = "toolGroupsView1";
            this.toolGroupsView1.Size = new System.Drawing.Size(215, 356);
            this.toolGroupsView1.TabIndex = 0;
            this.toolGroupsView1.ToolGroupSelected += new System.EventHandler<CPECentral.CustomEventArgs.ToolGroupEventArgs>(this.toolGroupsView1_ToolGroupSelected);
            // 
            // toolsView1
            // 
            this.toolsView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsView1.Location = new System.Drawing.Point(233, 13);
            this.toolsView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolsView1.Name = "toolsView1";
            this.toolsView1.ShowStockLevels = true;
            this.toolsView1.Size = new System.Drawing.Size(533, 356);
            this.toolsView1.TabIndex = 1;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 435);
            this.Controls.Add(this.toolsView1);
            this.Controls.Add(this.toolGroupsView1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ToolGroupsView toolGroupsView1;
        private Views.ToolsView toolsView1;
    }
}