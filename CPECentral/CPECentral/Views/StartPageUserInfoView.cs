#region Using directives

using System;

#endregion

namespace CPECentral.Views
{
    public partial class StartPageUserInfoView : ViewBase
    {
        public StartPageUserInfoView()
        {
            InitializeComponent();
        }

        private void StartPageUserInfoView_Load(object sender, EventArgs e)
        {
            if (!IsInDesignMode) {
                if (Session.CurrentEmployee != null) {
                    headerLabel.Text = "Hello " + Session.CurrentEmployee.FirstName + "!";
                }
            }
        }
    }
}