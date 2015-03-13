namespace CPECentral.Views
{
    partial class StartPageCalculatorSelectView
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
            this.optionsComboBox = new System.Windows.Forms.ComboBox();
            this.calculatorPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // optionsComboBox
            // 
            this.optionsComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.optionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optionsComboBox.FormattingEnabled = true;
            this.optionsComboBox.Location = new System.Drawing.Point(0, 360);
            this.optionsComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.optionsComboBox.Name = "optionsComboBox";
            this.optionsComboBox.Size = new System.Drawing.Size(372, 25);
            this.optionsComboBox.TabIndex = 1;
            this.optionsComboBox.SelectedIndexChanged += new System.EventHandler(this.optionsComboBox_SelectedIndexChanged);
            // 
            // calculatorPanel
            // 
            this.calculatorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calculatorPanel.Location = new System.Drawing.Point(0, 0);
            this.calculatorPanel.Margin = new System.Windows.Forms.Padding(0);
            this.calculatorPanel.Name = "calculatorPanel";
            this.calculatorPanel.Size = new System.Drawing.Size(372, 360);
            this.calculatorPanel.TabIndex = 2;
            // 
            // EngineerToolsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.calculatorPanel);
            this.Controls.Add(this.optionsComboBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EngineerToolsView";
            this.Size = new System.Drawing.Size(372, 385);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox optionsComboBox;
        private System.Windows.Forms.Panel calculatorPanel;
    }
}
