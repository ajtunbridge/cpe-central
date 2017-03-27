using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPECentral.ModernUI.Views
{
    /// <summary>
    /// Interaction logic for UserSessionView.xaml
    /// </summary>
    public partial class UserSessionView : UserControl
    {
        public UserSessionView()
        {
            InitializeComponent();
        }

        private void AppModuleSelectorView_AppModuleSelected(object sender, EventArgs.AppModuleSelectedEventArgs e)
        {
            switch (e.SelectedModule)
            {
                case AppModule.Inventory:
                    break;
                case AppModule.Maintenance:
                    break;
                case AppModule.PartLibrary:
                    break;
                case AppModule.Quality:
                    break;
                case AppModule.Start:
                    break;
            }
        }
    }
}
