namespace CPECentral.Controls
{
    partial class SettingsMachinesUserControl
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.enhancedListView1 = new nGenLibrary.Controls.EnhancedListView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.machinesImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addMachineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteMachineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.controlsToolStrip = new System.Windows.Forms.ToolStrip();
            this.enhancedListView2 = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addControlToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeControlToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.selectedControlPanel = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.parityComboBox = new System.Windows.Forms.ComboBox();
            this.baudRateComboBox = new System.Windows.Forms.ComboBox();
            this.dataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.handshakeComboBox = new System.Windows.Forms.ComboBox();
            this.stopBitsComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.controlsToolStrip.SuspendLayout();
            this.selectedControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(125, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 388);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(539, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Machines";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(539, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Controls";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.enhancedListView1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.comboBox2);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(533, 350);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 0;
            // 
            // enhancedListView1
            // 
            this.enhancedListView1.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.enhancedListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhancedListView1.EnsureSelection = false;
            this.enhancedListView1.IndexOfColumnToResize = 0;
            this.enhancedListView1.ItemContextMenuStrip = null;
            this.enhancedListView1.LargeImageList = this.machinesImageList;
            this.enhancedListView1.Location = new System.Drawing.Point(0, 25);
            this.enhancedListView1.Name = "enhancedListView1";
            this.enhancedListView1.ResizeColumnToFill = false;
            this.enhancedListView1.Size = new System.Drawing.Size(533, 269);
            this.enhancedListView1.TabIndex = 0;
            this.enhancedListView1.UseAlternatingBackColor = false;
            this.enhancedListView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 25);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "COM port";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(250, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Control";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(380, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(150, 25);
            this.comboBox2.TabIndex = 3;
            // 
            // machinesImageList
            // 
            this.machinesImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.machinesImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.machinesImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMachineToolStripButton,
            this.deleteMachineToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(533, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // addMachineToolStripButton
            // 
            this.addMachineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addMachineToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addMachineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addMachineToolStripButton.Name = "addMachineToolStripButton";
            this.addMachineToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addMachineToolStripButton.Text = "Add a new machine";
            // 
            // deleteMachineToolStripButton
            // 
            this.deleteMachineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteMachineToolStripButton.Enabled = false;
            this.deleteMachineToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.deleteMachineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteMachineToolStripButton.Name = "deleteMachineToolStripButton";
            this.deleteMachineToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteMachineToolStripButton.Text = "Delete currently selected machine";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.selectedControlPanel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.enhancedListView2);
            this.splitContainer2.Panel2.Controls.Add(this.controlsToolStrip);
            this.splitContainer2.Size = new System.Drawing.Size(533, 350);
            this.splitContainer2.SplitterDistance = 327;
            this.splitContainer2.TabIndex = 0;
            // 
            // controlsToolStrip
            // 
            this.controlsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addControlToolStripButton,
            this.removeControlToolStripButton});
            this.controlsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.controlsToolStrip.Name = "controlsToolStrip";
            this.controlsToolStrip.Size = new System.Drawing.Size(202, 25);
            this.controlsToolStrip.TabIndex = 0;
            this.controlsToolStrip.Text = "toolStrip1";
            this.controlsToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // enhancedListView2
            // 
            this.enhancedListView2.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.enhancedListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.enhancedListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhancedListView2.EnsureSelection = false;
            this.enhancedListView2.FullRowSelect = true;
            this.enhancedListView2.IndexOfColumnToResize = 0;
            this.enhancedListView2.ItemContextMenuStrip = null;
            this.enhancedListView2.Location = new System.Drawing.Point(0, 25);
            this.enhancedListView2.Name = "enhancedListView2";
            this.enhancedListView2.ResizeColumnToFill = false;
            this.enhancedListView2.Size = new System.Drawing.Size(202, 325);
            this.enhancedListView2.TabIndex = 1;
            this.enhancedListView2.UseAlternatingBackColor = true;
            this.enhancedListView2.UseCompatibleStateImageBehavior = false;
            this.enhancedListView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 198;
            // 
            // addControlToolStripButton
            // 
            this.addControlToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addControlToolStripButton.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.addControlToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addControlToolStripButton.Name = "addControlToolStripButton";
            this.addControlToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addControlToolStripButton.Text = "Add new control";
            // 
            // removeControlToolStripButton
            // 
            this.removeControlToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeControlToolStripButton.Enabled = false;
            this.removeControlToolStripButton.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.removeControlToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeControlToolStripButton.Name = "removeControlToolStripButton";
            this.removeControlToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.removeControlToolStripButton.Text = "Delete selected control";
            // 
            // selectedControlPanel
            // 
            this.selectedControlPanel.Controls.Add(this.textBox6);
            this.selectedControlPanel.Controls.Add(this.textBox9);
            this.selectedControlPanel.Controls.Add(this.textBox8);
            this.selectedControlPanel.Controls.Add(this.textBox7);
            this.selectedControlPanel.Controls.Add(this.textBox4);
            this.selectedControlPanel.Controls.Add(this.textBox5);
            this.selectedControlPanel.Controls.Add(this.textBox3);
            this.selectedControlPanel.Controls.Add(this.checkBox2);
            this.selectedControlPanel.Controls.Add(this.checkBox1);
            this.selectedControlPanel.Controls.Add(this.parityComboBox);
            this.selectedControlPanel.Controls.Add(this.baudRateComboBox);
            this.selectedControlPanel.Controls.Add(this.dataBitsComboBox);
            this.selectedControlPanel.Controls.Add(this.handshakeComboBox);
            this.selectedControlPanel.Controls.Add(this.stopBitsComboBox);
            this.selectedControlPanel.Controls.Add(this.label13);
            this.selectedControlPanel.Controls.Add(this.label11);
            this.selectedControlPanel.Controls.Add(this.textBox2);
            this.selectedControlPanel.Controls.Add(this.label16);
            this.selectedControlPanel.Controls.Add(this.label15);
            this.selectedControlPanel.Controls.Add(this.label12);
            this.selectedControlPanel.Controls.Add(this.label14);
            this.selectedControlPanel.Controls.Add(this.label10);
            this.selectedControlPanel.Controls.Add(this.label9);
            this.selectedControlPanel.Controls.Add(this.label8);
            this.selectedControlPanel.Controls.Add(this.label6);
            this.selectedControlPanel.Controls.Add(this.label7);
            this.selectedControlPanel.Controls.Add(this.label5);
            this.selectedControlPanel.Controls.Add(this.label4);
            this.selectedControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedControlPanel.Location = new System.Drawing.Point(0, 0);
            this.selectedControlPanel.Name = "selectedControlPanel";
            this.selectedControlPanel.Size = new System.Drawing.Size(327, 350);
            this.selectedControlPanel.TabIndex = 0;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(63, 278);
            this.textBox6.MaxLength = 2;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(52, 25);
            this.textBox6.TabIndex = 32;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(121, 278);
            this.textBox9.MaxLength = 2;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(96, 25);
            this.textBox9.TabIndex = 31;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(223, 230);
            this.textBox8.MaxLength = 2;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(96, 25);
            this.textBox8.TabIndex = 30;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(121, 230);
            this.textBox7.MaxLength = 2;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(96, 25);
            this.textBox7.TabIndex = 29;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 230);
            this.textBox4.MaxLength = 2;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(51, 25);
            this.textBox4.TabIndex = 28;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 278);
            this.textBox5.MaxLength = 2;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(51, 25);
            this.textBox5.TabIndex = 27;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(63, 230);
            this.textBox3.MaxLength = 2;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(52, 25);
            this.textBox3.TabIndex = 26;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(269, 176);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(49, 21);
            this.checkBox2.TabIndex = 25;
            this.checkBox2.Text = "RTS";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(212, 176);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 21);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "DTR";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // parityComboBox
            // 
            this.parityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityComboBox.FormattingEnabled = true;
            this.parityComboBox.Location = new System.Drawing.Point(114, 76);
            this.parityComboBox.Name = "parityComboBox";
            this.parityComboBox.Size = new System.Drawing.Size(103, 25);
            this.parityComboBox.TabIndex = 22;
            // 
            // baudRateComboBox
            // 
            this.baudRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRateComboBox.FormattingEnabled = true;
            this.baudRateComboBox.Location = new System.Drawing.Point(6, 172);
            this.baudRateComboBox.Name = "baudRateComboBox";
            this.baudRateComboBox.Size = new System.Drawing.Size(155, 25);
            this.baudRateComboBox.TabIndex = 21;
            // 
            // dataBitsComboBox
            // 
            this.dataBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataBitsComboBox.FormattingEnabled = true;
            this.dataBitsComboBox.Location = new System.Drawing.Point(223, 76);
            this.dataBitsComboBox.Name = "dataBitsComboBox";
            this.dataBitsComboBox.Size = new System.Drawing.Size(95, 25);
            this.dataBitsComboBox.TabIndex = 20;
            // 
            // handshakeComboBox
            // 
            this.handshakeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.handshakeComboBox.FormattingEnabled = true;
            this.handshakeComboBox.Location = new System.Drawing.Point(6, 124);
            this.handshakeComboBox.Name = "handshakeComboBox";
            this.handshakeComboBox.Size = new System.Drawing.Size(312, 25);
            this.handshakeComboBox.TabIndex = 23;
            // 
            // stopBitsComboBox
            // 
            this.stopBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBitsComboBox.FormattingEnabled = true;
            this.stopBitsComboBox.Location = new System.Drawing.Point(6, 76);
            this.stopBitsComboBox.Name = "stopBitsComboBox";
            this.stopBitsComboBox.Size = new System.Drawing.Size(103, 25);
            this.stopBitsComboBox.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(60, 258);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 16;
            this.label13.Text = "XOff Alt";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(60, 210);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "XOff";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(312, 25);
            this.textBox2.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(121, 258);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "New line";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(224, 210);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 17);
            this.label15.TabIndex = 13;
            this.label15.Text = "Program end";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 258);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "XOn Alt";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(118, 210);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 17);
            this.label14.TabIndex = 11;
            this.label14.Text = "Program start";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "XOn";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Baud rate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Data bits";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Parity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Handshake";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Stop bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name";
            // 
            // SettingsMachinesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsMachinesUserControl";
            this.Size = new System.Drawing.Size(547, 388);
            this.Load += new System.EventHandler(this.SettingsMachinesUserControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.controlsToolStrip.ResumeLayout(false);
            this.controlsToolStrip.PerformLayout();
            this.selectedControlPanel.ResumeLayout(false);
            this.selectedControlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private nGenLibrary.Controls.EnhancedListView enhancedListView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList machinesImageList;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addMachineToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteMachineToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private nGenLibrary.Controls.EnhancedListView enhancedListView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStrip controlsToolStrip;
        private System.Windows.Forms.ToolStripButton addControlToolStripButton;
        private System.Windows.Forms.ToolStripButton removeControlToolStripButton;
        private System.Windows.Forms.Panel selectedControlPanel;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox parityComboBox;
        private System.Windows.Forms.ComboBox baudRateComboBox;
        private System.Windows.Forms.ComboBox dataBitsComboBox;
        private System.Windows.Forms.ComboBox handshakeComboBox;
        private System.Windows.Forms.ComboBox stopBitsComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
