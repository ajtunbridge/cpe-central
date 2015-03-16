namespace CPECentral.Dialogs
{
    partial class SelectToolDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolSelectorView = new CPECentral.Views.ToolSelectorView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.selectButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 401);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(442, 43);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // selectButton
            // 
            this.selectButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectButton.Enabled = false;
            this.selectButton.Location = new System.Drawing.Point(3, 3);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(215, 37);
            this.selectButton.TabIndex = 1;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.Location = new System.Drawing.Point(224, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(215, 37);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // toolSelectorView
            // 
            this.toolSelectorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolSelectorView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolSelectorView.Location = new System.Drawing.Point(0, 0);
            this.toolSelectorView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolSelectorView.Name = "toolSelectorView";
            this.toolSelectorView.Padding = new System.Windows.Forms.Padding(3);
            this.toolSelectorView.Size = new System.Drawing.Size(442, 401);
            this.toolSelectorView.TabIndex = 2;
            this.toolSelectorView.ToolSelectionChanged += new System.EventHandler<CPECentral.CustomEventArgs.ToolEventArgs>(this.toolSelectorView_ToolSelectionChanged);
            this.toolSelectorView.ToolSelected += new System.EventHandler<CPECentral.CustomEventArgs.ToolEventArgs>(this.toolSelectorView_ToolSelected);
            // 
            // SelectToolDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 444);
            this.Controls.Add(this.toolSelectorView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectToolDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool selector";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ToolSelectorView toolSelectorView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button cancelButton;

    }
}