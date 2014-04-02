#region Using directives

using System;
using System.Data;
using System.Windows.Forms;
using InventoryNameGenerator.Modules;

#endregion

namespace InventoryNameGenerator.Data
{
    public partial class DataEditorDialog : Form
    {
        private readonly IModule _module;

        public DataEditorDialog(IModule module)
        {
            InitializeComponent();
            _module = module;
        }

        private void DataEditorDialogLoad(object sender, EventArgs e)
        {
            foreach (DataTable table in _module.Data.Tables)
            {
                sourceComboBox.Items.Add(table.TableName);
            }

            sourceComboBox.SelectedIndex = 0;
        }

        private void SourceComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            var tableName = (string) sourceComboBox.SelectedItem;

            bindingSource = new BindingSource();
            bindingSource.DataSource = _module.Data.Tables[tableName];
            dataGridView.DataSource = bindingSource;

            filterByComboBox.Items.Clear();

            foreach (DataColumn column in _module.Data.Tables[tableName].Columns)
            {
                filterByComboBox.Items.Add(column.ColumnName);
            }

            filterByComboBox.SelectedIndex = 0;
        }

        private void ComboBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // swallow all keypresses
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FilterByComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            filterValueTextBox.Focus();
            filterValueTextBox.SelectAll();
        }

        private void FilterValueTextBoxTextChanged(object sender, EventArgs e)
        {
            var columnName = (string) filterByComboBox.SelectedItem;

            if (filterValueTextBox.Text.Length == 0)
                bindingSource.RemoveFilter();
            else
                bindingSource.Filter = columnName + " LIKE '%" + filterValueTextBox.Text + "%'";
        }

        private void ClearFilterButtonClick(object sender, EventArgs e)
        {
            bindingSource.RemoveFilter();
        }

        private void DataGridViewUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this entry and any entries related to it?",
                                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}