namespace CPECentral.Views
{
    partial class EngineerToolsView
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
            this.hexagonDiameterCalculatorView1 = new CPECentral.Views.HexagonDiameterCalculatorView();
            this.SuspendLayout();
            // 
            // optionsComboBox
            // 
            this.optionsComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.optionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optionsComboBox.FormattingEnabled = true;
            this.optionsComboBox.Items.AddRange(new object[] {
            "Diameter for hexagon",
            "Trigonometry"});
            this.optionsComboBox.Location = new System.Drawing.Point(0, 263);
            this.optionsComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.optionsComboBox.Name = "optionsComboBox";
            this.optionsComboBox.Size = new System.Drawing.Size(372, 25);
            this.optionsComboBox.TabIndex = 1;
            // 
            // hexagonDiameterCalculatorView1
            // 
            this.hexagonDiameterCalculatorView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hexagonDiameterCalculatorView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexagonDiameterCalculatorView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexagonDiameterCalculatorView1.Location = new System.Drawing.Point(0, 0);
            this.hexagonDiameterCalculatorView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hexagonDiameterCalculatorView1.Name = "hexagonDiameterCalculatorView1";
            this.hexagonDiameterCalculatorView1.Size = new System.Drawing.Size(372, 263);
            this.hexagonDiameterCalculatorView1.TabIndex = 0;
            // 
            // EngineerToolsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.hexagonDiameterCalculatorView1);
            this.Controls.Add(this.optionsComboBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EngineerToolsView";
            this.Size = new System.Drawing.Size(372, 288);
            this.ResumeLayout(false);

        }

        #endregion

        private HexagonDiameterCalculatorView hexagonDiameterCalculatorView1;
        private System.Windows.Forms.ComboBox optionsComboBox;
    }
}
