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
    }
}