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
                tabControl.ImageList = tabPageImageList;

                tabPageImageList.Images.Add("StartIcon", Resources.StartPageTabIcon_16x16);
                tabPageImageList.Images.Add("PartLibraryIcon", Resources.PartLibraryTabIcon_16x16);
                tabPageImageList.Images.Add("PartIcon", Resources.PartViewTabIcon_16x16);

                //tabPage1.ImageIndex = 0;
                //tabPage2.ImageIndex = 1;
            }
        }

        public Employee SessionEmployee { get; private set; }

        private void PartEditedMessage_Published(PartEditedMessage partEditedMessage)
        {
            foreach (TabPage tabPage in tabControl.TabPages) {
                if (tabPage.Tag is Part) {
                    var part = tabPage.Tag as Part;
                    if (part == partEditedMessage.EditedPart) {
                        tabPage.Text = partEditedMessage.EditedPart.DrawingNumber;
                        break;
                    }
                }
            }
        }

        private void LoadPartMessage_Published(LoadPartMessage obj)
        {
            // we don't want to load other employees parts
            if (SessionEmployee != Session.CurrentEmployee) {
                return;
            }

            foreach (TabPage existingTab in tabControl.TabPages)
            {
                if (existingTab.Tag is Part)
                {
                    var part = existingTab.Tag as Part;
                    if (part != obj.PartToLoad)
                    {
                        continue;
                    }
                    tabControl.SelectTab(existingTab);
                    return;
                }
            }

            var newTab = new ClosableTabPage(obj.PartToLoad.DrawingNumber);
            newTab.Tag = obj.PartToLoad;
            //newTab.ImageIndex = 2;

            var partView = new PartView();
            partView.Dock = DockStyle.Fill;

            newTab.Controls.Add(partView);

            partView.LoadPart(obj.PartToLoad);

            tabControl.TabPages.Add(newTab);

            tabControl.SelectTab(newTab);
        }

        private void partLibraryView_PartSelected(object sender, PartEventArgs e)
        {
        }
    }
}