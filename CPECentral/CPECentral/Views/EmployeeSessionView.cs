#region Using directives

using System.Windows.Forms;
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

                flatTabControl.ImageList = tabPageImageList;

                tabPageImageList.Images.Add("StartIcon", Resources.HomeIcon_16x16);
                tabPageImageList.Images.Add("PartLibraryIcon", Resources.PartLibraryIcon_16x16);
                tabPageImageList.Images.Add("PartIcon", Resources.PartIcon_16x16);

                tabPage1.ImageIndex = 0;
                tabPage2.ImageIndex = 1;
            }
        }

        public Employee SessionEmployee { get; private set; }

        private void PartEditedMessage_Published(PartEditedMessage partEditedMessage)
        {
            foreach (TabPage tabPage in flatTabControl.TabPages) {
                if (tabPage.Tag is Part) {
                    var part = tabPage.Tag as Part;
                    if (part == partEditedMessage.EditedPart) {
                        tabPage.Text = partEditedMessage.EditedPart.DrawingNumber;
                        break;
                    }
                }
            }
        }

        private void partLibraryView_PartSelected(object sender, PartEventArgs e)
        {
            foreach (TabPage existingTab in flatTabControl.TabPages) {
                if (existingTab.Tag is Part) {
                    var part = existingTab.Tag as Part;
                    if (part != e.Part) {
                        continue;
                    }
                    flatTabControl.SelectTab(existingTab);
                    return;
                }
            }

            var newTab = new TabPage(e.Part.DrawingNumber);
            newTab.Tag = e.Part;
            newTab.ImageIndex = 2;

            var partView = new PartView();
            partView.Dock = DockStyle.Fill;

            newTab.Controls.Add(partView);

            partView.LoadPart(e.Part);

            flatTabControl.TabPages.Add(newTab);

            flatTabControl.SelectTab(newTab);
        }
    }
}