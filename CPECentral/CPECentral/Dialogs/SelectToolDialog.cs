#region Using directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using nGenLibrary;
using Tricorn;

#endregion

namespace CPECentral.Dialogs
{
    public partial class SelectToolDialog : Form
    {
        private static List<Tool> _allTools;
        private static List<Holder> _allHolders;
        private static Dictionary<Tool, double?> _stockLevels = new Dictionary<Tool, double?>();
        private static DateTime _clearCacheAt;

        public SelectToolDialog()
        {
            InitializeComponent();
        }

        public Tool SelectedTool { get; private set; }
        public Holder SelectedHolder { get; private set; }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            resultsListView.Items.Clear();
            optionalLabel.Text = "...";

            var searchValue = searchTextBox.Text.Trim().ToLower();

            if (searchTextBox.Text.Length < 2)
            {
                return;
            }
            
            using (BusyCursor.Show())
            {
                var matchedTools = _allTools.Where(t => t.Description.ToLower().Contains(searchValue));
                var matchedHolders = _allHolders.Where(h => h.Name.ToLower().Contains(searchValue));

                using (var tricorn = new TricornDataProvider())
                {
                    using (var cpe = new CPEUnitOfWork())
                    {
                        double? stockCount = null;

                        foreach (var tool in matchedTools)
                        {
                            if (_stockLevels.ContainsKey(tool))
                            {
                                stockCount = _stockLevels[tool];
                            }
                            else
                            {
                                List<TricornTool> tricornTools = cpe.TricornTools.GetByTool(tool).ToList();

                                if (tricornTools.Any())
                                {
                                    stockCount = 0;
                                    foreach (TricornTool tricornTool in tricornTools)
                                    {
                                        double? tricornStock =
                                            tricorn.GetMStocks(tricornTool.TricornReference)
                                                .Sum(ms => ms.Quantity_In_Stock);
                                        stockCount += tricornStock;
                                    }
                                }
                                _stockLevels.Add(tool, stockCount);
                            }

                            var item = resultsListView.Items.Add(tool.Description);
                            item.Group = resultsListView.Groups["toolsListViewGroup"];
                            item.Tag = tool;
                            item.ForeColor = stockCount > 0 ? Color.Green : Color.Red;
                        }
                    }
                }

                foreach (var holder in matchedHolders)
                {
                    var item = resultsListView.Items.Add(holder.Name);
                    item.Group = resultsListView.Groups["holdersListViewGroup"];
                    item.Tag = holder;
                }
            }
        }

        private void SelectToolDialog2_Load(object sender, EventArgs e)
        {
            if (_clearCacheAt < DateTime.Now)
            {
                _allTools = null;
                _allHolders = null;
                _stockLevels = new Dictionary<Tool, double?>();
            }

            if (_allTools == null)
            {
                using (BusyCursor.Show())
                {
                    using (var cpe = new CPEUnitOfWork())
                    {
                        _allTools = cpe.Tools.GetAll().OrderBy(t => t.Description).ToList();
                        _allHolders = cpe.Holders.GetAll().OrderBy(h => h.Name).ToList();
                    }
                }
            }
        }

        private void resultsListView_ClientSizeChanged(object sender, EventArgs e)
        {
            //resultsListView.Columns[0].Width = -2;
            //resultsListView.Columns[0].Width -= 5;
        }

        private void resultsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTool = null;
            SelectedHolder = null;
            optionalComboBox.Items.Clear();
            optionalComboBox.Enabled = false;
            okButton.Enabled = false;

            if (resultsListView.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedEntity = resultsListView.SelectedItems[0].Tag;

            if (selectedEntity is Tool)
            {
                SelectedTool = selectedEntity as Tool;
            }
            else
            {
                SelectedHolder = selectedEntity as Holder;
            }

            if (SelectedTool != null)
            {
                optionalComboBox.Items.Add("No holder");

                using (var cpe = new CPEUnitOfWork())
                {
                    var holders = cpe.Holders.GetByTool(SelectedTool).OrderBy(h => h.Name);

                    foreach (var holder in holders)
                    {
                        optionalComboBox.Items.Add(holder);
                    }
                }

                optionalLabel.Text = "Select a holder for this insert (optional)";
                okButton.Enabled = true;
            }
            else
            {
                optionalComboBox.Items.Add("No insert selected!");

                using (var cpe = new CPEUnitOfWork())
                {
                    var holderTools = cpe.HolderTools.GetByHolder(SelectedHolder);

                    var availableTools = holderTools.Select(ht => _allTools.Single(t => t.Id == ht.ToolId)).ToList();

                    foreach (var tool in availableTools)
                    {
                        optionalComboBox.Items.Add(tool);
                    }
                }
                optionalLabel.Text = "Select an insert for this holder";
                okButton.Enabled = false;
            }

            if (optionalComboBox.Items.Count > 0)
            {
                optionalComboBox.SelectedIndex = 0;
                optionalComboBox.Enabled = true;
            }
        }

        private void holdersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optionalComboBox.SelectedItem == null)
            {
                return;
            }

            if (SelectedHolder != null)
            {
                if (optionalComboBox.SelectedIndex == 0)
                {
                    SelectedTool = null;
                    okButton.Enabled = false;
                    return;
                }
                SelectedTool = optionalComboBox.SelectedItem as Tool;
                okButton.Enabled = true;
            }
            else
            {
                if (optionalComboBox.SelectedIndex == 0)
                {
                    SelectedHolder = null;
                    return;
                }
                SelectedHolder = optionalComboBox.SelectedItem as Holder;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SelectToolDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _clearCacheAt = DateTime.Now.AddMinutes(1);
        }
    }
}