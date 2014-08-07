using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tricorn;

namespace CPECentral.Dialogs
{
    public partial class SelectWorksOrderDialog : Form
    {
        private readonly ICollection<WOrder> _worksOrders;

        public WOrder SelectedWorksOrder { get; private set; }

        public SelectWorksOrderDialog(ICollection<WOrder> worksOrders)
        {
            InitializeComponent();

            _worksOrders = worksOrders;
        }

        private void SelectWorksOrderDialog_Load(object sender, EventArgs e)
        {
            matchesListBox.DataSource = _worksOrders;
            matchesListBox.DisplayMember = "User_Reference";
        }

        private void matchesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedWorksOrder = (WOrder)matchesListBox.SelectedItem;

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
