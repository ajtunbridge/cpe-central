#region Using directives

using System.Windows.Forms;
using CPECentral.CustomEventArgs;

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

        private void partLibraryView_PartSelected(object sender, PartSelectedEventArgs e)
        {
            var partView = new PartView(e.SelectedPart);
            ShowView(partView);
        }

        private void partLibraryView_CustomerSelected(object sender, CustomerSelectedEventArgs e)
        {
            var customerView = new CustomerView(e.SelectedCustomer);
            ShowView(customerView);
        }

        private void ShowView(ViewBase view)
        {
            librarySelectionPanel.Controls.Clear();
            librarySelectionPanel.Controls.Add(view);
        }
    }
}