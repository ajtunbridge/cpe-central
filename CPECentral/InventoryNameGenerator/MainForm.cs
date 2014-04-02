#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using InventoryNameGenerator.Modules;
using InventoryNameGenerator.Properties;

#endregion

namespace InventoryNameGenerator
{
    public partial class MainForm : Form
    {
        private readonly MainFormPresenter _presenter;

        public MainForm()
        {
            InitializeComponent();

            Icon = Resources.ApplicationIcon;

            _presenter = new MainFormPresenter(this);
        }

        public event EventHandler LoadModules;
        public event EventHandler<IModuleEventArgs> ModuleSelected;
        public event EventHandler<IModuleEventArgs> EditModuleDataFile;

        protected virtual void OnEditModuleDataFile(IModuleEventArgs e)
        {
            EventHandler<IModuleEventArgs> handler = EditModuleDataFile;
            if (handler != null) {
                handler(this, e);
            }
        }

        protected virtual void OnLoadModules()
        {
            var handler = LoadModules;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnModuleSelected(IModuleEventArgs e)
        {
            var handler = ModuleSelected;
            if (handler != null) {
                handler(this, e);
            }
        }

        public void DisplayModules(IEnumerable<IModule> loadedModules)
        {
            loadedModulesListBox.DisplayMember = "Name";

            foreach (var module in loadedModules) {
                loadedModulesListBox.Items.Add(module);
            }

            toolStripProgressBar.Visible = false;
            UpdateStatus(string.Format("{0} modules loaded", loadedModulesListBox.Items.Count));
        }

        public void DisplaySelectedModule(ModulePanel modulePanel)
        {
            if (modulePanel == null) {
                MessageBox.Show("Module failed to load!");
                return;
            }

            toolStripProgressBar.Visible = false;
            UpdateStatus("module loaded ok...");

            selectedModulePanel.Controls.Clear();

            selectedModulePanel.Controls.Add(modulePanel);

            modulePanel.Dock = DockStyle.Fill;

            modulePanel.Focus();
        }

        public void UpdateStatus(string text)
        {
            BeginInvoke((MethodInvoker) (() => toolStripStatusLabel.Text = text));
        }

        private void loadedModulesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedModule = loadedModulesListBox.SelectedItem as IModule;

            var label = new Label {
                Text = "loading " + selectedModule.Name + " module...",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily.Name, 14f, FontStyle.Bold),
                Dock = DockStyle.Fill,
                AutoSize = false
            };

            selectedModulePanel.Controls.Clear();
            selectedModulePanel.Controls.Add(label);

            toolStripProgressBar.Visible = true;
            UpdateStatus("loading selected module...");

            OnModuleSelected(new IModuleEventArgs(selectedModule));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OnLoadModules();
        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip.Hide();

            var selectedModule = loadedModulesListBox.SelectedItem as IModule;

            OnEditModuleDataFile(new IModuleEventArgs(selectedModule));
        }
    }
}