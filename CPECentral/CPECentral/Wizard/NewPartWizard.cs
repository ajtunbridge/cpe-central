#region Using directives

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Data.EF5;

#endregion

namespace CPECentral.Wizard
{
    public partial class NewPartWizard : Form
    {
        private readonly IDialogService _dialogService;

        public NewPartWizard()
        {
            InitializeComponent();

            _dialogService = Session.GetInstanceOf<IDialogService>();
        }

        private void wizardPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isOnFirstPage = wizardPages.SelectedIndex == 0;
            var isOnLastPage = wizardPages.SelectedIndex == wizardPages.TabCount - 1;

            previousButton.Enabled = !isOnFirstPage;

            nextFinishButton.Text = isOnLastPage ? "Finish" : "Next";

            headerLabel.Text = wizardPages.SelectedTab.Text;
        }

        private void nextFinishButton_Click(object sender, EventArgs e)
        {
            if (nextFinishButton.Text == "Finish")
            {
                return;
            }

            bool goToNextPage = true;

            switch (wizardPages.SelectedIndex)
            {
                case 0:
                    goToNextPage = PartInformationPageIsValid();
                    break;
            }

            if (!goToNextPage)
                return;

            wizardPages.SelectedIndex = wizardPages.SelectedIndex + 1;
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            wizardPages.SelectedIndex = wizardPages.SelectedIndex - 1;
        }

        private void NewPartWizard_Load(object sender, EventArgs e)
        {
            Height -= 25;

            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (var uow = new UnitOfWork())
            {
                var customers = uow.Customers.GetAll().OrderBy(c => c.Name);

                customerComboBox.Items.AddRange(customers.ToArray());

                if (customerComboBox.Items.Count > 0)
                    customerComboBox.SelectedIndex = 0;
                else
                {
                    isNewCustomerCheckBox.Checked = true;
                    isNewCustomerCheckBox.Enabled = false;
                }
            }
        }

        private bool PartInformationPageIsValid()
        {
            if (isNewCustomerCheckBox.Checked)
            {
                if (string.IsNullOrWhiteSpace(customerTextBox.Text))
                {
                    _dialogService.ShowError("You must provide a customer name!");
                    customerTextBox.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(drawingNumberTextBox.Text))
            {
                _dialogService.ShowError("You must enter a drawing number!");
                drawingNumberTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                _dialogService.ShowError("You must provide a name for this part!");
                nameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(versionTextBox.Text))
            {
                _dialogService.ShowError("You must enter a version number for this part!");
                drawingNumberTextBox.Focus();
                return false;
            }

            return true;
        }

        private void isNewCustomerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isNewCustomerCheckBox.Checked)
            {
                customerTextBox.BringToFront();
                customerTextBox.Width = customerComboBox.Width;
            }
            else
                customerComboBox.BringToFront();
        }
    }
}