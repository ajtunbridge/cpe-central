namespace CPECentral.Dialogs
{
    partial class ToolSelectorDialog
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
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.okayCancelFooter = new CPECentral.Controls.OkayCancelFooter();
            this.stockLevelsView = new CPECentral.Views.StockLevelsView();
            this.toolsView = new CPECentral.Views.ToolsView();
            this.toolGroupsView = new CPECentral.Views.ToolGroupsView();
            this.SuspendLayout();
            // 
            // filterComboBox
            // 
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Location = new System.Drawing.Point(12, 14);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(239, 25);
            this.filterComboBox.TabIndex = 4;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // okayCancelFooter
            // 
            this.okayCancelFooter.BackColor = System.Drawing.Color.White;
            this.okayCancelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okayCancelFooter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okayCancelFooter.Location = new System.Drawing.Point(0, 381);
            this.okayCancelFooter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okayCancelFooter.Name = "okayCancelFooter";
            this.okayCancelFooter.Size = new System.Drawing.Size(702, 45);
            this.okayCancelFooter.TabIndex = 3;
            this.okayCancelFooter.OkayClicked += new System.EventHandler(this.OkayCancelFooter_OkayClicked);
            this.okayCancelFooter.CancelClicked += new System.EventHandler(this.OkayCancelFooter_CancelClicked);
            // 
            // stockLevelsView
            // 
            this.stockLevelsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stockLevelsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockLevelsView.Location = new System.Drawing.Point(257, 230);
            this.stockLevelsView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.stockLevelsView.Name = "stockLevelsView";
            this.stockLevelsView.Size = new System.Drawing.Size(435, 142);
            this.stockLevelsView.TabIndex = 2;
            // 
            // toolsView
            // 
            this.toolsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolsView.EditMode = false;
            this.toolsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolsView.Location = new System.Drawing.Point(257, 14);
            this.toolsView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.toolsView.Name = "toolsView";
            this.toolsView.Size = new System.Drawing.Size(435, 206);
            this.toolsView.TabIndex = 1;
            this.toolsView.ToolSelected += new System.EventHandler<CPECentral.CustomEventArgs.ToolEventArgs>(this.ToolsView_ToolSelected);
            this.toolsView.ToolPicked += new System.EventHandler<CPECentral.CustomEventArgs.ToolEventArgs>(this.ToolsView_ToolPicked);
            // 
            // toolGroupsView
            // 
            this.toolGroupsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.toolGroupsView.EditMode = false;
            this.toolGroupsView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolGroupsView.Location = new System.Drawing.Point(12, 47);
            this.toolGroupsView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.toolGroupsView.Name = "toolGroupsView";
            this.toolGroupsView.Size = new System.Drawing.Size(239, 325);
            this.toolGroupsView.TabIndex = 0;
            this.toolGroupsView.ToolGroupSelected += new System.EventHandler<CPECentral.CustomEventArgs.ToolGroupEventArgs>(this.ToolGroupsView_ToolGroupSelected);
            // 
            // ToolSelectorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 426);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.okayCancelFooter);
            this.Controls.Add(this.stockLevelsView);
            this.Controls.Add(this.toolsView);
            this.Controls.Add(this.toolGroupsView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolSelectorDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tool selector";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ToolGroupsView toolGroupsView;
        private Views.ToolsView toolsView;
        private Views.StockLevelsView stockLevelsView;
        private Controls.OkayCancelFooter okayCancelFooter;
        private System.Windows.Forms.ComboBox filterComboBox;
    }
}