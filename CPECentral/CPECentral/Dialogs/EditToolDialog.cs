using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Data.EF5;
using nGenLibrary;
using Tricorn;

namespace CPECentral.Dialogs
{
    public partial class EditToolDialog : Form
    {
        private readonly Tool _tool;
        private readonly IDialogService _dialogService = Session.GetInstanceOf<IDialogService>();

        public Tool Tool
        {
            get { return _tool; }
        }

        public IEnumerable<Material> TricornLinks
        {
            get { return (from ListViewItem item in tricornLinksEnhancedListView.Items select item.Tag as Material).ToList(); }
        }

        public EditToolDialog() : this(new Tool())
        {
        }

        public EditToolDialog(Tool tool)
        {
            InitializeComponent();

            _tool = tool;

            descriptionEnhancedTextBox.DataBindings.Add("Text", _tool, "Description");
        }

        private void EditToolDialog_Load(object sender, EventArgs e)
        {
            using (BusyCursor.Show()) {
                using (var cpe = new CPEUnitOfWork()) {
                    var tricornTools = cpe.TricornTools.GetByTool(_tool);
                    if (!tricornTools.Any()) {
                        return;
                    }
                    using (var tricorn = new TricornDataProvider()) {
                        foreach (var tricornTool in tricornTools) {
                            var material = tricorn.GetMaterialByReference(tricornTool.TricornReference);
                            if (material == null) {
                                // TODO: handle missing Tricorn tool reference
                                continue;
                            }
                            ListViewItem item = tricornLinksEnhancedListView.Items.Add(material.Name);
                            item.Tag = material;
                        }
                    }
                }
            }
        }

        private void okayCancelFooter_OkayClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void okayCancelFooter_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var selectDialog = new SelectTricornMaterialDialog(descriptionEnhancedTextBox.Text)) {
                if (selectDialog.ShowDialog(this) != DialogResult.OK) {
                    return;
                }
                var materialsAlreadyAdded = (from ListViewItem item in tricornLinksEnhancedListView.Items select item.Tag as Material);

                foreach (var material in selectDialog.SelectedMaterials) {
                    if (materialsAlreadyAdded.Any(m => m.Material_Reference == material.Material_Reference)) {
                        continue;
                    }
                    ListViewItem item = tricornLinksEnhancedListView.Items.Add(material.Name);
                    item.Tag = material;
                }
            }
        }

        private void tricornLinksEnhancedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = tricornLinksEnhancedListView.SelectionCount == 1;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var question = string.Format("Are you sure you want to remove the link to this material?\n\n{0}",
                tricornLinksEnhancedListView.SelectedItems[0].Text);

            if (!_dialogService.AskQuestion(question)) {
                return;
            }

            tricornLinksEnhancedListView.Items.RemoveAt(tricornLinksEnhancedListView.SelectedIndices[0]);
        }
    }
}