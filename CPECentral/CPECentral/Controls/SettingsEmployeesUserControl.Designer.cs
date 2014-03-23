namespace CPECentral.Controls
{
    partial class SettingsEmployeesUserControl
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Create/delete documents"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Edit application settings"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.LightYellow, null);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Manage customer parts"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, null);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Manage employee accounts"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.LightYellow, null);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Manage part methods"}, -1, System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, null);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.employeesTabPage = new System.Windows.Forms.TabPage();
            this.selectedEmployeeGroupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.enhancedListView1 = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.groupsTabPage = new System.Windows.Forms.TabPage();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameEnhancedTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.firstNameEnhancedTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lastNameEnhancedTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupMembershipComboBox = new System.Windows.Forms.ComboBox();
            this.setPasswordButton = new System.Windows.Forms.Button();
            this.saveEmployeeButton = new System.Windows.Forms.Button();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.selectedGroupGroupBox = new System.Windows.Forms.GroupBox();
            this.saveGroupButton = new System.Windows.Forms.Button();
            this.groupNameEnhancedTextBox = new nGenLibrary.Controls.EnhancedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.permissionsEnhancedListView = new nGenLibrary.Controls.EnhancedListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupPermissionsListViewItemContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.employeesTabPage.SuspendLayout();
            this.selectedEmployeeGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupsTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.selectedGroupGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupPermissionsListViewItemContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.employeesTabPage);
            this.tabControl1.Controls.Add(this.groupsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(125, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(547, 388);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // employeesTabPage
            // 
            this.employeesTabPage.Controls.Add(this.selectedEmployeeGroupBox);
            this.employeesTabPage.Controls.Add(this.panel1);
            this.employeesTabPage.Controls.Add(this.toolStrip1);
            this.employeesTabPage.Location = new System.Drawing.Point(4, 26);
            this.employeesTabPage.Name = "employeesTabPage";
            this.employeesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.employeesTabPage.Size = new System.Drawing.Size(539, 358);
            this.employeesTabPage.TabIndex = 0;
            this.employeesTabPage.Text = "Employees";
            this.employeesTabPage.UseVisualStyleBackColor = true;
            // 
            // selectedEmployeeGroupBox
            // 
            this.selectedEmployeeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedEmployeeGroupBox.Controls.Add(this.saveEmployeeButton);
            this.selectedEmployeeGroupBox.Controls.Add(this.setPasswordButton);
            this.selectedEmployeeGroupBox.Controls.Add(this.groupMembershipComboBox);
            this.selectedEmployeeGroupBox.Controls.Add(this.lastNameEnhancedTextBox);
            this.selectedEmployeeGroupBox.Controls.Add(this.firstNameEnhancedTextBox);
            this.selectedEmployeeGroupBox.Controls.Add(this.userNameEnhancedTextBox);
            this.selectedEmployeeGroupBox.Controls.Add(this.label4);
            this.selectedEmployeeGroupBox.Controls.Add(this.label3);
            this.selectedEmployeeGroupBox.Controls.Add(this.label2);
            this.selectedEmployeeGroupBox.Controls.Add(this.label1);
            this.selectedEmployeeGroupBox.Enabled = false;
            this.selectedEmployeeGroupBox.Location = new System.Drawing.Point(6, 28);
            this.selectedEmployeeGroupBox.Name = "selectedEmployeeGroupBox";
            this.selectedEmployeeGroupBox.Size = new System.Drawing.Size(312, 327);
            this.selectedEmployeeGroupBox.TabIndex = 0;
            this.selectedEmployeeGroupBox.TabStop = false;
            this.selectedEmployeeGroupBox.Text = "Selected employee";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.enhancedListView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(324, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 327);
            this.panel1.TabIndex = 0;
            // 
            // enhancedListView1
            // 
            this.enhancedListView1.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.enhancedListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.enhancedListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhancedListView1.EnsureSelection = false;
            this.enhancedListView1.IndexOfColumnToResize = 0;
            this.enhancedListView1.ItemContextMenuStrip = null;
            this.enhancedListView1.Location = new System.Drawing.Point(0, 0);
            this.enhancedListView1.Name = "enhancedListView1";
            this.enhancedListView1.ResizeColumnToFill = true;
            this.enhancedListView1.Size = new System.Drawing.Size(212, 327);
            this.enhancedListView1.TabIndex = 0;
            this.enhancedListView1.UseAlternatingBackColor = true;
            this.enhancedListView1.UseCompatibleStateImageBehavior = false;
            this.enhancedListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Employee";
            this.columnHeader1.Width = 205;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(533, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // groupsTabPage
            // 
            this.groupsTabPage.Controls.Add(this.selectedGroupGroupBox);
            this.groupsTabPage.Controls.Add(this.panel2);
            this.groupsTabPage.Controls.Add(this.toolStrip2);
            this.groupsTabPage.Location = new System.Drawing.Point(4, 26);
            this.groupsTabPage.Name = "groupsTabPage";
            this.groupsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.groupsTabPage.Size = new System.Drawing.Size(539, 358);
            this.groupsTabPage.TabIndex = 1;
            this.groupsTabPage.Text = "Groups";
            this.groupsTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "User name";
            // 
            // userNameEnhancedTextBox
            // 
            this.userNameEnhancedTextBox.DisableDoubleSpace = true;
            this.userNameEnhancedTextBox.DisableLeadingSpace = true;
            this.userNameEnhancedTextBox.Location = new System.Drawing.Point(9, 41);
            this.userNameEnhancedTextBox.MaxLength = 30;
            this.userNameEnhancedTextBox.Name = "userNameEnhancedTextBox";
            this.userNameEnhancedTextBox.NumericCharactersOnly = false;
            this.userNameEnhancedTextBox.Size = new System.Drawing.Size(297, 25);
            this.userNameEnhancedTextBox.SuppressEnterKey = false;
            this.userNameEnhancedTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "First name";
            // 
            // firstNameEnhancedTextBox
            // 
            this.firstNameEnhancedTextBox.DisableDoubleSpace = true;
            this.firstNameEnhancedTextBox.DisableLeadingSpace = true;
            this.firstNameEnhancedTextBox.Location = new System.Drawing.Point(9, 89);
            this.firstNameEnhancedTextBox.MaxLength = 30;
            this.firstNameEnhancedTextBox.Name = "firstNameEnhancedTextBox";
            this.firstNameEnhancedTextBox.NumericCharactersOnly = false;
            this.firstNameEnhancedTextBox.Size = new System.Drawing.Size(297, 25);
            this.firstNameEnhancedTextBox.SuppressEnterKey = false;
            this.firstNameEnhancedTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Last name";
            // 
            // lastNameEnhancedTextBox
            // 
            this.lastNameEnhancedTextBox.DisableDoubleSpace = true;
            this.lastNameEnhancedTextBox.DisableLeadingSpace = true;
            this.lastNameEnhancedTextBox.Location = new System.Drawing.Point(9, 137);
            this.lastNameEnhancedTextBox.MaxLength = 30;
            this.lastNameEnhancedTextBox.Name = "lastNameEnhancedTextBox";
            this.lastNameEnhancedTextBox.NumericCharactersOnly = false;
            this.lastNameEnhancedTextBox.Size = new System.Drawing.Size(297, 25);
            this.lastNameEnhancedTextBox.SuppressEnterKey = false;
            this.lastNameEnhancedTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Group membership";
            // 
            // groupMembershipComboBox
            // 
            this.groupMembershipComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupMembershipComboBox.FormattingEnabled = true;
            this.groupMembershipComboBox.Location = new System.Drawing.Point(9, 185);
            this.groupMembershipComboBox.Name = "groupMembershipComboBox";
            this.groupMembershipComboBox.Size = new System.Drawing.Size(297, 25);
            this.groupMembershipComboBox.TabIndex = 3;
            // 
            // setPasswordButton
            // 
            this.setPasswordButton.Location = new System.Drawing.Point(9, 216);
            this.setPasswordButton.Name = "setPasswordButton";
            this.setPasswordButton.Size = new System.Drawing.Size(297, 43);
            this.setPasswordButton.TabIndex = 4;
            this.setPasswordButton.Text = "&Set password";
            this.setPasswordButton.UseVisualStyleBackColor = true;
            // 
            // saveEmployeeButton
            // 
            this.saveEmployeeButton.Enabled = false;
            this.saveEmployeeButton.Location = new System.Drawing.Point(9, 265);
            this.saveEmployeeButton.Name = "saveEmployeeButton";
            this.saveEmployeeButton.Size = new System.Drawing.Size(297, 56);
            this.saveEmployeeButton.TabIndex = 5;
            this.saveEmployeeButton.Text = "&Save changes";
            this.saveEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = global::CPECentral.Properties.Resources.SaveIcon_16x16;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupsEnhancedListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(324, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 327);
            this.panel2.TabIndex = 2;
            // 
            // groupsEnhancedListView
            // 
            this.groupsEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.groupsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.groupsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupsEnhancedListView.EnsureSelection = false;
            this.groupsEnhancedListView.IndexOfColumnToResize = 0;
            this.groupsEnhancedListView.ItemContextMenuStrip = null;
            this.groupsEnhancedListView.Location = new System.Drawing.Point(0, 0);
            this.groupsEnhancedListView.MultiSelect = false;
            this.groupsEnhancedListView.Name = "groupsEnhancedListView";
            this.groupsEnhancedListView.ResizeColumnToFill = true;
            this.groupsEnhancedListView.Size = new System.Drawing.Size(212, 327);
            this.groupsEnhancedListView.TabIndex = 0;
            this.groupsEnhancedListView.UseAlternatingBackColor = true;
            this.groupsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.groupsEnhancedListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Group";
            this.columnHeader2.Width = 205;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton6});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(533, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::CPECentral.Properties.Resources.AddIcon_16x16;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Enabled = false;
            this.toolStripButton5.Image = global::CPECentral.Properties.Resources.DeleteIcon_16x16;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton2";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Enabled = false;
            this.toolStripButton6.Image = global::CPECentral.Properties.Resources.SaveIcon_16x16;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton3";
            // 
            // selectedGroupGroupBox
            // 
            this.selectedGroupGroupBox.Controls.Add(this.groupBox1);
            this.selectedGroupGroupBox.Controls.Add(this.groupNameEnhancedTextBox);
            this.selectedGroupGroupBox.Controls.Add(this.label5);
            this.selectedGroupGroupBox.Controls.Add(this.saveGroupButton);
            this.selectedGroupGroupBox.Location = new System.Drawing.Point(6, 28);
            this.selectedGroupGroupBox.Name = "selectedGroupGroupBox";
            this.selectedGroupGroupBox.Size = new System.Drawing.Size(312, 327);
            this.selectedGroupGroupBox.TabIndex = 4;
            this.selectedGroupGroupBox.TabStop = false;
            this.selectedGroupGroupBox.Text = "Selected group";
            // 
            // saveGroupButton
            // 
            this.saveGroupButton.Enabled = false;
            this.saveGroupButton.Location = new System.Drawing.Point(9, 265);
            this.saveGroupButton.Name = "saveGroupButton";
            this.saveGroupButton.Size = new System.Drawing.Size(297, 56);
            this.saveGroupButton.TabIndex = 4;
            this.saveGroupButton.Text = "&Save changes";
            this.saveGroupButton.UseVisualStyleBackColor = true;
            // 
            // groupNameEnhancedTextBox
            // 
            this.groupNameEnhancedTextBox.DisableDoubleSpace = true;
            this.groupNameEnhancedTextBox.DisableLeadingSpace = true;
            this.groupNameEnhancedTextBox.Location = new System.Drawing.Point(9, 41);
            this.groupNameEnhancedTextBox.MaxLength = 30;
            this.groupNameEnhancedTextBox.Name = "groupNameEnhancedTextBox";
            this.groupNameEnhancedTextBox.NumericCharactersOnly = false;
            this.groupNameEnhancedTextBox.Size = new System.Drawing.Size(297, 25);
            this.groupNameEnhancedTextBox.SuppressEnterKey = false;
            this.groupNameEnhancedTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.permissionsEnhancedListView);
            this.groupBox1.Location = new System.Drawing.Point(9, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 187);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permissions";
            // 
            // permissionsEnhancedListView
            // 
            this.permissionsEnhancedListView.AlternateBackColor = System.Drawing.Color.LightYellow;
            this.permissionsEnhancedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.permissionsEnhancedListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permissionsEnhancedListView.EnsureSelection = false;
            this.permissionsEnhancedListView.IndexOfColumnToResize = 0;
            this.permissionsEnhancedListView.ItemContextMenuStrip = this.groupPermissionsListViewItemContextMenuStrip;
            this.permissionsEnhancedListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.permissionsEnhancedListView.Location = new System.Drawing.Point(3, 21);
            this.permissionsEnhancedListView.Name = "permissionsEnhancedListView";
            this.permissionsEnhancedListView.ResizeColumnToFill = true;
            this.permissionsEnhancedListView.Size = new System.Drawing.Size(291, 163);
            this.permissionsEnhancedListView.TabIndex = 0;
            this.permissionsEnhancedListView.UseAlternatingBackColor = true;
            this.permissionsEnhancedListView.UseCompatibleStateImageBehavior = false;
            this.permissionsEnhancedListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Permission";
            this.columnHeader3.Width = 224;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Granted";
            // 
            // groupPermissionsListViewItemContextMenuStrip
            // 
            this.groupPermissionsListViewItemContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem});
            this.groupPermissionsListViewItemContextMenuStrip.Name = "groupPermissionsListViewItemContextMenuStrip";
            this.groupPermissionsListViewItemContextMenuStrip.ShowImageMargin = false;
            this.groupPermissionsListViewItemContextMenuStrip.Size = new System.Drawing.Size(91, 26);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.changeToolStripMenuItem.Text = "&Change";
            // 
            // SettingsEmployeesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsEmployeesUserControl";
            this.Size = new System.Drawing.Size(547, 388);
            this.tabControl1.ResumeLayout(false);
            this.employeesTabPage.ResumeLayout(false);
            this.employeesTabPage.PerformLayout();
            this.selectedEmployeeGroupBox.ResumeLayout(false);
            this.selectedEmployeeGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupsTabPage.ResumeLayout(false);
            this.groupsTabPage.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.selectedGroupGroupBox.ResumeLayout(false);
            this.selectedGroupGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupPermissionsListViewItemContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage employeesTabPage;
        private System.Windows.Forms.TabPage groupsTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox selectedEmployeeGroupBox;
        private nGenLibrary.Controls.EnhancedListView enhancedListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox groupMembershipComboBox;
        private nGenLibrary.Controls.EnhancedTextBox lastNameEnhancedTextBox;
        private nGenLibrary.Controls.EnhancedTextBox firstNameEnhancedTextBox;
        private nGenLibrary.Controls.EnhancedTextBox userNameEnhancedTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button saveEmployeeButton;
        private System.Windows.Forms.Button setPasswordButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Panel panel2;
        private nGenLibrary.Controls.EnhancedListView groupsEnhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.GroupBox selectedGroupGroupBox;
        private System.Windows.Forms.Button saveGroupButton;
        private nGenLibrary.Controls.EnhancedTextBox groupNameEnhancedTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private nGenLibrary.Controls.EnhancedListView permissionsEnhancedListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip groupPermissionsListViewItemContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;

    }
}
