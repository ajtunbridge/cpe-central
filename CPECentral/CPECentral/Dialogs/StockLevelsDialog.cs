﻿#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using CPECentral.Properties;
using Tricorn;

#endregion

namespace CPECentral.Dialogs
{
    public partial class StockLevelsDialog : Form
    {
        private readonly ICollection<int> _toolIds;

        public StockLevelsDialog(IEnumerable<int> toolIds)
        {
            InitializeComponent();

            base.Font = Settings.Default.AppFont;

            _toolIds = toolIds.ToList();
        }

        private void StockLevelsDialog_Load(object sender, EventArgs e)
        {
            using (var cpe = new CPEUnitOfWork()) {
                using (var tricorn = new TricornDataProvider()) {
                    foreach (var toolId in _toolIds) {
                        var tool = cpe.Tools.GetById(toolId);
                        var groupKey = tool.Id.ToString();
                        ListViewGroup group = null;
                        var alreadyAdded = false;

                        foreach (ListViewGroup existingGroup in enhancedListView.Groups) {
                            if (existingGroup.Name == groupKey) {
                                group = existingGroup;
                                alreadyAdded = true;
                                break;
                            }
                        }

                        if (alreadyAdded) {
                            continue;
                        }

                        foreach (var tricornTool in cpe.TricornTools.GetByTool(tool)) {
                            var batches = tricorn.GetMStocks(tricornTool.TricornReference);

                            if (!batches.Any()) {
                                continue;
                            }

                            foreach (var batch in batches) {
                                if (batch.Quantity_In_Stock == 0 || !batch.Quantity_In_Stock.HasValue) {
                                    continue;
                                }

                                if (group == null) {
                                    group = enhancedListView.Groups.Add(groupKey, tool.Description);
                                }

                                var item = enhancedListView.Items.Add(batch.Batch_Number);
                                item.SubItems.Add(batch.Quantity_In_Stock.ToString());
                                item.SubItems.Add(batch.Location);
                                item.Group = group;
                            }
                        }
                    }
                }
            }
        }
    }
}