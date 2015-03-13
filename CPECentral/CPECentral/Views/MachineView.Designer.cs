namespace CPECentral.Views
{
    partial class MachineView
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
            this.machineNameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.machineTransferQueuePictureBox = new System.Windows.Forms.PictureBox();
            this.toggleFavouritePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.machineTransferQueuePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleFavouritePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // machineNameLabel
            // 
            this.machineNameLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.machineNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.machineNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.machineNameLabel.ForeColor = System.Drawing.Color.Black;
            this.machineNameLabel.Location = new System.Drawing.Point(0, 0);
            this.machineNameLabel.Name = "machineNameLabel";
            this.machineNameLabel.Size = new System.Drawing.Size(275, 27);
            this.machineNameLabel.TabIndex = 0;
            this.machineNameLabel.Text = "MACHINE NAME";
            this.machineNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImage = global::CPECentral.Properties.Resources.DocumentPreviewBgTile;
            this.pictureBox1.Image = global::CPECentral.Properties.Resources.NoMachineImageAvailable;
            this.pictureBox1.Location = new System.Drawing.Point(10, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // machineTransferQueuePictureBox
            // 
            this.machineTransferQueuePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.machineTransferQueuePictureBox.BackColor = System.Drawing.Color.Gainsboro;
            this.machineTransferQueuePictureBox.Image = global::CPECentral.Properties.Resources.MachineTransferQueueIcon_16x16;
            this.machineTransferQueuePictureBox.Location = new System.Drawing.Point(254, 5);
            this.machineTransferQueuePictureBox.Name = "machineTransferQueuePictureBox";
            this.machineTransferQueuePictureBox.Size = new System.Drawing.Size(16, 16);
            this.machineTransferQueuePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.machineTransferQueuePictureBox.TabIndex = 2;
            this.machineTransferQueuePictureBox.TabStop = false;
            this.machineTransferQueuePictureBox.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.machineTransferQueuePictureBox.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // toggleFavouritePictureBox
            // 
            this.toggleFavouritePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleFavouritePictureBox.BackColor = System.Drawing.Color.Gainsboro;
            this.toggleFavouritePictureBox.Image = global::CPECentral.Properties.Resources.NotFavouriteMachineIcon_16x16;
            this.toggleFavouritePictureBox.Location = new System.Drawing.Point(232, 5);
            this.toggleFavouritePictureBox.Name = "toggleFavouritePictureBox";
            this.toggleFavouritePictureBox.Size = new System.Drawing.Size(16, 16);
            this.toggleFavouritePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.toggleFavouritePictureBox.TabIndex = 3;
            this.toggleFavouritePictureBox.TabStop = false;
            this.toggleFavouritePictureBox.Click += new System.EventHandler(this.toggleFavouritePictureBox_Click);
            this.toggleFavouritePictureBox.MouseEnter += new System.EventHandler(this.toggleFavouritePictureBox_MouseEnter);
            this.toggleFavouritePictureBox.MouseLeave += new System.EventHandler(this.toggleFavouritePictureBox_MouseLeave);
            // 
            // MachineView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CPECentral.Properties.Resources.DocumentPreviewBgTile;
            this.Controls.Add(this.toggleFavouritePictureBox);
            this.Controls.Add(this.machineTransferQueuePictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.machineNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MachineView";
            this.Size = new System.Drawing.Size(275, 214);
            this.SizeChanged += new System.EventHandler(this.MachineView_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.machineTransferQueuePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleFavouritePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label machineNameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox machineTransferQueuePictureBox;
        private System.Windows.Forms.PictureBox toggleFavouritePictureBox;
    }
}
