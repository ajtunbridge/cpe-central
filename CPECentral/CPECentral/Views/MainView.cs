#region Using directives

using System.Windows.Forms;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Dialogs;

#endregion

namespace CPECentral.Views
{
    public partial class MainView : ViewBase
    {
        public MainView()
        {
            InitializeComponent();
            base.Dock = DockStyle.Fill;
        }

        private void partLibraryView_PartSelected(object sender, PartEventArgs e)
        {
            var partView = new PartView(e.Part);
            ShowView(partView);
        }

        private void partLibraryView_CustomerSelected(object sender, CustomerEventArgs e)
        {
            var customerView = new CustomerView(e.Customer);
            ShowView(customerView);
        }

        private void ShowView(ViewBase view)
        {
            librarySelectionPanel.Controls.Clear();
            librarySelectionPanel.Controls.Add(view);
        }

        private void MainMenuStrip_ItemClicked(object sender, System.EventArgs e)
        {
            var menuItem = (ToolStripMenuItem) sender;

            switch (menuItem.Name)
            {
                case "addNewPartToolStripMenuItem":
                    AddNewPart();
                    break;
            }
        }


        private void AddNewPart()
        {
            using (var addPartDialog = new AddPartDialog())
            {
                if (addPartDialog.ShowDialog(this) != DialogResult.OK)
                    return;

                if (addPartDialog.IsNewCustomer)
                {
                    var newCustomer = new Customer();
                }
            }
        }
    }
}