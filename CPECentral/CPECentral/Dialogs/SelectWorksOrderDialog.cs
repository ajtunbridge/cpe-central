#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tricorn;

#endregion

namespace CPECentral.Dialogs
{
    public partial class SelectWorksOrderDialog : Form
    {
        private readonly ICollection<WOrder> _worksOrders;

        public SelectWorksOrderDialog(ICollection<WOrder> worksOrders)
        {
            InitializeComponent();

            _worksOrders = worksOrders;
        }

        public WOrder SelectedWorksOrder { get; private set; }

        private void SelectWorksOrderDialog_Load(object sender, EventArgs e)
        {
            matchesListBox.DataSource = _worksOrders;
            matchesListBox.DisplayMember = "User_Reference";
        }

        private void matchesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedWorksOrder = (WOrder) matchesListBox.SelectedItem;

            customerNameTextBox.Text = SelectedWorksOrder.Customer.Name;
            drawingNumberTextBox.Text = SelectedWorksOrder.Drawing_Number;
            versionTextBox.Text = SelectedWorksOrder.Drawing_Issue;
            nameTextBox.Text = SelectedWorksOrder.Description;
        }

        private void okayCancelFooter1_OkayClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void okayCancelFooter1_CancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}