namespace CPECentral.Dialogs
{
    partial class PartAlertsDialog
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
            this.selectedAlertGroupBox = new System.Windows.Forms.GroupBox();
            this.createdByLabel = new System.Windows.Forms.Label();
            this.alertDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteAlertButton = new System.Windows.Forms.Button();
            this.newAlertButton = new System.Windows.Forms.Button();
            this.alertsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectedAlertGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectedAlertGroupBox
            // 
            this.selectedAlertGroupBox.Controls.Add(this.createdByLabel);
            this.selectedAlertGroupBox.Controls.Add(this.alertDescriptionTextBox);
            this.selectedAlertGroupBox.Enabled = false;
            this.selectedAlertGroupBox.Location = new System.Drawing.Point(271, 13);
            this.selectedAlertGroupBox.Name = "selectedAlertGroupBox";
            this.selectedAlertGroupBox.Size = new System.Drawing.Size(432, 339);
            this.selectedAlertGroupBox.TabIndex = 2;
            this.selectedAlertGroupBox.TabStop = false;
            this.selectedAlertGroupBox.Text = "Description";
            // 
            // createdByLabel
            // 
            this.createdByLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdByLabel.Location = new System.Drawing.Point(6, 302);
            this.createdByLabel.Name = "createdByLabel";
            this.createdByLabel.Size = new System.Drawing.Size(420, 31);
            this.createdByLabel.TabIndex = 2;
            this.createdByLabel.Text = "This alert was created by {0}";
            this.createdByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // alertDescriptionTextBox
            // 
            this.alertDescriptionTextBox.Location = new System.Drawing.Point(9, 24);
            this.alertDescriptionTextBox.Multiline = true;
            this.alertDescriptionTextBox.Name = "alertDescriptionTextBox";
            this.alertDescriptionTextBox.Size = new System.Drawing.Size(417, 275);
            this.alertDescriptionTextBox.TabIndex = 1;
            this.alertDescriptionTextBox.TextChanged += new System.EventHandler(this.alertDescriptionTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteAlertButton);
            this.groupBox2.Controls.Add(this.newAlertButton);
            this.groupBox2.Controls.Add(this.alertsListView);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 340);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alerts";
            // 
            // deleteAlertButton
            // 
            this.deleteAlertButton.Enabled = false;
            this.deleteAlertButton.Location = new System.Drawing.Point(155, 303);
            this.deleteAlertButton.Name = "deleteAlertButton";
            this.deleteAlertButton.Size = new System.Drawing.Size(85, 31);
            this.deleteAlertButton.TabIndex = 1;
            this.deleteAlertButton.Text = "Delete";
            this.deleteAlertButton.UseVisualStyleBackColor = true;
            this.deleteAlertButton.Click += new System.EventHandler(this.deleteAlertButton_Click);
            // 
            // newAlertButton
            // 
            this.newAlertButton.Location = new System.Drawing.Point(6, 303);
            this.newAlertButton.Name = "newAlertButton";
            this.newAlertButton.Size = new System.Drawing.Size(143, 31);
            this.newAlertButton.TabIndex = 1;
            this.newAlertButton.Text = "New";
            this.newAlertButton.UseVisualStyleBackColor = true;
            this.newAlertButton.Click += new System.EventHandler(this.newAlertButton_Click);
            // 
            // alertsListView
            // 
            this.alertsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.alertsListView.FullRowSelect = true;
            this.alertsListView.GridLines = true;
            this.alertsListView.HideSelection = false;
            this.alertsListView.Location = new System.Drawing.Point(6, 22);
            this.alertsListView.Name = "alertsListView";
            this.alertsListView.Size = new System.Drawing.Size(234, 275);
            this.alertsListView.TabIndex = 0;
            this.alertsListView.UseCompatibleStateImageBehavior = false;
            this.alertsListView.View = System.Windows.Forms.View.Details;
            this.alertsListView.SelectedIndexChanged += new System.EventHandler(this.alertsListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Created at";
            this.columnHeader1.Width = 230;
            // 
            // PartAlertsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 369);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.selectedAlertGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartAlertsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alerts for {0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PartAlertsDialog_FormClosing);
            this.Load += new System.EventHandler(this.PartAlertsDialog_Load);
            this.selectedAlertGroupBox.ResumeLayout(false);
            this.selectedAlertGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox selectedAlertGroupBox;
        private System.Windows.Forms.TextBox alertDescriptionTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button deleteAlertButton;
        private System.Windows.Forms.Button newAlertButton;
        private System.Windows.Forms.ListView alertsListView;
        private System.Windows.Forms.Label createdByLabel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}