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
            this.mainView21 = new CPECentral.Views.MainView2();
            this.SuspendLayout();
            // 
            // mainView21
            // 
            this.mainView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainView21.Location = new System.Drawing.Point(0, 0);
            this.mainView21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainView21.Name = "mainView21";
            this.mainView21.Size = new System.Drawing.Size(1096, 690);
            this.mainView21.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 690);
            this.Controls.Add(this.mainView21);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.MainView2 mainView21;

    }
}