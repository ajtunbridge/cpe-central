#region Using directives

using System.Windows.Forms;
using CPECentral.Controls;
using CPECentral.CustomEventArgs;
using CPECentral.Data.EF5;
using CPECentral.Messages;
using CPECentral.Properties;

#endregion

namespace CPECentral.Views
{
    public partial class EmployeeSessionView : ViewBase
    {
        public EmployeeSessionView(Employee employee)
        {
            InitializeComponent();

            base.Dock = DockStyle.Fill;

            SessionEmployee = employee;

            if (!IsInDesignMode) {
                Session.MessageBus.Subscribe<PartEditedMessage>(PartEditedMessage_Published);
                Session.MessageBus.Subscribe<LoadPartMessage>(LoadPartMessage_Published);
                Session.MessageBus.Subscribe<PartAddedMessage>(PartAddedMessage_Published);
                tabControl.ImageList = tabPageImageList;

                tabPageImageList.Images.Add("StartIcon", Resources.StartPageTabIcon_16x16);
                tabPageImageList.Images.Add("PartLibraryIcon", Resources.PartLibraryTabIcon_16x16);
                tabPageImageList.Images.Add("PartIcon", Resources.PartViewTabIcon_16x16);

                //tabPage1.ImageIndex = 0;
                //tabPage2.ImageIndex = 1;
            }
        }

        public Employee SessionEmployee { get; private set; }

        private void PartAddedMessage_Published(PartAddedMessage message)
        {

        }

        private void PartEditedMessage_Published(PartEditedMessage partEditedMessage)
        {
        }

        private void LoadPartMessage_Published(LoadPartMessage obj)
        {
            tabControl.SelectedIndex = 1;
        }

        private void partLibraryView_PartSelected(object sender, PartEventArgs e)
        {
        }
    }
}