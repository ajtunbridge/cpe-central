namespace CPECentral
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
            this.partLibraryView21 = new CPECentral.Views.PartLibraryView2();
            this.SuspendLayout();
            // 
            // partLibraryView21
            // 
            this.partLibraryView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partLibraryView21.Location = new System.Drawing.Point(0, 0);
            this.partLibraryView21.Name = "partLibraryView21";
            this.partLibraryView21.Size = new System.Drawing.Size(420, 612);
            this.partLibraryView21.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 612);
            this.Controls.Add(this.partLibraryView21);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.PartLibraryView2 partLibraryView21;
    }
}